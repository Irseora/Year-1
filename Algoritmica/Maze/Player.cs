using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player
    {
        public Point location;
        public int life;

        public Player() { }

        public Player(int x, int y)
        {
            location = new Point(x, y);
            this.life = 5;
        }

        public Player(Point f)
        {
            location = f;
            this.life = 5;
        }

        public void Draw(MyGraphics handler)
        {
            handler.grp.DrawEllipse(new Pen(Color.DarkViolet), location.X * Engine.deltaW, location.Y * Engine.deltaH, Engine.deltaW, Engine.deltaH);
            handler.grp.FillEllipse(new SolidBrush(Color.DarkViolet), location.X * Engine.deltaW, location.Y * Engine.deltaH, Engine.deltaW, Engine.deltaH);
        }

        public void MoveUp()
        {
            if (Engine.CanMove(location.X, location.Y - 1))
                location.Y--;
        }

        public void MoveDown()
        {
            if (Engine.CanMove(location.X, location.Y + 1))
                location.Y++;
        }

        public void MoveLeft()
        {
            if (Engine.CanMove(location.X - 1, location.Y))
                location.X--;
        }

        public void MoveRight()
        {
            if (Engine.CanMove(location.X + 1, location.Y))
                location.X++;
        }
    }
}
