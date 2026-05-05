namespace Sketcher
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            devDept.Eyeshot.CancelToolBarButton cancelToolBarButton3 = new devDept.Eyeshot.CancelToolBarButton("Cancel", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ProgressBar progressBar3 = new devDept.Eyeshot.ProgressBar(devDept.Eyeshot.ProgressBar.styleType.Circular, 0, "Idle", System.Drawing.Color.Black, System.Drawing.Color.Transparent, System.Drawing.Color.Green, 1D, true, cancelToolBarButton3, false, 0.1D, 0.333D, true);
            devDept.Graphics.BackgroundSettings backgroundSettings3 = new devDept.Graphics.BackgroundSettings(devDept.Graphics.backgroundStyleType.LinearGradient, System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245))))), System.Drawing.Color.DodgerBlue, System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(163)))), ((int)(((byte)(210))))), 0.75D, null, devDept.Graphics.colorThemeType.Auto, 0.33D);
            devDept.Eyeshot.Camera camera3 = new devDept.Eyeshot.Camera(new devDept.Geometry.Point3D(0D, 0D, 45D), 380D, new devDept.Geometry.Quaternion(0.018434349666532526D, 0.039532590434972079D, 0.42221602280006187D, 0.90544518284475428D), devDept.Graphics.projectionType.Perspective, 40D, 6.2799976776524788D, false, 0.001D);
            devDept.Eyeshot.HomeToolBarButton homeToolBarButton3 = new devDept.Eyeshot.HomeToolBarButton("Home", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.MagnifyingGlassToolBarButton magnifyingGlassToolBarButton3 = new devDept.Eyeshot.MagnifyingGlassToolBarButton("Magnifying Glass", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomWindowToolBarButton zoomWindowToolBarButton3 = new devDept.Eyeshot.ZoomWindowToolBarButton("Zoom Window", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomToolBarButton zoomToolBarButton3 = new devDept.Eyeshot.ZoomToolBarButton("Zoom", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.PanToolBarButton panToolBarButton3 = new devDept.Eyeshot.PanToolBarButton("Pan", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.RotateToolBarButton rotateToolBarButton3 = new devDept.Eyeshot.RotateToolBarButton("Rotate", devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true, true);
            devDept.Eyeshot.ZoomFitToolBarButton zoomFitToolBarButton3 = new devDept.Eyeshot.ZoomFitToolBarButton("Zoom Fit", devDept.Eyeshot.ToolBarButton.styleType.PushButton, true, true);
            devDept.Eyeshot.ToolBar toolBar3 = new devDept.Eyeshot.ToolBar(devDept.Eyeshot.ToolBar.positionType.HorizontalTopCenter, true, new devDept.Eyeshot.ToolBarButton[] {
            ((devDept.Eyeshot.ToolBarButton)(homeToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(magnifyingGlassToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(zoomWindowToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(zoomToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(panToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(rotateToolBarButton3)),
            ((devDept.Eyeshot.ToolBarButton)(zoomFitToolBarButton3))});
            devDept.Eyeshot.Grid grid3 = new devDept.Eyeshot.Grid(new devDept.Geometry.Point2D(-100D, -100D), new devDept.Geometry.Point2D(100D, 100D), 10D, new devDept.Geometry.Plane(new devDept.Geometry.Point3D(0D, 0D, 0D), new devDept.Geometry.Vector3D(0D, 0D, 1D)), System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), false, true, false, false, 10, 100, 10, System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90))))), System.Drawing.Color.Transparent, false, System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))));
            devDept.Eyeshot.OriginSymbol originSymbol3 = new devDept.Eyeshot.OriginSymbol(10, devDept.Eyeshot.originSymbolStyleType.Ball, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, "Origin", "X", "Y", "Z", true, null, false);
            devDept.Eyeshot.RotateSettings rotateSettings3 = new devDept.Eyeshot.RotateSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.None), 10D, true, 1D, devDept.Eyeshot.rotationType.Trackball, devDept.Eyeshot.rotationCenterType.CursorLocation, new devDept.Geometry.Point3D(0D, 0D, 0D), false);
            devDept.Eyeshot.ZoomSettings zoomSettings3 = new devDept.Eyeshot.ZoomSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Shift), 25, true, devDept.Eyeshot.zoomStyleType.AtCursorLocation, false, 1D, System.Drawing.Color.Empty, devDept.Eyeshot.Camera.perspectiveFitType.Accurate, false, 10, true);
            devDept.Eyeshot.PanSettings panSettings3 = new devDept.Eyeshot.PanSettings(new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Middle, devDept.Eyeshot.modifierKeys.Ctrl), 25, true);
            devDept.Eyeshot.NavigationSettings navigationSettings3 = new devDept.Eyeshot.NavigationSettings(devDept.Eyeshot.Camera.navigationType.Examine, new devDept.Eyeshot.MouseButton(devDept.Eyeshot.mouseButtonsZPR.Left, devDept.Eyeshot.modifierKeys.None), new devDept.Geometry.Point3D(-1000D, -1000D, -1000D), new devDept.Geometry.Point3D(1000D, 1000D, 1000D), 8D, 50D, 50D);
            devDept.Eyeshot.CoordinateSystemIcon coordinateSystemIcon3 = new devDept.Eyeshot.CoordinateSystemIcon(new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80))))), System.Drawing.Color.OrangeRed, "Origin", "X", "Y", "Z", true, devDept.Eyeshot.coordinateSystemPositionType.BottomLeft, 37, null, false);
            devDept.Eyeshot.ViewCubeIcon viewCubeIcon3 = new devDept.Eyeshot.ViewCubeIcon(devDept.Eyeshot.coordinateSystemPositionType.TopRight, true, System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60))))), true, "FRONT", "BACK", "LEFT", "RIGHT", "TOP", "BOTTOM", System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77))))), 'S', 'N', 'W', 'E', true, null, System.Drawing.Color.White, System.Drawing.Color.Black, 120, true, true, null, null, null, null, null, null, false, new devDept.Geometry.Quaternion(0D, 0D, 0D, 1D));
            devDept.Eyeshot.Viewport.SavedViewsManager savedViewsManager3 = new devDept.Eyeshot.Viewport.SavedViewsManager(8);
            devDept.Eyeshot.Viewport viewport3 = new devDept.Eyeshot.Viewport(new System.Drawing.Point(0, 0), new System.Drawing.Size(523, 628), backgroundSettings3, camera3, new devDept.Eyeshot.ToolBar[] {
            toolBar3}, new devDept.Eyeshot.Legend[0], devDept.Eyeshot.displayType.Rendered, true, false, false, false, new devDept.Eyeshot.Grid[] {
            grid3}, new devDept.Eyeshot.OriginSymbol[] {
            originSymbol3}, false, rotateSettings3, zoomSettings3, panSettings3, navigationSettings3, coordinateSystemIcon3, viewCubeIcon3, savedViewsManager3, devDept.Eyeshot.viewType.Trimetric);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.model1 = new devDept.Eyeshot.Model();
            this.chkOnCurve = new System.Windows.Forms.CheckBox();
            this.NudExtrusionHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NudAngle = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CmdCreateCircle = new System.Windows.Forms.Button();
            this.CmdToSpline = new System.Windows.Forms.Button();
            this.CmdSaveToContour = new System.Windows.Forms.Button();
            this.CmdCreatePoint = new System.Windows.Forms.Button();
            this.CmdUnitePoints = new System.Windows.Forms.Button();
            this.CmdDeleteLastPnt = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.NudY = new System.Windows.Forms.NumericUpDown();
            this.CmdReadyMove = new System.Windows.Forms.Button();
            this.CmdMeasureBetweenPoints = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.NudX = new System.Windows.Forms.NumericUpDown();
            this.CmdMovePoints = new System.Windows.Forms.Button();
            this.CmdDeletePoints = new System.Windows.Forms.Button();
            this.CmdInsertNewPoints = new System.Windows.Forms.Button();
            this.CmdLinesMeasure = new System.Windows.Forms.Button();
            this.CmdMeasureAngle = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CmdCreateRegions = new System.Windows.Forms.Button();
            this.CmdMergeRegions = new System.Windows.Forms.Button();
            this.CmdCutRegWithDiff = new System.Windows.Forms.Button();
            this.CmdTrimDownReg = new System.Windows.Forms.Button();
            this.CmdCutWithinReg = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CmdExtrudeRegion = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.NudVolume = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NudDeltaValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NudSegment = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCloseMesh = new System.Windows.Forms.CheckBox();
            this.CmdRevolve = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.NudElevationValue = new System.Windows.Forms.NumericUpDown();
            this.CmdLoft = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.CmdExportMesh = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TrkSaturation = new System.Windows.Forms.TrackBar();
            this.CmdClean = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudExtrusionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAngle)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudX)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudDeltaValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSegment)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudElevationValue)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkSaturation)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // model1
            // 
            this.model1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model1.Cursor = System.Windows.Forms.Cursors.Default;
            this.model1.Location = new System.Drawing.Point(522, 4);
            this.model1.Name = "model1";
            this.model1.ProgressBar = progressBar3;
            this.model1.Size = new System.Drawing.Size(523, 628);
            this.model1.TabIndex = 0;
            this.model1.Text = "model1";
            this.model1.Viewports.Add(viewport3);
            this.model1.SelectionChanged += new devDept.Eyeshot.Environment.SelectionChangedEventHandler(this.model1_SelectionChanged);
            this.model1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.model1_KeyDown);
            this.model1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.model1_MouseClick);
            this.model1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.model1_MouseDown);
            this.model1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.model1_MouseMove);
            this.model1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.model1_MouseUp);
            // 
            // chkOnCurve
            // 
            this.chkOnCurve.AutoSize = true;
            this.chkOnCurve.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnCurve.Location = new System.Drawing.Point(213, 8);
            this.chkOnCurve.Name = "chkOnCurve";
            this.chkOnCurve.Size = new System.Drawing.Size(69, 17);
            this.chkOnCurve.TabIndex = 12;
            this.chkOnCurve.Text = "On curve";
            this.chkOnCurve.UseVisualStyleBackColor = true;
            // 
            // NudExtrusionHeight
            // 
            this.NudExtrusionHeight.DecimalPlaces = 2;
            this.NudExtrusionHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudExtrusionHeight.Location = new System.Drawing.Point(49, 13);
            this.NudExtrusionHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NudExtrusionHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudExtrusionHeight.Name = "NudExtrusionHeight";
            this.NudExtrusionHeight.Size = new System.Drawing.Size(54, 20);
            this.NudExtrusionHeight.TabIndex = 25;
            this.NudExtrusionHeight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NudExtrusionHeight.ValueChanged += new System.EventHandler(this.NudExtrusionHeight_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Height";
            // 
            // NudAngle
            // 
            this.NudAngle.DecimalPlaces = 2;
            this.NudAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudAngle.Location = new System.Drawing.Point(167, 13);
            this.NudAngle.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NudAngle.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.NudAngle.Name = "NudAngle";
            this.NudAngle.Size = new System.Drawing.Size(50, 20);
            this.NudAngle.TabIndex = 27;
            this.NudAngle.ValueChanged += new System.EventHandler(this.NudAngle_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Angle";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 75);
            this.tabControl1.TabIndex = 29;
            this.toolTip1.SetToolTip(this.tabControl1, "Move selected point");
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CmdCreateCircle);
            this.tabPage1.Controls.Add(this.CmdToSpline);
            this.tabPage1.Controls.Add(this.CmdSaveToContour);
            this.tabPage1.Controls.Add(this.CmdCreatePoint);
            this.tabPage1.Controls.Add(this.CmdUnitePoints);
            this.tabPage1.Controls.Add(this.CmdDeleteLastPnt);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 49);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Points Editor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CmdCreateCircle
            // 
            this.CmdCreateCircle.Image = ((System.Drawing.Image)(resources.GetObject("CmdCreateCircle.Image")));
            this.CmdCreateCircle.Location = new System.Drawing.Point(178, 6);
            this.CmdCreateCircle.Name = "CmdCreateCircle";
            this.CmdCreateCircle.Size = new System.Drawing.Size(35, 35);
            this.CmdCreateCircle.TabIndex = 7;
            this.toolTip1.SetToolTip(this.CmdCreateCircle, "create circle");
            this.CmdCreateCircle.UseVisualStyleBackColor = true;
            this.CmdCreateCircle.Click += new System.EventHandler(this.CmdCreateCircle_Click);
            // 
            // CmdToSpline
            // 
            this.CmdToSpline.Image = ((System.Drawing.Image)(resources.GetObject("CmdToSpline.Image")));
            this.CmdToSpline.Location = new System.Drawing.Point(144, 6);
            this.CmdToSpline.Name = "CmdToSpline";
            this.CmdToSpline.Size = new System.Drawing.Size(35, 35);
            this.CmdToSpline.TabIndex = 6;
            this.toolTip1.SetToolTip(this.CmdToSpline, "Convert: Spline <=> Polyline");
            this.CmdToSpline.UseVisualStyleBackColor = true;
            this.CmdToSpline.Click += new System.EventHandler(this.CmdToSpline_Click);
            // 
            // CmdSaveToContour
            // 
            this.CmdSaveToContour.Image = ((System.Drawing.Image)(resources.GetObject("CmdSaveToContour.Image")));
            this.CmdSaveToContour.Location = new System.Drawing.Point(110, 6);
            this.CmdSaveToContour.Name = "CmdSaveToContour";
            this.CmdSaveToContour.Size = new System.Drawing.Size(35, 35);
            this.CmdSaveToContour.TabIndex = 5;
            this.toolTip1.SetToolTip(this.CmdSaveToContour, "Save points as contour");
            this.CmdSaveToContour.UseVisualStyleBackColor = true;
            this.CmdSaveToContour.Click += new System.EventHandler(this.CmdSaveToContour_Click);
            // 
            // CmdCreatePoint
            // 
            this.CmdCreatePoint.BackColor = System.Drawing.Color.Transparent;
            this.CmdCreatePoint.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.CmdCreatePoint.Image = ((System.Drawing.Image)(resources.GetObject("CmdCreatePoint.Image")));
            this.CmdCreatePoint.Location = new System.Drawing.Point(4, 6);
            this.CmdCreatePoint.Name = "CmdCreatePoint";
            this.CmdCreatePoint.Size = new System.Drawing.Size(35, 35);
            this.CmdCreatePoint.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CmdCreatePoint, "Creating a new point");
            this.CmdCreatePoint.UseVisualStyleBackColor = false;
            this.CmdCreatePoint.Click += new System.EventHandler(this.CmdCreatePoint_Click);
            // 
            // CmdUnitePoints
            // 
            this.CmdUnitePoints.Image = ((System.Drawing.Image)(resources.GetObject("CmdUnitePoints.Image")));
            this.CmdUnitePoints.Location = new System.Drawing.Point(39, 6);
            this.CmdUnitePoints.Name = "CmdUnitePoints";
            this.CmdUnitePoints.Size = new System.Drawing.Size(35, 35);
            this.CmdUnitePoints.TabIndex = 3;
            this.toolTip1.SetToolTip(this.CmdUnitePoints, "Unite created points");
            this.CmdUnitePoints.UseVisualStyleBackColor = true;
            this.CmdUnitePoints.Click += new System.EventHandler(this.CmdUnitePoints_Click);
            // 
            // CmdDeleteLastPnt
            // 
            this.CmdDeleteLastPnt.BackColor = System.Drawing.Color.Transparent;
            this.CmdDeleteLastPnt.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.CmdDeleteLastPnt.Image = ((System.Drawing.Image)(resources.GetObject("CmdDeleteLastPnt.Image")));
            this.CmdDeleteLastPnt.Location = new System.Drawing.Point(75, 6);
            this.CmdDeleteLastPnt.Name = "CmdDeleteLastPnt";
            this.CmdDeleteLastPnt.Size = new System.Drawing.Size(35, 35);
            this.CmdDeleteLastPnt.TabIndex = 4;
            this.toolTip1.SetToolTip(this.CmdDeleteLastPnt, "Delete last point");
            this.CmdDeleteLastPnt.UseVisualStyleBackColor = false;
            this.CmdDeleteLastPnt.Click += new System.EventHandler(this.CmdDeleteLastPnt_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.NudY);
            this.tabPage2.Controls.Add(this.CmdReadyMove);
            this.tabPage2.Controls.Add(this.CmdMeasureBetweenPoints);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.NudX);
            this.tabPage2.Controls.Add(this.chkOnCurve);
            this.tabPage2.Controls.Add(this.CmdMovePoints);
            this.tabPage2.Controls.Add(this.CmdDeletePoints);
            this.tabPage2.Controls.Add(this.CmdInsertNewPoints);
            this.tabPage2.Controls.Add(this.CmdLinesMeasure);
            this.tabPage2.Controls.Add(this.CmdMeasureAngle);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 49);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contour Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "y";
            // 
            // NudY
            // 
            this.NudY.DecimalPlaces = 3;
            this.NudY.Location = new System.Drawing.Point(57, 27);
            this.NudY.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.NudY.Minimum = new decimal(new int[] {
            90000,
            0,
            0,
            -2147483648});
            this.NudY.Name = "NudY";
            this.NudY.Size = new System.Drawing.Size(76, 20);
            this.NudY.TabIndex = 9;
            this.toolTip1.SetToolTip(this.NudY, "y-coordinate of the point");
            this.NudY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudY_KeyDown);
            // 
            // CmdReadyMove
            // 
            this.CmdReadyMove.Image = global::Sketcher.Properties.Resources.SaveContour02;
            this.CmdReadyMove.Location = new System.Drawing.Point(391, 6);
            this.CmdReadyMove.Name = "CmdReadyMove";
            this.CmdReadyMove.Size = new System.Drawing.Size(35, 35);
            this.CmdReadyMove.TabIndex = 9;
            this.toolTip1.SetToolTip(this.CmdReadyMove, "Save edited contour");
            this.CmdReadyMove.UseVisualStyleBackColor = true;
            this.CmdReadyMove.Click += new System.EventHandler(this.CmdReadyMove_Click);
            // 
            // CmdMeasureBetweenPoints
            // 
            this.CmdMeasureBetweenPoints.Image = ((System.Drawing.Image)(resources.GetObject("CmdMeasureBetweenPoints.Image")));
            this.CmdMeasureBetweenPoints.Location = new System.Drawing.Point(356, 6);
            this.CmdMeasureBetweenPoints.Name = "CmdMeasureBetweenPoints";
            this.CmdMeasureBetweenPoints.Size = new System.Drawing.Size(35, 35);
            this.CmdMeasureBetweenPoints.TabIndex = 8;
            this.toolTip1.SetToolTip(this.CmdMeasureBetweenPoints, "Measure distance between points");
            this.CmdMeasureBetweenPoints.UseVisualStyleBackColor = true;
            this.CmdMeasureBetweenPoints.Click += new System.EventHandler(this.CmdMeasureBetweenPoints_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "x";
            // 
            // NudX
            // 
            this.NudX.DecimalPlaces = 3;
            this.NudX.Location = new System.Drawing.Point(57, 6);
            this.NudX.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.NudX.Minimum = new decimal(new int[] {
            900000,
            0,
            0,
            -2147483648});
            this.NudX.Name = "NudX";
            this.NudX.Size = new System.Drawing.Size(76, 20);
            this.NudX.TabIndex = 8;
            this.toolTip1.SetToolTip(this.NudX, "x-coordinate of the point");
            this.NudX.Enter += new System.EventHandler(this.NudX_Enter);
            this.NudX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudX_KeyDown);
            this.NudX.Leave += new System.EventHandler(this.NudX_Leave);
            // 
            // CmdMovePoints
            // 
            this.CmdMovePoints.Image = ((System.Drawing.Image)(resources.GetObject("CmdMovePoints.Image")));
            this.CmdMovePoints.Location = new System.Drawing.Point(4, 6);
            this.CmdMovePoints.Name = "CmdMovePoints";
            this.CmdMovePoints.Size = new System.Drawing.Size(35, 35);
            this.CmdMovePoints.TabIndex = 8;
            this.toolTip1.SetToolTip(this.CmdMovePoints, "Move selected point");
            this.CmdMovePoints.UseVisualStyleBackColor = true;
            this.CmdMovePoints.Click += new System.EventHandler(this.CmdMovePoints_Click);
            // 
            // CmdDeletePoints
            // 
            this.CmdDeletePoints.Image = ((System.Drawing.Image)(resources.GetObject("CmdDeletePoints.Image")));
            this.CmdDeletePoints.Location = new System.Drawing.Point(139, 6);
            this.CmdDeletePoints.Name = "CmdDeletePoints";
            this.CmdDeletePoints.Size = new System.Drawing.Size(35, 35);
            this.CmdDeletePoints.TabIndex = 10;
            this.toolTip1.SetToolTip(this.CmdDeletePoints, "Delete selected point");
            this.CmdDeletePoints.UseVisualStyleBackColor = true;
            this.CmdDeletePoints.Click += new System.EventHandler(this.CmdDeletePoints_Click);
            // 
            // CmdInsertNewPoints
            // 
            this.CmdInsertNewPoints.Image = ((System.Drawing.Image)(resources.GetObject("CmdInsertNewPoints.Image")));
            this.CmdInsertNewPoints.Location = new System.Drawing.Point(174, 6);
            this.CmdInsertNewPoints.Name = "CmdInsertNewPoints";
            this.CmdInsertNewPoints.Size = new System.Drawing.Size(35, 35);
            this.CmdInsertNewPoints.TabIndex = 11;
            this.toolTip1.SetToolTip(this.CmdInsertNewPoints, "Insert new points");
            this.CmdInsertNewPoints.UseVisualStyleBackColor = true;
            this.CmdInsertNewPoints.Click += new System.EventHandler(this.CmdInsertNewPoints_Click);
            // 
            // CmdLinesMeasure
            // 
            this.CmdLinesMeasure.Image = ((System.Drawing.Image)(resources.GetObject("CmdLinesMeasure.Image")));
            this.CmdLinesMeasure.Location = new System.Drawing.Point(288, 6);
            this.CmdLinesMeasure.Name = "CmdLinesMeasure";
            this.CmdLinesMeasure.Size = new System.Drawing.Size(35, 35);
            this.CmdLinesMeasure.TabIndex = 21;
            this.toolTip1.SetToolTip(this.CmdLinesMeasure, "Measure selected lines");
            this.CmdLinesMeasure.UseVisualStyleBackColor = true;
            this.CmdLinesMeasure.Click += new System.EventHandler(this.CmdLinesMeasure_Click);
            // 
            // CmdMeasureAngle
            // 
            this.CmdMeasureAngle.Image = ((System.Drawing.Image)(resources.GetObject("CmdMeasureAngle.Image")));
            this.CmdMeasureAngle.Location = new System.Drawing.Point(322, 6);
            this.CmdMeasureAngle.Name = "CmdMeasureAngle";
            this.CmdMeasureAngle.Size = new System.Drawing.Size(34, 35);
            this.CmdMeasureAngle.TabIndex = 22;
            this.toolTip1.SetToolTip(this.CmdMeasureAngle, "Measure selected angle");
            this.CmdMeasureAngle.UseVisualStyleBackColor = true;
            this.CmdMeasureAngle.Click += new System.EventHandler(this.CmdMeasureAngle_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CmdCreateRegions);
            this.tabPage3.Controls.Add(this.CmdMergeRegions);
            this.tabPage3.Controls.Add(this.CmdCutRegWithDiff);
            this.tabPage3.Controls.Add(this.CmdTrimDownReg);
            this.tabPage3.Controls.Add(this.CmdCutWithinReg);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(492, 49);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Region Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CmdCreateRegions
            // 
            this.CmdCreateRegions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CmdCreateRegions.Image = ((System.Drawing.Image)(resources.GetObject("CmdCreateRegions.Image")));
            this.CmdCreateRegions.Location = new System.Drawing.Point(4, 6);
            this.CmdCreateRegions.Name = "CmdCreateRegions";
            this.CmdCreateRegions.Size = new System.Drawing.Size(35, 35);
            this.CmdCreateRegions.TabIndex = 14;
            this.toolTip1.SetToolTip(this.CmdCreateRegions, "Create region");
            this.CmdCreateRegions.UseVisualStyleBackColor = false;
            this.CmdCreateRegions.Click += new System.EventHandler(this.CmdCreateRegions_Click);
            // 
            // CmdMergeRegions
            // 
            this.CmdMergeRegions.Image = ((System.Drawing.Image)(resources.GetObject("CmdMergeRegions.Image")));
            this.CmdMergeRegions.Location = new System.Drawing.Point(135, 6);
            this.CmdMergeRegions.Name = "CmdMergeRegions";
            this.CmdMergeRegions.Size = new System.Drawing.Size(35, 35);
            this.CmdMergeRegions.TabIndex = 17;
            this.toolTip1.SetToolTip(this.CmdMergeRegions, "Merge regions");
            this.CmdMergeRegions.UseVisualStyleBackColor = true;
            this.CmdMergeRegions.Click += new System.EventHandler(this.CmdMergeRegions_Click);
            // 
            // CmdCutRegWithDiff
            // 
            this.CmdCutRegWithDiff.Image = ((System.Drawing.Image)(resources.GetObject("CmdCutRegWithDiff.Image")));
            this.CmdCutRegWithDiff.Location = new System.Drawing.Point(100, 6);
            this.CmdCutRegWithDiff.Name = "CmdCutRegWithDiff";
            this.CmdCutRegWithDiff.Size = new System.Drawing.Size(35, 35);
            this.CmdCutRegWithDiff.TabIndex = 18;
            this.toolTip1.SetToolTip(this.CmdCutRegWithDiff, "Cut region with another Region");
            this.CmdCutRegWithDiff.UseVisualStyleBackColor = true;
            this.CmdCutRegWithDiff.Click += new System.EventHandler(this.CmdCutRegWithDiff_Click);
            // 
            // CmdTrimDownReg
            // 
            this.CmdTrimDownReg.Image = ((System.Drawing.Image)(resources.GetObject("CmdTrimDownReg.Image")));
            this.CmdTrimDownReg.Location = new System.Drawing.Point(170, 6);
            this.CmdTrimDownReg.Name = "CmdTrimDownReg";
            this.CmdTrimDownReg.Size = new System.Drawing.Size(35, 35);
            this.CmdTrimDownReg.TabIndex = 19;
            this.toolTip1.SetToolTip(this.CmdTrimDownReg, "Trim down regions");
            this.CmdTrimDownReg.UseVisualStyleBackColor = true;
            this.CmdTrimDownReg.Click += new System.EventHandler(this.CmdTrimDownReg_Click);
            // 
            // CmdCutWithinReg
            // 
            this.CmdCutWithinReg.Image = ((System.Drawing.Image)(resources.GetObject("CmdCutWithinReg.Image")));
            this.CmdCutWithinReg.Location = new System.Drawing.Point(39, 6);
            this.CmdCutWithinReg.Name = "CmdCutWithinReg";
            this.CmdCutWithinReg.Size = new System.Drawing.Size(35, 35);
            this.CmdCutWithinReg.TabIndex = 20;
            this.toolTip1.SetToolTip(this.CmdCutWithinReg, "Create region with a hole");
            this.CmdCutWithinReg.UseVisualStyleBackColor = true;
            this.CmdCutWithinReg.Click += new System.EventHandler(this.CmdCutWithinReg_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.NudExtrusionHeight);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.NudAngle);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.CmdExtrudeRegion);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(492, 49);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Extrusion";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CmdExtrudeRegion
            // 
            this.CmdExtrudeRegion.Image = ((System.Drawing.Image)(resources.GetObject("CmdExtrudeRegion.Image")));
            this.CmdExtrudeRegion.Location = new System.Drawing.Point(235, 6);
            this.CmdExtrudeRegion.Name = "CmdExtrudeRegion";
            this.CmdExtrudeRegion.Size = new System.Drawing.Size(35, 35);
            this.CmdExtrudeRegion.TabIndex = 24;
            this.toolTip1.SetToolTip(this.CmdExtrudeRegion, "Extrude selected contour");
            this.CmdExtrudeRegion.UseVisualStyleBackColor = true;
            this.CmdExtrudeRegion.Click += new System.EventHandler(this.CmdExtrudeRegion_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.NudVolume);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.NudDeltaValue);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.NudSegment);
            this.tabPage5.Controls.Add(this.checkBoxCloseMesh);
            this.tabPage5.Controls.Add(this.CmdRevolve);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(492, 49);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Revolve";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Distance";
            // 
            // NudVolume
            // 
            this.NudVolume.DecimalPlaces = 2;
            this.NudVolume.Location = new System.Drawing.Point(289, 15);
            this.NudVolume.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NudVolume.Name = "NudVolume";
            this.NudVolume.Size = new System.Drawing.Size(47, 20);
            this.NudVolume.TabIndex = 6;
            this.NudVolume.ValueChanged += new System.EventHandler(this.NudVolume_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delta angle";
            // 
            // NudDeltaValue
            // 
            this.NudDeltaValue.Location = new System.Drawing.Point(179, 15);
            this.NudDeltaValue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudDeltaValue.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NudDeltaValue.Name = "NudDeltaValue";
            this.NudDeltaValue.Size = new System.Drawing.Size(46, 20);
            this.NudDeltaValue.TabIndex = 4;
            this.NudDeltaValue.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudDeltaValue.ValueChanged += new System.EventHandler(this.NudDeltaValue_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Segments";
            // 
            // NudSegment
            // 
            this.NudSegment.Location = new System.Drawing.Point(62, 15);
            this.NudSegment.Maximum = new decimal(new int[] {
            212,
            0,
            0,
            0});
            this.NudSegment.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NudSegment.Name = "NudSegment";
            this.NudSegment.Size = new System.Drawing.Size(41, 20);
            this.NudSegment.TabIndex = 2;
            this.NudSegment.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NudSegment.ValueChanged += new System.EventHandler(this.NudSegment_ValueChanged);
            // 
            // checkBoxCloseMesh
            // 
            this.checkBoxCloseMesh.AutoSize = true;
            this.checkBoxCloseMesh.Location = new System.Drawing.Point(403, 10);
            this.checkBoxCloseMesh.Name = "checkBoxCloseMesh";
            this.checkBoxCloseMesh.Size = new System.Drawing.Size(81, 17);
            this.checkBoxCloseMesh.TabIndex = 1;
            this.checkBoxCloseMesh.Text = "Close Mesh";
            this.checkBoxCloseMesh.UseVisualStyleBackColor = true;
            // 
            // CmdRevolve
            // 
            this.CmdRevolve.Image = ((System.Drawing.Image)(resources.GetObject("CmdRevolve.Image")));
            this.CmdRevolve.Location = new System.Drawing.Point(364, 6);
            this.CmdRevolve.Name = "CmdRevolve";
            this.CmdRevolve.Size = new System.Drawing.Size(35, 35);
            this.CmdRevolve.TabIndex = 0;
            this.toolTip1.SetToolTip(this.CmdRevolve, "Revolve selected contour");
            this.CmdRevolve.UseVisualStyleBackColor = true;
            this.CmdRevolve.Click += new System.EventHandler(this.CmdRevolve_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.NudElevationValue);
            this.tabPage6.Controls.Add(this.CmdLoft);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(492, 49);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Loft";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Elevation";
            // 
            // NudElevationValue
            // 
            this.NudElevationValue.DecimalPlaces = 2;
            this.NudElevationValue.Location = new System.Drawing.Point(120, 15);
            this.NudElevationValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NudElevationValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudElevationValue.Name = "NudElevationValue";
            this.NudElevationValue.Size = new System.Drawing.Size(51, 20);
            this.NudElevationValue.TabIndex = 1;
            this.NudElevationValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NudElevationValue.ValueChanged += new System.EventHandler(this.NudElevationValue_ValueChanged);
            // 
            // CmdLoft
            // 
            this.CmdLoft.Image = ((System.Drawing.Image)(resources.GetObject("CmdLoft.Image")));
            this.CmdLoft.Location = new System.Drawing.Point(4, 6);
            this.CmdLoft.Name = "CmdLoft";
            this.CmdLoft.Size = new System.Drawing.Size(35, 35);
            this.CmdLoft.TabIndex = 0;
            this.toolTip1.SetToolTip(this.CmdLoft, "Loft selected contours");
            this.CmdLoft.UseVisualStyleBackColor = true;
            this.CmdLoft.Click += new System.EventHandler(this.CmdLoft_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.CmdExportMesh);
            this.tabPage7.Controls.Add(this.CmdClose);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(492, 49);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Save&Exit";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // CmdExportMesh
            // 
            this.CmdExportMesh.Image = ((System.Drawing.Image)(resources.GetObject("CmdExportMesh.Image")));
            this.CmdExportMesh.Location = new System.Drawing.Point(4, 6);
            this.CmdExportMesh.Name = "CmdExportMesh";
            this.CmdExportMesh.Size = new System.Drawing.Size(35, 35);
            this.CmdExportMesh.TabIndex = 8;
            this.toolTip1.SetToolTip(this.CmdExportMesh, "Export the mesh");
            this.CmdExportMesh.UseVisualStyleBackColor = true;
            this.CmdExportMesh.Click += new System.EventHandler(this.CmdExportMesh_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.CmdClose.Image = ((System.Drawing.Image)(resources.GetObject("CmdClose.Image")));
            this.CmdClose.Location = new System.Drawing.Point(39, 6);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(35, 35);
            this.CmdClose.TabIndex = 5;
            this.toolTip1.SetToolTip(this.CmdClose, "Close the App");
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TrkSaturation);
            this.panel1.Controls.Add(this.CmdClean);
            this.panel1.Location = new System.Drawing.Point(2, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 45);
            this.panel1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Color saturation";
            // 
            // TrkSaturation
            // 
            this.TrkSaturation.LargeChange = 1;
            this.TrkSaturation.Location = new System.Drawing.Point(92, 7);
            this.TrkSaturation.Maximum = 255;
            this.TrkSaturation.MaximumSize = new System.Drawing.Size(250, 25);
            this.TrkSaturation.MinimumSize = new System.Drawing.Size(250, 25);
            this.TrkSaturation.Name = "TrkSaturation";
            this.TrkSaturation.Size = new System.Drawing.Size(250, 45);
            this.TrkSaturation.TabIndex = 2;
            this.TrkSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrkSaturation.Value = 125;
            this.TrkSaturation.ValueChanged += new System.EventHandler(this.TrkSaturation_ValueChanged);
            // 
            // CmdClean
            // 
            this.CmdClean.Image = ((System.Drawing.Image)(resources.GetObject("CmdClean.Image")));
            this.CmdClean.Location = new System.Drawing.Point(466, 6);
            this.CmdClean.Name = "CmdClean";
            this.CmdClean.Size = new System.Drawing.Size(33, 33);
            this.CmdClean.TabIndex = 6;
            this.toolTip1.SetToolTip(this.CmdClean, "Clean the scene");
            this.CmdClean.UseVisualStyleBackColor = true;
            this.CmdClean.Click += new System.EventHandler(this.CmdClean_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 81);
            this.panel2.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1047, 644);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.model1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Extruded and Revolved Primitives";
            this.toolTip1.SetToolTip(this, "Close the Program");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudExtrusionHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAngle)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudX)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudDeltaValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSegment)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudElevationValue)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkSaturation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private devDept.Eyeshot.Model model1;
        private System.Windows.Forms.Button CmdCreatePoint;
        private System.Windows.Forms.Button CmdUnitePoints;
        private System.Windows.Forms.Button CmdDeleteLastPnt;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.Button CmdClean;
        private System.Windows.Forms.Button CmdMovePoints;
        private System.Windows.Forms.Button CmdReadyMove;
        private System.Windows.Forms.Button CmdDeletePoints;
        private System.Windows.Forms.Button CmdInsertNewPoints;
        private System.Windows.Forms.CheckBox chkOnCurve;
        private System.Windows.Forms.Button CmdCreateRegions;
        private System.Windows.Forms.Button CmdMergeRegions;
        private System.Windows.Forms.Button CmdCutRegWithDiff;
        private System.Windows.Forms.Button CmdTrimDownReg;
        private System.Windows.Forms.Button CmdCutWithinReg;
        private System.Windows.Forms.Button CmdLinesMeasure;
        private System.Windows.Forms.Button CmdMeasureAngle;
        private System.Windows.Forms.Button CmdExtrudeRegion;
        private System.Windows.Forms.NumericUpDown NudExtrusionHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CmdSaveToContour;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button CmdRevolve;
        private System.Windows.Forms.CheckBox checkBoxCloseMesh;
        private System.Windows.Forms.TrackBar TrkSaturation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudSegment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NudDeltaValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudVolume;
        private System.Windows.Forms.Button CmdToSpline;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button CmdLoft;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NudElevationValue;
        private System.Windows.Forms.Button CmdExportMesh;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button CmdCreateCircle;
        private System.Windows.Forms.Button CmdMeasureBetweenPoints;
        private System.Windows.Forms.NumericUpDown NudY;
        private System.Windows.Forms.NumericUpDown NudX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

