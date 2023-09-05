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
    public partial class Sem8 : Form
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

        // Punctele multimii / poligonului
        List<Point> puncte = new List<Point>();
        int nrPuncte = 0;

        public Sem8()
        {
            InitializeComponent();
        }

        private void Sem8_Load(object sender, EventArgs e)
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

        public class Triunghi
        {
            public int A, B, C;

            public Triunghi(int a, int b, int c)
            {
                this.A = a;
                this.B = b;
                this.C = c;
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
            lblTextProb.Text = "a) Triangularea unui poligon simplu cu n>3 vârfuri prin metoda eliminării urechilor (otectomie).\n" +
                "b) 3-colorarea grafului asociat triangulării obținute (culorile se pot asocia în mod unic pornind de la vîrfurile triunghiului rămas și apoi urechile determinate, considerate în ordinea inversă eliminării).\n" +
                "c) Determinarea ariei poligonului (expresia analitică din Cursul 08 – Teorema 5.5).";

            // Clear point list
            nrPuncte = 0;
            puncte.Clear();

            // Clear picture box
            g.Clear(DefaultBackColor);
            pctBoxRezolvare.Image = bmp;

            allowDraw = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Deseneaza ultima latura a pligonului
            g.DrawLine(pBlack, puncte[nrPuncte - 1], puncte[0]);
            pctBoxRezolvare.Image = bmp;

            allowDraw = false;

            // Rezolvare
        }

        
    }
}
