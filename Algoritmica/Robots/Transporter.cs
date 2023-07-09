using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Transporter : Robot
    {
        // Apeleaza constructorul din clasa de baza
        public Transporter() : base() { }

        // ---------------------------------------------

        
        public override void Draw(Graphics handler)
        {
            int size = 7;

            handler.FillEllipse(Brushes.MediumSpringGreen, mapLocation.X - size, mapLocation.Y - size, 2 * size + 1, 2 * size + 1);
            handler.DrawEllipse(Pens.DarkGreen, mapLocation.X - size, mapLocation.Y - size, 2 * size + 1, 2 * size + 1);
        }
    }
}
