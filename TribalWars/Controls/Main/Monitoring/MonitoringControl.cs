using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TribalWars.Controls.Accordeon.Location;
using TribalWars.Controls.Display;
using TribalWars.Data;
using XPTable.Models;

namespace TribalWars.Controls.Main.Monitoring
{
    public partial class MonitoringControl : UserControl
    {
        #region Constructors
        public MonitoringControl()
        {
            InitializeComponent();

            for (int i = 0; i <= OptionsTree.Nodes.Count - 1; i++)
                OptionsTree.Nodes[i].Expand();

            World.Default.EventPublisher.MonitorLoaded += EventPublisher_Monitor;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Execute the selected predefined search operation
        /// </summary>
        private void OptionsTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                FinderOptions options = CreateOption(e.Node.Tag.ToString());
                Table.Display(options);
            }
        }

        /// <summary>
        /// Don't allow selection of Villages, Players, Tribes
        /// </summary>
        private void OptionsTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
                e.Cancel = true;
        }

        private void ApplyAdditionalFilters_CheckedChanged(object sender, EventArgs e)
        {
            AdditionalFilters.Enabled = ApplyAdditionalFilters.Checked;
        }

        /// <summary>
        /// Reload previous data
        /// </summary>
        private void PreviousDateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PreviousDateList.SelectedItems.Count == 1)
            {
                string dir = PreviousDateList.SelectedItems[0].ToString();
                DateTime test;
                if (DateTime.TryParseExact(dir.TrimEnd('h'), "dd MMM HH", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out test))
                {
                    dir = test.ToString("yyyyMMddHH", System.Globalization.CultureInfo.InvariantCulture);
                }

                // TODO: actual load other data
                //World.Default.Structure.LoadPreviousDictionary(dir,
                //    World.Default.Villages, World.Default.Players, World.Default.Tribes);
            }
        }
        #endregion

        #region Workers
        /// <summary>
        /// Occurs when the previous world data loading is completed
        /// </summary>
        private void EventPublisher_Monitor(object sender, EventArgs e)
        {
            // TODO: Use an Invoke mechanism instead of doing all the ifs...
            ClearPreviousDateList();
            string[] dirs = System.IO.Directory.GetDirectories(World.Default.Structure.CurrentWorldDataDirectory);
            var dirsList = new List<string>(dirs);
            dirsList.Reverse();
            foreach (string dir in dirsList)
            {
                var info = new System.IO.DirectoryInfo(dir);
                AddPreviousDateItem(info.Name);
            }
            SetPreviousDateEnablement(true);

            DateTime? date = World.Default.CurrentData;
            if (date.HasValue)
            {
                SetCurrentDateText(date.Value.ToString("dd MMM HH", System.Globalization.CultureInfo.InvariantCulture) + 'h');
            }

            date = World.Default.PreviousData;
            if (date.HasValue)
            {
                SetPreviousDateText(date.Value.ToString("dd MMM HH", System.Globalization.CultureInfo.InvariantCulture) + 'h');
            }
        }

        // Delegates for updating the interface from another thread
        private delegate void SetDelegate();
        private delegate void SetStringDelegate(string value);
        private delegate void SetBooleanDelegate(bool value);

        /// <summary>
        /// Sets the current date text
        /// </summary>
        private void SetCurrentDateText(string value)
        {
            if (!CurrentDate.InvokeRequired)
                CurrentDate.Text = value;
            else
                Invoke(new SetStringDelegate(SetCurrentDateText), value);
        }

        /// <summary>
        /// Sets the previous date text
        /// </summary>
        private void SetPreviousDateText(string value)
        {
            if (!PreviousDate.InvokeRequired)
                PreviousDate.Text = value;
            else
                Invoke(new SetStringDelegate(SetPreviousDateText), value);
        }

        /// <summary>
        /// Sets the enablement of the previous date list
        /// </summary>
        private void SetPreviousDateEnablement(bool value)
        {
            if (!PreviousDateList.InvokeRequired)
                PreviousDateList.Enabled = value;
            else
                Invoke(new SetBooleanDelegate(SetPreviousDateEnablement), value);
        }

        /// <summary>
        /// Adds a date item to the PreviousDateList
        /// </summary>
        /// <param name="item">The date</param>
        private void AddPreviousDateItem(string item)
        {
            if (!PreviousDateList.InvokeRequired)
            {
                DateTime test;
                if (DateTime.TryParseExact(item, "yyyyMMddHH", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out test))
                {
                    PreviousDateList.Items.Add(test.ToString("dd MMM HH", System.Globalization.CultureInfo.InvariantCulture) + 'h');
                }
                else
                {
                    PreviousDateList.Items.Add(item);
                }
            }
            else
                Invoke(new SetStringDelegate(AddPreviousDateItem), item);
        }

        /// <summary>
        /// Clears the previous dates list
        /// </summary>
        private void ClearPreviousDateList()
        {
            if (!InvokeRequired)
                PreviousDateList.Items.Clear();
            else
                Invoke(new SetDelegate(ClearPreviousDateList));
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Create the options for the provided keyword
        /// </summary>
        /// <param name="tag">The search criteria to create description</param>
        private FinderOptions CreateOption(string tag)
        {
            var options = new FinderOptions();
            // TODO: always evaluate custom filter (and remove custom filter)
            options.Evaluate = FinderOptions.FinderLocationEnum.ActiveRectangle;

            switch (tag)
            {
                case "VillageNewInactive":
                    options.SearchFor = SearchForEnum.Villages;
                    options.Options = FinderOptions.FinderOptionsEnum.NewInactives;
                    break;
                case "VillageLostPoints":
                    options.SearchFor = SearchForEnum.Villages;
                    options.Options = FinderOptions.FinderOptionsEnum.LostPoints;
                    break;
                case "PlayerNobled":
                    options.SearchFor = SearchForEnum.Villages;
                    options.Options = FinderOptions.FinderOptionsEnum.Nobled;
                    break;
                case "PlayerNoActivity":
                    options.SearchFor = SearchForEnum.Players;
                    options.Options = FinderOptions.FinderOptionsEnum.Inactives;
                    break;
                case "PlayerTribeChange":
                    options.SearchFor = SearchForEnum.Players;
                    options.Options = FinderOptions.FinderOptionsEnum.TribeChange;
                    break;
                case "TribeNobled":
                    options.SearchFor = SearchForEnum.Villages;
                    options.Evaluate = FinderOptions.FinderLocationEnum.EntireMap;
                    if (World.Default.You != null && World.Default.You.Player.HasTribe)
                    {
                        options.Tribe = World.Default.You.Player.Tribe;
                    }
                    options.Options = FinderOptions.FinderOptionsEnum.Nobled;
                    break;
                case "TribeNoActivity":
                    options.Evaluate = FinderOptions.FinderLocationEnum.EntireMap;
                    options.SearchFor = SearchForEnum.Players;
                    if (World.Default.You != null && World.Default.You.Player.HasTribe)
                    {
                        options.Tribe = World.Default.You.Player.Tribe;
                    }
                    options.Options = FinderOptions.FinderOptionsEnum.Inactives;
                    break;
                case "TribeLostPoints":
                    options.Evaluate = FinderOptions.FinderLocationEnum.EntireMap;
                    options.SearchFor = SearchForEnum.Players;
                    if (World.Default.You != null && World.Default.You.Player.HasTribe)
                        options.Tribe = World.Default.You.Player.Tribe;
                    options.Options = FinderOptions.FinderOptionsEnum.LostPoints;
                    break;
                case "TribePlayers":
                    options.Evaluate = FinderOptions.FinderLocationEnum.EntireMap;
                    options.SearchFor = SearchForEnum.Players;
                    if (World.Default.You != null && World.Default.You.Player.HasTribe)
                        options.Tribe = World.Default.You.Player.Tribe;
                    options.Options = FinderOptions.FinderOptionsEnum.All;
                    break;
                case "Filter":
                    options = AdditionalFilters.LoadFinderOptions();
                    break;
            }

            return options;
        }
        #endregion 
    }
}
