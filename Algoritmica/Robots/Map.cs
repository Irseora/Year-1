using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Robots
{
    public class Map
    {
        Tile[,] tiles;

        public Map(int m, int n)
        {
            tiles = new Tile[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tiles[i, j] = new Tile(0, new PointF(i, j));
                }
            }
        }

        // ---------------------------------------------

        public void Draw(Graphics handler)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
                for (int j = 0; j < tiles.GetLength(1); j++)
                    tiles[i, j].Draw(handler);
        }
    }
}
