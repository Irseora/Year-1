using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particule
{
    public partial class Form1 : Form
    {
        MyGraphics graphics = new MyGraphics();
        Map demo = new Map();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics.InitGraphics(pictureBox1);

            demo.width = pictureBox1.Width;
            demo.height = pictureBox1.Height;

            demo.Init(50);
            demo.Draw(graphics.g);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            demo.Tick();
            graphics.Clear();
            demo.Draw(graphics.g);
            graphics.Refresh();
        }
    }
}
