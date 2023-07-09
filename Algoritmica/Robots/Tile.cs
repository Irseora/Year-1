using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Tile
    {
        int crystal = 0, processedCrystal = 0, fog = 0;

        public PointF mapLocation;

        // ---------------------------------------------

        public Tile (int crystal, PointF mapLocation) { this.crystal = crystal; this.mapLocation = mapLocation; }

        /// <summary>
        /// Draw tile
        /// </summary>
        /// <param name="handler">Graphics</param>
        public void Draw(Graphics handler)
        {
            int deltaX = 20, deltaY = 20;

            handler.FillRectangle(Brushes.ForestGreen, mapLocation.X * deltaX, mapLocation.Y * deltaY, deltaX, deltaY);
            handler.DrawRectangle(Pens.Black, mapLocation.X * deltaX, mapLocation.Y * deltaY, deltaX, deltaY);
        }
    }
}
