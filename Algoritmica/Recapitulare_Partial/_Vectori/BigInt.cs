using System;

namespace Vectori
{
    class BigInt
    {
        int[] num;

        // -----------------------------------------------------------------------
        // CONSTRUCTORS

        /// <summary> BigInt 0 </summary>
        public BigInt()
        {
            num = new int[1] {0};
        }

        /// <summary> Empty BigInt of size n </summary>
        public BigInt(int n)
        {
            num = new int[n];
        }

        // -----------------------------------------------------------------------
        // METHODS

        /// <summary> Print BigInt to console </summary>
        public void Print()
        {
            for (int i = this.num.Length - 1; i >= 0; i--)
            {
                if (i == this.num.Length - 1 && this.num[i] == 0)
                    continue;
                
                Console.Write(this.num[i]);
            }

            Console.WriteLine();
        }

        // -----------------------------------------------------------------------
        // OPERATORS

        /// <summary> BigInt addition </summary>
        public static BigInt operator +(BigInt A, BigInt B)
        {
            int maxLength = A.num.Length > B.num.Length ? A.num.Length : B.num.Length;
            BigInt C = new BigInt(maxLength + 1);

            int carry = 0;
            for (int i = 0; i < maxLength; i++)
            {
                int sum = A.num[i] + B.num[i] + carry;
                C.num[i] = sum % 10;
                carry = sum / 10;
            }

            C.num[maxLength] = carry;

            return C;
        }

        /// <summary> BigInt subtraction </summary>
        public static BigInt operator -(BigInt A, BigInt B)
        {
            int maxLength = A.num.Length > B.num.Length ? A.num.Length : B.num.Length;
            BigInt C = new BigInt(maxLength);

            int carry = 0;
            for (int i = 0; i < maxLength; i++)
            {
                int diff = A.num[i] - B.num[i] - carry;
                if (diff < 0)
                {
                    diff += 10;
                    carry = 1;
                }
                else
                    carry = 0;

                C.num[i] = diff;
            }

            return C;
        }

        /// <summary> BigInt multiplication </summary>
        public static BigInt operator *(BigInt A, BigInt B)
        {
            int maxLength = A.num.Length > B.num.Length ? A.num.Length : B.num.Length;
            BigInt C = new BigInt(maxLength * 2);

            // Multiply each digit of A with each digit of B
            // Store result on 2 positions in C (2 digits)
            for (int i = 0; i < A.num.Length; i++)
            {
                for (int j = 0; j < B.num.Length; j++)
                {
                    int prod = A.num[i] * B.num[j];
                    C.num[i + j] += prod % 10;
                    C.num[i + j + 1] += prod / 10;
                }
            }

            int carry = 0;

            // Add carry to each digit
            // Get rid of extra spaces in C
            for (int i = 0; i < C.num.Length; i++)
            {
                int sum = C.num[i] + carry;
                C.num[i] = sum % 10;
                carry = sum / 10;
            }

            return C;
        }
    }
}