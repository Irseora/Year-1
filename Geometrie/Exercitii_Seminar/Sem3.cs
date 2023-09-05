using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Exercitii_Seminar
{
    public partial class Sem3 : Form
    {
        int choice = 0;

        public Sem3()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de 2*n puncte in plan.\nSa se uneasca 2 cate 2, astfel incat suma lungimilor segmentelor obtinute sa fie minima.\n(Problema de cuplaj)";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime S de segmente de drepte inchise.\nSe cere sa se determine toate intersectiile dintre segmentele din S.";
            choice = 2;
            pctBoxRezolvare.Invalidate();
        }

        private void pctBoxRezolvare_Paint(object sender, PaintEventArgs e)
        {
            // Init
            Graphics g = e.Graphics;
            Random rnd = new Random();
            int width = pctBoxRezolvare.Width;
            int height = pctBoxRezolvare.Height;

            if (choice == 1) SumLungimiMin(g, rnd, width, height);
            else if (choice == 2) Intersectii(g, rnd, width, height);
        }

        /// <summary>
        /// Uneste 2 cate 2 punctele, astfel incat suma lungimilor sa fie minima
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void SumLungimiMin(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);

            // Init
            int nrPoints = rnd.Next(10, 50);
            float currentL, totalL = 0;
            Point[] points = new Point[nrPoints];

            // Genereaza punctele aleatoriu
            for (int i = 0; i < nrPoints; i++)
            {
                Point current = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                points[i] = current;
                g.DrawEllipse(black, current.X, current.Y, 2, 2);
            }
            
            // Rezolvare
            int prim = 0, secund = 0;
            for (int i = 0; i < nrPoints; i++)
            {
                float minL = float.MaxValue;
                prim = 0;
                secund = 0;

                // Cauta cele mai apropiate 2 puncte
                for (int j = i + 1; j < nrPoints; j++)
                {
                    currentL = (float)Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));

                    if (currentL < minL)
                    {
                        minL = currentL;
                        prim = i;
                        secund = j;
                    }
                }

                // Uneste 2 puncte
                g.DrawLine(black, points[prim].X, points[prim].Y, points[secund].X, points[secund].Y);
                totalL += minL;

                // Sterge punctele deja folosite
                points[prim].X = 0;
                points[prim].Y = 0;
                points[secund].X = 0;
                points[secund].Y = 0;
            }

            // Afiseaza suma lungimilor
            lblRezolvare.Text = totalL.ToString();
        }

        /// <summary>
        /// Determina toate intersectiile segmentelor
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void Intersectii(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);
            Pen green = new Pen(Color.Green, 2);
            Pen blue = new Pen(Color.Blue, 2);

            // Init
            int nrPoints = rnd.Next(10, 50);
            Point[] init = new Point[nrPoints];
            Point[] fin = new Point[nrPoints];

            for (int i = 0; i < nrPoints; i++)
            {
                int x, y;

                x = rnd.Next(10, width - 10);
                y = rnd.Next(10, height - 10);
                init[i] = new Point(x, y);
                g.DrawEllipse(red, x, y, 2, 2);

                x = rnd.Next(10, width - 10);
                y = rnd.Next(10, height - 10);
                fin[i] = new Point(x, y);
                g.DrawEllipse(green, x, y, 2, 2);

                g.DrawLine(black, init[i].X, init[i].Y, fin[i].X, fin[i].Y);
            }

            for (int i = 0; i < nrPoints; i++)
                for (int j = 0; j < nrPoints; j++)
                {
                    float A1, A2, B1, B2, C1, C2, fraction;

                    A1 = fin[i].Y - init[i].Y;
                    B1 = init[i].X - fin[i].X;
                    C1 = A1 * init[i].X + B1 * init[i].Y;

                    A2 = fin[j].Y - init[j].Y;
                    B2 = init[j].X - fin[j].X;
                    C2 = A2 * init[j].X + B2 * init[j].Y;

                    fraction = A1 * B2 - A2 * B1;

                    if (fraction != 0)
                    {
                        float intersectX = (B2 * C1 - B1 * C2) / fraction;
                        float intersectY = (A1 * C2 - A2 * C1) / fraction;

                        float rx1, rx2, ry1, ry2;
                        rx1 = (intersectX - init[i].X) / (fin[i].X - init[i].X);
                        rx2 = (intersectX - init[j].X) / (fin[j].X - init[j].X);
                        ry1 = (intersectY - init[i].Y) / (fin[i].Y - init[i].Y);
                        ry2 = (intersectY - init[j].Y) / (fin[j].Y - init[j].Y);

                        if (((rx1 >= 0 && rx1 <= 1) || (ry1 >= 0 && ry1 <= 1)) &&
                            ((rx2 >= 0 && rx2 <= 1) || (ry2 >= 0 && ry2 <= 1)))
                            g.DrawEllipse(blue, intersectX, intersectY, 3, 3);
                    }
                }
        }

        private void Sem3_Load(object sender, EventArgs e)
        {

        }
    }
}
