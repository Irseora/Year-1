using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Ball_Game
{
    public class RepelentBall : Ball
    {
        public RepelentBall(int canvasWidth, int canvasHeight) : base(canvasWidth, canvasHeight) { }

        // --------------------------------------------------------

        protected override void Collide(Ball other)
        {

        }
    }
}
