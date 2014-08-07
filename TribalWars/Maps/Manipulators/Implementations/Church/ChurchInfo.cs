﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TribalWars.Villages;

namespace TribalWars.Maps.Manipulators.Implementations.Church
{
    public class ChurchInfo
    {
        private int _churchLevel;

        #region Properties
        /// <summary>
        /// Village with the church change
        /// </summary>
        public Village Village { get; set; }

        public int ChurchLevel
        {
            get { return _churchLevel; }
            set
            {
                _churchLevel = Math.Max(0, Math.Min(3, value));
            }
        }

        public Color Color { get; set; }
        #endregion

        #region Constructors
        public ChurchInfo(Village village, int churchLevel)
        {
            Village = village;
            ChurchLevel = churchLevel;
            Color = Color.Yellow;
        }
        #endregion
    }
}
