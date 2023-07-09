using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 17. Determinati cel mai mare divizor comun si cel mai mic multiplu comun a doua numere.
//     Folositi algoritmul lui Euclid.

namespace Rezolvari
{
    class Prob_17
    {
        /// <summary> Determina cel mai mare divizor comun si cel mai mic multiplu comun a 2 numere. Date de intrare: 2 numere </summary>
        /// <param name="indicatie"> Indicatia problemei pe care o rezolva functia </param>
        public static void Euclid(string indicatie)
        {
            Console.Clear();
            Console.WriteLine($"{indicatie}{Environment.NewLine}");
            Console.WriteLine("------------------------------------------------------");

            Console.Write("Introduceti 2 numere intregi: ");
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]), b = int.Parse(input[1]);

            int copyA = a, copyB = b;
            while (copyB != 0)
            {
                int rest = copyA % copyB;
                copyA = copyB;
                copyB = rest;
            }

            Console.WriteLine($"Cel mai mare divizor comun ({a}, {b}): {copyA}");
            Console.Write($"Cel mai mic multiplu comun [{a}, {b}]: {a*b/copyA}");
        }
    }
}