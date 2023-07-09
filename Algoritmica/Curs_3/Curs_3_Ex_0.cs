using System;

/*
Se da un sir de numere si se cere sa se determine suma celor mai mari 3 valori dintre acestea.
Lungimea sirului: n < 10.000
Valori: 0 < v_i < 1.000.000
*/

namespace Curs_3
{
    class Curs_3_Ex_0
    {
        public void Driver()
        {
            // TODO:
        }

        public void BubbleSort(int[] v)
        {
            int n = v.Length;

            for (int i = 0; i < n-1; i++)
                for (int j = i+1; j < n; j++)
                    if (v[i] > v[j])
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                    }

            int sum = v[n-1] + v[n-2] + v[n-3];
        }

        public int VectorFrecventa()
        {
            int n = 1001;
            int[] v = new int[1001];

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                v[x]++;
            }

            int sum = 0, k = 0;
            for (int i = 1000; i >= 0; i--)
            {
                while (v[i] != 0 && k < 3)
                {
                    sum += v[i];
                    v[i]--;
                    k++;
                }

                if (k == 3) break;
            }

            return sum;
        }

        public int ParcurgereLiniara()
        {
            int m1 = 0, m2 = 0, m3 = 0;

            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Elementele vectorului: ");
            m1 = int.Parse(Console.ReadLine());
            m2 = int.Parse(Console.ReadLine());
            m3 = int.Parse(Console.ReadLine());

            if (m1 > m2)
            {
                int aux = m1;
                m1 = m2;
                m2 = aux;
            }
            if (m1 > m3)
            {
                int aux = m1;
                m1 = m3;
                m3 = aux;
            }
            if (m2 > m3)
            {
                int aux = m2;
                m2 = m3;
                m3 = m2;
            }

            for (int i = 3; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());

                if (x >= m3)       // m1 <= m2 <= m3 <= x
                {
                    m1 = m2;
                    m2 = m3;
                    m3 = x;
                }
                else if (x >= m2)  // m1 <= m2 <= x <= m3
                {
                    m1 = m2;
                    m2 = x;
                }
                else if (x > m1)  // m1 <= x <= m2 <= m3
                    m1 = x;
            }

            return (m1 + m2 + m3);
        }
    }
}