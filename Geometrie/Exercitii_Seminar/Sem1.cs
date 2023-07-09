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
    public partial class Sem1 : Form
    {
        int choice;

        public Sem1()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine dreptunghiul de arie minima, care contine toate punctele date in interior.";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se dau 2 multimi de puncte in plan.\nPentru fiecare punct din prima multime, sa se gaseasca cel mai apropiat punct din a doua multime.";
            choice = 2;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx3_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se dau n puncte in plan.\nPentru un punct dat q, sa se determine cercul cu centrul q si de raza maxima, care sa nu contina niciun punct.";
            choice = 3;
            pctBoxRezolvare.Invalidate();
        }

        private void pctBoxRezolvare_Paint(object sender, PaintEventArgs e)
        {
            // Init
            Graphics g = e.Graphics;
            Random rnd = new Random();
            int width = pctBoxRezolvare.Width;
            int height = pctBoxRezolvare.Height;

            if (choice == 1) DreptunghiArieMin(g, rnd, width, height);
            else if (choice == 2) CeleMaiApropPuncte(g, rnd, width, height);
            else if (choice == 3) CercRazaMax(g, rnd, width, height);
        }

        /// <summary>
        /// Deseneaza dreptunghiul de arie minima care contine in interior n puncte generate aleatoriu
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void DreptunghiArieMin(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);

            // Init
            int nrPoints = rnd.Next(100);
            Point min = new Point(width, height);
            Point max = new Point(0, 0);

            // Genereaza punctele & determina extremitatile dreptunghiului
            for (int i = 0; i < nrPoints; i++)
            {
                Point current = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(black, current.X, current.Y, 2, 2);

                if (current.X < min.X) min.X = current.X;
                else if (current.X > max.X) max.X = current.X;

                if (current.Y < min.Y) min.Y = current.Y;
                else if (current.Y > max.Y) max.Y = current.Y;
            }

            // Deseneaza dreptunghiul cerut (+2 pentru ca puntele sa fie in interior)
            g.DrawRectangle(black, min.X + 2, min.Y + 2, max.X - min.X + 2, max.Y - min.Y + 2);
        }

        /// <summary>
        /// Deseneaza perechile cele mai apropiate, dintre n puncte generate aleatoriu
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void CeleMaiApropPuncte(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen green = new Pen(Color.Green, 2);
            Pen red = new Pen(Color.Red, 2);

            // Init
            int nrPoints1 = rnd.Next(100), nrPoints2 = rnd.Next(100);
            Point[] points = new Point[nrPoints1];

            // Deseneaza si memoreaza puctele primei multimi
            for (int i = 0; i < nrPoints1; i++)
            {
                points[i] = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(red, points[i].X, points[i].Y, 2, 2);
            }

            // Deseneaza punctele celei de a doua multimi
            // si leaga fiecare dintre ele la cel mai apropiat din prima multime
            for (int i = 0; i < nrPoints2; i++)
            {
                Point current = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(green, current.X, current.Y, 2, 2);

                // Init
                double minDist = Math.Sqrt((points[0].X - current.X) * (points[0].X - current.X) + (points[0].Y - current.Y) * (points[0].Y - current.Y));
                int closestPoint = 0;

                // Cauta cel mai apropiat punct
                for (int j = 0; j < nrPoints1; j++)
                {
                    double dist = Math.Sqrt((points[j].X - current.X) * (points[j].X - current.X) + (points[j].Y - current.Y) * (points[j].Y - current.Y));
                
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestPoint = j;
                    }
                }

                // Leaga cele 2 puncte printr-un segment (+2 compenseaza pt. marimea punctului)
                g.DrawLine(black, current.X + 2, current.Y + 2, points[closestPoint].X + 2, points[closestPoint].Y + 2);
            }
        }

        /// <summary>
        /// Determina cercul de raza maxima si centru Q, care nu contine niciunul dintre punctele generate aleatoriu
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void CercRazaMax(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);

            // Init
            int nrPoints = rnd.Next(100);
            double closesDist = double.MaxValue;

            // Deseneaza punctul Q
            Point q = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
            g.DrawEllipse(red, q.X, q.Y, 2, 2);

            // Deseneaza punctele si determina distanta la cel mai apropiat punct lui Q
            for (int i = 0; i < nrPoints; i++)
            {
                Point current = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(black, current.X, current.Y, 2, 2);

                double distToQ = Math.Sqrt((current.X - q.X) * (current.X - q.X) + (current.Y - q.Y) * (current.Y - q.Y));
                if (distToQ < closesDist) closesDist = distToQ;
            }

            // Deseneaza cercul de raza maxima (-3 compenseaza pt. marimea punctului)
            float radius = (float)closesDist - 3;
            g.DrawEllipse(black, q.X - radius, q.Y - radius, radius * 2, radius * 2);
        }
    }
}
