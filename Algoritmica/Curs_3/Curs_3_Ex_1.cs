/*
A) Subprogramul cif, cu 2 parametrii, primeste prin intermediul parametrului a un nr. natural cu max. 8 cifre
   si prin intermediul parametrului b o cifra.
   Subprogramul returneaza numarul de aparitii ale cifrei b in scrierea numarului a.
   Ex.: a = 125854, b = 5  -->  2.

B) Scrieti un prog. care citeste de la tastatura un nr. nat. n cu exact 8 cifre
   si care determina si afiseaza pe ecran cel mai mare nr. palindrom ce poate fi obtinut prin rearanjarea
   tuturor cifrelor numarului n.
   Daca nu se poate crea palindrom, afiseaza 0.
   Ex.: 21523531  -->  53211235
        12272351  -->  0
*/

namespace Curs_3
{
    class Curs_3_Ex_1
    {
        public void Driver()
        {
            // TODO:
        }

        /// <summary> Determina de cate ori apare cifra b in numarul a </summary>
        /// <param name="a"> Numarul </param>
        /// <param name="b"> Cifra cautata </param>
        /// <returns> Numarul de aparitii ale cifrei b in numarul a </returns>
        int Cif(int a, int b)
        {
            int aparitiiB = 0;

            while (a > 0)
            {
                if (a % 10 == b) aparitiiB++;
                a /= 10;
            }

            return aparitiiB;
        }

        /// <summary> Determina cel mai mare numar palindrom obtinut din cifrele lui n </summary>
        /// <param name="n"> Numarul natural initial </param>
        /// <returns> Cel mai mare palindrom obtinut din cifrele lui n </returns>
        
        int CelMaiMarePalindrom(int num)
        {
            int palindrom = 0;
            int[] frecv = new int [10];
            bool ok = true;

            for (int i = 0; i < 10 && ok; i++)
            {
                frecv[i] = Cif(num, i);

                if (frecv[i] % 2 == 1)
                    ok = false;
            }

            if (!ok) return 0;

            for (int i = 9; i >= 0; i--)
                for (int j = 0; j < frecv[i] / 2; j++)
                    palindrom += 10 + i;
            
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j < frecv[i] / 2; j++)
                    palindrom += 10 + i;

            return palindrom;
        }
    }
}