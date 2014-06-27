namespace TribalWars.Controls.Main.Monitoring
{
    partial class MonitoringControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("New inactive");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lost points");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Nobled");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Villages", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("No activity");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tribe change");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Players", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("All players");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Nobled");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("No activity");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Lost points");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Tribe", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.OptionsTree = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PreviousDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentDate = new System.Windows.Forms.Label();
            this.AdditionalFiltersGroupbox = new System.Windows.Forms.GroupBox();
            this.PreviousDateList = new System.Windows.Forms.ListBox();
            this.NobledVillage = new XPTable.Models.TextColumn();
            this.NobledPlayer = new XPTable.Models.TextColumn();
            this.NobledPlayerOld = new XPTable.Models.TextColumn();
            this.NobledPoints = new XPTable.Models.NumberColumn();
            this.NobledPointsOld = new XPTable.Models.NumberColumn();
            this.AdditionalFilters = new TribalWars.Controls.Accordeon.Location.FinderOptionsControl();
            this.Table = new TribalWars.Controls.Display.TableWrapperControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ApplyAdditionalFilters = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.AdditionalFiltersGroupbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsTree
            // 
            this.OptionsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTree.HideSelection = false;
            this.OptionsTree.Indent = 15;
            this.OptionsTree.Location = new System.Drawing.Point(3, 16);
            this.OptionsTree.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsTree.Name = "OptionsTree";
            treeNode1.Name = "Node2";
            treeNode1.Tag = "VillageNewInactive";
            treeNode1.Text = "New inactive";
            treeNode1.ToolTipText = "Villages that have become abandoned";
            treeNode2.Name = "Node3";
            treeNode2.Tag = "VillageLostPoints";
            treeNode2.Text = "Lost points";
            treeNode2.ToolTipText = "Villages that lost points";
            treeNode3.Name = "Node8";
            treeNode3.Tag = "PlayerNobled";
            treeNode3.Text = "Nobled";
            treeNode3.ToolTipText = "Villages that have been nobled";
            treeNode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode4.Name = "Node0";
            treeNode4.Text = "Villages";
            treeNode5.Name = "Node7";
            treeNode5.Tag = "PlayerNoActivity";
            treeNode5.Text = "No activity";
            treeNode5.ToolTipText = "Players that have not increased in points";
            treeNode6.Name = "Node10";
            treeNode6.Tag = "PlayerTribeChange";
            treeNode6.Text = "Tribe change";
            treeNode6.ToolTipText = "Players that have changed tribes";
            treeNode7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode7.Name = "Node6";
            treeNode7.Text = "Players";
            treeNode8.Name = "Node2";
            treeNode8.Tag = "TribePlayers";
            treeNode8.Text = "All players";
            treeNode8.ToolTipText = "Get a list of all players";
            treeNode9.Name = "Node1";
            treeNode9.Tag = "TribeNobled";
            treeNode9.Text = "Nobled";
            treeNode9.ToolTipText = "See who has nobled or was nobled in your tribe";
            treeNode10.Name = "Node2";
            treeNode10.Tag = "TribeNoActivity";
            treeNode10.Text = "No activity";
            treeNode10.ToolTipText = "See who has not grown in your tribe.";
            treeNode11.Name = "Node3";
            treeNode11.Tag = "TribeLostPoints";
            treeNode11.Text = "Lost points";
            treeNode11.ToolTipText = "See who has lost points in your tribe.";
            treeNode12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode12.Name = "Node0";
            treeNode12.Text = "Tribe";
            this.OptionsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode12});
            this.OptionsTree.ShowNodeToolTips = true;
            this.OptionsTree.ShowPlusMinus = false;
            this.OptionsTree.ShowRootLines = false;
            this.OptionsTree.Size = new System.Drawing.Size(114, 175);
            this.OptionsTree.TabIndex = 1;
            this.OptionsTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.OptionsTree_BeforeSelect);
            this.OptionsTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OptionsTree_NodeMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.PreviousDate);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.CurrentDate);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(182, 301);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(97, 283);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comparing";
            // 
            // PreviousDate
            // 
            this.PreviousDate.AutoSize = true;
            this.PreviousDate.Location = new System.Drawing.Point(3, 19);
            this.PreviousDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.PreviousDate.Name = "PreviousDate";
            this.PreviousDate.Size = new System.Drawing.Size(53, 13);
            this.PreviousDate.TabIndex = 1;
            this.PreviousDate.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "and";
            // 
            // CurrentDate
            // 
            this.CurrentDate.AutoSize = true;
            this.CurrentDate.Location = new System.Drawing.Point(3, 51);
            this.CurrentDate.Name = "CurrentDate";
            this.CurrentDate.Size = new System.Drawing.Size(53, 13);
            this.CurrentDate.TabIndex = 3;
            this.CurrentDate.Text = "Unknown";
            // 
            // AdditionalFiltersGroupbox
            // 
            this.AdditionalFiltersGroupbox.Controls.Add(this.ApplyAdditionalFilters);
            this.AdditionalFiltersGroupbox.Controls.Add(this.AdditionalFilters);
            this.AdditionalFiltersGroupbox.Location = new System.Drawing.Point(129, 3);
            this.AdditionalFiltersGroupbox.Name = "AdditionalFiltersGroupbox";
            this.AdditionalFiltersGroupbox.Size = new System.Drawing.Size(285, 194);
            this.AdditionalFiltersGroupbox.TabIndex = 0;
            this.AdditionalFiltersGroupbox.TabStop = false;
            this.AdditionalFiltersGroupbox.Text = "      Activate additional filters";
            // 
            // PreviousDateList
            // 
            this.PreviousDateList.Enabled = false;
            this.PreviousDateList.FormattingEnabled = true;
            this.PreviousDateList.Location = new System.Drawing.Point(106, 214);
            this.PreviousDateList.Name = "PreviousDateList";
            this.PreviousDateList.Size = new System.Drawing.Size(116, 56);
            this.PreviousDateList.TabIndex = 5;
            this.PreviousDateList.SelectedIndexChanged += new System.EventHandler(this.PreviousDateList_SelectedIndexChanged);
            // 
            // NobledVillage
            // 
            this.NobledVillage.Text = "Village";
            // 
            // NobledPlayer
            // 
            this.NobledPlayer.Text = "Player";
            // 
            // NobledPlayerOld
            // 
            this.NobledPlayerOld.Text = "Previous owner";
            // 
            // NobledPoints
            // 
            this.NobledPoints.Format = "#,0";
            this.NobledPoints.Text = "Points";
            // 
            // NobledPointsOld
            // 
            this.NobledPointsOld.Format = "#,0";
            this.NobledPointsOld.Text = "Difference";
            // 
            // AdditionalFilters
            // 
            this.AdditionalFilters.BackColor = System.Drawing.Color.Transparent;
            this.AdditionalFilters.Buttonsvisible = false;
            this.AdditionalFilters.Enabled = false;
            this.AdditionalFilters.Expanded = true;
            this.AdditionalFilters.Location = new System.Drawing.Point(-1, 14);
            this.AdditionalFilters.Margin = new System.Windows.Forms.Padding(0);
            this.AdditionalFilters.Name = "AdditionalFilters";
            this.AdditionalFilters.Size = new System.Drawing.Size(285, 178);
            this.AdditionalFilters.TabIndex = 0;
            // 
            // Table
            // 
            this.Table.AutoSelectSingleRow = true;
            this.Table.BackColor = System.Drawing.Color.Transparent;
            this.Table.DisplayType = TribalWars.Controls.Display.TableWrapperControl.ColumnDisplayTypeEnum.All;
            this.Table.Location = new System.Drawing.Point(279, 214);
            this.Table.Margin = new System.Windows.Forms.Padding(0);
            this.Table.Name = "Table";
            this.Table.RowSelectionAction = TribalWars.Controls.Display.TableWrapperControl.RowSelectionActionEnum.SelectVillage;
            this.Table.Size = new System.Drawing.Size(453, 317);
            this.Table.TabIndex = 0;
            this.Table.VisiblePlayerFields = TribalWars.Controls.Display.PlayerFields.None;
            this.Table.VisibleReportFields = TribalWars.Controls.Display.ReportFields.None;
            this.Table.VisibleTribeFields = TribalWars.Controls.Display.TribeFields.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptionsTree);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select filter";
            // 
            // ApplyAdditionalFilters
            // 
            this.ApplyAdditionalFilters.AutoSize = true;
            this.ApplyAdditionalFilters.Location = new System.Drawing.Point(10, 1);
            this.ApplyAdditionalFilters.Name = "ApplyAdditionalFilters";
            this.ApplyAdditionalFilters.Size = new System.Drawing.Size(15, 14);
            this.ApplyAdditionalFilters.TabIndex = 1;
            this.ApplyAdditionalFilters.UseVisualStyleBackColor = true;
            this.ApplyAdditionalFilters.CheckedChanged += new System.EventHandler(this.ApplyAdditionalFilters_CheckedChanged);
            // 
            // MonitoringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PreviousDateList);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.AdditionalFiltersGroupbox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MonitoringControl";
            this.Size = new System.Drawing.Size(719, 788);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.AdditionalFiltersGroupbox.ResumeLayout(false);
            this.AdditionalFiltersGroupbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XPTable.Models.TextColumn NobledVillage;
        private XPTable.Models.TextColumn NobledPlayer;
        private XPTable.Models.TextColumn NobledPlayerOld;
        private XPTable.Models.NumberColumn NobledPoints;
        private XPTable.Models.NumberColumn NobledPointsOld;
        private System.Windows.Forms.TreeView OptionsTree;
        private System.Windows.Forms.GroupBox AdditionalFiltersGroupbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PreviousDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CurrentDate;
        private TribalWars.Controls.Accordeon.Location.FinderOptionsControl AdditionalFilters;
        private System.Windows.Forms.ListBox PreviousDateList;
        private TribalWars.Controls.Display.TableWrapperControl Table;
        private System.Windows.Forms.CheckBox ApplyAdditionalFilters;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
