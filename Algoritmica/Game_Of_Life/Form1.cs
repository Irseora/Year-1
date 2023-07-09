using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Of_Life
{
    public partial class Form1 : Form
    {
        Map demo;
        MyGraphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            demo = new Map();
            demo.Load(@"..\..\demo.txt");

            //foreach(string line in demo.View())
            //listBox1.Items.Add(line);

            g = new MyGraphics();
            g.InitGraphics(pictureBox1);
            demo.Draw(g);
            g.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(demo.Count1s().ToString());

            g.Clear();
            demo.Tick();
            demo.Draw(g);
            g.Refresh();
        }
    }
}
