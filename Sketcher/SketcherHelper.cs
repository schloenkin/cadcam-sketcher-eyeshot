using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Labels;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Windows.Forms;
using Region = devDept.Eyeshot.Entities.Region;

namespace Sketcher
{
    internal class SketcherHelper
    {
        #region VARIABLES
        private List<Point3D> _points = new List<Point3D>();
        public List<Point3D> _Points => _points;
        private List<ICurve> _contours = new List<ICurve>();
        public List<ICurve> _Contours => _contours;
        private List<Region> _regions = new List<Region>();
        public List<Region> _Regions => _regions;
        private Bitmap _label = new Bitmap(Properties.Resources.old_symbol);
        public Bitmap Label => _label;
        #endregion
        #region POINTS LIST FUNCTIONS
        public void AddPoint(Point3D pnt) => _points.Add(pnt); //expression-bodied method. There is no return, but funstion: _points.Add...
        public void RemovePoint(Point3D pnt) => _points.Remove(pnt);
        public void RemoveAt(int index) => _points.RemoveAt(index);
        #endregion
        #region EDITING POINTS && CONTOURS
        public bool TryBuildAuxiliaryLines(out List<Line> auxiliaryLines)
        {
            auxiliaryLines = new List<Line>();
            try
            {
                for (int i = 0; i < _points.Count - 1; i++)
                {
                    var line = new Line(_points[i], _points[i + 1]);
                    auxiliaryLines.Add(line);
                }
                if (auxiliaryLines.Count <= 0)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TryBuildLabels(bool isMoving, out List<ImageOnly> labels)
        {
            labels = new List<ImageOnly>();
            if (_label == null || _points.Count < 1)
                return false;   
            try
            {
                var max = isMoving ? _points.Count - 1 : _points.Count; 

                for (int i = 0; i < max; i++)
                {
                    var symbol = new ImageOnly(_points[i], _label, 10, 10);
                    labels.Add(symbol);   
                }
                return true;
            }
            catch
            {
                labels.Clear();
                return false;
            }
        }
        public void ClearListen()
        {
            _contours.Clear();
            _points.Clear();
            _regions.Clear();
        }
        public void Unite()
        {
            if (_points.Count == 0)
                return;
            _points.Add(_points[0].Clone() as Point3D); 
        }
        public void DeleteLastPoint()
        {
            if (_points.Count == 0) return;
            _points.RemoveAt(_points.Count - 1);         
        }
        public void EndEdit()
        {
            _contours.Add(new LinearPath(_points)); // LinearPath() is here a constructor and as such it needs a "new" 
            _points.Clear(); //  in order to call a constructor: declare & create the object! And then add _points as an argument
            // then _contours.Add adds a new object: LinearPath
        }
        public void SetEdit(ICurve crv) // the _selected contour is here
        {
            var index = _contours.IndexOf(crv); // index keeps now a current position of the contour among the contours

            if (index < 0)
            {
                Console.WriteLine("curve not found");
                return;
            }
            _contours.RemoveAt(index); // the INDEX of the contour is getting deleted but the OBJECT "crv" comes down to UtilityEx.

            var pnts = UtilityEx.GetSignificantPointsOnICurve(crv);
            // "crv" remains somewhere in the model1 and only garbage-collector deletes it finally when no reference is there
            _points.Clear();
            _points.AddRange(pnts); // add all elements from the collection "pnts" into the collection "_points"
        }
        public void SetEdit(Region region) // the _selectedRegion is here
        {
            var contourList = region.ContourList;  // region keeps a list of contours
            _Points.Clear();

            if(contourList.Count > 0)
            {
                var pnts = UtilityEx.GetSignificantPointsOnICurve(contourList[0]);
                _Points.AddRange(pnts);
            }
        }
        public void createCirclefromPoints()
        {
            if (_Points.Count < 1) return;
            if (_Points.Count >= 3)
            {
                var circle = new Circle(
                    _Points[0],
                    _Points[1],
                    _Points[2]);
                _Contours.Add(circle);
            }
            if (_Points.Count == 2)
            {
                var circle = new Circle(
                    Plane.XY,
                    _Points[0],
                    _Points[0].DistanceTo(_Points[1]));
                _Contours.Add(circle);
            }
            if (_Points.Count == 1)
            {
                var center = Point3D.Origin;
                var circle = new Circle(
                    Plane.XY,
                    center,
                    center.DistanceTo(_Points[0]));
                _Contours.Add(circle);
            }
        }
        #endregion
        #region CREATING && EDITING REGIONS
        public void CreateRegionFromContour(ICurve curve) 
        {
            var region = new Region(curve);
            _Regions.Add(region);
            if (_Contours.Contains(curve))
                _Contours.Remove(curve);
        }
        public void MergeRegions(List<Region> regions)
        {
            if (regions == null || regions.Count < 2) return;
            Region acc = (Region)regions[0].Clone(); // Clone() возвращает тип Object. И ему надо явно указать тип (Region)
            for (int i = 1; i < regions.Count; i++)
            {
                Region[] step = Region.Union(acc, regions[i]);
                if (step == null || step.Length != 1)
                {
                    return;
                }
                acc = step[0];
            }
            foreach (var r in regions)
                _Regions.Remove(r);
            _Regions.Add(acc);
        }
        public void CutRegion(List<Region> regions)
        {
            if (regions == null || regions.Count < 2) return;
            Region acc = (Region)regions[0].Clone();
            for (int i = 1; i < regions.Count; i++)
            {
                Region[] step = Region.Difference(acc, regions[i]);
                if (step == null || step.Length != 1)
                {
                    return;
                }
                acc = step[0];
            }
            foreach (var r in regions)
                _Regions.Remove(r);
            _Regions.Add(acc);
        }
        public void TrimDownRegions(List<Region> regions)
        {
            if (regions == null || regions.Count < 2) return;
            Region acc = (Region)regions[0].Clone();
            for (int i = 1; i < regions.Count; i++)
            {
                Region[] step = Region.Intersection(acc, regions[i]);
                if (step == null || step.Length != 1)
                { return; }
                acc = step[0];
            } 
            foreach (var r in regions)
                    _Regions.Remove(r);
                _Regions.Add(acc);
        }
        public void CutWithinRegion(List<ICurve> curves)
        {   
            List<Region> regs =  UtilityEx.DetectRegionsFromContours(curves,1e-6).ToList();
            _Regions.AddRange(regs);
            foreach (ICurve curve in curves)
                _Contours.Remove(curve);
        }
        #endregion
    }
}
