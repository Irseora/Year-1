using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexNum;

namespace Recursivitate
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex A = new Complex(0.2,-0.4);
            Complex B = A + A;
            Console.WriteLine(B.View());
            B = B * B;
            Console.WriteLine(B.View());
            B = B * B;
            Console.WriteLine(B.View());
            B = B * B;
            Console.WriteLine(B.View());
            B = B * B;
            Console.WriteLine(B.View());
        }
    }
}