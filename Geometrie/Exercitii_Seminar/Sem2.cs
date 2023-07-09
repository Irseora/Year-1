using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Exercitii_Seminar
{
    public partial class Sem2 : Form
    {
        int choice = 0;

        public Sem2()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se dau n puncte in plan si o constanta d > 0.\nSa se determine toate punctele care sunt la o distanta <= d, fata de un punct fixat q.";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine triunghiul de arie minima ale carui varfuri sa faca parte din multimea data.\nOptional: Solutie optimizata, bazata pe sortarea punctelor in raport cu relatia de ordine: (x1, y1) < (x2, y2)  <==>  x1 * y2 < x2 * y1";
            choice = 2;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx3_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine cercul de raza minima, care sa contina toate punctele date in interior.";
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

            if (choice == 1) DistLessThanDFromQ(g, rnd, width, height);
            else if (choice == 2) TriunghiMin(g, rnd, width, height);
            else if (choice == 3) ;
        }

        /// <summary>
        /// Determina toate punctele care sunt la o distana mai mica sau egala cu d
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void DistLessThanDFromQ(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);
            Pen green = new Pen(Color.Green, 2);

            // Init
            int nrPoints = rnd.Next(1000), d = rnd.Next(1, 100);

            // Deseneaza Q
            Point q = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
            g.DrawEllipse(red, q.X, q.Y, 2, 2);

            // Deseneaza punctele
            for (int i = 0; i < nrPoints; i++) 
            {
                Point current = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };

                // Daca dist(curent, q) <= d, deseneaza punctul curent cu verde
                if (Math.Sqrt((current.X - q.X) * (current.X - q.X) + (current.Y - q.Y) * (current.Y - q.Y)) <= d)
                    g.DrawEllipse(green, current.X, current.Y, 2, 2);
                // Altfel, deseneaza punctul curent cu negru
                else g.DrawEllipse(black, current.X, current.Y, 2, 2);
            }
        }

        /// <summary>
        /// Sorteaza punctele pe baza relatiei de ordine (x1,y1) < (x2,y2)  <==>  x1 * y2 < x2 * y1
        /// </summary>
        /// <param name="puncte">Lista punctelor</param>
        /// <returns>Lista punctelor sortate</returns>
        private Point[] Sort(Point[] puncte)
        {
            for (int i = 0; i <  puncte.Length; i++)
                for (int j = i+1; j < puncte.Length; j++ )
                    if (puncte[i].X * puncte[j].Y >= puncte[j].X * puncte[i].Y)
                    {
                        Point aux = puncte[i];
                        puncte[i] = puncte[j];
                        puncte[j] = aux;
                    }
            
            return puncte;
        }

        /// <summary>
        /// Determina triunghiul de arie minima ale carui varfuri fac parte din multimea de puncte
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void TriunghiMin(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);
            Pen green = new Pen(Color.Green, 2);

            // Init
            int nrPoints = rnd.Next(100);
            Point[] puncte = new Point[nrPoints];

            // Deseneaza punctele
            for (int i = 0; i < nrPoints; i++)
            {
                puncte[i] = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(black, puncte[i].X, puncte[i].Y, 2, 2);
            }

            // Sorteaza punctele
            puncte = Sort(puncte);

            // Determina triunghiul de arie minima
            double arieMin = 0;
            int[] triunghiArieMin = new int[3];

            for (int i = 0; i < nrPoints - 2; i++)
            {
                int det = puncte[i].X * puncte[i + 1].Y + puncte[i + 1].X * puncte[i + 2].Y + puncte[i + 2].X * puncte[i].Y
                          - puncte[i + 2].X * puncte[i + 1].Y - puncte[i].X * puncte[i + 2].Y - puncte[i + 1].X * puncte[i].Y;

                double arieCurenta = 0.5 * (double)Math.Abs(det);

                if (arieCurenta < arieMin || arieMin == 0)
                {
                    arieMin = arieCurenta;
                    triunghiArieMin[0] = i;
                    triunghiArieMin[1] = i + 1;
                    triunghiArieMin[2] = i + 2;
                }
            }

            g.DrawLine(green, puncte[triunghiArieMin[0]], puncte[triunghiArieMin[1]]);
            g.DrawLine(green, puncte[triunghiArieMin[1]], puncte[triunghiArieMin[2]]);
            g.DrawLine(green, puncte[triunghiArieMin[2]], puncte[triunghiArieMin[0]]);
            g.DrawEllipse(red, puncte[triunghiArieMin[0]].X, puncte[triunghiArieMin[0]].Y, 2, 2);
            g.DrawEllipse(red, puncte[triunghiArieMin[1]].X, puncte[triunghiArieMin[1]].Y, 2, 2);
            g.DrawEllipse(red, puncte[triunghiArieMin[2]].X, puncte[triunghiArieMin[2]].Y, 2, 2);
        }
    }
}
