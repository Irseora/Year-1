using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercitii_Seminar
{
    public class Line
    {
        public Point A, B;

        public Line(Point A, Point B)
        {
            this.A = A;
            this.B = B;
        }

        public int Det(Point A, Point B, Point C)
        {
            int det = A.X * B.Y + B.X * C.Y + A.Y * C.X - B.Y * C.X - C.Y * A.X - B.X * A.Y;

            if (det > 0) return 1;
            if (det < 0) return -1;
            return 0;
        }
    }
}
