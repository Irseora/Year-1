using System;
using System.IO;

namespace BAC
{
    class Simulare2022
    {
        public static void S3P1()
        {

        }

        public static void S3P2()
        {

        }

        public static void S3P3()
        {
            
        }
    }

    class Special2022
    {
        public static void S3P1()
        {

        }

        public static void S3P2()
        {

        }

        public static void S3P3()
        {
            
        }
    }

    class Vara2022
    {   
        // TODO:
        public static void S3P1()
        {
            int n = 202233228;
        }

        public static void S3P2()
        {
            // Linii
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());

            // Coloane
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[,] plaja = new int[m+2, n+2];
            
            // Border with int max value
            for (int i = 0; i < m+2; i++)
            {
                plaja[i, 0] = int.MaxValue;
                plaja[i, n+1] = int.MaxValue;
            }
            for (int i = 0; i < n+2; i++)
            {
                plaja[0, i] = int.MaxValue;
                plaja[m+1, i] = int.MaxValue;
            }

            // Read matrix
            for (int i = 1; i <= m; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int j = 1; j <= n; j++)
                    plaja[i, j] = int.Parse(line[j-1]);
            }

            int totalSandNeeded = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // Find smallest neighbour
                    int minNeighbour = int.MaxValue;
                    if (plaja[i-1, j] < minNeighbour) minNeighbour = plaja[i-1,j];
                    if (plaja[i, j+1] < minNeighbour) minNeighbour = plaja[i, j+1];
                    if (plaja[i+1, j] < minNeighbour) minNeighbour = plaja[i+1, j];
                    if (plaja[i, j-1] < minNeighbour) minNeighbour = plaja[i, j-1];

                    if (plaja[i,j] < minNeighbour)
                    {
                        totalSandNeeded += minNeighbour - plaja[i,j];
                        Console.Write(" " + (minNeighbour - plaja[i,j]));
                    }
                }
            }

            Console.WriteLine("\nTotal sand needed: " + totalSandNeeded);
        }
    
        // TODO:
        public static void S3P3()
        {
            string path = @"C:\Users\Vivi\Documents\Algo\Recapitulare_Partial\_BAC\Inputs\2022_3_3_vara.txt";
            string[] line;
            int x, y;
            int[] numere;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine().Split(' ');
                x = int.Parse(line[0]);
                y = int.Parse(line[1]);

                line = sr.ReadLine().Split(' ');
                numere = new int[line.Length];

                for (int i = 0; i < line.Length; i++)
                    numere[i] = int.Parse(line[i]);
            }

            // Eficient ???
        }
    }

    class Toamna2022
    {
        public static void S3P1()
        {
            // Replace p-th digit in n with digit x
            // Numbered from 0, right to left

            int n = 12587, x = 6, p = 3;

            int pow = 1;
            for (int i = 1; i <= p; i++) pow *= 10;

            int temp = n % pow;
            n /= (pow * 10);

            n = n * (pow * 10) + x * pow + temp;
            Console.WriteLine(n);
        }

        public static void S3P3()
        {
            string path = @"C:\Users\Vivi\Documents\Algo\Recapitulare_Partial\_BAC\Inputs\2022_3_3_toamna.txt";
            string[] line;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine().Split(' ');
            }

            int[] numere = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
                numere[i] = int.Parse(line[i]);

            int maxLength = 0, currentLength = 1, nrMaxLength = 0;
            for (int i = 0; i < numere.Length - 1; i++)
            {
                if (numere[i] % 2 == numere[i+1] % 2)
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        nrMaxLength = 1;
                    }
                    else if (currentLength == maxLength)
                        nrMaxLength++;
                }
                else
                    currentLength = 1;
            }

            Console.WriteLine(nrMaxLength + " " + maxLength);
        }
    }
}