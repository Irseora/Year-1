using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Big_Ball_Game
{
    public abstract class Ball
    {
        #region Properties

        protected int radius;
        protected Vector2 delta;
        protected bool alive;
        protected Color col;

        public Color Col { get; }

        Point position;

        #endregion

        public Ball(int canvasWidth, int canvasHeight)
        {
            Random rnd = new Random();

            radius = rnd.Next(30);

            int R = rnd.Next(256), G = rnd.Next(256), B = rnd.Next(256);
            col = new Color();
            col = Color.FromArgb(R, G, B);

            position = new Point(rnd.Next(radius, canvasWidth - radius), rnd.Next(radius, canvasHeight - radius));
            delta.X = rnd.Next(10);
            delta.Y = rnd.Next(10);

            alive = true;
        }

        // --------------------------------------------------------

        protected abstract void Collide(Ball other);

        protected void Destroy()
        {
            alive = false;
        }
    }
}
