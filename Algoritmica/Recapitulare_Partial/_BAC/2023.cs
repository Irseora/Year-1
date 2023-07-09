using System;
using System.IO;

namespace BAC
{
    class Simulare2023
    {
        public static void S2P3()
        {
            int[,] mat = new int[6,6];

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (j == 1 || i == 5) mat[i,j] = 4;
                    else if ((j == 2 && i < 5) || (i == 4 && j > 1)) mat[i,j] = 3;
                    else if ((j == 3 && i < 4) || (i == 3 && j > 2)) mat[i,j] = 2;
                    else if ((j == 4 && i < 3) || (i == 2 && j > 3)) mat[i,j] = 1;
                    else mat[i,j] = 0;
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                    Console.Write(mat[i,j] + " ");
                Console.WriteLine();
            }
        }

        public static void S3P3()
        {
            string path = @"C:\Users\Vivi\Documents\Algo\Recapitulare_Partial\_BAC\Inputs\2023_3_3_sim.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string[] line = sr.ReadLine().Split(' ');

                int maxTemp = -1;

                for (int i = 0; i < line.Length; i++)
                {
                    if (int.Parse(line[i]) > maxTemp)
                    {
                        maxTemp = int.Parse(line[i]);
                        Console.Write((i+1) + " ");
                    }
                }
            }
        }
    }

    class Model2023
    {
        public static void S3P2()
        {
            // 0 - tobogan
            // 1 - leagan
            // 2 - balansoar
            // 3 - carusel

            int n = int.Parse(Console.ReadLine());
            int[,] playground = new int[n+2, n+2];

            // Read playground
            for (int i = 1; i <= n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int j = 1; j <= n; j++)
                    playground[i,j] = int.Parse(line[j-1]);
            }

            // Border with 1
            for (int i = 0; i < n+2; i++)
            {
                playground[0, i] = 1;
                playground[i, 0] = 1;
                playground[n+1, i] = 1;
                playground[i, n+1] = 1;
            }

            // Check carusel spots
            bool foundSpot = false;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (playground[i,j] == 3 && playground[i-1, j] != 0 && playground[i, j+1] != 0 && playground[i+1, j] != 0 && playground[i, j-1] != 0)
                    {
                        foundSpot = true;
                        Console.Write(i + " ");
                    }
                }
            }

            if (!foundSpot) Console.WriteLine("nu exista");
        }

        public static void S3P3()
        {
            string path = @"C:\Users\Vivi\Documents\Algo\Recapitulare_Partial\_BAC\Inputs\2023_3_3_mod.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                int n = int.Parse(sr.ReadLine());
                string[] line = sr.ReadLine().Split(' ');

                int[] numere = new int[2*n];
                for (int i = 0; i < 2*n; i++)
                    numere[i] = int.Parse(line[i]);

                bool pOrdonat = true;

                for (int i = 0; i < n; i++)
                {
                    if (numere[i] % 2 != numere[i+n] % 2 && numere[i] <= numere[i+n])
                    {
                        pOrdonat = false;
                        break;
                    }
                }

                if (pOrdonat) Console.Write("DA");
                else Console.Write("NU");
            }
        }
    }
}