using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Ball_Game
{
    public class MonsterBall : Ball
    {
        public MonsterBall(int canvasWidth, int canvasHeight) : base(canvasWidth, canvasHeight)
        {
            delta.X = 0;
            delta.Y = 0;
        }

        // --------------------------------------------------------

        protected override void Collide(Ball other)
        {

        }
    }
}
