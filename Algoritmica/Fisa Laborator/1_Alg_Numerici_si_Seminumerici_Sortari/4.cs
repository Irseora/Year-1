using System;

// 4. Alg. de determinare a cifrelor unui numar.

namespace Rezolvari
{
    class Ex_4
    {
        public static void Solve()
        {
            Console.WriteLine("Algoritmul de determinare a cifrelor unui numar.");

            Random rnd = new Random();
            int number = rnd.Next(int.MinValue, int.MaxValue);

            if (number < 0) number = -number;

            bool[] cifre = new bool[10];
            for (int i = 0; i < 10; i++)
                cifre[i] = false;

            while (number > 0)
            {
                cifre[number % 10] = true;
                number /= 10;
            }

            Console.Write("Cifrele numarului " + number + " sunt: ");
            for (int i = 0; i < 10; i++)
                if (cifre[i])
                    Console.Write(i + " "); 
        }
    }
}