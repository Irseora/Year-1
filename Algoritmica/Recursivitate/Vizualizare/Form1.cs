using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizualizare
{
    public partial class Form1 : Form
    {
        MyGraphics g = new MyGraphics();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g.InitGraphics(pictureBox1);
            Rec(300, 170, 150);
            g.Refresh();
        }

        public void Patrat(float x, float y, float l)
        {
            g.grp.DrawLine(Pens.Black, x - l / 2, y - l / 2, x + l / 2, y - l / 2);
            g.grp.DrawLine(Pens.Black, x + l / 2, y - l / 2, x + l / 2, y + l / 2);
            g.grp.DrawLine(Pens.Black, x + l / 2, y + l / 2, x - l / 2, y + l / 2);
            g.grp.DrawLine(Pens.Black, x - l / 2, y + l / 2, x - l / 2, y - l / 2);
        }

        public void Rec(float x, float y, float l)
        {
            Patrat(x, y, l);

            if (l > 3)
            {
                Rec(x - l / 2, y - l / 2, l / 2);
                Rec(x + l / 2, y - l / 2, l / 2);
                Rec(x - l / 2, y + l / 2, l / 2);
                Rec(x + l / 2, y + l / 2, l / 2);
            }
        }
    }
}
