#region Using
using System.Collections.Generic;
using System.Xml;
using TribalWars.Data.Maps.Manipulators.Helpers.EventArgs;

#endregion

namespace TribalWars.Data.Maps.Manipulators.Managers
{
    /// <summary>
    /// The base class for a manipulator manager
    /// </summary>
    public class ManipulatorManagerBase : ManipulatorBase
    {
        #region Fields
        protected List<ManipulatorBase> _manipulators;
        protected ManipulatorBase _fullControllManipulator;
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether a tooltip should
        /// show up when hovering over a village
        /// </summary>
        public bool ShowTooltip { get; set; }
        #endregion

        #region Constructors
        public ManipulatorManagerBase(Map map)
            : base(map)
        {
            _manipulators = new List<ManipulatorBase>();
            ShowTooltip = true;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gives this manipulator full control of the map, the other manipulators
        /// are the completely ignored
        /// </summary>
        public void SetFullControlManipulator(ManipulatorBase manipulator)
        {
            RemoveFullControlManipulator();
            _fullControllManipulator = manipulator;
            _fullControllManipulator.SetFullControlManipulatorCore();
            _map.Control.GiveFocus();
        }

        /// <summary>
        /// Gives each manipulator the ability to respond to map events again
        /// </summary>
        public void RemoveFullControlManipulator()
        {
            if (_fullControllManipulator != null)
            {
                _fullControllManipulator.RemoveFullControlManipulatorCore();
                _fullControllManipulator = null;
            }
        }
        #endregion

        #region Event Handlers
        public void Initialize()
        {
            _map.SetCursor();
            _map.Control.Invalidate();
        }

        /// <summary>
        /// Saves state to stream
        /// </summary>
        public virtual void WriteXml(XmlWriter w)
        {
            WriteXmlCore(w);
        }

        /// <summary>
        /// Loads state from stream
        /// </summary>
        public virtual void ReadXml(XmlReader r)
        {
            if (r.IsEmptyElement)
            {
                r.Read();
            }
            else
            {
                r.ReadStartElement();
                ReadXmlCore(r);
                r.ReadEndElement();
            }
        }
        #endregion

        #region IMapManipulator Members
        /// <summary>
        /// Informs all the manipulators the user
        /// has clicked the map
        /// </summary>
        protected internal override bool MouseDownCore(MapMouseEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.MouseDownCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.MouseDownCore(e);
                return redraw;
            }
        }

        protected internal override bool MouseUpCore(MapMouseEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.MouseUpCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.MouseUpCore(e);
                return redraw;
            }
        }

        protected internal override bool MouseMoveCore(MapMouseMoveEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.MouseMoveCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.MouseMoveCore(e);
                return redraw;
            }
        }

        protected internal override bool OnVillageDoubleClickCore(MapVillageEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.OnVillageDoubleClickCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.OnVillageDoubleClickCore(e);
                return redraw;
            }
        }

        protected internal override bool OnVillageClickCore(MapVillageEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.OnVillageClickCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.OnVillageClickCore(e);
                return redraw;
            }
        }

        protected internal override bool OnKeyDownCore(MapKeyEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.OnKeyDownCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.OnKeyDownCore(e);
                return redraw;
            }
        }

        protected internal override bool OnKeyUpCore(MapKeyEventArgs e)
        {
            if (_fullControllManipulator != null)
                return _fullControllManipulator.OnKeyUpCore(e);
            else
            {
                bool redraw = false;
                foreach (ManipulatorBase m in _manipulators) redraw |= m.OnKeyUpCore(e);
                return redraw;
            }
        }
        #endregion

        #region IMapDrawer Members
        public override void Paint(MapPaintEventArgs e)
        {
            if (_fullControllManipulator != null && !_manipulators.Contains(_fullControllManipulator))
            {
                _fullControllManipulator.Paint(e);
            }

            foreach (ManipulatorBase manipulator in _manipulators)
                manipulator.Paint(e);
        }

        public override void TimerPaint(MapTimerPaintEventArgs e)
        {
            if (_fullControllManipulator != null && !_manipulators.Contains(_fullControllManipulator))
            {
                _fullControllManipulator.TimerPaint(e);
            }

            foreach (ManipulatorBase manipulator in _manipulators)
                manipulator.TimerPaint(e);
        }

        public override void Dispose()
        {
        }
        #endregion
    }
}