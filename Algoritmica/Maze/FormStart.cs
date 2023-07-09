using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Maze
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.isCamp = false;
            Engine.crtLevel = comboBox1.SelectedItem.ToString();
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            string[] dir = Directory.GetFiles(@"..\..\..\Maps");
            foreach (string s in dir)
            {
                string[] local = s.Split("\\");
                listBox1.Items.Add(s);
                comboBox1.Items.Add(local[local.Length - 1]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Engine.camp = new Campaign();
            Engine.isCamp = true;
            Engine.crtLevel = Engine.camp.GetCurrentFile();

            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
