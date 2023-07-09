using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    // Static
    public enum MonsterType { Horizontal, Vertical, AnyDirection }

    internal class Monster
    {
        public static Random rnd = new Random();
        public int locX, locY, deltaX, deltaY;
        public MonsterType type;

        public Monster(int locX, int locY, int type)
        {
            int t;
            this.locX = locX;
            this.locY = locY;

            switch (type) 
            {
                case 5:
                    this.type = MonsterType.Horizontal;
                    t = rnd.Next(2);

                    if (t == 0)
                        deltaY = -1;
                    else
                        deltaY = 1;

                    deltaX = 0;
                    break;
                case 6:
                    this.type = MonsterType.Vertical;
                    t = rnd.Next(2);

                    if (t == 0)
                        deltaX = -1;
                    else
                        deltaX = 1;

                    deltaY = 0;
                    break;
                case 7:
                    this.type = MonsterType.AnyDirection;

                    t = rnd.Next(2);
                    int x;
                    if (t == 0) x = -1;
                    else x = 1;

                    t = rnd.Next(2);
                    if (t == 0)
                    {
                        deltaX = x;
                        deltaY = 0;
                    }
                    else
                    {
                        deltaX = 0;
                        deltaY = x;
                    }
                    
                    break;
            }
        }

        public void Tick()
        {
            if (Engine.gMatrix[locX + deltaX, locY + deltaY] == 1)
            {
                int t;
                switch(type)
                {
                    case MonsterType.Horizontal:
                        deltaY *= -1;
                        break;
                    case MonsterType.Vertical:
                        deltaX *= -1;
                        break;
                    case MonsterType.AnyDirection:
                        t = rnd.Next(2);
                        int x;
                        if (t == 0) x = -1;
                        else x = 1;

                        t = rnd.Next(2);
                        if (t == 0)
                        {
                            deltaX = x;
                            deltaY = 0;
                        }
                        else
                        {
                            deltaX = 0;
                            deltaY = x;
                        }
                        break;
                }
            }
            else
            {
                locX += deltaX;
                locY += deltaY;
            }
        }

        public void Draw(MyGraphics handler)
        {
            Color fillColor = Color.Black;

            switch (type)
            {
                case MonsterType.Horizontal:
                    fillColor = Color.Blue;
                    break;
                case MonsterType.Vertical:
                    fillColor = Color.Yellow;
                    break;
                case MonsterType.AnyDirection: 
                    fillColor = Color.Red;
                    break;
            }

            handler.grp.FillEllipse(new SolidBrush(fillColor), locY * Engine.deltaW, locX * Engine.deltaH, Engine.deltaW, Engine.deltaH);
            handler.grp.DrawEllipse(Pens.Black, locY * Engine.deltaW, locX * Engine.deltaH, Engine.deltaW, Engine.deltaH);
        }
    }
}
