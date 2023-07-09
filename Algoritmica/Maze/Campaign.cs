using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Campaign
    {
        public int crtLevel;
        public List<string> files;

        public Campaign()
        {
            crtLevel = 0;

            files = new List<string>();
            files.Add("Level1.txt");
            files.Add("Level2.txt");
            files.Add("Level3.txt");
        }

        public string GetCurrentFile()
        {
            return files[crtLevel];
        }
    }
}
