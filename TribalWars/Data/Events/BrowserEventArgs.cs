#region Using
using System;
using System.Collections.Generic;
using System.Text;
using TribalWars.Controls.Main.Browser;
using TribalWars.Data.Events;
#endregion

namespace TribalWars.Data.Events
{
    /// <summary>
    /// Encapsulates the destination for a web browsing event
    /// </summary>
    public class BrowserEventArgs : EventArgs
    {
        #region Fields
        private bool _gameDestination;
        private DestinationEnum _destination;
        private System.Collections.ObjectModel.ReadOnlyCollection<string> _args;	
        #endregion

        #region Properties
        /// <summary>
        /// Gets the browse destination
        /// </summary>
        public DestinationEnum Destination
        {
            get { return _destination; }
        }

        /// <summary>
        /// Gets the list of arguments
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<string> Arguments
        {
            get { return _args; }
        }

        /// <summary>
        /// Gets a value indicating whether the game browser should
        /// handle the request
        /// </summary>
        public bool GameDestination
        {
            get { return _gameDestination; }
        }
        #endregion

        #region Constructors
        public BrowserEventArgs(DestinationEnum dest, string[] args)
            : base()
        {
            switch (dest)
            {
                case DestinationEnum.TWStatsPlayer:
                case DestinationEnum.TWStatsTribe:
                case DestinationEnum.TWStatsVillage:
                    _gameDestination = false;
                    break;
                default:
                    _gameDestination = true;
                    break;
            }
            _destination = dest;
            _args = new List<string>(args).AsReadOnly();
        }
        #endregion
    }        
}
