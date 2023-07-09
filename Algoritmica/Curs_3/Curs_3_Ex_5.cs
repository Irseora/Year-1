using System;
using System.IO;

/*
In fisierul BAC.IN se gasesc nr. nat. de cel mult 6 cifre fiecare.
Se cere sa se determine si afiseze ultimele 2 nr. impare (nu neaparat distincte) din fisier.
Daca nu se gasesc 2, sau nu se gaseste niciunul, se va scrie "Numere insuficiente.".
Ex.: 12 15 68 13 17 90 31 42   -->   17 31
*/

namespace Curs_3
{
    class Curs_3_Ex_5
    {
        public void Driver()
        {
            // TODO:
        }

        public void Ultimele2Impare()
        {
            int impar1 = 0, impar2 = 0;

            using (StreamReader sr = new StreamReader("BAC.IN"))
            {
                string input;
                while ((input = sr.ReadLine()) != null && input != "")
                {
                    int x = int.Parse(input);

                    if (x % 2 == 1)
                    {
                        impar1 = impar2;
                        impar2 = x;
                    }
                }
            }

            if (impar1 == 0 || impar2 == 0)
                Console.WriteLine("Numere insuficiente.");
            else
                Console.WriteLine(impar1 + " " + impar2);
        }
    }
}