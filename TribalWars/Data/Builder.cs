#region Using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using System.IO;
using System.Xml;
using TribalWars.Data.Maps.Manipulators.Managers;
using TribalWars.Data.Maps;
using TribalWars.Data.Maps.Views;
using TribalWars.Data.Maps.Markers;
using TribalWars.Data.Monitoring;
using TribalWars.Data.Players;
using TribalWars.Data.Buildings;
using TribalWars.Data.Units;
using TribalWars.Data.Tribes;
using TribalWars.Tools;
using System.Globalization;
using TribalWars.Data.Maps.Displays;
using TribalWars.WorldTemplate;

#endregion

namespace TribalWars.Data
{
    /// <summary>
    /// Creates a whole bunch of classes from XML files
    /// </summary>
    public static class Builder
    {
        #region Setting Files
        /// <summary>
        /// Builds the classes from a sets file 
        /// </summary>
        public static DisplaySettings ReadSettings(FileInfo file, Map map, Monitor monitor)
        {
            Debug.Assert(file.Exists);
            
            var sets = new XmlReaderSettings();
            sets.IgnoreWhitespace = true;
            sets.CloseInput = true;
            using (XmlReader r = XmlReader.Create(File.Open(file.FullName, FileMode.Open, FileAccess.Read), sets))
            {
                r.ReadStartElement();
                //DateTime date = XmlConvert.ToDateTime(r.GetAttribute("Date"));

                // You
                string youString = r.GetAttribute("Name");
                r.ReadStartElement();
                Player ply = World.Default.GetPlayer(youString);
                if (ply != null)
                {
                    World.Default.You = ply;
                }
                else
                {
                    World.Default.You = new Player();
                }

                map.MarkerManager.YourMarker = ReadMarker(r, map);
                Debug.Assert(map.MarkerManager.YourMarker.Settings.Name == Marker.DefaultNames.You);
                map.MarkerManager.YourTribeMarker = ReadMarker(r, map);
                Debug.Assert(map.MarkerManager.YourTribeMarker.Settings.Name == Marker.DefaultNames.YourTribe);
                map.MarkerManager.EnemyMarker = ReadMarker(r, map);
                Debug.Assert(map.MarkerManager.EnemyMarker.Settings.Name == Marker.DefaultNames.Enemy);
                map.MarkerManager.AbandonedMarker = ReadMarker(r, map);
                Debug.Assert(map.MarkerManager.AbandonedMarker.Settings.Name == Marker.DefaultNames.Abandoned);
                r.ReadEndElement();

                // Monitor
                monitor.ReadXml(r);

                // MainMap
                r.ReadStartElement();

                // MainMap: Location
                Point? location = World.Default.GetCoordinates(r.GetAttribute("XY"));
                int x = 500;
                int y = 500;
                if (location.HasValue)
                {
                    x = location.Value.X;
                    y = location.Value.Y;
                }
                int z = Convert.ToInt32(r.GetAttribute("Zoom"));
                var displayType = (DisplayTypes)Enum.Parse(typeof(DisplayTypes), r.GetAttribute("Display"), true);
                if (displayType == DisplayTypes.None) displayType = DisplayTypes.Icon;
                map.HomeLocation = new Location(x, y, z);
                map.HomeDisplay = displayType;

                // MainMap: Display
                r.ReadStartElement();
                Color backgroundColor = XmlHelper.GetColor(r.GetAttribute("BackgroundColor"));

                r.ReadStartElement();
                bool continentLines = Convert.ToBoolean(r.ReadElementString("LinesContinent"));
                bool provinceLines = Convert.ToBoolean(r.ReadElementString("LinesProvince"));
                bool hideAbandoned = Convert.ToBoolean(r.ReadElementString("HideAbandoned"));
                bool markedOnly = Convert.ToBoolean(r.ReadElementString("MarkedOnly"));
                r.ReadEndElement();

                var displaySettings = new DisplaySettings(backgroundColor, continentLines, provinceLines, hideAbandoned, markedOnly);

                // MainMap: Markers
                r.ReadStartElement();
                var markers = new List<Marker>();
                while (r.IsStartElement("Marker"))
                {
                    markers.Add(ReadMarker(r, map));
                }
                map.MarkerManager.SetMarkers(markers);

                // MainMap: Manipulators
                r.ReadToFollowing("Manipulator");
                while (r.IsStartElement("Manipulator"))
                {
                    var manipulatorType = (ManipulatorManagerTypes)Enum.Parse(typeof(ManipulatorManagerTypes), r.GetAttribute("Type"));
                    Dictionary<ManipulatorManagerTypes, ManipulatorManagerBase> dict = map.Manipulators.Manipulators;
                    if (dict.ContainsKey(manipulatorType))
                    {
                        dict[manipulatorType].ReadXml(r);
                    }
                    else
                    {
                        r.Skip();
                    }
                }
                r.ReadEndElement();

                // End Main Map
                r.ReadEndElement();

                return displaySettings;
            }
        }

        /// <summary>
        /// Reads a Marker from the XML node
        /// </summary>
        private static Marker ReadMarker(XmlReader r, Map map)
        {
            string name = r.GetAttribute("Name");
            bool enabled = Convert.ToBoolean(r.GetAttribute("Enabled").ToLower());
            Color color = XmlHelper.GetColor(r.GetAttribute("Color"));
            Color extraColor = XmlHelper.GetColor(r.GetAttribute("ExtraColor"));
            string view = r.GetAttribute("View");
            var settings = new MarkerSettings(name, enabled, color, extraColor, view);
            Marker marker = null;

            if (!r.IsEmptyElement)
            {
                r.ReadStartElement();
                while (r.IsStartElement("Marker"))
                {
                    string markerType = r.GetAttribute("Type");
                    string markerName = r.GetAttribute("Name");

                    if (markerType == "Player")
                    {
                        Player ply = World.Default.GetPlayer(markerName);
                        if (ply != null)
                        {
                            marker = new Marker(ply, settings);
                        }
                    }
                    else
                    {
                        Debug.Assert(markerType == "Tribe");
                        Tribe tribe = World.Default.GetTribe(markerName);
                        if (tribe != null)
                        {
                            marker = new Marker(tribe, settings);
                        }
                    }

                    r.Read();
                }
                r.ReadEndElement();
            }
            else
                r.Read();
           
            return marker ?? new Marker(settings);
        }

        /// <summary>
        /// Writes a marker to the XML node
        /// </summary>
        private static void WriteMarker(XmlWriter w, Marker group)
        {
            w.WriteStartElement("Marker");
            w.WriteAttributeString("Name", group.Settings.Name);
            w.WriteAttributeString("Enabled", group.Settings.Enabled.ToString());
            w.WriteAttributeString("Color", XmlHelper.SetColor(group.Settings.Color));
            w.WriteAttributeString("ExtraColor", XmlHelper.SetColor(group.Settings.ExtraColor));
            w.WriteAttributeString("View", group.Settings.View);

            group.WriteXml(w);

            w.WriteEndElement();
        }

        /// <summary>
        /// Write the settings file
        /// </summary>
        public static void WriteSettings(FileInfo file, Map map, Monitor monitor)
        {
            var sets = new XmlWriterSettings();
            sets.Indent = true;
            sets.IndentChars = " ";
            using (XmlWriter w = XmlWriter.Create(file.FullName, sets))
            {
                w.WriteStartElement("Settings");
                w.WriteAttributeString("Date", DateTime.Now.ToLongDateString());

                w.WriteStartElement("You");
                w.WriteAttributeString("Name", World.Default.You != null ? World.Default.You.Name : "");
                WriteMarker(w, map.MarkerManager.YourMarker);
                WriteMarker(w, map.MarkerManager.YourTribeMarker);
                WriteMarker(w, map.MarkerManager.EnemyMarker);
                WriteMarker(w, map.MarkerManager.AbandonedMarker);
                w.WriteEndElement();

                monitor.WriteXml(w);

                w.WriteStartElement("MainMap");
                w.WriteStartElement("Location");
                w.WriteAttributeString("Display", map.Display.Type.ToString());
                w.WriteAttributeString("XY", map.Location.X + "|" + map.Location.Y);
                w.WriteAttributeString("Zoom", map.Location.Zoom.ToString(CultureInfo.InvariantCulture));
                w.WriteEndElement();

                w.WriteStartElement("Display");
                w.WriteAttributeString("BackgroundColor", XmlHelper.SetColor(map.Display.Settings.BackgroundColor));
                w.WriteElementString("LinesContinent", map.Display.Settings.ContinentLines.ToString());
                w.WriteElementString("LinesProvince", map.Display.Settings.ProvinceLines.ToString());
                w.WriteElementString("HideAbandoned", map.Display.Settings.HideAbandoned.ToString());
                w.WriteElementString("MarkedOnly", map.Display.Settings.MarkedOnly.ToString());
                w.WriteEndElement();

                w.WriteStartElement("Markers");
                foreach (Marker group in map.MarkerManager.Markers)
                {
                    WriteMarker(w, group);
                }
                w.WriteEndElement();

                // Manipulators
                w.WriteStartElement("Manipulators");
                foreach (KeyValuePair<ManipulatorManagerTypes, ManipulatorManagerBase> pair in map.Manipulators.Manipulators)
                {
                    w.WriteStartElement("Manipulator");
                    w.WriteAttributeString("Type", pair.Key.ToString());
                    pair.Value.WriteXml(w);
                    w.WriteEndElement();
                }
                w.WriteEndElement();

                // end MainMap
                w.WriteEndElement();

                // end Settings
                w.WriteEndElement();
            }
        }
        #endregion

        #region World Files
        /// <summary>
        /// Reads the world settings
        /// </summary>
        public static void ReadWorld(string worldXmlPath)
        {
            World w = World.Default;
            var info = WorldTemplate.World.LoadFromFile(worldXmlPath);

            w.Server = new Uri(info.Server);
            w.Name = info.Name;
            w.ServerOffset = new TimeSpan(Convert.ToInt32(info.Offset), 0, 0);
            w.Speed = Convert.ToSingle(info.Speed, CultureInfo.InvariantCulture);
            w.UnitSpeed = Convert.ToSingle(info.UnitSpeed, CultureInfo.InvariantCulture);

            w.Structure.DownloadVillage = info.DataVillage;
            w.Structure.DownloadPlayer = info.DataPlayer;
            w.Structure.DownloadTribe = info.DataTribe;

            w.GameLink = info.GameVillage;
            w.GuestPlayerLink = info.GuestPlayer;
            w.GuestTribeLink = info.GuestTribe;

            w.TwStats.Default = new Uri(info.TWStatsGeneral);
            w.TwStats.Village = info.TWStatsVillage;
            w.TwStats.Player = info.TWStatsPlayer;
            w.TwStats.Tribe = info.TWStatsTribe;
            w.TwStats.PlayerGraph = info.TWStatsPlayerGraph;
            w.TwStats.TribeGraph = info.TWStatsTribeGraph;

            w.IconScenery = (IconDrawerFactory.Scenery)Convert.ToInt32(info.WorldDatScenery);

            World.Default.Views.Clear();
            foreach (var view in info.Views)
            {
                ViewBase viewToAdd = CreateView(view.Name, view.Type);
                foreach (var drawer in view.Drawers)
                {
                    viewToAdd.AddDrawer(drawer.Type, drawer.Icon, drawer.BonusIcon, Convert.ToInt32(drawer.Value), drawer.ExtraValue);
                }
                World.Default.Views.Add(viewToAdd.Name, viewToAdd);
            }

            WorldBuildings.Default.SetBuildings(ReadWorldBuildings(info.Buildings));
            WorldUnits.Default.SetBuildings(ReadWorldUnits(info.Units));
        }

        /// <summary>
        /// Creates a view from the XML node
        /// </summary>
        private static ViewBase CreateView(string name, string type)
        {
            switch (type)
            {
                case "Points":
                    return new PointsView(name);
                case "VillageType":
                    return new VillageTypeView(name);
            }

            Debug.Assert(false);
            return null;
        }

        /// <summary>
        /// Loads the buildings from the World.xml stream
        /// </summary>
        private static Dictionary<BuildingTypes, Building> ReadWorldBuildings(IEnumerable<WorldBuildingsBuilding> buildingsIn)
        {
            var buildingsOut = new Dictionary<BuildingTypes, Building>();
            foreach (var building in buildingsIn)
            {
                var build = new Building(building.Name, building.Type, building.Image, building.Points, building.People);
                build.Production = building.Production;
                buildingsOut.Add(build.Type, build);
            }
            return buildingsOut;
        }

        /// <summary>
        /// Loads the units from the World.xml stream
        /// </summary>
        private static Dictionary<UnitTypes, Unit> ReadWorldUnits(IEnumerable<WorldUnitsUnit> unitsIn)
        {
            var  unitsOut = new Dictionary<UnitTypes, Unit>();
            foreach (var unit in unitsIn)
            {
                int carry = Convert.ToInt32(unit.Carry);
                float speed = Convert.ToSingle(unit.Speed, CultureInfo.InvariantCulture);

                bool farmer = Convert.ToBoolean(unit.Farmer);
                bool hideAttacker = Convert.ToBoolean(unit.HideAttacker);
                bool offense = Convert.ToBoolean(unit.Offense);

                int people = Convert.ToInt32(unit.CostPeople);
                int wood = Convert.ToInt32(unit.CostWood);
                int clay = Convert.ToInt32(unit.CostClay);
                int iron = Convert.ToInt32(unit.CostIron);

                var u = new Unit(Convert.ToInt32(unit.Position), unit.Name, unit.Short, unit.Type, carry, farmer, hideAttacker, wood, clay, iron, people, speed, offense);

                unitsOut.Add(u.Type, u);
            }
            return unitsOut;
        }
        #endregion
    }
}
