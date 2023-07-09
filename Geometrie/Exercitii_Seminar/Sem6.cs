using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercitii_Seminar
{
    public partial class Sem6 : Form
    {
        int choice = 0;
        bool allowDraw = false;

        // Pens
        Pen pBlack = new Pen(Color.Black, 2);
        Pen pGreen = new Pen(Color.Green, 2);
        SolidBrush sbBlack = new SolidBrush(Color.Black);
        SolidBrush sbWhite = new SolidBrush(Color.White);
        Font font = new Font(FontFamily.GenericMonospace, 15);

        // Latura reprezentata prin 2 puncte
        struct Line
        {
            public PointF a, b;
        }

        // Graphics
        public Graphics g;
        public Bitmap bmp;

        // Punctele multimii / poligonului
        List<PointF> puncte = new List<PointF>();
        int nrPuncte = 0;

        public Sem6()
        {
            InitializeComponent();
        }

        private void Sem6_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pctBoxRezolvare.Width, pctBoxRezolvare.Height);
            g = Graphics.FromImage(bmp);
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Triangularea unei multimi finite de puncte din plan.\nDesenati o multime de puncte.";
            choice = 1;

            // Clear point list
            nrPuncte = 0;
            puncte.Clear();

            // Clear picture box
            g.Clear(DefaultBackColor);
            pctBoxRezolvare.Image = bmp;

            allowDraw = true;
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Triangularea unui poligon convex.\nDesenati un poligon convex.";
            choice = 2;

            // Clear point list
            nrPuncte = 0;
            puncte.Clear();

            // Clear picture box
            g.Clear(DefaultBackColor);
            pctBoxRezolvare.Image = bmp;

            allowDraw = true;
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

        /// <summary>
        /// Calculeaza lungimea unui segment
        /// </summary>
        /// <param name="segment">Segmentul</param>
        /// <returns>Lungimea segmentului</returns>
        private double Length(Line segment)
        {
            return Math.Sqrt((segment.b.X - segment.a.X) * (segment.b.X - segment.a.X) + (segment.b.Y - segment.a.Y) * (segment.b.Y - segment.a.Y));
        }

        /// <summary>
        /// Sorteaza o lista de segmente dupa lungimea lor
        /// </summary>
        /// <param name="segmente">Lista de segmente</param>
        /// <returns>Lista de segmente ordonata</returns>
        private List<Line> Sort(List<Line> segmente)
        {
            for (int i = 0; i < segmente.Count - 1; i++)
                for (int j = i + 1; j < segmente.Count; j++)
                    if (Length(segmente[i]) > Length(segmente[j]))
                    {
                        Line aux = segmente[i];
                        segmente[i] = segmente[j];
                        segmente[j] = aux;
                    }

            return segmente;
        }

        /// <summary>
        /// Triangularea unei multimi finite de puncte din plan, print-un algoritm Greedy.
        /// </summary>
        private void TriangulareMultime()
        {
            // Genereaza toate segmentele posibile
            List<Line> toateSegPosibile = new List<Line>();
            for (int i = 0; i < nrPuncte; i++)
                for (int j = i + 1; j < nrPuncte; j++)
                    toateSegPosibile.Add(new Line { a = puncte[i], b = puncte[j] });

            // Ordoneaza crescator lista tuturor segmentelor posibile dupa lungime
            toateSegPosibile = Sort(toateSegPosibile);

            // Adauga consecutiv in triangulare segmentele
            List<Line> triangulare = new List<Line>();
            for (int i = 0; i < toateSegPosibile.Count; i++)
            {
                if (triangulare.Count == 0)
                    triangulare.Add(toateSegPosibile[i]);
                else
                {
                    bool adauga = true;

                    // Daca segmentul nu intersecteaza segmentele anterior adaugate
                    for (int j = 0; j < triangulare.Count; j++)
                    {
                        if (Intersect(toateSegPosibile[i], triangulare[j]))
                            adauga = false;
                    }

                    if (adauga == true)
                        triangulare.Add(toateSegPosibile[i]);
                }
            }

            // Deseneaza triangularea
            for (int i = 0; i < triangulare.Count; i++)
            {
                g.DrawLine(pGreen, triangulare[i].a, triangulare[i].b);
            }
        }

        /// <summary>
        /// Triangularea unui poligon convex
        /// </summary>
        private void TriangularePoligonConvex()
        {
            for (int i = 2; i < nrPuncte - 1; i++)
                g.DrawLine(pGreen, puncte[0], puncte[i]);

            // Refresh picture box
            pctBoxRezolvare.Image = bmp;
        }

        /// <summary>
        /// Deseneaza poligonul / multimea de puncte
        /// </summary>
        private void pctBoxRezolvare_Click(object sender, EventArgs e)
        {
            if (allowDraw)
            {
                // Cast to MouseEvent
                MouseEventArgs me = (MouseEventArgs)e;

                // Get mouse location
                PointF current = me.Location;

                // Add point to list
                nrPuncte++;
                puncte.Add(current);

                // Draw point & number
                g.FillEllipse(sbBlack, current.X, current.Y, 20, 20);
                g.DrawString(nrPuncte.ToString(), font, sbWhite, current.X, current.Y);

                // If drawing a polygon, unite points starting from point 2
                if (nrPuncte > 1 && choice == 2)
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
            if (choice == 2)
            {
                g.DrawLine(pBlack, puncte[nrPuncte - 1], puncte[0]);
                pctBoxRezolvare.Image = bmp;
            }
      
            allowDraw = false;

            if (choice == 1) TriangulareMultime();
            else if (choice == 2) TriangularePoligonConvex();
        }
    }
}
