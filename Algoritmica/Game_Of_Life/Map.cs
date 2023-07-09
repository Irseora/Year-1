using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    public class Map
    {
        int[,] map;

        public int Rows { get { return map.GetLength(0); } }
        public int Cols { get { return map.GetLength(1); } }

        // --------------------------------------------------------------------------------
        // METHODS

        public void Load(string fileName)
        {
            TextReader sr = new StreamReader(fileName);
            List<string> readLines = new List<string>();
            string buffer;

            while ((buffer = sr.ReadLine()) != null)
                readLines.Add(buffer);

            sr.Close();

            int rows = readLines.Count;
            int cols = readLines[0].Split(' ').Length;

            map = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] values = readLines[i].Split(' ');

                for (int j = 0; j < cols; j++)
                    map[i, j] = int.Parse(values[j]);
            }
        }

        public List<string> View()
        {
            List<string> toRet = new List<string>();

            for (int i = 0; i < Rows; i++)
            {
                string buffer = "";

                for (int j = 0; j < Cols; j++)
                    buffer += map[i, j].ToString();

                toRet.Add(buffer);
            }

            return toRet;
        }

        public void Draw(MyGraphics handler)
        {
            float deltaW = (float)handler.resY / Cols;
            float deltaH = (float)handler.resX / Rows;

            Color color;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    switch (map[i, j])
                    {
                        case 1:  color = Color.Black;
                                 break;

                        default: color = handler.bgColor;
                                 break;
                    }

                    handler.grp.FillEllipse(new SolidBrush(color), j * deltaW, i * deltaH, deltaW, deltaH);
                    handler.grp.DrawEllipse(Pens.Gray, j * deltaW, i * deltaH, deltaW, deltaH);
                }
            }
        }

        public void Tick()
        {
            int[,] temp = new int[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    int vecini = 0;

                    /*
                    if (i - 1 >= 0 && j - 1 >= 0 && temp[i - 1, j - 1] == 1)
                        vecini++;

                    if (i - 1 >= 0 && temp[i - 1, j] == 1)
                        vecini++;

                    if (i - 1 >= 0 && j + 1 < Cols && temp[i - 1, j + 1] == 1)
                        vecini++;

                    if (j - 1 >= 0 && temp[i, j - 1] == 1)
                        vecini++;

                    if (j + 1 < Cols && temp[i, j + 1] == 1)
                        vecini++;

                    if (i + 1 < Rows && j - 1 >= 0 && temp[i + 1, j - 1] == 1)
                        vecini++;

                    if (i + 1 < Rows && temp[i + 1, j] == 1)
                        vecini++;

                    if (i + 1 < Rows && j + 1 < Cols && temp[i + 1, j + 1] == 1)
                        vecini++;
                    */

                    int[] ModifI = { -1, -1, -1,  0,  0,  1,  1,  1 };
                    int[] ModifJ = { -1,  0,  1, -1,  1, -1,  0,  1 };

                    for (int k = 0; k < ModifI.Length; k++)
                    {
                        if (i + ModifI[k] < Rows && i + ModifI[k] >= 0 && j + ModifJ[k] < Cols && j + ModifJ[k] >= 0)
                            if (map[i + ModifI[k], j + ModifJ[k]] == 1)
                                vecini++;
                    }

                    switch(map[i,j])
                    {
                        case 0: if (vecini >= 3) temp[i, j] = 1;
                                break;
                        case 1: if (vecini >= 4) temp[i, j] = 0;
                                else temp[i, j] = 1;
                                break;
                    }
                }
            }

            map = temp;
        }

        public int Count1s()
        {
            int nrOf1 = 0;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (map[i, j] == 1)
                        nrOf1++;

            return nrOf1;
        }
    }
}
