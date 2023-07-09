using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Curs6
{
    public class Matrix
    {
        public float[,] mat;
        public static Matrix empty;  // return on error
        static Random rnd = new Random();

        // "Constructor global"
        private void Base(int rows, int columns)
        {
            mat = new float[rows, columns];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            Base(rows, columns);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="valMin"></param>
        /// <param name="valMax"></param>
        public Matrix(int rows, int columns, int valMin, int valMax)
        {
            mat = new float[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    mat[i,j] = rnd.Next(valMin, valMax);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="A"></param>
        public Matrix(int columns, PointF generatorPoint)
        {
            mat = new float[2, columns];

            for (int i = 0; i < columns; i++)
            {
                mat[0, i] = generatorPoint.X;
                mat[1, i] = generatorPoint.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dim"></param>
        public Matrix(int dim)
        {
            mat = new float[dim, dim];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public Matrix(string fileName)
        {
            List<string> lines = new List<string>();

            using (TextReader reader = new StreamReader(fileName))
            {
                string buffer;

                while ((buffer = reader.ReadLine()) != null)
                    lines.Add(buffer);
            }

            int rows = lines.Count;
            int columns = lines[0].Split(' ').Length;
            Base(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                string[] local = lines[i].Split(' ');

                for (int j = 0; j < columns; j++)
                    mat[i,j] = int.Parse(local[j]);
            }
        }



        // ---------------------------------------------

        /// <summary>
        /// Transforma o matrice intr-un poligon
        /// </summary>
        /// <returns>Poligonul</returns>
        public Poligon MatrixToPoligon()
        {
            Poligon toRet = new Poligon(mat.GetLength(1));

            for (int i = 0; i < mat.GetLength(1); i++)
            {
                toRet.points[i].X = mat[0, i];
                toRet.points[i].Y = mat[1, i];
            }

            return toRet;
        }

        public List<string> View()
        {
            List<string> toRet = new List<string>();
            string buffer;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                buffer = "";

                for (int j = 0; j < mat.GetLength(1); j++)
                    buffer += mat[i, j].ToString();

                toRet.Add(buffer);
            }

            return toRet;
        }

        // OPERATORS ------------------------------------------------------------

        /// <summary>
        /// Adunarea a doua matrici
        /// </summary>
        /// <param name="A">Prima matrice</param>
        /// <param name="B">A doua matrice</param>
        /// <returns>O matrice care reprezinta suma celor 2 matrici</returns>
        public static Matrix operator + (Matrix A, Matrix B)
        {
            if (A.mat.GetLength(0) != B.mat.GetLength(0) || A.mat.GetLength(1) != B.mat.GetLength(1))
                return empty;

            Matrix toRet = new Matrix(A.mat.GetLength(0), A.mat.GetLength(1));

            for (int i = 0; i < A.mat.GetLength(0); i++)
                for (int j = 0; j <  A.mat.GetLength(1); j++)
                    toRet.mat[i,j] = A.mat[i,j] + B.mat[i,j];

            return toRet;
        }

        /// <summary>
        /// Scaderea a doua matrici
        /// </summary>
        /// <param name="A">Prima matrice</param>
        /// <param name="B">A doua matrice</param>
        /// <returns>O matrice care reprezinta diferenta celor 2 matrici</returns>
        public static Matrix operator - (Matrix A, Matrix B)
        {
            if (A.mat.GetLength(0) != B.mat.GetLength(0) || A.mat.GetLength(1) != B.mat.GetLength(1))
                return empty;

            Matrix toRet = new Matrix(A.mat.GetLength(0), A.mat.GetLength(1));

            for (int i = 0; i < A.mat.GetLength(0); i++)
                for (int j = 0; j < A.mat.GetLength(1); j++)
                    toRet.mat[i, j] = A.mat[i, j] - B.mat[i, j];

            return toRet;
        }

        /// <summary>
        /// Inmultirea a doua matrici
        /// </summary>
        /// <param name="A">Prima matrice</param>
        /// <param name="B">A doua matrice</param>
        /// <returns>O matrice care reprezinta produsul celor 2 matrici</returns>
        public static Matrix operator * (Matrix A, Matrix B)
        {
            if (A.mat.GetLength(1) != B.mat.GetLength(0))
                return empty;

            Matrix toRet = new Matrix(A.mat.GetLength(0), B.mat.GetLength(1));

            for (int i = 0; i < A.mat.GetLength(0); i++)
            {
                for (int j = 0; j < B.mat.GetLength(1); j++)
                {
                    toRet.mat[i, j] = 0;

                    for (int k = 0; k < A.mat.GetLength(0); k++)
                    {
                        toRet.mat[i,j] += A.mat[i,k] * B.mat[k,j];
                    }
                }
            }

            return toRet;
        }
    }
}
