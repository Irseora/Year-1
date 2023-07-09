using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big_Ball_Game
{
    public class RegularBall : Ball
    {
        public RegularBall(int canvasWidth, int canvasHeight) : base(canvasWidth, canvasHeight) { }

        // --------------------------------------------------------

        protected override void Collide(Ball other)
        {
            switch (other)
            {
                case RegularBall reg:
                    RegularBall biggerBall = this.radius > reg.radius ? this : reg;
                    RegularBall smallerBall = this.radius > reg.radius ? reg : this;

                    smallerBall.Destroy();

                    biggerBall.radius += smallerBall.radius;

                    int newR = (biggerBall.col.R + smallerBall.col.R) / 2;
                    int newG = (biggerBall.col.G + smallerBall.col.G) / 2;
                    int newB = (biggerBall.col.B + smallerBall.col.B) / 2;
                    Color newCol = new Color();
                    newCol = Color.FromArgb(newR, newG, newB);

                    break;
                case RepelentBall rep:
                    
                    

                    break;
                case MonsterBall mon:
                    break;
            }
        }
    }
}
