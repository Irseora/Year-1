using System;
using System.IO;

/*
Numim pereche asemenea (x, y) 2 nr. nat. cu min. 2 cifre, cu prop. ca ultimele 2 cifre ale lor sunt egale, eventual in alta ordine.

Fisierul numere.in contine nr. nat. din intervalul [10, 10^5]. Pe prima linie 2 numere nA si nB.
Pe a doua linie un sir A de nA nr. Pe a treia linie un sir B de nB nr.

Se cere sa se afiseze numarul perechilor asemenea (x, y), cu prop. ca x apartine de A, iar y apartine de B

Ex.: 9 7
     112 20 42 112 5013 824 10012 55 155
     402 1024 321 521 57 6542 255
*/

// Brute force: O(nA * nB)

namespace Curs_3
{
    class Curs_3_Ex_8
    {
        bool Asemenea(int a, int b)
        {
            int a1 = a % 10, a2 = a % 100 / 10;
            int b1 = b % 10, b2 = b % 100 / 10;

            if ((a1 == b1 && a2 == b2) || (a1 == b2 && a2 == b1))
                return true;

            return false;
        }

        public void VectorFrecventa()
        {
            int perechiAsemenea = 0;

            using (StreamReader sr = new StreamReader("numere.in"))
            {
                string[] buffer = sr.ReadLine().Split(" ");
                int nA = int.Parse(buffer[0]), nB = int.Parse(buffer[1]);

                int[] frecvA = new int [100];
                buffer = sr.ReadLine().Split(" ");
                for (int i = 0; i < nA; i++)
                {
                    int xA = int.Parse(buffer[i]);
                    frecvA[xA % 100]++;
                }

                buffer = sr.ReadLine().Split(" ");
                for (int i = 0; i < nB; i++)
                {
                    int xB = int.Parse(buffer[i]);
                    if (frecvA[xB % 100] != 0)
                        perechiAsemenea += frecvA[xB % 100];
                }
            }

            Console.WriteLine(perechiAsemenea);
        }
    }
}