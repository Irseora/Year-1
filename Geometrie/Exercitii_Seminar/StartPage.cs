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
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void btnSem1_Click(object sender, EventArgs e)
        {
            Sem1 sem1 = new Sem1();
            sem1.Show();
        }

        private void btnSem2_Click(object sender, EventArgs e)
        {
            Sem2 sem2 = new Sem2();
            sem2.Show();
        }

        private void btnSem3_Click(object sender, EventArgs e)
        {
            Sem3 sem3 = new Sem3();
            sem3.Show();
        }

        private void btnSem4_Click(object sender, EventArgs e)
        {
            Sem4 sem4 = new Sem4();
            sem4.Show();
        }

        private void btnSem5_Click(object sender, EventArgs e)
        {
            Sem5 sem5 = new Sem5();
            sem5.Show();
        }

        private void btnSem6_Click(object sender, EventArgs e)
        {
            Sem6 sem6 = new Sem6();
            sem6.Show();
        }

        private void btnSem7_Click(object sender, EventArgs e)
        {

        }

        private void btnSem8_Click(object sender, EventArgs e)
        {

        }

        private void btnSem9_Click(object sender, EventArgs e)
        {

        }

        private void btnSem10_Click(object sender, EventArgs e)
        {

        }
    }
}
