using System;

namespace Alg_Numerici
{
    class MinMaxSecvential
    {
        /// <summary> Return minimum value and nr. of appearances </summary>
        public static int[] MinimumSecvential()
        {
            string input = Console.ReadLine();
            int min_Value = int.Parse(input), min_Appearance = 1;

            while ((input = Console.ReadLine()) != null)
            {
                int num = int.Parse(input);

                if (num < min_Value)
                {
                    min_Value = num;
                    min_Appearance = 1;
                }
                else if (num == min_Value)
                    min_Appearance++;
            }

            return new int[] {min_Value, min_Appearance};
        }

        /// <summary> Return maximum value and nr. of appearances </summary>
        public static int[] MaximumSecvential()
        {
            string input = Console.ReadLine();
            int max_Value = int.Parse(input), max_Appearance = 1;

            while ((input = Console.ReadLine()) != null)
            {
                int num = int.Parse(input);

                if (num > max_Value)
                {
                    max_Value = num;
                    max_Appearance = 1;
                }
                else if (num == max_Value)
                    max_Appearance++;
            }

            return new int[] {max_Value, max_Appearance};
        }
    }
}