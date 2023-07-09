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
    public partial class Sem4 : Form
    {
        int choice = 0;

        public Sem4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// O structura de date care reprezinta latura unui poligon prin 2 puncte
        /// </summary>
        struct Latura
        {
            public Point p, q;
            // TODO: public Latura(Point p, Point q) { this.p = p; this.q = q; }
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine invelitoarea convexa a acestei multimi.\nAlgoritmul slab.";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de puncte in plan.\nSa se determine invelitoarea convexa a acestei multimi.\nAlgoritmul prin determinarea invelitorii superioare si inferioare.";
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

            if (choice == 1) ConvexHullSlab(g, rnd, width, height);
            else if (choice == 2) ConvexHullSupInf(g, rnd, width, height);
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
        /// Determina invelitoarea convexa - algoritmul slab
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void ConvexHullSlab(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);

            // Init
            int nrPuncte = rnd.Next(100);
            Point[] puncte = new Point[nrPuncte];
            Latura[] laturiCH = new Latura[0];

            // Deseneaza punctele aleatorii
            for (int i = 0; i < nrPuncte; i++)
            {
                puncte[i] = new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) };
                g.DrawEllipse(black, puncte[i].X, puncte[i].Y, 2, 2);
            }

            for (int p = 0; p < nrPuncte; p++)
                for (int q = 0; q < nrPuncte; q++)
                    if (p != q)
                    {
                        bool valid = true;

                        // Daca un punct se intoarce spre stanga, se poate trasa o latura directa,
                        // sarind peste punctul intermediar
                        for (int r = 0; r < nrPuncte; r++)
                            if (r != p && r != q && !LaStanga(puncte[p], puncte[q], puncte[r]))
                            {
                                valid = false;
                                break;
                            }

                        if (valid)
                        {
                            laturiCH.Append(new Latura { p = puncte[p], q = puncte[q] });
                            g.DrawLine(red, puncte[p].X, puncte[p].Y, puncte[q].X, puncte[q].Y);
                        }
                    }
        }

        /// <summary>
        /// Determina invelitoarea convexa - algoritmul prin determinarea invelitorii superioare si inferioare
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void ConvexHullSupInf(Graphics g, Random rnd, int width, int height)
        {
            // Pens
            Pen black = new Pen(Color.Black, 2);
            Pen red = new Pen(Color.Red, 2);
            Pen green = new Pen(Color.Green, 2);

            // Init
            int nrPuncte = rnd.Next(4, 100);
            List<Point> puncte = new List<Point>(nrPuncte);
            List<Point> superiorCH = new List<Point>();
            List<Point> inferiorCH = new List<Point>();

            // Deseneaza punctele aleatorii
            for (int i = 0; i < nrPuncte; i++)
            {
                puncte.Add(new Point { X = rnd.Next(10, width - 10), Y = rnd.Next(10, height - 10) });
                g.DrawEllipse(black, puncte[i].X, puncte[i].Y, 2, 2);
            }

            // Ordoneaza lista punctelor dupa x, si dupa y unde este cazul
            puncte = puncte.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

            superiorCH.Add(puncte[0]);
            superiorCH.Add(puncte[1]);

            // Determina invelitoarea superioara
            for (int i = 3; i < nrPuncte; i++)
            {
                superiorCH.Add(puncte[i]);

                while (superiorCH.Count > 2 && LaStanga(superiorCH[superiorCH.Count - 3], superiorCH[superiorCH.Count - 2], superiorCH[superiorCH.Count - 1]))
                    superiorCH.RemoveAt(superiorCH.Count - 2);
            }

            inferiorCH.Add(puncte[nrPuncte - 1]);
            inferiorCH.Add(puncte[nrPuncte - 2]);

            // Determina invelitoarea inferioara
            for (int i = nrPuncte - 3; i >= 0; i--)
            {
                inferiorCH.Add(puncte[i]);

                while (inferiorCH.Count > 2 && LaStanga(inferiorCH[inferiorCH.Count - 3], inferiorCH[inferiorCH.Count - 2], inferiorCH[inferiorCH.Count - 1]))
                    inferiorCH.RemoveAt(inferiorCH.Count - 2);
            }

            inferiorCH.RemoveAt(0);
            inferiorCH.RemoveAt(inferiorCH.Count - 1);

            // Deseneaza invelitoarea superioara cu rosu
            for (int i = 0; i < superiorCH.Count - 1; i++)
                g.DrawLine(red, superiorCH[i].X, superiorCH[i].Y, superiorCH[i+1].X, superiorCH[i+1].Y);

            // Deseneaza invelitoarea inferioara cu verde
            for (int i = 0; i < inferiorCH.Count - 1; i++)
                g.DrawLine(green, inferiorCH[i].X, inferiorCH[i].Y, inferiorCH[i+1].X, inferiorCH[i+1].Y);
        }

        private void Sem4_Load(object sender, EventArgs e)
        {

        }
    }
}
