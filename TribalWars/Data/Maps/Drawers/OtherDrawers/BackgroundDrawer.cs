#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using TribalWars.Data.Maps.Markers;
#endregion

namespace TribalWars.Data.Maps.Drawers
{
    /// <summary>
    /// Draws a bitmap to the map
    /// </summary>
    public class BackgroundDrawer : DrawerBase
    {
        #region Fields
        private Bitmap _bitmap;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the bitmap that will be drawn to the map
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }
        #endregion

        #region Constructors
        public BackgroundDrawer(Bitmap icon)
        {
            _bitmap = icon;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Paints one non-village to the map (mountains, ...)
        /// </summary>
        protected override void PaintVillageCore(Graphics g, int x, int y, int width, int height)
        {
            g.DrawImageUnscaledAndClipped(_bitmap, new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// Dispose of unmanaged resources
        /// </summary>
        public override void Dispose(bool disposing)
        {
            _bitmap.Dispose();
        }
        #endregion
    }
}
