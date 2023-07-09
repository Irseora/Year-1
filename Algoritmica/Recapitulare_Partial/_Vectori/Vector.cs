using System;

namespace Vectori
{
    class Vector
    {
        int[] vector;

        // -----------------------------------------------------------------------
        // CONSTRUCTORS

        /// <summary> Empty vector of size n </summary>
        public Vector(int n)
        {
            vector = new int[n];
        }

        // -----------------------------------------------------------------------
        // METHODS

        /// <summary> Print vector to console </summary>
        public void Print()
        {
            for (int i = 0; i < this.vector.Length; i++)
                Console.Write(this.vector[i] + " ");

            Console.WriteLine();
        }

        // -----------------------------------------------------------------------
        // OPERATORS

        /// <summary> Vector addition </summary>
        public static Vector operator +(Vector A, Vector B)
        {
            int maxLength = A.vector.Length > B.vector.Length ? A.vector.Length : B.vector.Length;
            Vector toRet = new Vector(maxLength);

            for (int i = 0; i < maxLength; i++)
                toRet.vector[i] = A.vector[i] + B.vector[i];

            return toRet;
        }

        /// <summary> Vector subtraction </summary>
        public static Vector operator -(Vector A, Vector B)
        {
            int maxLength = A.vector.Length > B.vector.Length ? A.vector.Length : B.vector.Length;
            Vector toRet = new Vector(maxLength);

            for (int i = 0; i < maxLength; i++)
                toRet.vector[i] = A.vector[i] - B.vector[i];

            return toRet;
        }

        /// <summary> Vector multiplication </summary>
        public static Vector operator *(Vector A, Vector B)
        {
            int maxLength = A.vector.Length > B.vector.Length ? A.vector.Length : B.vector.Length;
            Vector toRet = new Vector(maxLength);

            for (int i = 0; i < maxLength; i++)
                toRet.vector[i] = A.vector[i] * B.vector[i];

            return toRet;
        }

        /// <summary> Vector division </summary>
        public static Vector operator /(Vector A, Vector B)
        {
            int maxLength = A.vector.Length > B.vector.Length ? A.vector.Length : B.vector.Length;
            Vector toRet = new Vector(maxLength);

            for (int i = 0; i < maxLength; i++)
                toRet.vector[i] = A.vector[i] / B.vector[i];

            return toRet;
        }
    }
}