using System;
using System.Collections.Generic;

/*
Scrieti un prog. care citeste o val. nat. nenula n (n <= 20),
apoi un sir de n nr. naturale, avand fiecare exact 5 cifre.
Dintre cele n nr. citite, prog. determina pe acelea care au toate cifrele egale
si le afiseaza pe ecran, in ordine crescatoare.
Ex.: 5
     11111 33333 12423 59824 11111 33443   -->   11111 22222 33333
*/

namespace Curs_3
{
    class Curs_3_Ex_4
    {
        public void Driver()
        {
            // TODO:
        }

        bool ToateCifEgale(int n)
          {
               int cif = n % 10;
               n /= 10;

               while (n > 0)
               {
                    if (n % 10 != cif) return false;
                    n /= 10;
               }

               return true;
          }

          public void Numere()
          {
               Console.Write("N = ");
               int n = int.Parse(Console.ReadLine());

               List<int> cifreEgale = new List<int>();

               Console.Write("Introduceti " + n + " numere de 5 cifre");
               for (int i = 0; i < n; i++)
               {
                    int x = int.Parse(Console.ReadLine());

                    if (ToateCifEgale(x)) cifreEgale.Add(x);
               }

               for (int i = 0; i < cifreEgale.Count; i++)
                    Console.Write(cifreEgale[i] + " ");
          }
    }
}