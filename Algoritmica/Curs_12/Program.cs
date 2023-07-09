using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            bool[] coloaneFolosite = new bool[n];

            int[] solutii = new int[n];

            NDame(0, n, coloaneFolosite, solutii);
        }

        #region TEORIE

        /// <summary> Genereaza aruncari de zaruri </summary>
        /// <param> k = nivelul curent de BK </param>
        /// <param> nrZaruri -> numarul de for-uri </param>
        /// <param> nrLaturi -> valoarea maxima dintr-un for </param>
        static void BK(int k, int nrZaruri, int nrLaturi, int[] solutie)
        {
            if (k >= nrZaruri)
                WriteVector(solutie);
            else
            {
                for (int i = 0; i < nrLaturi; i++)
                {
                    solutie[k] = i + 1;
                    BK(k+1, nrZaruri, nrLaturi, solutie);
                }
            }
        }

        /// <summary> Genereaza permutari </summary>
        static void BKPermutari(int k, int n, bool[] aparitii, int[] solutie)
        {
            if (k >= n)
                WriteVector(solutie);
            else
            {
                for (int i = 0; i < n; i++)
                    if (!aparitii[i])
                    {
                        aparitii[i] = true;
                        solutie[k] = i;

                        BKPermutari(k+1, n, aparitii, solutie);

                        // Reset aparitii
                        aparitii[i] = false;
                    }
            }
        }

        /// <summary> Genereaza aranjamente de n luate cate p </summary>
        static void Aranjamente(int k, int n, int p, bool[] aparitii, int[] solutie)
        {
            if (k >= p)
                WriteVector(solutie, p);
            else
            {
                for (int i = 0; i < n; i++)
                    if (!aparitii[i])
                    {
                        aparitii[i] = true;
                        solutie[k] = i;

                        Aranjamente(k+1, n, p, aparitii, solutie);

                        aparitii[i] = false;
                    }
            }
        }

        /// <summary> Genereaza combinari de n luate cate p </summary>
        /// <param name="solutie"> Indexat de la 1 </param>
        static void Combinari(int k, int n, int p, int[] solutie)
        {
            if (k >= p)
                WriteVector(solutie, p);
            else
            {
                for (int i = solutie[k-1] + 1; i < n; i++)
                {
                    solutie[k] = i;
                    Combinari(k+1, n, p, solutie);
                }
            }
        }

        #endregion
        
        #region EXERCITII

        static void NDame(int k, int n, bool[] coloaneFolosite, int[] solutii)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n-1; i++)
                    for (int j = i+1; j < n; j++)
                        if (Math.Abs(i-j) == Math.Abs(solutii[i] - solutii[j]))
                        {
                            ok = false;
                            break;
                        }
                if (ok)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                            if (solutii[i] == j)
                                Console.Write("X ");
                            else
                                Console.Write("O ");

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                    if (!coloaneFolosite[i])
                    {
                        coloaneFolosite[i] = true;
                        solutii[k] = i;

                        NDame(k+1, n, coloaneFolosite, solutii);

                        coloaneFolosite[i] = false;
                    }
            }
        }

        static void PatrateMagice3x3(int k, bool[] aparitii, int[] solutie)
        {
            if (k >= 8)
            {
                int sumLine1 = solutie[0] + solutie[1] + solutie[2];
                int sumLine2 = solutie[3] + solutie[4] + solutie[5];
                int sumLine3 = solutie[6] + solutie[7] + solutie[8];

                int sumCol1 = solutie[0] + solutie[3] + solutie[6];
                int sumCol2 = solutie[1] + solutie[4] + solutie[7];
                int sumCol3 = solutie[2] + solutie[5] + solutie[8];

                int sumDiagPrincipala = solutie[0] + solutie[4] + solutie[8];
                int sumDiagSecundara = solutie[2] + solutie[4] + solutie[6];

                if (sumLine1 == sumLine2 && sumLine2 == sumLine3 && sumLine3 == sumCol1 &&
                    sumCol1 == sumCol2 && sumCol2 == sumCol3 && sumCol3 == sumDiagPrincipala &&
                    sumDiagPrincipala == sumDiagSecundara)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(solutie[i] + " ");
                        if (i == 2 || i == 5 || i == 8)
                            Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            else
            {
                // Permutari
                for (int i = 0; i < 9; i++)
                    if (!aparitii[i])
                    {
                        aparitii[i] = true;
                        solutie[k] = i+1;

                        PatrateMagice3x3(k+1, aparitii, solutie);

                        aparitii[i] = false;
                    }
            }
        }

        #endregion

        #region EXTRA

        /// <summary> Afiseaza un vector </summary>
        static void WriteVector(int[] v)
        {
            WriteVector(v, v.Length);
        }

        /// <summary> Afiseaza primele n elemente dintr-un vector </summary>
        static void WriteVector(int[] v, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }

        #endregion
    }
}