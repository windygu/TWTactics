namespace TribalWars.Controls.Main.Polygons
{
    partial class PolygonControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolygonControl));
            Janus.Windows.GridEX.GridEXLayout GridExVillage_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout GridExPolygon_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ButtonGenerate = new Janus.Windows.EditControls.UIButton();
            this.LoadPolygonData = new Janus.Windows.EditControls.UIButton();
            this.VisibleImageList = new System.Windows.Forms.ImageList(this.components);
            this.GridExVillageShowFieldChooser = new Janus.Windows.EditControls.UIButton();
            this.GridExVillage = new Janus.Windows.GridEX.GridEX();
            this.polygonDataSet1 = new TribalWars.Controls.Main.Polygons.PolygonDataSet();
            this.ModusPolygon = new Janus.Windows.EditControls.UIButton();
            this.GeneratorActions = new Janus.Windows.EditControls.UIGroupBox();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.ModusVillage = new Janus.Windows.EditControls.UIButton();
            this.GridExPolygon = new Janus.Windows.GridEX.GridEX();
            this.CurrentModusGroupbox = new Janus.Windows.EditControls.UIGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridExVillage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polygonDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorActions)).BeginInit();
            this.GeneratorActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExPolygon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentModusGroupbox)).BeginInit();
            this.CurrentModusGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGenerate.Location = new System.Drawing.Point(6, 72);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(88, 45);
            this.ButtonGenerate.TabIndex = 1;
            this.ButtonGenerate.Text = "&Generate BBCodes";
            this.ButtonGenerate.ToolTipText = "Put BBCodes for all checked visible village rows to the clipboard.";
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // LoadPolygonData
            // 
            this.LoadPolygonData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPolygonData.Location = new System.Drawing.Point(6, 19);
            this.LoadPolygonData.Name = "LoadPolygonData";
            this.LoadPolygonData.Size = new System.Drawing.Size(88, 45);
            this.LoadPolygonData.TabIndex = 1;
            this.LoadPolygonData.Text = "Load Polygon Data";
            this.LoadPolygonData.ToolTipText = "Load (or reload) all your drawn polygons.";
            this.LoadPolygonData.Click += new System.EventHandler(this.LoadPolygonData_Click);
            // 
            // VisibleImageList
            // 
            this.VisibleImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("VisibleImageList.ImageStream")));
            this.VisibleImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.VisibleImageList.Images.SetKeyName(0, "Visible");
            // 
            // GridExVillageShowFieldChooser
            // 
            this.GridExVillageShowFieldChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GridExVillageShowFieldChooser.Location = new System.Drawing.Point(576, 27);
            this.GridExVillageShowFieldChooser.Name = "GridExVillageShowFieldChooser";
            this.GridExVillageShowFieldChooser.Size = new System.Drawing.Size(110, 23);
            this.GridExVillageShowFieldChooser.TabIndex = 2;
            this.GridExVillageShowFieldChooser.TabStop = false;
            this.GridExVillageShowFieldChooser.Text = "Show/Hide Columns";
            this.GridExVillageShowFieldChooser.Click += new System.EventHandler(this.GridExVillageShowFieldChooser_Click);
            // 
            // GridExVillage
            // 
            this.GridExVillage.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridExVillage.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridExVillage.AlternatingColors = true;
            this.GridExVillage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridExVillage.AutoEdit = true;
            this.GridExVillage.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><EmptyGridInfo>Click \'" +
    "Load Polygon Data\' to load all villages inside your polygons.</EmptyGridInfo></L" +
    "ocalizableData>";
            this.GridExVillage.ColumnAutoResize = true;
            this.GridExVillage.DataMember = "VILLAGE";
            this.GridExVillage.DataSource = this.polygonDataSet1;
            GridExVillage_DesignTimeLayout.LayoutString = resources.GetString("GridExVillage_DesignTimeLayout.LayoutString");
            this.GridExVillage.DesignTimeLayout = GridExVillage_DesignTimeLayout;
            this.GridExVillage.DynamicFiltering = true;
            this.GridExVillage.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GridExVillage.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.GridExVillage.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.GridExVillage.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridExVillage.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.GridExVillage.ImageList = this.VisibleImageList;
            this.GridExVillage.Location = new System.Drawing.Point(6, 19);
            this.GridExVillage.Name = "GridExVillage";
            this.GridExVillage.SaveSettings = true;
            this.GridExVillage.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            this.GridExVillage.SettingsKey = "PolygonVillage";
            this.GridExVillage.Size = new System.Drawing.Size(706, 244);
            this.GridExVillage.TabIndex = 0;
            this.GridExVillage.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.GridExVillage.UseGroupRowSelector = true;
            this.GridExVillage.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.GridExVillage_RowCheckStateChanged);
            this.GridExVillage.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.GridExVillage_RowDoubleClick);
            this.GridExVillage.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.GridExVillage_FormattingRow);
            this.GridExVillage.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.GridExVillage_LoadingRow);
            this.GridExVillage.GroupsChanging += new Janus.Windows.GridEX.GroupsChangingEventHandler(this.GridExVillage_GroupsChanging);
            this.GridExVillage.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.GridExVillage_CurrentCellChanging);
            // 
            // polygonDataSet1
            // 
            this.polygonDataSet1.DataSetName = "PolygonDataSet";
            this.polygonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ModusPolygon
            // 
            this.ModusPolygon.Location = new System.Drawing.Point(6, 70);
            this.ModusPolygon.Name = "ModusPolygon";
            this.ModusPolygon.Size = new System.Drawing.Size(84, 45);
            this.ModusPolygon.TabIndex = 0;
            this.ModusPolygon.Text = "Manage Polygons";
            this.ModusPolygon.ToolTipText = "Change polygon groups, names and colors!";
            this.ModusPolygon.Click += new System.EventHandler(this.ModusPolygon_Click);
            // 
            // GeneratorActions
            // 
            this.GeneratorActions.Controls.Add(this.ButtonGenerate);
            this.GeneratorActions.Controls.Add(this.LoadPolygonData);
            this.GeneratorActions.Location = new System.Drawing.Point(3, 133);
            this.GeneratorActions.Name = "GeneratorActions";
            this.GeneratorActions.Size = new System.Drawing.Size(100, 123);
            this.GeneratorActions.TabIndex = 5;
            this.GeneratorActions.Text = "Actions";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.ModusVillage);
            this.uiGroupBox1.Controls.Add(this.ModusPolygon);
            this.uiGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(100, 124);
            this.uiGroupBox1.TabIndex = 6;
            this.uiGroupBox1.Text = "Switch modus";
            // 
            // ModusVillage
            // 
            this.ModusVillage.Enabled = false;
            this.ModusVillage.Location = new System.Drawing.Point(6, 19);
            this.ModusVillage.Name = "ModusVillage";
            this.ModusVillage.Size = new System.Drawing.Size(84, 45);
            this.ModusVillage.TabIndex = 1;
            this.ModusVillage.Text = "BBCodes Generator";
            this.ModusVillage.ToolTipText = "Generate BBCodes based on villages inside the polygons";
            this.ModusVillage.Click += new System.EventHandler(this.ModusVillage_Click);
            // 
            // GridExPolygon
            // 
            this.GridExPolygon.AlternatingColors = true;
            this.GridExPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridExPolygon.AutoEdit = true;
            GridExPolygon_DesignTimeLayout.LayoutString = resources.GetString("GridExPolygon_DesignTimeLayout.LayoutString");
            this.GridExPolygon.DesignTimeLayout = GridExPolygon_DesignTimeLayout;
            this.GridExPolygon.GroupByBoxVisible = false;
            this.GridExPolygon.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.GridExPolygon.Location = new System.Drawing.Point(6, 19);
            this.GridExPolygon.Name = "GridExPolygon";
            this.GridExPolygon.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridExPolygon.SaveSettings = true;
            this.GridExPolygon.SettingsKey = "PolygonManage";
            this.GridExPolygon.Size = new System.Drawing.Size(706, 244);
            this.GridExPolygon.TabIndex = 7;
            this.GridExPolygon.Visible = false;
            this.GridExPolygon.InitCustomEdit += new Janus.Windows.GridEX.InitCustomEditEventHandler(this.GridExPolygon_InitCustomEdit);
            this.GridExPolygon.EndCustomEdit += new Janus.Windows.GridEX.EndCustomEditEventHandler(this.GridExPolygon_EndCustomEdit);
            // 
            // CurrentModusGroupbox
            // 
            this.CurrentModusGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentModusGroupbox.Controls.Add(this.GridExVillageShowFieldChooser);
            this.CurrentModusGroupbox.Controls.Add(this.GridExVillage);
            this.CurrentModusGroupbox.Controls.Add(this.GridExPolygon);
            this.CurrentModusGroupbox.Location = new System.Drawing.Point(109, 3);
            this.CurrentModusGroupbox.Name = "CurrentModusGroupbox";
            this.CurrentModusGroupbox.Size = new System.Drawing.Size(718, 269);
            this.CurrentModusGroupbox.TabIndex = 8;
            this.CurrentModusGroupbox.Text = "Current modus: BBCodes Generator";
            // 
            // PolygonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CurrentModusGroupbox);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.GeneratorActions);
            this.Name = "PolygonControl";
            this.Size = new System.Drawing.Size(829, 278);
            ((System.Configuration.IPersistComponentSettings)(this.GridExVillage)).LoadComponentSettings();
            ((System.ComponentModel.ISupportInitialize)(this.GridExVillage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polygonDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorActions)).EndInit();
            this.GeneratorActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.Configuration.IPersistComponentSettings)(this.GridExPolygon)).LoadComponentSettings();
            ((System.ComponentModel.ISupportInitialize)(this.GridExPolygon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentModusGroupbox)).EndInit();
            this.CurrentModusGroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridExVillage;
        private PolygonDataSet polygonDataSet1;
        private Janus.Windows.EditControls.UIButton ButtonGenerate;
        private Janus.Windows.EditControls.UIButton LoadPolygonData;
        private System.Windows.Forms.ImageList VisibleImageList;
        private Janus.Windows.EditControls.UIButton GridExVillageShowFieldChooser;
        private Janus.Windows.EditControls.UIButton ModusPolygon;
        private Janus.Windows.EditControls.UIGroupBox GeneratorActions;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton ModusVillage;
        private Janus.Windows.GridEX.GridEX GridExPolygon;
        private Janus.Windows.EditControls.UIGroupBox CurrentModusGroupbox;

    }
}
