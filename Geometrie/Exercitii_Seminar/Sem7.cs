using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercitii_Seminar
{
    public partial class Sem7 : Form
    {
        public Sem7()
        {
            InitializeComponent();
        }

        struct Line
        {
            public Point a, b;
            // TODO: public Latura(Point p, Point q) { this.p = p; this.q = q; }
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Partiționarea unui poligon simplu cu n>3 vârfuri în triunghiuri (triangularea) folosind diagonalele.";
            pctBoxRezolvare.Invalidate();
        }

        private void TriangulareDiagonale(Graphics g, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);

            // Init
            Random rnd = new Random();
            int nrPuncte = rnd.Next(100);
            Point[] puncte = new Point[nrPuncte];

            // Deseneaza punctele aleatorii
            for (int i = 0; i < nrPuncte; i++)
            {
                puncte[i] = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(black, puncte[i].X, puncte[i].Y, 2, 2);
            }

            int nrDiagonale = 0;
            List<Line> diagonale = new List<Line>();

            for (int i = 0; i < nrPuncte - 3; i++)
            {
                for (int j = i+2; j < nrPuncte-1; j++)
                {
                    if (i == 0 && j == nrPuncte - 1)
                        break;

                    // nu intersecteaza nicio latura neincidenta
                    // nu intersecteaza anterioarele
                    // e in interiorul poligonului
                    

                    Line temp = new Line();
                    temp.a = puncte[i];
                    temp.b = puncte[j];
                    diagonale.Add(temp);

                    if (nrDiagonale == nrPuncte - 3)
                        return;
                }
            }
        }

        private void pctBoxRezolvare_Paint(object sender, PaintEventArgs e)
        {
            // Init
            Graphics g = e.Graphics;
            Random rnd = new Random();
            int width = pctBoxRezolvare.Width;
            int height = pctBoxRezolvare.Height;

            TriangulareDiagonale(g, width, height);
        }

        /// <summary>
        /// Determina daca 2 segmente se intersecteaza
        /// </summary>
        /// <param name="seg1">Primul segment</param>
        /// <param name="seg2">Al doilea segment</param>
        /// <returns>Adevarat - daca cele 2 segmente se intersecteaza; Fals - altfel</returns>
        private bool Intersect(Line seg1, Line seg2)
        {
            // [p2, p1, s1] x [p2, p1, s2] < 0 && [s2, s1, p1] x [s2, s1, p2] < 0

            float det1 = seg1.b.X * seg1.a.Y + seg1.a.X * seg2.a.Y + seg2.a.X * seg1.b.Y
                        - seg2.a.X * seg1.a.Y - seg1.b.X * seg2.a.Y - seg1.a.X * seg1.b.Y;

            float det2 = seg1.b.X * seg1.a.Y + seg1.a.X * seg2.b.Y + seg2.b.X * seg1.b.Y
                        - seg2.b.X * seg1.a.Y - seg1.b.X * seg2.b.Y - seg1.a.X * seg1.b.Y;

            float det3 = seg2.b.X * seg2.a.Y + seg2.a.X * seg1.a.Y + seg1.a.X * seg2.b.Y
                        - seg1.a.X * seg2.a.Y - seg2.b.X * seg1.a.Y - seg2.a.X * seg2.b.Y;

            float det4 = seg2.b.X * seg2.a.X + seg2.a.X * seg1.b.Y + seg1.b.X * seg2.b.Y
                        - seg1.b.X * seg2.a.Y - seg2.b.X * seg1.b.Y - seg2.a.X * seg2.b.Y;

            if (det1 * det2 < 0 && det3 * det4 < 0)
                return true;

            return false;
        }

        private void Sem7_Load(object sender, EventArgs e)
        {

        }
    }
}
