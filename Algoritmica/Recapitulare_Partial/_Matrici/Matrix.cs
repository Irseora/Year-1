using System;

namespace Matrix
{
    class Matrix
    {
        int[,] mat;

        // Gets returned on error
        static Matrix empty;

        static Random rnd = new Random();

        // -----------------------------------------------------------------------
        // CONSTRUCTORS

        /// <summary> Empty matrix </summary>
        /// <param name="rows"> Nr. of rows </param>
        /// <param name="cols"> Nr. of columns </param>
        public Matrix(int rows, int cols)
        {
            mat = new int[rows, cols];
        }

        /// <summary> Matrix with random values </summary>
        /// <param name="rows"> Nr. of rows </param>
        /// <param name="cols"> Nr. of columns </param>
        /// <param name="minVal"> Minimum value for RNG </param>
        /// <param name="maxVal"> Maximum value for RNG </param>
        public Matrix (int rows, int cols, int minVal, int maxVal)
        {
            mat = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    mat[i,j] = rnd.Next(minVal, maxVal);
        }

        // -----------------------------------------------------------------------
        // METHODS

        /// <summary> Print matrix to console </summary>
        public void Print()
        {
            int rows = mat.GetLength(0), cols = mat.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write("\t" + mat[i,j]);

                Console.WriteLine();
            }
        }

        // -----------------------------------------------------------------------
        // OPERATORS

        /// <summary> Matrix addition </summary>
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.mat.GetLength(0) != B.mat.GetLength(0) || A.mat.GetLength(1) != B.mat.GetLength(1))
                return empty;

            int rows = A.mat.GetLength(0), cols = A.mat.GetLength(1);
            Matrix toRet = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    toRet.mat[i,j] = A.mat[i,j] + B.mat[i,j];

            return toRet;
        }

        /// <summary> Matrix subtraction </summary>
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.mat.GetLength(0) != B.mat.GetLength(0) || A.mat.GetLength(1) != B.mat.GetLength(1))
                return empty;

            int rows = A.mat.GetLength(0), cols = A.mat.GetLength(1);
            Matrix toRet = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    toRet.mat[i,j] = A.mat[i,j] - B.mat[i,j];

            return toRet;
        }

        /// <summary> Matrix multiplication </summary>
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.mat.GetLength(1) != B.mat.GetLength(0))
                return empty;

            int rows = A.mat.GetLength(0), cols = B.mat.GetLength(1);
            Matrix toRet = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    toRet.mat[i,j] = 0;

                    for (int k = 0; k < rows; k++)
                        toRet.mat[i,j] += A.mat[i,k] * B.mat[k,j];
                }

            return toRet;
        }
    }
}