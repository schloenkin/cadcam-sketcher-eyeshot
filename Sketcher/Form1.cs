using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Labels;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Region = devDept.Eyeshot.Entities.Region;

namespace Sketcher
{
    public partial class Form1 : Form
    {
        public static readonly Dictionary<string, Layer> Layers = new Dictionary<string, Layer>()
        {
            {"Auxiliary", new Layer("AuxiliaryLayer")},// Auxillary is a dictionary key; new Layer is the value with a name "AuxillaryLayer"
            {"Contour", new Layer("ContourLayer")},//  e.g. "ContourLayer" is the actual layer name registered in model1.Layers
            {"Region", new Layer("RegionLayer")},
            {"Dim", new Layer("DimLayer")},
            {"Mesh", new Layer("MeshLayer")},
            {"Spline", new Layer("SplineLayer")}
        };
        private List<ICurve> _selectedContours = new List<ICurve>();
        private List<Region> _selectedRegions = new List<Region>();
        private Region _currentRegion;
        private Region _oldRegion;
        private ICurve _oldContour;
        private ICurve _currentContour;
        private ImageOnly _selectedLabel;
        SketcherHelper sketcherHelper = new SketcherHelper();

        private List<Line> _selectedLines = new List<Line>();

        private CultureInfo cultureGB = new CultureInfo("en-GB");
        //private NumberStyles numberStyle = NumberStyles.Number;
        private Mesh lastExtrudedObject;
        private Mesh _mesh;
        private int transparency;
        private ICurve profile0;
        private ICurve profile;
        private ObjectManipulator objManip;
        private bool _isContourClosed;
        private bool _isEscapePressed;

        private string tempFilePath;


        public Form1()
        {
            InitializeComponent();// As a part of the constructor it starts all the visual elements
            InitializeModel(); // it is our method. See below
        }
        public Form1(string tfp)
        {
            InitializeComponent();
            InitializeModel();
            tempFilePath = tfp;
        }
        private void InitializeModel()
        {
            // Eyeshot license key is not included in this public repository.
            // A valid local Eyeshot license is required to run the project.
            
            // Setup controls
            model1.ActiveViewport.Rotate.MouseButton = new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Right, devDept.Eyeshot.modifierKeys.None);
            model1.ActiveViewport.Pan.MouseButton = new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.None);
            model1.ActiveViewport.Zoom.ReverseMouseWheel = true;

            // Setup camera
            model1.ActiveViewport.Camera.ProjectionMode = devDept.Graphics.projectionType.Perspective;
            model1.ActiveViewport.SetView(viewType.Top);

            model1.ActionMode = actionType.SelectVisibleByPick;

            foreach (var layer in Layers.Values) // layers are "registed" in model1.Layers
                model1.Layers.Add(layer);

            objManip = model1.ObjectManipulator;
            objManip.ShowOriginalWhileEditing = false; // if true, you see an old copy
            objManip.TranslationStep = 0;
            objManip.RotationStep = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            transparency = 125;
        }
        public enum Op
        {
            None,
            CreatePoint,
            Unite,
            MovePoints,
            DeletePoints,
            InsertNewPoints,
            MeasureLines,
            MeasureAngle,
            objManipEnable,
            MeasureDistance,
        }
        private Op currentOp = Op.None;
        private void model1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            switch (currentOp)
            {
                case Op.None:
                    break;
                case Op.CreatePoint:
                    CreatePointOnClick(e);
                    break;
                case Op.DeletePoints:
                    DeletePointsOnClick(e);
                    break;
                case Op.InsertNewPoints:
                    InsertNewPointsOnClick(e);
                    break;
                case Op.MeasureAngle:
                    MeasureAngleOnClick(e);
                    break;
            }

            _selectedLabel = model1.ActiveViewport.Labels.FirstOrDefault(c => c is ImageOnly && c.Selected) as ImageOnly;
            if (_selectedLabel != null)
            {
                Point3D selectedXY = _selectedLabel.AnchorPoint;
                NudX.Value = (decimal)selectedXY.X;
                NudY.Value = (decimal)selectedXY.Y;
            }
        }
        private void AddEntityToModel(Entity ent, Color color, float lw, string layerName = "default")
        {
            if (ent != null)
            {
                try
                {
                    ent.Color = color;
                    ent.ColorMethod = colorMethodType.byEntity;
                    ent.LineWeight = lw;
                    ent.LineWeightMethod = colorMethodType.byEntity;
                    ent.LayerName = layerName;
                    model1.Entities.Add(ent);
                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
            }
        }
        private void CmdCreatePoint_Click(object sender, EventArgs e)
        {
            if (currentOp == Op.CreatePoint)
                return;
            currentOp = Op.CreatePoint;
            model1.ActionMode = actionType.None;
            sketcherHelper._Points.Clear();
            model1.ActiveViewport.Labels.Clear();
            model1.Invalidate();
          }
        private void CreatePointOnClick(MouseEventArgs e)
        {
            System.Drawing.Point newPoint = e.Location;
            Vector3D vektor = model1.ActiveViewport.Camera.ViewNormal;
            Plane plane = new Plane(vektor);
            model1.ScreenToPlane(newPoint, plane, out Point3D point);
            sketcherHelper.AddPoint(point);
            AddLabels(false);
            UpdateAuxiliaryLines();
            UpdateContourEntity();
        }
        private void AddLabels(bool isMoving)
        {
            model1.ActiveViewport.Labels.Clear();
            if (sketcherHelper.TryBuildLabels(isMoving, out List<ImageOnly> labels))
            {
                foreach (var label in labels)
                {
                    model1.ActiveViewport.Labels.Add(label);
                }
            }
            model1.Invalidate();
        }
        private void UpdateAuxiliaryLines()
        {
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Auxiliary"].Name);
            if (sketcherHelper.TryBuildAuxiliaryLines(out List<Line> lines))
            {
                foreach (var line in lines)
                    AddEntityToModel(line, Color.BlueViolet, 3, Layers["Auxiliary"].Name);
            }
            model1.Invalidate();
        }
        private void UpdateContourEntity()
        {
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
            foreach (ICurve contour in sketcherHelper._Contours)
                AddEntityToModel((Entity)contour, Color.Black, 3, Layers["Contour"].Name);
            model1.Invalidate();
            model1.Refresh();
        }
        private void UpdateRegions()
        {
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Region"].Name);
            foreach (Region region in sketcherHelper._Regions)
                AddEntityToModel(region, Color.LightBlue, 3, Layers["Region"].Name);
            model1.Invalidate();
        }
        private void CmdUnitePoints_Click(object sender, EventArgs e)
        {
            if (_selectedContours.Count != 0)
            {
                _currentContour = _selectedContours[0];
                if (_currentContour.IsClosed) return;
                sketcherHelper.SetEdit(_currentContour);
                sketcherHelper.Unite();
                EndEditContour();
                _selectedContours.Clear();
                currentOp = Op.None;
            }

            //if (currentOp != Op.CreatePoint)
            //    return;
            if (currentOp == Op.CreatePoint)
            {
                sketcherHelper.Unite();
                EndEditContour();
                _selectedContours.Clear();
                currentOp = Op.None;
            }

        }
        private void EndEditContour()
        {
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Auxiliary"].Name);
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Dim"].Name);
            model1.ActiveViewport.Labels.Clear();
            currentOp = Op.None;
            model1.ActionMode = actionType.SelectVisibleByPick;
            if (_currentRegion == null)
            {
                sketcherHelper.EndEdit();
            }
            else
            {
                _selectedContours.Clear(); // can be taken away?
                _currentRegion = null;
            }
            if (!_isEscapePressed) 
            UpdateContourEntity();
            model1.Refresh();
        }
        private void CmdDeleteLastPnt_Click(object sender, EventArgs e)
        {
            if (currentOp != Op.CreatePoint)
                return;
            sketcherHelper.DeleteLastPoint();
            AddLabels(false);
            UpdateAuxiliaryLines();
            UpdateContourEntity();
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CmdClean_Click(object sender, EventArgs e)
        {
            Clean();
        }
        private void Clean()
        {
            currentOp = Op.None;
            sketcherHelper.ClearListen();
            _selectedContours.Clear();
            _selectedRegions.Clear();
            model1.Entities.Clear();
            model1.ActiveViewport.Labels.Clear();
            model1.ActionMode = actionType.SelectByPick;
            model1.Invalidate();
            model1.Refresh();
            _currentRegion = null;
            lastExtrudedObject = null;
            _mesh = null;
        }
        private void CmdSaveToContour_Click(object sender, EventArgs e)
        {
            if (currentOp != Op.CreatePoint)
                return;
            EndEditContour();
            _selectedContours.Clear();
            currentOp = Op.None;
        }
        private void CmdMovePoints_Click(object sender, EventArgs e)
        {
            currentOp = Op.MovePoints;
            if (_selectedContours.Count == 0 && _selectedRegions.Count == 0) return;

            if (_selectedContours.Count > 0)
            {
                ICurve ic = _selectedContours[0];
                _currentContour = _selectedContours[0];
                _oldContour = (_currentContour as Entity).Clone() as ICurve; // clone() create a snapshot of _currentContour
                sketcherHelper.SetEdit(ic);
                UpdateAuxiliaryLines();
                UpdateContourEntity();
                if (ic.IsClosed) AddLabels(true);
                else AddLabels(false);
            }
            if (_selectedRegions.Count > 0)
            {
                _currentRegion = _selectedRegions[0];
                _oldRegion = _currentRegion.Clone() as Region;
                sketcherHelper.SetEdit(_selectedRegions[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                AddLabels(true);
            }
            model1.ActionMode = actionType.SelectVisibleByPickLabel;
            model1.Invalidate();
        }
        private void model1_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentOp != Op.MovePoints)
                return;

            Vector3D vektor = model1.ActiveViewport.Camera.ViewNormal;
            Plane plane = new Plane(vektor);
            model1.ScreenToPlane(e.Location, plane, out Point3D newP);

            var selectedLabel = model1.ActiveViewport.Labels.FirstOrDefault(lab => lab.Selected);

            if (selectedLabel != null)
            {
                selectedLabel.AnchorPoint = newP;
                int indexOfPoint3D = model1.ActiveViewport.Labels.IndexOf(selectedLabel);
                sketcherHelper._Points[indexOfPoint3D] = newP;

                ICurve ic = null;
                //if (_selectedContours.Count != 0) ic = _selectedContours[0];
                if (_currentContour != null) ic = _currentContour; 
                if (_currentRegion != null) ic = _currentRegion.ContourList[0];
                if (ic != null && ic.IsClosed)
                {
                    if (indexOfPoint3D == 0)
                        sketcherHelper._Points[sketcherHelper._Points.Count - 1] = newP;
                    if (indexOfPoint3D == sketcherHelper._Points.Count - 1)
                        sketcherHelper._Points[0] = newP;
                    if (_currentRegion != null)
                    {
                        _currentRegion.ContourList[0] = new LinearPath(sketcherHelper._Points);
                        _currentRegion.Regen(0.1);
                    }
                }
                model1.Entities.Regen();
                UpdateAuxiliaryLines();
            }
        }
        private void model1_SelectionChanged(object sender, devDept.Eyeshot.Environment.SelectionChangedEventArgs e)
        {
            foreach (var itm in e.AddedItems)
            {
                if (itm.Item is Line ln)
                {
                    _selectedLines.Add(ln);
                }
                else if (itm.Item is ICurve crv)
                {
                    _selectedContours.Add(crv);
                    if (_selectedContours.First().IsClosed) _isContourClosed = true;
                    else _isContourClosed = false;
                }
                else if (itm.Item is Region region)
                {
                    _selectedRegions.Add(region);
                    _isContourClosed = true;
                }
            }
            foreach (var itm in e.RemovedItems)
            {
                if (itm.Item is Line ln)
                {
                    _selectedLines.Remove(ln);
                }
                else if (itm.Item is ICurve crv && crv is Entity)
                {
                    _selectedContours.Remove(crv);
                }
                else if (itm.Item is Region region)
                {
                    _selectedRegions.Remove(region);
                }
            }
        }
        private void model1_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentOp == Op.MovePoints)
            {
                model1.ActiveViewport.Labels.ClearSelection();// wenn you relieve the buttom, your anchor the label
            }
        }
        private void CmdReadyMove_Click(object sender, EventArgs e)
        {
            EndEditContour();
        }
        private void NudY_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selectedLabel != null && e.KeyCode == Keys.Enter)
            {
                EnterNewXYasParameter();
                model1.Entities.Regen();
                UpdateAuxiliaryLines();
                model1.ActiveViewport.Labels.ClearSelection();
                model1.Focus();
                model1.Refresh();
            }
        }
        private void NudX_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selectedLabel != null && e.KeyCode == Keys.Enter)
            {
                EnterNewXYasParameter();
                model1.Entities.Regen();
                UpdateAuxiliaryLines();
                model1.ActiveViewport.Labels.ClearSelection();

                model1.Refresh();
                model1.Focus();
            }
        }
        private void EnterNewXYasParameter()
        {
            double x = (double)NudX.Value;
            double y = (double)NudY.Value;
            Point3D newPoint = new Point3D(x, y);
            _selectedLabel.AnchorPoint = newPoint;
            int indexOfPoint3D = model1.ActiveViewport.Labels.IndexOf(_selectedLabel);
            sketcherHelper._Points[indexOfPoint3D] = newPoint;

            ICurve ic = null;
            if (_selectedContours.Count != 0) ic = _selectedContours[0];
            if (_currentRegion != null) ic = _currentRegion.ContourList[0];
            if (ic != null && ic.IsClosed)
            {
                if (indexOfPoint3D == 0)
                    sketcherHelper._Points[sketcherHelper._Points.Count - 1] = newPoint;
                if (indexOfPoint3D == sketcherHelper._Points.Count - 1)
                    sketcherHelper._Points[0] = newPoint;
                if (_currentRegion != null)
                {

                    _currentRegion.ContourList[0] = new LinearPath(sketcherHelper._Points);
                    _currentRegion.Regen(0.1);
                }
            }
        }
        private void NudX_Enter(object sender, EventArgs e)
        {
            currentOp = Op.None;
            if (_selectedLabel != null) _selectedLabel.Selected = true;
            model1.Refresh();
        }
        private void NudX_Leave(object sender, EventArgs e)
        {
            model1.ActiveViewport.Labels.ClearSelection();
            currentOp = Op.MovePoints;
        }
        private void CmdDeletePoints_Click(object sender, EventArgs e)
        {
            currentOp = Op.DeletePoints;
            if (_selectedContours.Count == 0 && _selectedRegions.Count == 0)
            {
                return;
            }
            if (_selectedContours.Count > 0)
            {
                _currentContour = _selectedContours[0];
                _oldContour = (_currentContour as Entity).Clone() as ICurve;
                sketcherHelper.SetEdit(_selectedContours[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                UpdateContourEntity();
            }
            for (int i = 0; i < sketcherHelper._Points.Count - 1; i++)
            {
                var pnt = sketcherHelper._Points[i];
                var lbl = new ImageOnly(pnt, Properties.Resources.old_symbol, 10, 10);
                model1.ActiveViewport.Labels.Add(lbl);
            }

            if (_selectedRegions.Count > 0)
            {
                _currentRegion = _selectedRegions[0];
                _oldRegion = _currentRegion.Clone() as Region;
                sketcherHelper.SetEdit(_selectedRegions[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                //AddLabels(true);
            }
            if (_currentRegion != null) AddLabels(true);
            else AddLabels(false); //
            model1.ActionMode = actionType.SelectVisibleByPickLabel;
            model1.Refresh();
        }
        private void DeletePointsOnClick(MouseEventArgs e)
        {
            if (currentOp != Op.DeletePoints) return;
            currentOp = Op.DeletePoints;
            if (model1.ActiveViewport.Labels.Count <= 3) return;

            _selectedLabel = (ImageOnly)model1.ActiveViewport.Labels.FirstOrDefault(lab => lab is ImageOnly && lab.Selected);
            if (_selectedLabel == null)
                return;
            var pnts = new List<Point3D>(sketcherHelper._Points.Where(pt => pt == _selectedLabel.AnchorPoint));

            foreach (var pnt in pnts)
                sketcherHelper.RemovePoint(pnt);

            if (pnts.Count > 1)
                sketcherHelper.AddPoint(sketcherHelper._Points[0].Clone() as Point3D); // this enables us not to break down our contour

            if (_currentRegion != null)
            {
                _currentRegion.ContourList[0] = new LinearPath(sketcherHelper._Points);
                _currentRegion.Regen(0.1);
            }
            UpdateAuxiliaryLines();

            AddLabels(_isContourClosed);
            _selectedLabel = null;
            model1.Entities.Regen();
        }
        private void CmdInsertNewPoints_Click(object sender, EventArgs e)
        {
            currentOp = Op.InsertNewPoints;
            if (_selectedContours.Count == 0 && _selectedRegions.Count == 0)
            {
                return;
            }
            if (_selectedContours.Count > 0)
            {
                _currentContour = _selectedContours[0];
                _oldContour = (_currentContour as Entity).Clone() as ICurve;
                sketcherHelper.SetEdit(_selectedContours[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                UpdateContourEntity();
                model1.ActiveViewport.Labels.Clear();
            }
            if (_selectedRegions.Count > 0)
            {
                _currentRegion = _selectedRegions[0];
                _oldRegion = _currentRegion.Clone() as Region;
                sketcherHelper.SetEdit(_selectedRegions[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
            }
            AddLabels(_isContourClosed);
            model1.ActionMode = actionType.None;
            model1.Focus();
            model1.Refresh();
        }
        private void InsertNewPointsOnClick(MouseEventArgs e)
        {
            currentOp = Op.InsertNewPoints;
            if (currentOp != Op.InsertNewPoints || _selectedContours == null)
                return;
            System.Drawing.Point screenPoint = e.Location;
            Vector3D cameraNormalVector = model1.ActiveViewport.Camera.ViewNormal;
            Plane plane = new Plane(cameraNormalVector);
            model1.ScreenToPlane(screenPoint, plane, out Point3D pNew);

            int bestSegmentIndex = -1;
            double bestDist = double.MaxValue;
            Point3D bestProjectedPoint = null;
            int numberOfPoints = sketcherHelper._Points.Count;

            for (int i = 0; i < numberOfPoints - 1; i++)
            {
                Point3D a = sketcherHelper._Points[i];
                Point3D b = sketcherHelper._Points[(i + 1)];

                Line segment = new Line(a, b);

                segment.ClosestPointTo(pNew, out double t);

                Point3D closestPoint = segment.PointAt(t);
                double distance = closestPoint.DistanceTo(pNew);
                if (distance < bestDist)
                {
                    bestDist = distance;
                    bestSegmentIndex = i;
                    bestProjectedPoint = closestPoint;
                }
            }
            if (bestSegmentIndex < 0)
                return;
            Point3D pointToInsert = chkOnCurve.Checked ? bestProjectedPoint : pNew;

            int insertIndex = bestSegmentIndex + 1;
            sketcherHelper._Points.Insert(insertIndex, pointToInsert);
            if (_currentRegion != null)
            {
                _currentRegion.ContourList[0] = new LinearPath(sketcherHelper._Points);
                _currentRegion.Regen(0.1);
            }
            UpdateAuxiliaryLines();
            AddLabels(_isContourClosed);
            model1.Entities.Regen();
            model1.ActionMode = actionType.SelectVisibleByPickLabel;
            model1.Invalidate();
        }
        private void model1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (currentOp == Op.objManipEnable)
                {
                    objManip.Apply();
                    model1.Entities.Regen();
                    currentOp = Op.None;
                }
                else
                {
                    EndEditContour();
                    model1.Refresh();
                    model1.Entities.ClearSelection();
                    _selectedContours.Clear();
                    _oldRegion = null;
                    e.Handled = true;
                }

            }
            if (e.KeyCode == Keys.Escape)
            {
                _isEscapePressed = true;

                if (currentOp == Op.CreatePoint)
                {
                    model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Auxillary"].Name);
                    model1.ActiveViewport.Labels.Clear();
                    sketcherHelper._Points.Clear();
                    currentOp = Op.None;
                    model1.ActionMode = actionType.SelectVisibleByPick;
                }
                if (currentOp == Op.MeasureLines || currentOp == Op.MeasureAngle)
                {
                    EndEditContour();
                    UpdateContourEntity();// in Conflict mit isEscapePress = true
                }
                if (currentOp == Op.MeasureDistance)
                {
                    _firstPtOnCurve = null;
                    ClearMeasureGraphics();
                }

                if ((currentOp == Op.MovePoints || currentOp == Op.DeletePoints || currentOp == Op.InsertNewPoints) && _oldContour != null)
                {
                    EndEditContour();
                    model1.Entities.Remove(sketcherHelper._Contours.Last() as Entity);
                    sketcherHelper._Contours.Remove(sketcherHelper._Contours.Last());
                    _selectedContours.Clear();
                    sketcherHelper._Contours.Add(_currentContour);
                    UpdateContourEntity();
                    model1.Entities.ClearSelection();
                    model1.Refresh();
                    _oldContour = null;
                    _currentContour = null;
                }

                if ((currentOp == Op.MovePoints || currentOp == Op.DeletePoints || currentOp == Op.InsertNewPoints) && _oldRegion != null)
                {

                    model1.Entities.Remove(_currentRegion);
                    sketcherHelper._Regions.Remove(_currentRegion);
                    EndEditContour();
                    model1.Entities.ClearSelection();
                    _selectedRegions.Clear();
                    sketcherHelper._Regions.Add(_oldRegion);
                    UpdateRegions();
                    _oldRegion = null;
                    _currentRegion = null;
                    ReturnOldContour();
                }
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                List<Entity> selectedEntities = model1.Entities.Where(ent => ent.Selected).ToList();
                if (selectedEntities.Count == 0)
                {
                    MessageBox.Show("Nothing is selected", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (objManip.Visible) return;
                if (tabControl1.SelectedIndex < 3)
                {
                    objManip.TranslateZ.Visible = false;
                    objManip.RotateX.Visible = false;
                    objManip.RotateY.Visible = false;
                }
                else
                {
                    objManip.TranslateZ.Visible = true;
                    objManip.RotateX.Visible = true;
                    objManip.RotateY.Visible = true;
                }
                model1.CompileUserInterfaceElements();
                currentOp = Op.objManipEnable;
                objManip.Enable(null, true, selectedEntities);
                model1.Entities.ClearSelection();
                model1.Refresh();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (_selectedContours != null)
                {
                    foreach (ICurve ic in _selectedContours) sketcherHelper._Contours.Remove(ic);
                }
                if (_selectedRegions != null)
                {
                    foreach (Region r in _selectedRegions) sketcherHelper._Regions.Remove(r);
                }
                _selectedContours.Clear();
                _selectedRegions.Clear();
            }

            model1.Refresh();
            _isEscapePressed = false;
        }
        private void ReturnOldContour()
        {
            EndEditContour();
            model1.Entities.Remove(sketcherHelper._Contours.Last() as Entity);
            sketcherHelper._Contours.RemoveAt(sketcherHelper._Contours.Count - 1);
            _selectedContours.Clear();
            sketcherHelper._Contours.Add(_currentContour);
            UpdateContourEntity();
            model1.Entities.ClearSelection();
            _oldContour = null;
            _currentContour = null;
        }
        private void CmdCreateRegions_Click(object sender, EventArgs e)
        {
            if (currentOp == Op.MovePoints || currentOp == Op.DeletePoints || currentOp == Op.InsertNewPoints) return;
            if (_selectedContours == null || _selectedContours.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one contour before creating a region.",
                    "No contour selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            foreach (var curve in _selectedContours)
            {
                sketcherHelper.CreateRegionFromContour(curve);
                model1.Entities.Remove(curve as Entity);
            }
            UpdateRegions();
            model1.Entities.ClearSelection();
            _selectedContours.Clear();
        }
        private void CmdMergeRegions_Click(object sender, EventArgs e)
        {
            if (_selectedRegions == null || _selectedRegions.Count < 2)
            {
                MessageBox.Show(
                    "Please select at least two regions before merging two of them.",
                    "Two regions should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            sketcherHelper.MergeRegions(_selectedRegions);
            _selectedRegions.Clear();
            UpdateRegions();
        }
        private void CmdCutRegWithDiff_Click(object sender, EventArgs e)
        {
            if (_selectedRegions == null || _selectedRegions.Count < 2)
            {
                MessageBox.Show(
                    "Please select at least two regions (not contours!) before the first selected region cuts the second selected one.",
                    "Two regions should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            sketcherHelper.CutRegion(_selectedRegions);
            _selectedRegions.Clear();
            UpdateRegions();
        }
        private void CmdTrimDownReg_Click(object sender, EventArgs e)
        {
            if (_selectedRegions == null || _selectedRegions.Count < 2)
            {
                MessageBox.Show(
                    "Please select at least two regions.",
                    "At least two regions should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            sketcherHelper.TrimDownRegions(_selectedRegions);
            _selectedRegions.Clear();
            UpdateRegions();
        }
        private void CmdCutWithinReg_Click(object sender, EventArgs e)
        {
            if (_selectedContours == null || _selectedContours.Count < 2)
            {
                MessageBox.Show("Select at least 2 contours",
                    "Two contours should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            sketcherHelper.CutWithinRegion(_selectedContours);
            _selectedRegions.Clear();
            _selectedContours.Clear();
            UpdateContourEntity();
            UpdateRegions();
        }
        private void CmdLinesMeasure_Click(object sender, EventArgs e)
        {
            currentOp = Op.MeasureLines;
            if (_selectedContours.Count > 0)
            {
                sketcherHelper.SetEdit(_selectedContours[0]);
                model1.Entities.ClearSelection();

                UpdateAuxiliaryLines();
                model1.ActiveViewport.Labels.Clear();
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
            }
            model1.ActionMode = actionType.SelectVisibleByPick;
            model1.Invalidate();
        }
        private void CmdMeasureBetweenPoints_Click(object sender, EventArgs e)
        {
            currentOp = Op.MeasureDistance;
            if (_selectedContours.Count != 0)
            {
                sketcherHelper.SetEdit(_selectedContours[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                model1.ActiveViewport.Labels.Clear();
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
                model1.ActionMode = actionType.SelectVisibleByPick;
                model1.Invalidate();
            }

        }
      
        private Point3D _firstPtOnCurve = null;
        private Entity _measureP1 = null;
        private Entity _measureP2 = null;
        private Entity _measureLine = null;
        private Entity _measureText = null;
        private Entity _measureTextP1 = null;
        private Entity _measureTextP2 = null;

        private void model1_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentOp == Op.MeasureLines)
            {
                int entIndex = model1.GetEntityUnderMouseCursor(e.Location);
                if (entIndex < 0) return;
                var ent = model1.Entities[entIndex];
                if (ent is Line ln)
                {
                    Point3D p1 = ln.StartPoint;
                    Point3D p2 = ln.EndPoint;

                    if (p1.X > p2.X) // we need it because otherwise the size will be indicated inversely
                    {
                        Point3D pt = p1;
                        p1 = p2;
                        p2 = pt;
                    }
                    Vector3D vx = new Vector3D(p1, p2);
                    vx.Normalize(); // we need a unit, not a distance (a compass: we need a north, not km to the North).
                    Vector3D vy = Vector3D.Cross(Vector3D.AxisZ, vx);
                    vy.Normalize();
                    Plane pl = new Plane(p1, vx, vy);
                    Vector3D offsetDir = vy;

                    Point3D p3 = (p1 + p2) / 2 + vy * (-5);

                    LinearDim dim = new LinearDim(
                        pl,
                        p1,
                        p2,
                        p3,
                        3
                    );

                    double v = ln.Length();
                    string s = v.ToString("F2"); // 2 symnols after comma
                    dim.TextOverride = s;

                    AddEntityToModel(dim, Color.Gray, 3, Layers["Dim"].Name);
                    model1.Invalidate();
                }
            }
            if (currentOp == Op.MeasureDistance)
            {
                int idx = model1.GetEntityUnderMouseCursor(e.Location);
                if (idx < 0) return;

                var ent = model1.Entities[idx];
                var curve = ent as ICurve;
                if (curve == null) return;

                Point3D worldClick;
                model1.ScreenToPlane(e.Location, Plane.XY, out worldClick);

                double t;
                curve.ClosestPointTo(worldClick, out t);
                Point3D ptOnCurve = curve.PointAt(t);

                double markerRadius = 1.0;
                double textHeight = 3.0;

                if (_firstPtOnCurve == null)
                {
                    ClearMeasureGraphics();

                    _firstPtOnCurve = ptOnCurve;

                    _measureP1 = new Circle(Plane.XY, _firstPtOnCurve, markerRadius);
                    AddEntityToModel(_measureP1, Color.DarkRed, 3);
                    string p1Label = $"P1 (X: {_firstPtOnCurve.X:0.##}"+ " " +$"Y: {_firstPtOnCurve.Y:0.##})";
                    Point3D p1TextPos = new Point3D(_firstPtOnCurve.X + markerRadius * 2, _firstPtOnCurve.Y + markerRadius * 2, _firstPtOnCurve.Z);
                    _measureTextP1 = new Text(p1TextPos, p1Label, textHeight);
                    AddEntityToModel(_measureTextP1, Color.DarkBlue, 4);


                    model1.Refresh();
                    return;
                }

                Point3D p1 = _firstPtOnCurve;
                Point3D p2 = ptOnCurve;

                double dist = p1.DistanceTo(p2);

                _measureP2 = new Circle(Plane.XY, p2, markerRadius);
                AddEntityToModel(_measureP2, Color.DarkRed, 3);
                string p2Label = $"P2 (X: {p2.X:0.##}" + " " + $"Y: {p2.Y:0.##})";
                Point3D p2TextPos = new Point3D(p2.X + markerRadius * 2, p2.Y + markerRadius * 2, p2.Z);
                _measureTextP2 = new Text(p2TextPos, p2Label, textHeight);
                AddEntityToModel(_measureTextP2, Color.DarkBlue, 4);

                _measureLine = new Line(p1, p2);
                AddEntityToModel(_measureLine, Color.DarkRed, 4);

                Point3D mid = new Point3D((p1.X + p2.X) / 2.0, (p1.Y + p2.Y) / 2.0, (p1.Z + p2.Z) / 2.0);
                string txt = $"{dist:0.###} mm";
                _measureText = new Text(mid, txt, textHeight);
                AddEntityToModel(_measureText, Color.DarkBlue, 4);

                model1.Refresh();
                _firstPtOnCurve = null;
            }
        }
        private void ClearMeasureGraphics()
        {
            if (_measureP1 != null) model1.Entities.Remove(_measureP1);
            if (_measureP2 != null) model1.Entities.Remove(_measureP2);
            if (_measureLine != null) model1.Entities.Remove(_measureLine);
            if (_measureText != null) model1.Entities.Remove(_measureText);
            if (_measureTextP1 != null) model1.Entities.Remove(_measureTextP1);
            if (_measureTextP2 != null) model1.Entities.Remove(_measureTextP2);

            _measureP1 = _measureP2 = _measureLine = _measureText = _measureTextP1 = _measureTextP2 = null;
            model1.Refresh();
        }
        public float GetAngleBetweenLines(Line ln1, Line ln2)
        {
            var dir1 = ln1.Direction;
            var dir2 = ln2.Direction;
            var angle = Vector3D.SignedAngleBetween(dir1, dir2);

            return (float)Utility.RadToDeg(angle);
        }
        private void CmdMeasureAngle_Click(object sender, EventArgs e)
        {
            currentOp = Op.MeasureAngle;
            if (_selectedContours.Count > 0)
            {
                sketcherHelper.SetEdit(_selectedContours[0]);
                model1.Entities.ClearSelection();
                UpdateAuxiliaryLines();
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
                AddLabels(false);
            }
            model1.ActionMode = actionType.SelectVisibleByPick;
            model1.Invalidate();
        }
        private void MeasureAngleOnClick(MouseEventArgs e)
        {
            if (currentOp != Op.MeasureAngle) return;
            if (_selectedLines.Count < 2) return;

            var l1 = _selectedLines[0];
            var l2 = _selectedLines[1];

            if (!TryGetAngleRays(l1, l2, 1e-6, out var v, out var p1, out var p2))
                return;

            // Strahlen aus dem Scheitelpunkt
            Vector3D r1 = new Vector3D(v, p1);
            Vector3D r2 = new Vector3D(v, p2);

            // Wir berechnen den orientierten Winkel r1 → r2 (0..360)
            double ang = SignedAngleRadXY(r1, r2);

            // Wenn er > 180° ist, würde Eyeshot den äußeren Kreisbogen wählen
            //    → daher tauschen wir die Strahlen
            if (ang > Math.PI)
            {
                (p1, p2) = (p2, p1);
                (r1, r2) = (r2, r1);
                ang = 2.0 * Math.PI - ang; //  jetzt ist es der kleinere Winkel
            }

            // 3)  Wir platzieren den Text innerhalb des kleineren Winkels:
            //    entlang der Winkelhalbierenden (u1 + u2)
            Vector3D u1 = Unit(r1);
            Vector3D u2 = Unit(r2);

            Vector3D bis = u1 + u2;
            if (bis.Length < 1e-9) bis = new Vector3D(-u1.Y, u1.X, 0); // fast 180°
            bis = Unit(bis);

            Point3D textPos = v + bis * 20;

            Plane dimPlane = new Plane(v, Vector3D.AxisZ);

            var dim = new AngularDim(dimPlane, p1, p2, textPos, 3);

            AddEntityToModel(dim, Color.Gray, 3, Layers["Dim"].Name);

            _selectedLines.Clear();
            model1.Invalidate();
        }
        private static Vector3D Unit(Vector3D v)
        {
            double len = v.Length;
            if (len < 1e-12) return v;
            return v / len;
        }
        private static double SignedAngleRadXY(Vector3D a, Vector3D b)
        {
            // Orientierter Winkel von a nach b in der XY-Ebene: 0..2π (gegen den Uhrzeigersinn)
            double crossZ = a.X * b.Y - a.Y * b.X;
            double dot = a.X * b.X + a.Y * b.Y;
            double ang = Math.Atan2(crossZ, dot);
            if (ang < 0) ang += 2.0 * Math.PI;
            return ang;
        }
        private static bool TryGetAngleRays(Line a, Line b, double tol, out Point3D vertex, out Point3D aRayPoint, out Point3D bRayPoint)
        {
            vertex = null; aRayPoint = null; bRayPoint = null;

            bool Close(Point3D p, Point3D q) => p.DistanceTo(q) <= tol;

            if (Close(a.StartPoint, b.StartPoint))
            { vertex = a.StartPoint; aRayPoint = a.EndPoint; bRayPoint = b.EndPoint; return true; }

            if (Close(a.StartPoint, b.EndPoint))
            { vertex = a.StartPoint; aRayPoint = a.EndPoint; bRayPoint = b.StartPoint; return true; }

            if (Close(a.EndPoint, b.StartPoint))
            { vertex = a.EndPoint; aRayPoint = a.StartPoint; bRayPoint = b.EndPoint; return true; }

            if (Close(a.EndPoint, b.EndPoint))
            { vertex = a.EndPoint; aRayPoint = a.StartPoint; bRayPoint = b.StartPoint; return true; }

            return false; //Die Linien haben keinen gemeinsamen Scheitelpunkt
        }
        private void CmdExtrudeRegion_Click(object sender, EventArgs e)
        {
            if (_selectedRegions.Count != 1)
            {
                MessageBox.Show("First a created region should be selected",
                    "A created region should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            _currentRegion = _selectedRegions[0];

            //tabPage1.Hide();
            //tabPage2.Hide();
            //tabPage3.Hide();

            List<Region> otherRegions = sketcherHelper._Regions.Where(c => c != _currentRegion).ToList();
            foreach (Region region in otherRegions)
            {
                model1.Entities.Remove(region);
                sketcherHelper._Regions.Remove(region);
            }
            ExtrudeTheObject();
            model1.ActiveViewport.SetView(viewType.Isometric);
            model1.Refresh();
        }
        private void ExtrudeTheObject()
        {
            double extrusionHeight = double.Parse(NudExtrusionHeight.Text.Replace(',', '.'), cultureGB);
            if (_currentRegion.Plane.AxisZ.Z < 0) extrusionHeight *= -1; //ckeck: if one draws a contour contourclockwise. 
            double extrusionAngle = double.Parse(NudAngle.Text.Replace(',', '.'), cultureGB);
            Brep brep = _currentRegion.ExtrudeAsBrep(extrusionHeight, Math.PI / 180 * extrusionAngle);
            brep.Regen(0.1);
            _mesh = brep.ConvertToMesh();
            //mesh.Selectable = false;
            lastExtrudedObject = _mesh;
            AddEntityToModel(_mesh, Color.FromArgb(transparency, Color.Lime), 1);
            _currentRegion.Visible = false;
            model1.Refresh();
        }
        private void NudExtrusionHeight_ValueChanged(object sender, EventArgs e)
        {
            if (lastExtrudedObject != null)
            {
                model1.Entities.Remove(lastExtrudedObject);
                ExtrudeTheObject();
            }
        }
        private void NudAngle_ValueChanged(object sender, EventArgs e)
        {
            if (lastExtrudedObject != null)
            {
                model1.Entities.Remove(lastExtrudedObject);
                ExtrudeTheObject();
            }
        }

        private void CmdToSpline_Click(object sender, EventArgs e)
        {
            if (_selectedContours.Count == 0)
            {
                MessageBox.Show("Select contours first",
                    "Contours should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }

            foreach (ICurve ic in _selectedContours)
            {
                ICurve icNew;
                if (ic is LinearPath)
                {
                    List<Point3D> sortedPoints = UtilityEx.GetSignificantPointsOnICurve(ic).ToList();
                    icNew = Curve.CubicSplineInterpolation(sortedPoints);

                }
                else
                {
                    Point3D[] splinePoints = (ic as Curve).ControlPoints;
                    icNew = new LinearPath(splinePoints);
                }

                model1.Entities.Remove(ic as Entity);
                AddEntityToModel(icNew as Entity, Color.Black, 2, Layers["Contour"].Name);
                sketcherHelper._Contours.Remove(ic);
                sketcherHelper._Contours.Add(icNew);
            }
            model1.Entities.ClearSelection();
            model1.Refresh();
            _selectedContours.Clear();
            currentOp = Op.None;

        }
        private void CmdRevolve_Click(object sender, EventArgs e)
        {
            if (_selectedContours.Count != 1)
            {
                MessageBox.Show("Select a contour first",
                    "A contour should be selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return;
            }
            RevolveTheObject();
            model1.ActiveViewport.SetView(viewType.Isometric);
            model1.Refresh();
        }
        private void RevolveTheObject()
        {
            profile0 = _selectedContours[0];
            //ICurve profile;

            if (profile0.IsClosed) // isClosed - property of a curve: it is either open or closed
            {
                checkBoxCloseMesh.Checked = false;
                checkBoxCloseMesh.Enabled = false;
            }
            else
            {
                checkBoxCloseMesh.Enabled = true;
            }

            List<Point3D> profilePoints;
            if (profile0 is LinearPath) profilePoints = UtilityEx.GetSignificantPointsOnICurve(profile0).ToList();
            else
            {
                Point3D[] psArray = (profile0 as Curve).ControlPoints;
                profilePoints = psArray.ToList();
            }
            double minDistance = profilePoints.Min(c => Math.Abs(c.X));
            NudVolume.Value = (decimal)minDistance;

            //** Close mesh (if desired) **
            //**=========================**
            if (checkBoxCloseMesh.Checked)
            {
                Point3D ps = profile0.StartPoint;
                Point3D pe = profile0.EndPoint;
                Point3D psNew = new Point3D(0, ps.Y, ps.Z);
                Point3D peNew = new Point3D(0, pe.Y, pe.Z);
                profilePoints.Insert(0, psNew);
                profilePoints.Add(peNew);
                if (profile0 is LinearPath) profile = new LinearPath(profilePoints);
                else profile = new Curve(3, profilePoints);
            }
            else profile = profile0;
            int meshSlice = (int)NudSegment.Value;
            double meshDelta = (double)NudDeltaValue.Value;
            _mesh = profile.RevolveAsMesh(
            0,                                  // startAngle
            Utility.DegToRad(meshDelta),      // deltaAngle (a full circle of 360^)
            new Point3D(0, 0, 0),               // axisStart
            new Point3D(0, 1, 0),               // axisEnd  (axis X)
            meshSlice,                         // slices (quality)
            0.01,                               // tolerance
            Mesh.natureType.Plain
            );

            _mesh.TransformBy(new Rotation(Math.PI / 2, Vector3D.AxisX));
            _mesh.Regen(0.1);
            double zMin = _mesh.BoxMin.Z;
            _mesh.TransformBy(new Translation(0, 0, -zMin));
            _mesh.Regen(0.1);
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Spline"].Name);
            AddEntityToModel(_mesh, Color.FromArgb(transparency, Color.Lime), 1, Layers["Mesh"].Name);
            model1.Entities.ClearSelection();
            model1.Invalidate();
        }
        private void TrkSaturation_ValueChanged(object sender, EventArgs e)
        {
            transparency = TrkSaturation.Value;
            if (_mesh != null)
            {
                _mesh.Color = Color.FromArgb(transparency, _mesh.Color);
                model1.Refresh();
            }
        }
        private void NudSegment_ValueChanged(object sender, EventArgs e)
        {
            if (_mesh != null)
            {
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Mesh"].Name);
                //model1.Entities.Remove(mesh);
                RevolveTheObject();
            }
        }
        private void NudDeltaValue_ValueChanged(object sender, EventArgs e)
        {

            if (_mesh != null)
            {
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Mesh"].Name);
                //model1.Entities.Remove(mesh);
                RevolveTheObject();
            }
        }
        private void ScaleMesh()
        {
            if (profile == null) return;
            List<Point3D> profilePoints = UtilityEx.GetSignificantPointsOnICurve(profile0).ToList();
            double minDistance = profilePoints.Min(c => Math.Abs(c.X));
            int positionSign = Math.Sign(profile0.StartPoint.X);
            double positionChange = (double)NudVolume.Value - minDistance;
            if (_mesh != null)
            {
                //model1.Entities.Remove(mesh);
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Mesh"].Name);
                double translationAmount;
                if (positionSign < 0) translationAmount = positionChange;
                translationAmount = -positionChange;
                (profile0 as Entity).TransformBy(new Translation(translationAmount, 0, 0));
                (profile0 as Entity).Regen(0.1);
                RevolveTheObject();
            }
        }
        private void NudVolume_ValueChanged(object sender, EventArgs e)
        {
            ScaleMesh();
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_mesh != null)
            {
                bool allowed = (e.TabPageIndex == 3) || (e.TabPageIndex == 6);
                if (!allowed)
                {
                    e.Cancel = true; 
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedIndex == 1 ||
                tabControl1.SelectedIndex == 2)
                model1.ActiveViewport.SetView(viewType.Top);
            //else
            //{
            //    _selectedContours.Clear();
            //    model1.Entities.ClearSelection();
            //    sketcherHelper._Contours.Clear();
            //}
            model1.Refresh();
        }
        private void CmdLoft_Click(object sender, EventArgs e)
        {
            LoftTheObject();
            model1.ActiveViewport.SetView(viewType.Isometric);
            model1.Refresh();
            model1.Invalidate();
        }
        private void LoftTheObject()
        {
            if (_selectedContours.Count < 2)
            {
                MessageBox.Show("Select minimum two contours",
                  "Two contours should be selected",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning
                  );
                return;
            }
            List<ICurve> cs = new List<ICurve>();
            Point3D firstPoint = null;
            for (int i = 0; i < _selectedContours.Count; i++)
            {
                ICurve ic = _selectedContours[i];
                Curve c = null;
                List<Point3D> ps;
                int curveDgree = 0;
                if (ic is Curve)
                {
                    curveDgree = 3;
                    Point4D[] ps0 = (ic as Curve).ControlPoints;
                    Point3D[] ps00 = ps0;
                    ps = ps00.ToList();
                }
                else
                {
                    curveDgree = 1;
                    ps = UtilityEx.GetSignificantPointsOnICurve(ic).ToList();
                }
                if (i == 0)
                {
                    c = new Curve(curveDgree, ps);
                    firstPoint = c.StartPoint;
                }
                else
                {
                    double minD = 1e10;
                    Point3D closestPoint = null;
                    foreach (Point3D p in ps)
                    {
                        double d = p.DistanceTo(firstPoint);
                        if (d < minD)
                        {
                            minD = d;
                            closestPoint = p;
                        }
                    }
                    int indexOfClosestPoint = ps.IndexOf(closestPoint);
                    List<Point3D> psNew = ps.GetRange(indexOfClosestPoint, ps.Count - indexOfClosestPoint);
                    List<Point3D> psAddition = ps.GetRange(0, indexOfClosestPoint + 1);
                    psNew.AddRange(psAddition);
                    c = new Curve(curveDgree, psNew);

                    double step = (double)NudElevationValue.Value;

                    double z = i * step;
                    c.TransformBy(new Translation(0, 0, z));
                }
                cs.Add(c);
            }
            Surface s = Surface.Loft(cs, 3).First();
            s.Regen(0.1);
            _mesh = s.ConvertToMesh();
            _mesh.Regen(0.1);
            AddEntityToModel(_mesh, Color.Lime, 2, Layers["Mesh"].Name);
            //model1.Entities.ClearSelection();
            //sketcherHelper.ClearListen();
            model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Contour"].Name);
        }
        private void NudElevationValue_ValueChanged(object sender, EventArgs e)
        {
            if (_mesh != null)
            {
                model1.Entities.RemoveAll(ent => ent.LayerName == Layers["Mesh"].Name);
                LoftTheObject();
                model1.Entities.Regen();
                model1.Invalidate();
            }
        }
        private void CmdCreateCircle_Click(object sender, EventArgs e)
        {
            sketcherHelper.createCirclefromPoints();
            foreach (ICurve circle in sketcherHelper._Contours)
            {
                AddEntityToModel(circle as Entity, Color.Black, 2, Layers["Contour"].Name);
            }
            EndEditContour();
            model1.Entities.Remove(sketcherHelper._Contours.Last() as Entity);
            sketcherHelper._Contours.Remove(sketcherHelper._Contours.Last());
            model1.Refresh();
        }
        private void CmdExportMesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mesh == null)
                {
                    MessageBox.Show("Mesh not found!", "Export STL",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title = "Save STL";
                    sfd.Filter = "STL file (*.stl)|*.stl";
                    sfd.DefaultExt = "stl";
                    sfd.AddExtension = true;
                    sfd.FileName = "model.stl";

                    if (sfd.ShowDialog(this) != DialogResult.OK)
                        return;

                    ExportMesh(sfd.FileName);
                    MessageBox.Show("STL successfully saved.", "Export STL",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export error STL:\n{ex.Message}", "Export STL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportMesh(string path)
        {
            WriteSTL writeSTL = new WriteSTL(new WriteParams(model1), path);
            writeSTL.DoWork();
        }

        //private void numericUpDownExtrusionHeight_Leave(object sender, EventArgs e)
        //{
        //    bool b = double.TryParse(numericUpDownExtrusionHeight.Text.Replace(',', '.'), numberStyle, cultureGB, out _);
        //    if (b == false)
        //    {
        //        MessageBox.Show("Extrusion Height is not correctly defined!", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

    }
}