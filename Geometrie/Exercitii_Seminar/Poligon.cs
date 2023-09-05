using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercitii_Seminar
{
    public class Poligon
    {
        public List<Point> puncte;
        public List<Point> puncteSortate;

        public int[] chainIndex;

        public List<Line> laturi;
        public List<Line> diagonale;

        public Poligon(List<Point> p)
        {
            puncte = new List<Point>();
            this.puncte.AddRange(p);

            laturi = new List<Line>();
            for (int i = 0; i < puncte.Count - 1; i++)
                laturi.Add(new Line(puncte[i], puncte[i + 1]));

            laturi.Add(new Line(puncte[puncte.Count - 1], puncte[0]));
            diagonale = new List<Line>();
        }

        public void SorteazaPuncte()
        {
            puncteSortate = new List<Point>();
            puncteSortate.AddRange(puncte);
            puncteSortate.Sort((a, b) => Math.Sign(a.Y - b.Y));
        }

        public void ComputeChains()
        {
            chainIndex = new int[puncte.Count];

            int start = Math.Min(puncte.IndexOf(puncteSortate[0]), puncte.IndexOf((puncteSortate[puncteSortate.Count - 1])));
            int end = Math.Max(puncte.IndexOf(puncteSortate[0]), puncte.IndexOf((puncteSortate[puncteSortate.Count - 1])));

            for (int i = 0; i < puncte.Count; i++)
                if (i > start && i < end)
                    chainIndex[puncteSortate.IndexOf(puncte[i])] = 1;
                else
                    chainIndex[puncteSortate.IndexOf(puncte[i])] = 0;
        }

        public void Draw(Graphics g, Color c)
        {
            for (int i = 0; i < puncte.Count - 1; i++)
            {
                g.DrawEllipse(new Pen(Color.Red, 4), puncte[i].X - 2, puncte[i].Y - 2, 4, 4);
                g.DrawLine(new Pen(c, 5), puncte[i], puncte[i + 1]);
            }

            g.DrawEllipse(Pens.Red, puncte[puncte.Count - 1].X - 2, puncte[puncte.Count - 1].Y - 2, 4, 4);
            g.DrawLine(new Pen(c, 5), puncte[0], puncte[puncte.Count - 1]);
        }
    }
}
