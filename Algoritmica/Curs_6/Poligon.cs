using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs6
{
    public class Poligon
    {
        public PointF[] points;

        public int length { get { return points.Length; } }

        public static Random rnd = new Random();

        /// <summary>
        /// Constructor from file
        /// </summary>
        /// <param name="fileName">List of points</param>
        public Poligon(string fileName)
        {
            List<string> lines = new List<string>();

            using (TextReader reader = new StreamReader(fileName)) 
            {
                string buffer;

                while ((buffer  = reader.ReadLine()) != null)
                    lines.Add(buffer);
            }

            points = new PointF[lines.Count];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(float.Parse(lines[i].Split(' ')[0]), float.Parse(lines[i].Split(' ')[1]));
            }
        }

        public Poligon(int dim, int maxX, int maxY)
        {
            points = new PointF[dim];

            for (int i = 0; i < dim; i++)
                points[i] = new PointF(rnd.Next(maxX), rnd.Next(maxY));
        }

        public Poligon(int dim)
        {
            points = new PointF[dim];
        }

        // ---------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Matrix PoligonToMatrix()
        {
            Matrix toRet = new Matrix(length);

            for (int i = 0; i < length; i++)
            {
                toRet.mat[0, i] = (int)points[i].X;
                toRet.mat[1, i] = (int)points[i].Y;
            }

            return toRet;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawPolygon(Pens.Black, points);
        }

        public float Perimetru()
        {
            float perimetru = 0;

            // for (int i = 0; i < points.Length - 1; i++)
            //      perimetru += MyMath.Distanta(points[i], points[i + 1]);
            // perimetru += MyMath.Distanta(points[0], points[points.Length - 1]);

            for (int i = 0; i < points.Length; i++)
                perimetru += MyMath.Distanta(points[i], points[(i + 1) % points.Length]);

            return perimetru;
        }

        public PointF CentruGreutate()
        {
            float gX = 0, gY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                gX += points[i].X;
                gY += points[i].Y;
            }

            return new PointF(gX / points.Length, gY / points.Length);
        }

        public float Arie()
        {
            float arie = 0;

            for (int i = 0; i < points.Length; i++)
            {
                arie += points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X;
                arie *= 0.5f;
            }

            return arie;
        }
    }
}
