using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using XPTable.Models;

using TribalWars.Data.Players;
using TribalWars.Data.Tribes;
using TribalWars.Data.Villages;

using TribalWars.Controls.Accordeon.Location;
using TribalWars.Controls.Display;
using TribalWars.Controls.TWContextMenu;
using TribalWars.Data.Reporting;

namespace TribalWars.Controls.Display
{
    /// <summary>
    /// Control for displaying villages, players and tribes in an XPTable.
    /// Also provides right click functionality etc.
    /// </summary>
    public partial class TableWrapperControl : UserControl
    {
        #region Enums
        /// <summary>
        /// The fields to display in the XPTable
        /// </summary>
        public enum ColumnDisplayTypeEnum
        {
            All,
            Default,
            Custom
        }

        /// <summary>
        /// The action to take when the user
        /// selects a row in the XPTable
        /// </summary>
        public enum RowSelectionActionEnum
        {
            None,
            RaiseSelectEvent,
            SelectVillage
        }
        #endregion

        #region Events
        public event EventHandler<EventArgs> RowSelected;
        #endregion

        #region Fields
        private ColumnDisplayTypeEnum _displayType = ColumnDisplayTypeEnum.Default;
        private ColumnModel _playerColumnModel;
        private ColumnModel _villageColumnModel;
        private ColumnModel _tribeColumnModel;
        private ColumnModel _reportColumnModel;

        private PlayerFields _playerFields;
        private VillageFields _villageFields;
        private TribeFields _tribeFields;
        private ReportFields _reportFields;

        private bool _autoSelectSingleRow = true;
        private RowSelectionActionEnum _rowSelectionAction = RowSelectionActionEnum.SelectVillage;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether
        /// all columns, the most import columns or
        /// custom selected columns are visible
        /// </summary>
        public ColumnDisplayTypeEnum DisplayType
        {
            get { return _displayType; }
            set { _displayType = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the report display
        /// </summary>
        public ReportFields VisibleReportFields
        {
            get { return _reportFields; }
            set { _reportFields = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the tribe display
        /// </summary>
        public TribeFields VisibleTribeFields
        {
            get { return _tribeFields; }
            set { _tribeFields = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the village display
        /// </summary>
        public VillageFields VisibleVillageFields
        {
            get { return _villageFields; }
            set { _villageFields = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating which
        /// columns are visible for the player display
        /// </summary>
        public PlayerFields VisiblePlayerFields
        {
            get { return _playerFields; }
            set { _playerFields = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the row should be automatically selected
        /// when there is only one record
        /// </summary>
        public bool AutoSelectSingleRow
        {
            get { return _autoSelectSingleRow; }
            set { _autoSelectSingleRow = value; }
        }

        /// <summary>
        /// Gets or sets the action when the user
        /// selects a row
        /// </summary>
        public RowSelectionActionEnum RowSelectionAction
        {
            get { return _rowSelectionAction; }
            set { _rowSelectionAction = value; }
        }

        /// <summary>
        /// Gets the player XPTable ColumnModel
        /// </summary>
        public ColumnModel PlayerColumnModel
        {
            get
            {
                if (_playerColumnModel == null)
                {
                    switch (_displayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(_playerFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(PlayerFields.All);
                            break;
                        default:
                            _playerColumnModel = ColumnDisplay.CreateColumnModel(PlayerFields.Default);
                            break;
                    }
                }
                return _playerColumnModel;
            }
        }

        /// <summary>
        /// Gets the village XPTable ColumnModel
        /// </summary>
        public ColumnModel VillageColumnModel
        {
            get
            {
                if (_villageColumnModel == null)
                {
                    switch (_displayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(_villageFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(VillageFields.All);
                            break;
                        default:
                            _villageColumnModel = ColumnDisplay.CreateColumnModel(VillageFields.Default);
                            break;
                    }
                }
                return _villageColumnModel;
            }
        }

        /// <summary>
        /// Gets the tribe XPTable ColumnModel
        /// </summary>
        public ColumnModel TribeColumnModel
        {
            get
            {
                if (_tribeColumnModel == null)
                {
                    switch (_displayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(_tribeFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(TribeFields.All);
                            break;
                        default:
                            _tribeColumnModel = ColumnDisplay.CreateColumnModel(TribeFields.Default);
                            break;
                    }
                }
                return _tribeColumnModel;
            }
        }

        /// <summary>
        /// Gets the report XPTable ColumnModel
        /// </summary>
        public ColumnModel ReportColumnModel
        {
            get
            {
                if (_reportColumnModel == null)
                {
                    switch (_displayType)
                    {
                        case ColumnDisplayTypeEnum.Custom:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(_reportFields);
                            break;
                        case ColumnDisplayTypeEnum.All:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(ReportFields.All);
                            break;
                        default:
                            _reportColumnModel = ColumnDisplay.CreateColumnModel(ReportFields.Default);
                            break;
                    }
                }
                return _reportColumnModel;
            }
        }
        #endregion

        #region Constructors
        public TableWrapperControl()
        {
            InitializeComponent();
        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Right click village context menu on the XPTable
        /// </summary>
        private void TableControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Table.TableModel.Selections.SelectedItems.Length > 1)
                {
                    // Show context menu for multiple villages
                    TribalWars.Controls.TWContextMenu.VillagesContextMenu menu = new VillagesContextMenu();
                    List<Village> vils = new List<Village>();
                    foreach (Row row in Table.TableModel.Selections.SelectedItems)
                    {
                        vils.AddRange(((ITWContextMenu)row).GetVillages());
                    }
                    menu.Show(Table, e.Location, vils);
                }
                else
                {
                    // Display context menu for one village, player or tribe
                    Table.TableModel.Selections.Clear();
                    Table.TableModel.Selections.SelectCells(Table.RowIndexAt(e.Location), 0, Table.RowIndexAt(e.Location), Table.ColumnModel.Columns.Count - 1);
                    if (Table.TableModel.Selections.SelectedItems.Length == 1)
                    {
                        ITWContextMenu row = (ITWContextMenu)Table.TableModel.Selections.SelectedItems[0];
                        row.ShowContext(e.Location);
                    }
                }
            }
            else
            {
                // Raise the select event
                if (Table.TableModel.Selections.SelectedItems.Length == 1)
                {
                    ITWContextMenu row = (ITWContextMenu)Table.TableModel.Selections.SelectedItems[0];
                    switch (_rowSelectionAction)
                    {
                        case RowSelectionActionEnum.RaiseSelectEvent:
                            if (RowSelected != null)
                                RowSelected(row, EventArgs.Empty);
                            break;
                        case RowSelectionActionEnum.SelectVillage:
                            row.DisplayDetails();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Double click to pinpoint the selected row
        /// </summary>
        private void TableControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Table.TableModel.Selections.SelectedItems.Length > 0)
            {
                ITWContextMenu row = (ITWContextMenu)Table.TableModel.Selections.SelectedItems[0];
                World.Default.Map.EventPublisher.SelectVillages(null, row.GetVillages(), VillageTools.PinPoint);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Show a list of players in the XPTable
        /// </summary>
        /// <param name="players">A list of players</param>
        public void DisplayPlayers(IEnumerable<Player> players)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = PlayerColumnModel;
            if (World.Default.HasLoaded && players != null)
            {
                Table.SuspendLayout();
                foreach (Player ply in players)
                {
                    Table.TableModel.Rows.Add(new PlayerTableRow(ply));
                }
                if (_autoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Player player = ((PlayerTableRow)Table.TableModel.Rows[0]).Player;
                    World.Default.Map.EventPublisher.SelectVillages(null, player, VillageTools.PinPoint);
                }
                Table.ResumeLayout();
            }
        }

        /// <summary>
        /// Show a list of tribes in the XPTable
        /// </summary>
        /// <param name="tribes">A list of tribes</param>
        public void DisplayTribes(IEnumerable<Tribe> tribes)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = TribeColumnModel;
            if (tribes != null)
            {
                Table.SuspendLayout();
                foreach (Tribe tribe in tribes)
                {
                    Table.TableModel.Rows.Add(new TribeTableRow(tribe));
                }
                if (_autoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Tribe tribe = ((TribeTableRow)Table.TableModel.Rows[0]).Tribe;
                    World.Default.Map.EventPublisher.SelectVillages(null, tribe, VillageTools.PinPoint);
                }
                Table.ResumeLayout();
            }
        }

        /// <summary>
        /// Show a list of villages in the XPTable
        /// </summary>
        /// <param name="villages">A list of villages</param>
        public void DisplayVillages(IEnumerable<Village> villages)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = VillageColumnModel;
            if (villages != null)
            {
                Table.SuspendLayout();
                foreach (Village vil in villages)
                {
                    Table.TableModel.Rows.Add(new VillageTableRow(vil));
                }
                Table.ResumeLayout();
                if (_autoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Village village = ((VillageTableRow)Table.TableModel.Rows[0]).Village;
                    World.Default.Map.EventPublisher.SelectVillages(null, village, VillageTools.PinPoint);
                }
            }
        }

        /// <summary>
        /// Show a list of reports in the XPTable
        /// </summary>
        /// <param name="village">The village the reports are for</param>
        /// <param name="reports">The list of reports</param>
        public void DisplayReports(Village village, IEnumerable<Report> reports)
        {
            TableRows.Rows.Clear();
            Table.ColumnModel = ReportColumnModel;
            if (reports != null)
            {
                Table.SuspendLayout();
                foreach (Report report in reports)
                {
                    Table.TableModel.Rows.Add(new ReportTableRow(village, report));
                }
                Table.ResumeLayout();
                if (_autoSelectSingleRow && Table.TableModel.Rows.Count == 1)
                {
                    Report report = ((ReportTableRow)Table.TableModel.Rows[0]).Report;
                    List<Village> list = new List<Village>();
                    list.Add(report.Defender.Village);
                    list.Add(report.Attacker.Village);
                    World.Default.Map.EventPublisher.SelectVillages(null, list, VillageTools.PinPoint);
                }
            }
        }

        /// <summary>
        /// Displays a list of villages, players or tribes
        /// </summary>
        /// <param name="options">The search conditions</param>
        public void Display(FinderOptions options)
        {
            Table.BeginUpdate();
            Table.TableModel.Rows.Clear();
            switch (options.SearchFor)
            {
                case SearchForEnum.Tribes:
                    Table.ColumnModel = TribeColumnModel;
                    foreach (Tribe vil in options.TribeMatches())
                    {
                        Table.TableModel.Rows.Add(new TribeTableRow(vil));
                    }
                    break;
                case SearchForEnum.Villages:
                    Table.ColumnModel = VillageColumnModel;
                    foreach (Village vil in options.VillageMatches())
                    {
                        Table.TableModel.Rows.Add(new VillageTableRow(vil));
                    }
                    break;
                default:
                    Table.ColumnModel = PlayerColumnModel;
                    foreach (Player vil in options.PlayerMatches())
                    {
                        Table.TableModel.Rows.Add(new PlayerTableRow(vil));
                    }
                    break;
            }

            // auto sorting
            if (Table.SortingColumn != -1)
                Table.Sort(Table.SortingColumn, Table.ColumnModel.Columns[Table.SortingColumn].SortOrder);
            else if (Table.ColumnModel.Columns.Count > 4)
            {
                Table.Sort(4, SortOrder.Descending);
            }
            Table.EndUpdate();
        }

        /// <summary>
        /// Clears the XPTable
        /// </summary>
        public void Clear()
        {
            TableRows.Rows.Clear();
        }
        #endregion
    }
}