using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Desen, Rotatie, Translatie, Arie

namespace Curs6
{
    public partial class Form1 : Form
    {
        MyGraphics g;

        Poligon[] test;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = new MyGraphics(pictureBox1);
            g.Clear();

            /*
            int size = 20;
            test = new Poligon[size];

            test[0] = new Poligon("C:\\Users\\Vivi\\Documents\\Algo\\Exercitii\\Curs6\\poligon.txt");
            test[0].Draw(g.g);

            for (int i = 1; i < size; i++)
            {
                test[i] = new Poligon(3, g.resX, g.resY);
                test[i].Draw(g.g);
            }
            */

            test = new Poligon[5];
            test[0] = new Poligon("C:\\Users\\Vivi\\Documents\\Algo\\Exercitii\\Curs_6\\poligon.txt");
            test[0].Draw(g.g);

            g.Refresh();

            Matrix test1 = new Matrix(3, 3, 0, 2);
            Matrix test2 = new Matrix(3, 3, 0, 2);
            Matrix test3 = test1 * test2;

            ViewMatrix(test1);
            ViewMatrix(test2);
            ViewMatrix(test3);
        }

        public void ViewMatrix(Matrix matrix)
        {
            foreach (string s in matrix.View())
                listBox1.Items.Add(s);
            listBox1.Items.Add("");
        }

        private void btnCentruGreutate_Click(object sender, EventArgs e)
        {
            PointF G = test[0].CentruGreutate();
            g.g.DrawEllipse(Pens.Red, G.X - 2, G.Y - 2, 5, 5);
            g.Refresh();
        }

        private void btnPerimetru_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test[0].Perimetru().ToString());
        }

        private void btnArie_Click(object sender, EventArgs e)
        {
            MessageBox.Show(test[0].Arie().ToString());
        }

        private void btn_Translatie_Click(object sender, EventArgs e)
        {
            Poligon X = g.Translate(test[0], new Point(200, 100));
            X.Draw(g.g);
            g.Refresh();
        }

        private void btn_Scalare_Click(object sender, EventArgs e)
        {
            Poligon X = g.Scale(test[0], 1, 2);
            X.Draw(g.g);
            g.Refresh();
        }

        private void btn_Rotatie_Click(object sender, EventArgs e)
        {
            for (float rotation = 0; rotation < (float)Math.PI; rotation += 0.1f)
            {
                Poligon X = g.Rotate(test[0], rotation, test[0].CentruGreutate());
                X.Draw(g.g);

                Poligon Y = g.Rotate(test[0], rotation, new PointF(300, 300));
                Y.Draw(g.g);
            }

            g.Refresh();
        }
    }
}
