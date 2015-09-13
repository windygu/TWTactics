#region Using
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using TribalWars.Controls;
using TribalWars.Controls.GridExs;
using TribalWars.Controls.XPTables;
using TribalWars.Maps.Manipulators.Managers;
using TribalWars.Tools;
using TribalWars.Tools.JanusExtensions;
using TribalWars.Villages;
using TribalWars.Villages.ContextMenu;
using TribalWars.Worlds;
using TribalWars.Worlds.Events;
using TribalWars.Worlds.Events.Impls;

#endregion

namespace TribalWars.Maps.Polygons
{
    /// <summary>
    /// Manages the villages inside the BBCodeArea polygons
    /// </summary>
    public partial class PolygonControl : UserControl
    {
        #region Constructors
        public PolygonControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            World.Default.Map.EventPublisher.PolygonActivated += EventPublisher_PolygonActivated;
            World.Default.Map.EventPublisher.LocationChanged += EventPublisher_LocationChanged;
            SetGridExVillageTooltips();
        }
        #endregion

        #region Event Handlers
        private void PolygonControl_Load(object sender, System.EventArgs e)
        {
            GridExVillage.Configure(false, true);
            GridExPolygon.Configure(true, false);

            GridExPolygon.RootTable.Columns["LineColor"].ConfigureAsColor();
        }

        /// <summary>
        /// BBCodeArea polygon(s) have been ported to this control
        /// </summary>
        private void EventPublisher_PolygonActivated(object sender, PolygonEventArgs e)
        {
            Polygon[] polygons = e.Polygons.ToArray();
            if (polygons.Length == 1)
            {
                // Polygon management grid: jump to the selected polygon row
                foreach (GridEXRow row in GridExPolygon.GetRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        var polygon = (Polygon)row.DataRow;
                        if (polygon.Equals(polygons[0]))
                        {
                            GridExPolygon.MoveTo(row);
                            break;
                        }
                    }
                }
            }

            GridExVillage.DataSource = PolygonDataSet.CreateDataSet(e.Polygons);
            GridExVillage.MoveFirst();
        }

        /// <summary>
        /// Update visibility of villages after map move
        /// </summary>
        private void EventPublisher_LocationChanged(object sender, MapLocationEventArgs e)
        {
            var villageDs = (PolygonDataSet)GridExVillage.DataSource;
            foreach (var record in villageDs.VILLAGE.Rows.OfType<PolygonDataSet.VILLAGERow>())
            {
                record.ISVISIBLE = World.Default.Map.Display.IsVisible(record.Village);
            }
        }

        /// <summary>
        /// Load all villages from all polygons
        /// </summary>
        private void LoadPolygonData_Click(object sender, System.EventArgs e)
        {
            List<Polygon> polygons = World.Default.Map.Manipulators.PolygonManipulator.GetAllPolygons().ToList();
            if (!polygons.Any())
            {
                World.Default.Map.Manipulators.SetManipulator(ManipulatorManagerTypes.Polygon);
				MessageBox.Show(ControlsRes.PolygonControl_StartHelp, ControlsRes.PolygonControl_StartHelpTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (ModusPolygon.Enabled)
            {
                // BBCode export: load villages
                GridExVillage.RemoveFilters();
                World.Default.Map.EventPublisher.ActivatePolygon(this, polygons);
            }
            else
            {
                // Polygon management
                IEnumerable<string> groups = polygons.Select(x => x.Group).Distinct().OrderBy(x => x);
                var valueList = new GridEXValueListItemCollection();
                foreach (string group in groups)
                {
                    valueList.Add(group, group);
                }
                GridExPolygon.RootTable.Columns["GROUP"].EditValueList = valueList;

                GridExPolygon.DataSource = polygons;
                GridExPolygon.MoveFirst();
            }
        }
        #endregion

        #region GridExVillage
        /// <summary>
        /// The selected villages are exported to the clipboard
        /// </summary>
        private void ButtonGenerate_Click(object sender, System.EventArgs e)
        {
            if (GridExVillage.RowCount == 0)
            {
				MessageBox.Show(string.Format(ControlsRes.PolygonControl_EmptyGrid, LoadPolygonData.Text), ControlsRes.PolygonControl_StartHelpTitle);
                return;
            }

            var str = new StringBuilder();
            int villagesExported = 0;
            foreach (GridEXRow groupRow in GridExVillage.GetRows())
            {
                if (groupRow.RowType == RowType.GroupHeader)
                {
                    str.AppendLine();
                    str.AppendLine();
                    str.AppendLine(groupRow.GroupValue.ToString());
                    foreach (GridEXRow row in groupRow.GetChildRecords())
                    {
                        if (row.CheckState == RowCheckState.Checked)
                        {
                            villagesExported++;

                            var villageRow = (PolygonDataSet.VILLAGERow)((DataRowView)row.DataRow).Row;
                            if (!string.IsNullOrWhiteSpace(villageRow.Village.Type.GetDescription()))
                            {
                                str.AppendLine(villageRow.BBCODE + " (" + villageRow.Village.Type.GetDescription() + ")");
                            }
                            else
                            {
                                str.AppendLine(villageRow.BBCODE);
                            }
                        }
                    }
                }
            }

            if (WinForms.ToClipboard(str.ToString().Trim()))
            {
				MessageBox.Show(string.Format(ControlsRes.PolygonControl_ToClipboard, villagesExported), ControlsRes.PolygonControl_ToClipboardTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Select the village
        /// </summary>
        private void GridExVillage_CurrentCellChanging(object sender, CurrentCellChangingEventArgs e)
        {
            if (e.Row != null && e.Row.RowType == RowType.Record)
            {
                var row = e.Row.GetDataRow<PolygonDataSet.VILLAGERow>();
                World.Default.Map.EventPublisher.SelectVillages(null, row.Village, VillageTools.PinPoint);
            }
            else
            {
                GridExVillage.ContextMenu = null;
            }
        }

        /// <summary>
        /// Provide right click context menu
        /// </summary>
        private void GridExVillage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowCount = GridExVillage.SelectedItems.Count;
                if (rowCount == 1)
                {
                    var row = GridExVillage.CurrentRow;
                    if (row != null && row.RowType == RowType.Record)
                    {
                        var record = row.GetDataRow<PolygonDataSet.VILLAGERow>();

                        var contextMenu = new VillageContextMenu(World.Default.Map, record.Village, () => GridExVillage.Refresh());
                        contextMenu.Show(GridExVillage, e.Location);
                    }
                }
                else if (rowCount > 1)
                {
                    IEnumerable<Village> villages = GridExVillage.SelectedItems.GetDataSetRows<PolygonDataSet.VILLAGERow>().Select(x => x.Village);

                    var contextMenu = new VillagesContextMenu(World.Default.Map, villages.ToArray(), type => GridExVillage.Refresh());
                    contextMenu.Show(GridExVillage, e.Location);
                }
            }
        }

        /// <summary>
        /// PinPoint the village
        /// </summary>
        private void GridExVillage_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                var row = e.Row.GetDataRow<PolygonDataSet.VILLAGERow>();
                World.Default.Map.EventPublisher.SelectVillages(null, row.Village, VillageTools.PinPoint);
                World.Default.Map.SetCenter(row.Village.Location);
            }
        }

        /// <summary>
        /// Special formatting, image display, tooltips
        /// </summary>
        private void GridExVillage_FormattingRow(object sender, RowLoadEventArgs e)
        {
            // GroupHeaders
            UpdateGroupRecordText(e.Row);

            // Normal Rows
            if (e.Row.RowType == RowType.Record)
            {
                var record = e.Row.GetDataRow<PolygonDataSet.VILLAGERow>();

                // SetVillageVisibility()
                if (record.ISVISIBLE)
                {
                    e.Row.Cells["ISVISIBLE"].Image = Properties.Resources.Visible;
					e.Row.Cells["ISVISIBLE"].ToolTipText = VillageGridExRes.VisibleTooltip;
                }

                // SetVillageType()
                if (record.Village.Type != VillageType.None)
                {
                    e.Row.Cells["TYPE"].Image = record.Village.Type.GetImage(true);
                    if (record.Village.HasComments)
                    {
                        e.Row.Cells["TYPE"].ToolTipText = record.Village.Comments;
                    }
                    else
                    {
                        e.Row.Cells["TYPE"].ToolTipText = record.Village.Type.GetDescription();
                    }
                }

                // Display You and your tribe in special color
                if (record.Village.HasPlayer)
                {
                    var you = World.Default.You;
                    if (record.Village.Player == you)
                    {
                        var style = new GridEXFormatStyle();
                        style.ForeColor = Color.Red;
                        style.FontBold = TriState.True;
                        e.Row.Cells["PLAYER"].FormatStyle = style;
                    }
                    else if (you != null && record.Village.Player.Tribe == you.Tribe)
                    {
                        var style = new GridEXFormatStyle();
                        style.ForeColor = Color.Blue;
                        style.FontBold = TriState.True;
                        e.Row.Cells["PLAYER"].FormatStyle = style;
                    }
                }
            }
        }

        private void GridExVillage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (var row in GridExVillage.SelectedItems.GetGridRows())
                {
                    row.IsChecked = !row.IsChecked;
                }
            }
        }

        /// <summary>
        /// Update group header totals
        /// </summary>
        private void GridExVillage_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            GridEXRow groupToUpdate = e.Row;
            if (groupToUpdate == null)
            {
                // Column header checkbox click
                foreach (var row in GridExVillage.GetRows())
                {
                    UpdateGroupRecordText(row);
                }
                return;
            }

            if (e.Row.RowType == RowType.Record)
            {
                // Normal row
                groupToUpdate = e.Row.Parent;
            }

            if (groupToUpdate.RowType == RowType.GroupHeader)
            {
                if (groupToUpdate.Parent != null)
                {
                    UpdateGroupRecordText(groupToUpdate.Parent);
                }
                else
                {
                    UpdateGroupRecordText(groupToUpdate);
                }
            }
        }

        /// <summary>
        /// Update the group text with the amount of checked villages / total villages
        /// </summary>
        private void UpdateGroupRecordText(GridEXRow row)
        {
            if (row.RowType == RowType.GroupHeader)
            {
                // Set group totals
                int totalRecords = row.GetRecordCount();
                int totalChecked = row.GetChildRecords().Count(x => x.CheckState == RowCheckState.Checked);
				row.GroupCaption = string.Format(ControlsRes.PolygonControl_Grid_GroupText, row.GroupValue, totalChecked, totalRecords);

                GridEXRow[] children = row.GetChildRows();
                foreach (var child in children)
                {
                    UpdateGroupRecordText(child);
                }
            }
        }

        /// <summary>
        /// Don't allow changing the default grouping
        /// </summary>
        private void GridExVillage_GroupsChanging(object sender, GroupsChangingEventArgs e)
        {
            // Things will break if groups are changed
            e.Cancel = true;
        }

        /// <summary>
        /// Column chooser
        /// </summary>
        private void GridExVillageShowFieldChooser_Click(object sender, System.EventArgs e)
        {
            GridExVillage.ShowFieldChooser();
        }

        private void SetGridExVillageTooltips()
        {
            GridExVillage.RootTable.Columns["NAME"].HeaderToolTip = VillageGridExRes.NameTooltip;
			GridExVillage.RootTable.Columns["LOCATION"].HeaderToolTip = VillageGridExRes.LocationTooltip;
			GridExVillage.RootTable.Columns["KINGDOM"].HeaderToolTip = VillageGridExRes.KingdomTooltip;
			GridExVillage.RootTable.Columns["POINTS"].HeaderToolTip = VillageGridExRes.PointsTooltip;
			GridExVillage.RootTable.Columns["POINTSDIFF"].HeaderToolTip = VillageGridExRes.PointsDifferenceTooltip;
			GridExVillage.RootTable.Columns["PLAYER"].HeaderToolTip = VillageGridExRes.NameTooltip;
			GridExVillage.RootTable.Columns["TRIBE"].HeaderToolTip = VillageGridExRes.TribeTag;
			GridExVillage.RootTable.Columns["TYPE"].HeaderToolTip = VillageGridExRes.TypeTooltip;
			GridExVillage.RootTable.Columns["ISVISIBLE"].HeaderToolTip = VillageGridExRes.VisibleTooltip;
        }
        #endregion

        #region Modus Switch
        private void ModusVillage_Click(object sender, System.EventArgs e)
        {
            SetModus(true);
        }

        private void ModusPolygon_Click(object sender, System.EventArgs e)
        {
            SetModus(false);
        }

        /// <summary>
        /// Change control enablement
        /// </summary>
        /// <param name="isVillageModus">VillageModus=Export bbcodes OR PolygonModus=Manage polygons</param>
        private void SetModus(bool isVillageModus)
        {
            ModusVillage.Enabled = !isVillageModus;
            ModusPolygon.Enabled = isVillageModus;

			CurrentModusGroupbox.Text = string.Format(ControlsRes.PolygonControl_ModusCaption, isVillageModus ? ModusVillage.Text : ModusPolygon.Text);
            GridExVillage.Visible = isVillageModus;
            GridExVillageShowFieldChooser.Visible = isVillageModus;
            GridExPolygon.Visible = !isVillageModus;

            ButtonGenerate.Enabled = isVillageModus;

            LoadPolygonData.PerformClick();
        }
        #endregion
    }
}