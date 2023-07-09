using System;

/*
1. Se dau 5 valori întregi a,b,c,d şi e. Construiţi un algoritm care identifică următoarele cazuri:
    - Există 2 valori identice;
    - Există 2 cȃte 2 valori identice;
    - Există 3 valori identice;
    - Există 3 cu 2 valori identice;
    - Există 4 valori identice;
    - Toate valorile sunt identice.
*/

namespace Rezolvari
{
    class Ex_1
    {
        public static void Solve()
        {
            Console.WriteLine("Se dau 5 valori întregi a,b,c,d şi e. Construiţi un algoritm care identifică următoarele cazuri:");
            Console.WriteLine("\t- Exista 2 valori identice;");
            Console.WriteLine("\t- Exista 2 cu 2 valori identice;");
            Console.WriteLine("\t- Exista 3 valori identice;");
            Console.WriteLine("\t- Exista 3 cu 2 valori identice;");
            Console.WriteLine("\t- Exista 4 valori identice;");
            Console.WriteLine("\t- Toate valorile sunt identice.\n");

            int[] vector = Util.Util.FillVectorRandomInt(5, 0, 15);
            Console.Write("Vectorul: ");
            Util.Util.PrintVectorConsoleInt(vector);

            int[] frecventa = VectorFrecventa(vector, MaxValue(vector));

            // Maxim + Contor 2
            int max = frecventa[0], contor2 = 0;
            for (int i = 0; i < MaxValue(vector); i++)
            {
                if(frecventa[i] > max)
                    max = frecventa[i];

                if (frecventa[i] == 2)
                    contor2++;
            }

            Console.WriteLine();
            if (max == 5)
                Console.WriteLine("5 numere identice");
            else if (max == 4)
                Console.WriteLine("4 numere identice");
            else if (max == 3)
            {
                if (contor2 == 1)
                    Console.WriteLine("3 - 2 numere identice");
                else
                    Console.WriteLine("3 numere identice");
            }
            else if (max == 2)
            {
                if (contor2 == 2)
                    Console.WriteLine("2 - 2 numere identice");
                else
                    Console.WriteLine("2 numere identice");
            }
            else Console.WriteLine("Nu sunt numere identice");
        }

        /// <summary> Determina cea mai mare valoare dintr-un vector dat </summary>
        /// <param name="vector"> Vectorul dat </param>
        /// <returns> Valoarea maxima din vector </returns>
        static int MaxValue(int[] vector)
        {
            int max = int.MinValue;

            for (int i = 0; i < vector.Length; i++)
                if (vector[i] > max)
                    max = vector[i];

            return max;
        }

        /// <summary> Construieste vectorul de frecventa al unui vector dat </summary>
        /// <param name="vector"> Vectorul dat </param>
        /// <returns> Vectorul de frecventa construit </returns>
        static int[] VectorFrecventa(int[] vector, int maxValue)
        {
            int[] toRet = new int[maxValue + 1];

            for (int i = 0; i < vector.Length; i++)
                toRet[vector[i]]++;

            return toRet;
        }
    }
}