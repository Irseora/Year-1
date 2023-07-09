using System;

/*
Se considera fisierul BAC.TXT ce contine un sir crescator cu max. 1 mil. nr. nat.
de cel mult 9 cifre fiecare, separate prin cate 1 spatiu.

A) Sa se scrie un prog. care citeste din fisier toti termenii sirului si afiseaza
   fiecare termen distinct al sirului urmat de nr. de aparitii ale lui in sir.
   Ex.: 1 1 1 5 5 5 5 9 11 20 20 20  -->  1 3 5 4 9 2 11 1 20 3
*/

namespace Curs_3
{
    class Curs_3_Ex_2
    {
        public void Aparitii()
        {
            int nrAparitii = 1;
            int x = int.Parse(Console.ReadLine()), y;

            while(true) // TODO: until end of file
            {
                y = int.Parse(Console.ReadLine());

                if (x == y)
                {
                    nrAparitii++;
                }
                else
                {
                    Console.Write(x + " " + nrAparitii);
                    nrAparitii = 1;
                }
            }

            // Ultimul element
            Console.Write(x + " " + nrAparitii);
        }
    }
}