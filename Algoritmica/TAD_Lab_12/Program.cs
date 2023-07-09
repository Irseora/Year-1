using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAD_Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            TAD test = new TAD(3);

            for (int i = 1; i <= 20; i++)
            {
                test.PushEnd(i);
            }

            Console.WriteLine(test.View());
            for (int i = 1; i <= 20; i++)
            {
                int temp = test.PopBegin();
                Console.WriteLine(test.View());
            }
        }
    }
}