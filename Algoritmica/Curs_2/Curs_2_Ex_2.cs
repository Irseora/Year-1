using System;
using System.IO;

/*
In fisierul data.in se gases n < 10^9 numere intregi din intervalul [-10^9, 10^9].
Afisati cele mai mari 2 numere de 3 cifre care nu apar in fisier.
Ex: IN: 2191 7 999 14 976 5
        1 45273
        997 997 997
        0 -496
        5
    OUT: 998 996
*/

namespace Curs_2
{
    class Curs_2_Ex_2
    {
        public void Ex_2()
        {
            bool[] found = new bool[1000];
            string buffer;
            string[] currentLine;
            TextReader load = new StreamReader(@"..\..\data.in");
            while ((buffer = load.ReadLine()) != null)
            {
                currentLine = buffer.Split(' ');

                for (int i = 0; i < currentLine.Length; i++)
                {
                    int n = int.Parse(currentLine[i]);
                    if (n > 99 && n < 1000)
                        found[n] = true;
                }
            }

            int k = 0;
            for (int i = 999; i > 99 && k < 2; i--)
                if (!found[i])
                {
                    Console.WriteLine(i + " ");
                    k++;
                }
        }
    }
}