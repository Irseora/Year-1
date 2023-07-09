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
    public partial class Sem3 : Form
    {
        int choice = 0;

        public Sem3()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime de 2*n puncte in plan.\nSa se uneasca 2 cate 2, astfel incat suma lungimilor segmentelor obtinute sa fie minima.\n(Problema de cuplaj)";
            choice = 1;
            pctBoxRezolvare.Invalidate();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            lblTextProb.Text = "Se da o multime S de segmente de drepte inchise.\nSe cere sa se determine toate intersectiile dintre segmentele din S.";
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

            if (choice == 1) SumLungimiMin(g, rnd, width, height);
            else if (choice == 2) Intersectii(g, rnd, width, height);
        }

        /// <summary>
        /// Uneste 2 cate 2 punctele, astfel incat suma lungimilor sa fie minima
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void SumLungimiMin(Graphics g, Random rnd, int width, int height)
        {
            
        }

        /// <summary>
        /// Determina toate intersectiile segmentelor
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="rnd">Random</param>
        /// <param name="width">Width of picture box</param>
        /// <param name="height">Height of picture box</param>
        private void Intersectii(Graphics g, Random rnd, int width, int height)
        {

        }

        private void Sem3_Load(object sender, EventArgs e)
        {

        }
    }
}
