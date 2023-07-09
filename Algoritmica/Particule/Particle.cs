using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particule
{
    public class Particle
    {
        // Shared by all particles
        static int rataDisparitie = 20, rataDublare = 30;
        static int radiusDublare = 30, nrMaxDublare = 3;

        public PointF location;

        public bool isDead;
        public static Random rnd = new Random();

        // ----------------------------------------------------------
        // CONSTRUCTORS

        public Particle(int maxWidth, int maxHeight)
        {
            isDead = false;
            location = new PointF(rnd.Next(maxWidth), rnd.Next(maxHeight));
        }

        public Particle()
        {
            isDead = false;
        }

        // ----------------------------------------------------------
        // METHODS

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, location.X - 3, location.Y - 3, 7, 7);
        }

        public List<Particle> Tick()
        {
            List<Particle> toReturn = new List<Particle>();

            int x = rnd.Next(100);
            if (x < rataDublare)
            {
                int nrSpawn = rnd.Next(nrMaxDublare) + 1;

                for (int i = 0; i < nrSpawn; i++)
                {
                    Particle local = new Particle();
                    local.location = this.Spawn();
                    toReturn.Add(local);
                }
            }

            x = rnd.Next(100);
            if (x < rataDisparitie)
                isDead = true;

            return toReturn;
        }

        // Give location of new particle inside radiusDublare
        PointF Spawn()
        {
            float alpha = (float)(rnd.NextDouble() * Math.PI * 2);
            float radius = rnd.Next(radiusDublare);

            float x = location.X + (float)(radius * Math.Cos(alpha));
            float y = location.Y + (float)(radius * Math.Sin(alpha));

            return new PointF(x, y);
        }
    }
}
