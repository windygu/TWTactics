#region Using
using System;
using System.Collections.Generic;
using TribalWars.Browsers.Reporting;
using TribalWars.Maps.Manipulators.Helpers;
using TribalWars.Villages;
using TribalWars.Worlds.Events;
using TribalWars.Worlds.Events.Impls;

#endregion

namespace TribalWars.Maps
{
    /// <summary>
    /// Raises events for a specific map
    /// </summary>
    public class Publisher
    {
        #region Fields
        private readonly Map _map;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the map the events get raised for
        /// </summary>
        public Map Map
        {
            get { return _map; }
        }
        #endregion

        #region Events
        public event EventHandler<VillagesEventArgs> VillagesSelected;
        public event EventHandler<PlayerEventArgs> PlayerSelected;
        public event EventHandler<TribeEventArgs> TribeSelected;
        public event EventHandler<ReportEventArgs> ReportSelected;

        public event EventHandler<PolygonEventArgs> PolygonActivated;

        public event EventHandler<MapLocationEventArgs> LocationChanged;
        public event EventHandler<MapDisplayTypeEventArgs> DisplayTypeChanged;
        public event EventHandler<ManipulatorEventArgs> ManipulatorChanged;
        #endregion

        #region Constructors
        public Publisher(Map map)
        {
            _map = map;
        }
        #endregion

        #region Publish Methods
        #region Selection Events
        /// <summary>
        /// Publishes an event for several villages
        /// </summary>
        public void SelectVillages(object sender, IEnumerable<Village> vil, VillageTools action)
        {
            if (VillagesSelected != null)
            {
                VillagesSelected(sender, new VillagesEventArgs(vil, action));
            }
        }

        /// <summary>
        /// Publishes an event for one village
        /// </summary>
        public void SelectVillages(object sender, Village village, VillageCommand action)
        {
            if (VillagesSelected != null)
                VillagesSelected(sender, new VillagesEventArgs(village, action));
        }

        /// <summary>
        /// Publishes an event for the villages of one player
        /// </summary>
        public void SelectVillages(object sender, Player ply, VillageTools action)
        {
            if (ply != null)
                VillagesSelected(sender, new PlayerEventArgs(ply, action));
        }

        /// <summary>
        /// Publishes an event for all the villages in one tribe
        /// </summary>
        public void SelectVillages(object sender, Tribe tribe, VillageTools action)
        {
            if (tribe != null)
                VillagesSelected(sender, new TribeEventArgs(tribe, action));
        }

        /// <summary>
        /// Publishes an event without linked village(s)
        /// </summary>
        /// <remarks>Used to remove the pinpoint</remarks>
        public void SelectVillages(object sender, VillageTools villageTools)
        {
            if (VillagesSelected != null)
            {
                VillagesSelected(sender, new VillagesEventArgs(null, villageTools));
            }
        }

        /// <summary>
        /// Publishes an event for one tribe
        /// </summary>
        public void SelectTribe(object sender, Tribe tribe, VillageTools tool)
        {
            if (TribeSelected != null)
            {
                TribeSelected(sender, new TribeEventArgs(tribe, tool));
            }
        }

        /// <summary>
        /// Publishes an event for one player
        /// </summary>
        public void SelectPlayer(object sender, Player player, VillageTools tool)
        {
            if (PlayerSelected != null)
            {
                PlayerSelected(sender, new PlayerEventArgs(player, tool));
            }
        }

        /// <summary>
        /// Publishes an event for a report
        /// </summary>
        public void SelectReport(object sender, Report report)
        {
            if (ReportSelected != null)
            {
                ReportSelected(sender, new ReportEventArgs(report));
            }
        }
        #endregion

        #region Action Events
        /// <summary>
        /// Publishes a map location change
        /// </summary>
        internal void SetMapCenter(object sender, MapLocationEventArgs e)
        {
            // TODO: this one can't be called directly
            // instead use map.SetCenter()
            if (LocationChanged != null)
                LocationChanged(sender, e);
        }

        /// <summary>
        /// Publishes a change in DisplayType
        /// </summary>
        internal void SetDisplayType(Map sender, MapDisplayTypeEventArgs e)
        {
            if (DisplayTypeChanged != null)
                DisplayTypeChanged(sender, e);
        }

        /// <summary>
        /// Change the active map manipulator
        /// </summary>
        public void ChangeManipulator(object sender, ManipulatorEventArgs e)
        {
            if (ManipulatorChanged != null)
                ManipulatorChanged(sender, e);
        }

        /// <summary>
        /// Ship villages to the Polygon control
        /// </summary>
        public void ActivatePolygon(object sender, IEnumerable<Polygon> polygons)
        {
            if (PolygonActivated != null)
                PolygonActivated(sender, new PolygonEventArgs(polygons));
        }
        #endregion
        #endregion
    }
}