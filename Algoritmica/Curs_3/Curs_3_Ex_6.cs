using System;
using System.IO;

/*
In fisierul numere.txt sun max. 10.000 nr. nat. cu max. 9 cifre fiecare.
Se cere afisarea, in ordine descrescatoare, a tuturor cifrelor care apa in nr. din fisier.
Ex.: 267      -->   9987766322
     39628
     79
*/

namespace Curs_3
{
    class Curs_3_Ex_6
    {
        public void ToateCifrele()
          {
               using (StreamReader sr = new StreamReader("numere.txt"))
               {
                    string input;
                    int[] cifre = new int[10];

                    while ((input = sr.ReadLine()) != null && input != "")
                    {
                         int x = int.Parse(input);

                         while (x > 0)
                         {
                              cifre[x % 10]++;
                              x /= 10;
                         }
                    }

                    for (int i = 9; i >= 0; i--)
                         for (int j = 0; j < cifre[i]; j++)
                              Console.Write(i);
               }
          }
    }
}