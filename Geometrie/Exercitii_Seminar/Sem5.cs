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
    public partial class Sem5 : Form
    {
        int choice = 0;

        public Sem5()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine invelitoarea convexa a acestei multimi.\nAlgoritmul lui Jarvis.";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine invelitoarea convexa a acestei multimi.\nAlgoritmul de scanare Graham.";
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

            if (choice == 1) ConvexHullJarvis(g, rnd, width, height);
            else if (choice == 2) ConvexHullGraham(g, rnd, width, height);
        }

        /// <summary>
        /// Determina daca punctul r este la stanga dreptei pq
        /// </summary>
        /// <param name="p">Capat al dreptei pq</param>
        /// <param name="q">Capat al dreptei pq</param>
        /// <param name="r">Punctul r</param>
        /// <returns>Adevarat - daca punctul r se afla la stanga dreptei pq, Fals - altfel</returns>
        private bool LaStanga(Point p, Point q, Point r)
        {
            int det = (p.X * q.Y) + (q.X * r.Y) + (r.X * p.Y) - (r.X * q.Y) - (p.X * r.Y) - (q.X * p.Y);
            return det < 0;
        }

        /// <summary>
        /// Determina invelitoarea convexa - algoritmul Jarvis
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void ConvexHullJarvis(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);

            // Init
            int nrPuncte = rnd.Next(3, 100);
            List<Point> puncte = new List<Point>();
            List<Point> convexHull = new List<Point>();
            int leftmost = 0;

            // Deseneaza punctele & determina cel mai din stanga punct
            for (int i = 0; i < nrPuncte; i++)
            {
                puncte.Add(new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) });
                g.DrawEllipse(black, puncte[i].X, puncte[i].Y, 2, 2);

                if (puncte[i].X < puncte[leftmost].X)
                    leftmost = i;
            }

            // Repeta pana cand revine la punctul de inceput
            int currentPoint = leftmost, nextPoint;
            do
            {
                // Adauga punctul curent la lista invelitorii convexe
                convexHull.Add(puncte[currentPoint]);

                // Cauta nextPoint cu unghiul cautat maxim
                nextPoint = (currentPoint + 1) % nrPuncte;
                for (int i = 0; i < nrPuncte; i++)
                    if (LaStanga(puncte[currentPoint], puncte[i], puncte[nextPoint]))
                        nextPoint = i;

                // Update currentPoint
                currentPoint = nextPoint;
            } while (currentPoint != leftmost);

            // Deseneaza invelitoarea convexa
            for (int i = 0; i < convexHull.Count - 1; i++)
                g.DrawLine(red, convexHull[i].X, convexHull[i].Y, convexHull[i + 1].X, convexHull[i + 1].Y);
            g.DrawLine(red, convexHull[0].X, convexHull[0].Y, convexHull[convexHull.Count - 1].X, convexHull[convexHull.Count - 1].Y);
        }

        /// <summary>
        /// Determina invelitoarea convexa - algoritmul Graham
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void ConvexHullGraham(Graphics g, Random rnd, int width, int height)
        {
            
        }

        private void Sem5_Load(object sender, EventArgs e)
        {

        }
    }
}
