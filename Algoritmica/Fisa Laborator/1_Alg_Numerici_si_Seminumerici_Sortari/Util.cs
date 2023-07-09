using System;
using System.IO;
using System.Collections.Generic;

namespace Util
{
    class Util
    {
        static Random rnd = new Random();

        /// <summary> Fill a vector with random integers </summary>
        /// <param name="size"> Vector's size </param>
        /// <param name="minValue"> Minimum value for rng </param>
        /// <param name="maxValue"> Maximum value for rng </param>
        /// <returns> A vector filled with random integers </returns>
        public static int[] FillVectorRandomInt(int size = 20, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[] toRet = new int[size];

            for (int i = 0; i < size; i++)
                toRet[i] = rnd.Next(minValue, maxValue);

            return toRet;
        }

        // -------------------------------------------- READ ------------------------------------------------------------

        /// <summary> Read a vector of integers of given size from console </summary>
        /// <param name="size"> Vector's size </param>
        /// <returns> Read vector </returns>
        
        public static int[] ReadVectorConsoleInt(int size)
        {
            int[] toRet = new int[size];

            for (int i = 0; i < size; i++)
                toRet[i] = int.Parse(Console.ReadLine());

            return toRet;
        }

        /// <summary> Read a vector of integers from console until empty input </summary>
        /// <returns> Read vector </returns>
        
        public static int[] ReadVectorConsoleInt()
        {
            List<int> toRet = new List<int>();

            string buffer;
            while ((buffer = Console.ReadLine()) != "")
                toRet.Add(int.Parse(buffer));

            return toRet.ToArray();
        }

        // -------------------------------------------- PRINT ------------------------------------------------------------

        public static void PrintVectorConsoleInt(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
                Console.Write(vector[i] + " ");
        }
    }
}