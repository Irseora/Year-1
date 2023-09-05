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
        // Init
        bool allowDraw = false;

        // Pens
        Pen pBlack = new Pen(Color.Black, 2);
        Pen pGreen = new Pen(Color.Green, 2);
        SolidBrush sbBlack = new SolidBrush(Color.Black);
        SolidBrush sbWhite = new SolidBrush(Color.White);
        Font font = new Font(FontFamily.GenericMonospace, 15);

        // Graphics
        public Graphics g;
        public Bitmap bmp;

        List<Point> puncte = new List<Point>();
        int nrPuncte = 0;

        public Sem7()
        {
            InitializeComponent();
        }

        private void Sem7_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pctBoxRezolvare.Width, pctBoxRezolvare.Height);
            g = Graphics.FromImage(bmp);
        }

        public class Line
        {
            public Point A, B;

            public Line(Point a, Point b)
            {
                A = a;
                B = b;
            }
        }

        public int Det(Point A, Point B, Point C)
        {
            int det = A.X * B.Y + B.X * C.Y + A.Y * C.X - B.Y * C.X - C.Y * A.X - B.X * A.Y;
            if (det > 0) return 1;
            if (det < 0) return -1;
            return 0;
        }

        public bool Intersecteaza(Line prim, Line secund)
        {
            int det1 = Det(prim.A, prim.B, secund.B);
            int det2 = Det(prim.A, prim.B, secund.A);
            int det3 = Det(secund.A, secund.B, prim.B);
            int det4 = Det(secund.A, secund.B, prim.A);

            return (det1 * det2 < 0) && (det3 * det4 < 0);
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Partiționarea unui poligon simplu cu n>3 vârfuri în triunghiuri (triangularea) folosind diagonalele.";

            // Clear point list
            nrPuncte = 0;
            puncte.Clear();

            // Clear picture box
            g.Clear(DefaultBackColor);
            pctBoxRezolvare.Image = bmp;

            allowDraw = true;
        }

        private void TriangulareDiagonale()
        {
            List<Line> diagonale = new List<Line>();

            List<Line> inafara = new List<Line>();
            for (int i = 0; i < nrPuncte - 1; i++)
            {
                inafara.Add(new Line(puncte[i], puncte[i + 1]));
                Line temp = new Line(puncte[i], puncte[i + 1]);
                inafara.Add(temp);
            }
            inafara.Add(new Line(puncte[0], puncte[nrPuncte - 1]));
            
            for (int i = 0; i < nrPuncte - 2; i++)
                for (int j = i + 2; j < nrPuncte; j++)
                {
                    if (diagonale.Count == nrPuncte - 3) break;
                    if (i == 0 && j == nrPuncte - 1) break;

                    bool ok = true;
                    Line l = new Line(puncte[i], puncte[j]);
                    foreach (Line latura in inafara)
                        if (Intersecteaza(l, latura))
                        {
                            ok = false;
                            break;
                        }
                    if (!ok) continue;

                    ok = true;
                    foreach (Line latura in diagonale)
                        if (Intersecteaza(l, latura))
                        {
                            ok = false;
                            break;
                        }
                    if (!ok) continue;

                    ok = true;
                    int rez = (i == 0) ? nrPuncte - 1 : i - 1;
                    bool inv = Det(puncte[rez], puncte[i], puncte[i + 1]) > 0;
                    int det1 = Det(puncte[i], puncte[j], puncte[i + 1]);
                    int det2 = Det(puncte[i], puncte[rez], puncte[j]);
                    if (inv)
                        ok = det1 < 0 && det2 < 0;
                    else
                        ok = !(det1 > 0 && det2 > 0);
                    if (!ok) continue;

                    diagonale.Add(l);
                    g.DrawLine(pBlack, l.A, l.B);
                }

            pctBoxRezolvare.Image = bmp;
        }

        /*
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
        }*/

        /// <summary>
        /// Deseneaza poligonul
        /// </summary>
        private void pctBoxRezolvare_Click(object sender, EventArgs e)
        {
            if (allowDraw)
            {
                // Cast to MouseEvent
                MouseEventArgs me = (MouseEventArgs)e;

                // Get mouse location
                Point current = me.Location;

                // Add point to list
                nrPuncte++;
                puncte.Add(current);

                // Draw point & number
                g.FillEllipse(sbBlack, current.X, current.Y, 20, 20);
                g.DrawString(nrPuncte.ToString(), font, sbWhite, current.X, current.Y);

                // Unite points starting from point 2
                if (nrPuncte > 1)
                    g.DrawLine(pBlack, puncte[nrPuncte - 2], puncte[nrPuncte - 1]);

                // Refresh picture box
                pctBoxRezolvare.Image = bmp;
            }
        }

        /// <summary>
        /// Opreste desenarea
        /// </summary>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Deseneaza ultima latura a pligonului
            g.DrawLine(pBlack, puncte[nrPuncte - 1], puncte[0]);
            pctBoxRezolvare.Image = bmp;

            allowDraw = false;

            TriangulareDiagonale();
        }
    }
}
