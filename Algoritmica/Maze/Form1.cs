using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.t.InitGraphics(pictureBox1);

            Engine.Load(Engine.crtLevel);
            Engine.DoMath(Engine.t);
            Engine.Draw(Engine.t);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.t.ClearGraphics();

            Engine.Tick();

            if (Engine.isGameOver())
                timer1.Enabled = false;

            Engine.Draw(Engine.t);

            Engine.t.RefreshGraphics();
        }

        /*private void start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    Engine.player1.MoveDown();
                    break;
                case Keys.Up:
                    Engine.player1.MoveUp();
                    break;
                case Keys.Left:
                    Engine.player1.MoveLeft();
                    break;
                case Keys.Right:
                    Engine.player1.MoveRight();
                    break;
                case Keys.Space:
                    timer1.Enabled = !timer1.Enabled;
                    break;
            }

            if (Engine.gMatrix[Engine.player1.location.X, Engine.player1.location.Y] == 9)
            {
                Engine.gMatrix[Engine.player1.location.X, Engine.player1.location.Y] = 0;
                Engine.nrDiamonds--;
            }

            Engine.t.ClearGraphics();
            Engine.Draw(Engine.t);
            Engine.t.RefreshGraphics();

            Engine.CheckForWin(Engine.player1);
            if (Engine.isWin)
            {
                MessageBox.Show("You won");
                timer1.Enabled = false;
            }
        }
    }
}
