using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Explorer : Robot
    {
        // Apeleaza constructorul din clasa de baza
        public Explorer() : base() { }

        // ---------------------------------------------

        public override void Draw(Graphics handler)
        {
            int size = 7;

            handler.FillEllipse(Brushes.DarkGray, mapLocation.X - size, mapLocation.Y - size, 2 * size + 1, 2 * size + 1);
            handler.DrawEllipse(Pens.Black, mapLocation.X - size, mapLocation.Y - size, 2 * size + 1, 2 * size + 1);

            handler.FillEllipse(Brushes.Yellow, mapLocation.X - size, mapLocation.Y - size, 5, 5);
        }
    }
}
