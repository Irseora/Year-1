using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rezolvari;

namespace Alg_Numerici_si_Seminumerici_Sortari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("1. Algoritmi Numerici & Seminumerici. Sortari");
            Console.Write("Alege o problema (1-27): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:  Ex_1.Solve(); break;
                // case 2:  Ex_2.Solve(); break;
                // case 3:  Ex_3.Solve(); break;
                case 4:  Ex_4.Solve(); break;
                // case 5:  Ex_5.Solve(); break;
                // case 6:  Ex_6.Solve(); break;
                // case 7:  Ex_7.Solve(); break;
                case 8:  Ex_8.Solve(); break;
                // case 9:  Ex_9.Solve(); break;
                // case 10: Ex_10.Solve(); break;
                // case 11: Ex_11.Solve(); break;
                // case 12: Ex_12.Solve(); break;
                // case 13: Ex_13.Solve(); break;
                // case 14: Ex_14.Solve(); break;
                // case 15: Ex_15.Solve(); break;
                // case 16: Ex_16.Solve(); break;
                // case 17: Ex_17.Solve(); break;
                // case 18: Ex_18.Solve(); break;
                // case 19: Ex_19.Solve(); break;
                // case 20: Ex_20.Solve(); break;
                // case 21: Ex_21.Solve(); break;
                // case 22: Ex_22.Solve(); break;
                // case 23: Ex_23.Solve(); break;
                // case 24: Ex_24.Solve(); break;
                // case 25: Ex_25.Solve(); break;
                // case 26: Ex_26.Solve(); break;
                // case 27: Ex_27.Solve(); break;
                default: break;
            }
        }

        void Menu()
        {
            


        }
    }
}