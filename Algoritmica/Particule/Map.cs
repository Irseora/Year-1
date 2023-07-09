using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particule
{
    public class Map
    {
        public int width, height;

        public List<Particle> particles;

        // ----------------------------------------------------------
        // CONSTRUCTORS

        public Map()
        {
            particles = new List<Particle> ();
        }

        // ----------------------------------------------------------
        // METHODS

        public void Init(int nrParticule)
        {
            for (int i = 0;  i < nrParticule; i++)
            {
                particles.Add(new Particle(width, height));
            }
        }

        public void Draw(Graphics handler)
        {
            foreach (Particle particle in particles)
            {
                particle.Draw(handler);
            }
        }

        public void Tick()
        {
            // Remove dead particles
            particles = particles.FindAll(delegate (Particle A) { return !A.isDead; });

            // Add new particles
            List<Particle> toAdd = new List<Particle> ();

            foreach (Particle particle in particles)
                foreach (Particle newParticle in particle.Tick())
                    toAdd.Add(newParticle);

            foreach (Particle particle in toAdd)
            {
                if (particle.location.X >= 0 && particle.location.X < width && particle.location.Y >= 0 && particle.location.Y < height)
                    particles.Add(particle);
            }
        }
    }
}
