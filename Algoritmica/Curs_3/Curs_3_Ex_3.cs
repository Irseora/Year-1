using System;

/*
Evidenta produselor vandute de o societate comerciala este pastrata in fisierul PRODUSE.TXT.
Pt. fiecare vanzare se cunosc:
    - tipul produsului (nr. nat. de max. 4 cifre);
    - cantitatea vanduta in kg (nr. nat. <= 100);
    - pretul unui kg (nr. nat. <= 100).
Fisierul are max. 200.000 de linii si fiecare linie contine 3 nr. nat.,
ce reprezinta tipul, cantitatea si pretul de vanzare al unui produs.

A) Sa se scrie un prog. care determina pt. fiecare tip de produs vandut suma totala obtinuta
   in urma vanzarilor. Va afisa pe cate o linie tipul produsului si suma totala obtinuta.
   Ex.: 3 1  5         1 150
        1 20 5   -->   2  30
        2 10 3         3   5
        1 10 5
*/

namespace Curs_3
{
    class Curs_3_Ex_3
    {
        public void Driver()
        {
            // TODO:
        }

        void SumaTotalaVanduta()
        {
            int[] sume = new int[10000];
            int produsIDMax = 0;

            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                string[] buffer = line.Split(" ");

                int produsID = int.Parse(buffer[0]);
                if (produsID > produsIDMax)
                    produsIDMax = produsID;

                int cantitate = int.Parse(buffer[1]);
                int pret = int.Parse(buffer[2]);

                sume[produsID - 1] += cantitate * pret;
            }

            for (int i = 0; i < produsIDMax; i++)
                Console.WriteLine((i + 1) + " " + sume[i]);
        }
    }
}