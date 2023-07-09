using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting.Lifetime;
using System.Net.NetworkInformation;

namespace Maze
{
    public static class Engine
    {
        public static float deltaW, deltaH;

        public static int[,] gMatrix;
        static List<Monster> monsters = new List<Monster>();
        public static Player player1;
        public static Point final;
        public static string crtLevel;

        public static int nrDiamonds = 0;

        public static Campaign camp;
        public static bool isCamp;

        public static bool isWin;

        public static MyGraphics t = new MyGraphics();


        public static void Load(string fileName)
        {
            isWin = false;

            TextReader load = new StreamReader(fileName);
            List<string> data = new List<string>();
            string buffer;

            while ((buffer = load.ReadLine()) != null) 
                data.Add(buffer);
            load.Close();

            gMatrix = new int[data.Count, data[0].Split(' ').Length];
            for (int i = 0; i < data.Count; i++)
            {
                string[] local = data[i].Split(' ');

                for (int j = 0; j < local.Length; j++)
                {
                    gMatrix[i, j] = int.Parse(local[j]);

                    if (gMatrix[i, j] >= 5 && gMatrix[i, j] <= 7)
                        monsters.Add(new Monster(i, j, gMatrix[i, j]));
                    else
                        if (gMatrix[i, j] == 2)
                        player1 = new Player(i, j);
                    else
                        if (gMatrix[i, j] == 3) final = new Point(i, j);
                    else
                        if (gMatrix[i, j] == 9) nrDiamonds++;
                }
            }
        }

        public static void Draw(MyGraphics handler)
        {
            for (int i = 0; i < gMatrix.GetLength(0); i++)
                for (int j = 0; j < gMatrix.GetLength(1); j++)
                    switch (gMatrix[i,j]) 
                    {
                        case 1: // Pereti
                            handler.grp.FillRectangle(Brushes.Gray, j * deltaW, i * deltaH, deltaW, deltaH);
                            handler.grp.DrawRectangle(Pens.Black, j * deltaW, i * deltaH, deltaW, deltaH);
                            break;
                        case 2:
                            player1.Draw(handler);
                            break;
                        case 3: // Final
                            handler.grp.FillRectangle(Brushes.Black, j * deltaW, i * deltaH, deltaW, deltaH);
                            handler.grp.DrawRectangle(Pens.Black, j * deltaW, i * deltaH, deltaW, deltaH);
                            break;
                        case 4:

                            break;
                        case 9: // Diamond
                            handler.grp.FillEllipse(Brushes.LightGreen, j * deltaW, i * deltaH, deltaW, deltaH);
                            handler.grp.DrawEllipse(Pens.Black, j * deltaW, i * deltaH, deltaW, deltaH);
                            break;
                        default:
                            break;
                    }

            foreach (Monster m in monsters)
                m.Draw(handler);

            player1.Draw(handler);

            handler.grp.DrawString(Engine.player1.life.ToString(), new Font("Arial", 30, FontStyle.Bold), Brushes.Red, new Point(10, 10));
            handler.grp.DrawString(nrDiamonds.ToString(), new Font("Arial", 30, FontStyle.Bold), Brushes.Blue, new Point(50, 10));
        }

        public static bool CanMove(int locX, int locY)
        {
            if (gMatrix[locY, locX] != 1)
                return true;
            return false;
        }

        public static bool IsMonster(int locX, int locY)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.locX == locX && monster.locY == locY)
                    return true;
            }
            return false;
        }

        public static void CheckForWin(Player player)
        {
            if (gMatrix[player.location.X, player.location.Y] == 3)
            {
                if (nrDiamonds == 0)
                {
                    if (isCamp)
                    {
                        Engine.camp.crtLevel++;

                        if (Engine.camp.crtLevel >= Engine.camp.files.Count)
                            isWin = true;
                        else
                        {
                            crtLevel = Engine.camp.GetCurrentFile();
                            Load(crtLevel);
                            DoMath(t);
                        }
                    }
                    else
                    {
                        isWin = true;
                    }
                }
            }
        }

        public static bool MonsterCollision(Player player)
        {
            foreach(Monster mon in monsters)
            {
                if (player.location.X == mon.locX && player.location.Y == mon.locY)
                    return true;
            }

            return false;
        }

        public static void Tick()
        {
            foreach (Monster m in monsters)
                m.Tick();

            if (MonsterCollision(player1))
                player1.life--;
        }

        public static bool isGameOver()
        {
            if (player1.life <= 0)
                return true;
            return false;
        }

        public static void DoMath(MyGraphics handler) 
        {
            deltaW = (float)handler.resX / gMatrix.GetLength(1);
            deltaH = (float)handler.resY / gMatrix.GetLength(0);
        }
    }
}
