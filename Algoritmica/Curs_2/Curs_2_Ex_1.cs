using System;

/*
Se da un numar intreg.
Construiti numarul min. si max. cu cifrele acestuia.
Ex: 
    IN: 29117300
    OUT: 10012379
         97321100
*/

namespace Curs_2
{
    class Curs_2_Ex_1
    {
        public void Ex_1()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            int[] rezultat = Numarare(n);
            Console.WriteLine("Maxim: " + rezultat[0]);
            Console.WriteLine("Minim: " + rezultat[1]);
        }

        // Metoda de numarare / Vector frecventa
        static int[] Numarare(int n)
        {
            int[] v = new int[10];
            while (n != 0)
            {
                v[n % 10]++;
                n /= 10;
            }

            // Maxim
            int max = 0;
            for (int i = 9; i >= 0; i--)
                for (int j = 0; j < v[i]; j++)
                    max = max * 10 + i;

            // Minim
            int min = 0;
            if (v[0] != 0)
            {
                int idx = 1;
                while (v[idx] == 0)
                    idx++;

                min = idx;
                v[idx]--;
            }
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j < v[i]; j++)
                    min = min * 10 + i;

            return new int[2] {max, min};
        }

        // Sortare: Parcurgere triunghi
        // Caz favorabil: O(n^2)
        // Caz mediu: O(n^2)
        // Caz nefavorabil: O(n^2)
        static int[] Sortare(int n)
        {
            int[] v = new int[16];

            int k = 0;
            while (n != 0)
            {
                v[k++] = n % 10;
                n /= 10;
            }

            for (int i = 0; i < k; i++)
                for (int j = i+1; j < k; j++)
                    if (v[i] > v[j])
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }

            int max = 0;
            for (int i = k - 1; i >= 0; i--)
                max = max * 10 + v[i];

            int min = 0;
            if (v[0] == 0)
            {
                int idx = 1;
                while (v[idx] == 0)
                    idx++;
                    
                int aux = v[0];
                v[0] = v[idx];
                v[idx] = 0;
            }
            for (int i = 0; i < k; i++)
                min = min * 10 + v[i];

            return new int[2] {max, min};
        }

        // BubbleSort
        // Caz favorabil: O(1)
        // Caz mediu: O(n^2)
        // Caz nefavorabil: O(n^2)
        /* Exemplu:
        2 9 1 7 7 3 1 5
        2 1 7 7 3 1 5 9
        2 1 7 3 1 5 7 9
        */
        static int[] BubbleSort(int[] v)
        {
            bool done;
            int lastChange = 0;

            do
            {
                done = true;

                for (int i = 0; i < v.Length - 1 - lastChange; i++)
                {
                    if (v[i] > v[i+1])
                    {
                        int aux = v[i];
                        v[i] = v[i+1];
                        v[i+1] = aux;

                        done = false;
                    }
                }

                lastChange++;
            }while (!done);

            return v;
        }

        // Selection Sort
        // Caz favorabil: O(n^2)
        // Caz mediu: O(n^2)
        // Caz nefavorabil: O(n^2)
        /* Exemplu:
        2  9  1  7  7  3  1  5
        1| 9  2  7  7  3  1  5
        1  1| 2  7  7  3  9  5
        1  1  2| 7  7  3  9  5
        1  1  2  3| 7  7  9  5
        1  1  2  3  5| 7  9  7
        1  1  2  3  5  7| 9  7
        1  1  2  3  5  7  7| 9
        1  1  2  3  5  7  7  9
        */
        static int[] SelectionSort(int[] v)
        {
            for (int j = 0; j < v.Length - 1; j++)
            {
                int min = v[j], pozMin = j;

                for (int i = j + 1; j < v.Length; j++)
                    if (v[i] < min)
                    {
                        min = v[i];
                        pozMin = i;
                    }

                int aux = v[j];
                v[j] = v[pozMin];
                v[pozMin] = aux;
            }

            return v;
        } 
    }
}