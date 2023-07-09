using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robots
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyGraphics g = new MyGraphics();
            g.InitGraphics(picBox);

            /*
            for (float t = 0; t <= (float)Math.PI / 2; t += 0.1f)
            {
                PointF[] points = Engine.PoligonRegulat(new PointF(400, 200), 100, 4, t);
                g.grp.DrawPolygon(Pens.Black, points);
                g.RefreshGraphics();
            }
            */

            Map map = new Map(20, 20);
            map.Draw(g.grp);
            g.RefreshGraphics();
        }
    }
}
