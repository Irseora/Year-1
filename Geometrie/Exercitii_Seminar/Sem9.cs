using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exercitii_Seminar
{
    public partial class Sem9 : Form
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

        List<Line> diagonale = new List<Line>();
        List<Point> puncteSortate = new List<Point>();
        List<Poligon> poligoane = new List<Poligon>();

        public Sem9()
        {
            InitializeComponent();
        }

        private void Sem9_Load(object sender, EventArgs e)
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

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Partiționarea unui poligon simplu în poligoane monotone, prin identificarea vârfurilor de întoarcere și unirea acestora prin diagonale cu vârfurile corespunzătoare.";

            // Clear point list
            nrPuncte = 0;
            puncte.Clear();

            // Clear picture box
            g.Clear(DefaultBackColor);
            pctBoxRezolvare.Image = bmp;

            allowDraw = true;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Deseneaza ultima latura a pligonului
            g.DrawLine(pBlack, puncte[nrPuncte - 1], puncte[0]);
            pctBoxRezolvare.Image = bmp;

            allowDraw = false;

            Rezolvare();
        }

        public int Determinant(Point A, Point B, Point C)
        {
            int det = A.X * B.Y + B.X * C.Y + A.Y * C.X - B.Y * C.X - C.Y * A.X - B.X * A.Y;
            if (det > 0) return 1;
            if (det < 0) return -1;
            return 0;
        }

        private void Rezolvare()
        {
            poligoane.Add(new Poligon(puncte));

            puncteSortate.AddRange(puncte);
            puncteSortate.Sort(Compare);

            List<Line> exterior = new List<Line>();

            for (int i = 0; i < puncte.Count - 1; i++)
                exterior.Add(new Line(puncte[i], puncte[i + 1]));
            exterior.Add(new Line(puncte[puncte.Count - 1], puncte[0]));

            for (int i = 0; i < puncte.Count; i++)
            {
                int prev = (i - 1 + puncte.Count) % puncte.Count;
                int current = i;
                int next = (i + 1) % puncte.Count;

                bool reflexiv = Determinant(puncte[prev], puncte[current], puncte[next]) < 0;
                if (reflexiv) 
                {
                    int prevSort = puncteSortate.IndexOf(puncte[prev]);
                    int currentSort = puncteSortate.IndexOf(puncte[current]);
                    int nextSort = puncteSortate.IndexOf(puncte[next]);

                    int index = 0, increment = 0;

                    if (prevSort < currentSort && nextSort < currentSort)
                    {
                        index = currentSort + 1;
                        increment = 1;
                    }

                    if (prevSort > currentSort && nextSort > currentSort)
                    {
                        index = currentSort - 1;
                        increment = -1;
                    }

                    if (increment == 0) continue;

                    for (int j = index; j < puncteSortate.Count && j >= 0; j += increment)
                    {
                        Line temp = new Line(puncteSortate[currentSort], puncteSortate[j]);
                        bool ok = true;

                        foreach (Line diag in diagonale)
                            if (diag.B == temp.B && diag.A == temp.A)
                            {
                                ok = false;
                                break;
                            }
                        if (!ok) continue;
                        if (!Intersect(temp, exterior)) continue;
                        if (!Intersect(temp, diagonale)) continue;

                        if (Determinant(puncte[prev], puncte[current], puncte[next]) > 0)
                        {
                            bool stanga1 = Det(puncte[current], puncteSortate[j], puncte[next]) < 0;
                            bool stanga2 = Det(puncte[current], puncte[prev], puncteSortate[j]) < 0;
                            ok = stanga1 && stanga2;
                        }
                        else
                        {
                            bool dreapta1 = Det(puncte[current], puncteSortate[j], puncte[next]) > 0;
                            bool dreapta2 = Det(puncte[current], puncte[prev], puncteSortate[j]) > 0;
                            ok = !(dreapta1 && dreapta2);
                        }

                        if (!ok) continue;

                        diagonale.Add(temp);
                        g.DrawLine(pBlack, temp.A, temp.B);
                        break;
                    }
                }
            }

            pctBoxRezolvare.Image = bmp;
        }

        public bool Intersecteaza(Line prim, Line secund)
        {
            int det1 = Det(prim.A, prim.B, secund.B);
            int det2 = Det(prim.A, prim.B, secund.A);
            int det3 = Det(secund.A, secund.B, prim.B);
            int det4 = Det(secund.A, secund.B, prim.A);

            return (det1 * det2 < 0) && (det3 * det4 < 0);
        }

        public bool Intersect(Line l, List<Line> exterior)
        {
            foreach (Line linie in exterior)
                if (Intersecteaza(linie, l)) return false;
            return true;
        }

        private static int Compare(Point A, Point B)
        {
            if (A.Y < B.Y) return -1;
            if (A.Y > B.Y) return 1;
            if (A.X < B.X) return -1;
            if (A.X > B.X) return 1;

            return 0;
        }
    }
}
