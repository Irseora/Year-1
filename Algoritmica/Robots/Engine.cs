using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public static class Engine
    {
        public static PointF[] PoligonRegulat(PointF mapLocation, float radius, int nrPoints, float rotAngle)
        {
            // Unghiul de structura => arcele cercului => distanta dintre puncte
            float alpha = (float)(Math.PI * 2) / nrPoints;

            PointF[] toReturn = new PointF[nrPoints];

            for (int i = 0; i < nrPoints; i++)
            {
                // Coordonate polare
                float x = mapLocation.X + radius * (float)Math.Cos(i * alpha + rotAngle);
                float y = mapLocation.Y + radius * (float)Math.Sin(i * alpha + rotAngle);

                toReturn[i] = new PointF(x, y);
            }

            return toReturn;
        }
    }
}
