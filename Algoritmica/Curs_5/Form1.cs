using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs_5
{
    public partial class Form1 : Form
    {
        Bitmap source, destination;

        public Form1()
        {
            InitializeComponent();
        }

        // FILTERS ----------------------------------------------------------------------

        // Copy
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color col = source.GetPixel(i, j);
                    destination.SetPixel(i, j, col);
                }
            }

            pictureBox2.Image = destination;
        }

        // Grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldCol = source.GetPixel(i, j);
                    int t = (oldCol.R + oldCol.G + oldCol.B) / 3;
                    Color newCol = Color.FromArgb(t, t, t);

                    destination.SetPixel(i, j, newCol);
                }
            }

            pictureBox2.Image = destination;
        }

        // Darken
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);
            int k = 100;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldCol = source.GetPixel(i, j);

                    int newR = oldCol.R - k;
                    if (newR < 0) newR = 0;

                    int newG = oldCol.G - k;
                    if (newG < 0) newG = 0;

                    int newB = oldCol.B - k;
                    if (newB < 0) newB = 0;

                    Color newCol = Color.FromArgb(newR, newG, newB);

                    destination.SetPixel(i, j, newCol);
                }
            }

            pictureBox2.Image = destination;
        }

        // Brighten
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);
            int k = 100;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldCol = source.GetPixel(i, j);

                    int newR = oldCol.R + k;
                    if (newR > 255) newR = 255;

                    int newG = oldCol.G + k;
                    if (newG > 255) newG = 255;

                    int newB = oldCol.B + k;
                    if (newB > 255) newB = 255;

                    Color newCol = Color.FromArgb(newR, newG, newB);

                    destination.SetPixel(i, j, newCol);
                }
            }

            pictureBox2.Image = destination;
        }

        // Brute force contrast
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);
            int k = 50;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    int newR, newG, newB;
                    Color oldCol = source.GetPixel(i, j);

                    int t = (oldCol.R + oldCol.G + oldCol.B) / 3;
                    if (t < 127)
                    {
                        newR = oldCol.R - k;
                        if (newR < 0) newR = 0;

                        newG = oldCol.G - k;
                        if (newG < 0) newG = 0;

                        newB = oldCol.B - k;
                        if (newB < 0) newB = 0;
                    }
                    else
                    {
                        newR = oldCol.R + k;
                        if (newR > 255) newR = 255;

                        newG = oldCol.G + k;
                        if (newG > 255) newG = 255;

                        newB = oldCol.B + k;
                        if (newB > 255) newB = 255;
                    }

                    Color newCol = Color.FromArgb(newR, newG, newB);

                    destination.SetPixel(i, j, newCol);
                }
            }

            pictureBox2.Image = destination;
        }

        // Color shift
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            destination = new Bitmap(source.Width, source.Height);
            int k = 50;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldCol = source.GetPixel(i, j);

                    int newR = (oldCol.R + k) % 255;
                    int newG = (oldCol.G + k) % 255;
                    int newB = (oldCol.B + k) % 255;
                    Color newCol = Color.FromArgb(newR, newG, newB);

                    destination.SetPixel(i, j, newCol);
                }
            }

            pictureBox2.Image = destination;
        }

        // Zoom
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            destination = new Bitmap(source.Width * 2 - 1, source.Height * 2 - 1);

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldCol = source.GetPixel(i, j);

                    destination.SetPixel(i * 2, j * 2, oldCol);
                }
            }

            for (int i = 0; i < destination.Width; i += 2)
            {
                for (int j = 1; j < destination.Height; j += 2)
                {
                    Color t1 = destination.GetPixel(i, j - 1);
                    Color t2 = destination.GetPixel(i, j + 1);

                    int newR = (t1.R + t2.R) / 2;
                    int newG = (t1.G + t2.G) / 2;
                    int newB = (t1.B + t2.B) / 2;

                    destination.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }
            }

            for (int i = 1; i < destination.Width; i += 2)
            {
                for (int j = 0; j < destination.Height; j += 2)
                {
                    Color t1 = destination.GetPixel(i - 1, j);
                    Color t2 = destination.GetPixel(i + 1, j);

                    int newR = (t1.R + t2.R) / 2;
                    int newG = (t1.G + t2.G) / 2;
                    int newB = (t1.B + t2.B) / 2;

                    destination.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }
            }

            pictureBox2.Image = destination;
        }

        // --------------------------------------------------------------------------------

        // Load source
        private void Form1_Load(object sender, EventArgs e)
        {
            source = new Bitmap(@"C:\Users\Vivi\Documents\Algo\Exercitii\Curs_5\Assets\image2.jpg");
            pictureBox1.Image = source;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
