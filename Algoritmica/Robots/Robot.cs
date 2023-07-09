using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public abstract class Robot
    {
        /// <summary>
        /// Locatia pe harta a robotului
        /// </summary>
        public PointF mapLocation { get; private set; }

        public Robot () { }

        // ---------------------------------------------

        /// <summary>
        /// Spawn @ toSet
        /// </summary>
        /// <param name="toSet">Where to spawn</param>
        public void SetOnMap(PointF toSet)
        { this.mapLocation = toSet; }

        /// <summary>
        /// Draw robot
        /// </summary>
        /// <param name="handler">Graphics</param>
        public abstract void Draw(Graphics handler);
    }
}
