using System;
using System.IO;

/*
Se numeste varf intr-un sir de nr. nat. un termen al sirului care este strict mai mare decat fiecare dintre cei 2 vecini ai sai.

Fisierul bac.in contine un sir de max. 10^6 nr. nat. din intervalul [0, 10^9].
Se cere sa se afiseze varful sirului, pentru care valoarea abs. a diferentei dintre cei 2 vecini ai sai este minima.
Daca exista mai multe astfel de nr., se afiseaza cel mai mare.
Daca nu exista niciun varf, se afiseaza mesajul "nu exista".

Ex.: 2 7 10 5 6 2 1 3 20 17 9 11 7 3 10 6 2   -->   11
*/

namespace Curs_3
{
    class Curs_3_Ex_7
    {
        public void Varf()
        {
            int varfulCautat = -1;

            using (StreamReader sr = new StreamReader("bac.in"))
            {
                int unu = int.Parse(sr.ReadLine()), doi = int.Parse(sr.ReadLine()), trei;
                string input;
                int difAbsolutaMinima = int.MaxValue;

                while ((input = sr.ReadLine()) != null && input != "")
                {
                    trei = int.Parse(input);

                    if (doi > unu && doi > trei && Math.Abs(unu - trei) < difAbsolutaMinima)
                        varfulCautat = doi;
                }
            }

            if (varfulCautat == -1)
                Console.WriteLine("nu exista");
            else
                Console.WriteLine(varfulCautat);
        }
    }
}