using System;

// 8. Alg. de calcul a sumei / produsului / normei elementelor unui vector.

namespace Rezolvari
{
    class Ex_8
    {
        public static void Solve()
        {
            Console.WriteLine("Algoritmul de calcul a sumei, produsului & normei elementelor unui vector.\n");

            int[] vector = Util.Util.FillVectorRandomInt(50, 1, 50);
            Console.Write("Vectorul: ");
            Util.Util.PrintVectorConsoleInt(vector);
            
            long suma = 0, produs = 1;
            double norma = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                suma += vector[i];
                produs *= vector[i];
                norma += (double)suma / vector.Length;
            }

            Console.WriteLine();
            Console.WriteLine("Suma: " + suma);
            Console.WriteLine("Produs: " + produs);
            Console.WriteLine("Norma: " + norma);
        }
    }
}