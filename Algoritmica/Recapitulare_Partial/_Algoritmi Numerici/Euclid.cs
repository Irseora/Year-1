namespace Alg_Numerici
{
    class Euclid
    {
        /// <summary> Algoritmul lui Euclid pentru cel mai mare divizor comun </summary>
        public static int CMMDC(int a, int b)
        {
            while (a != b)
                if (a > b) a -= b;
                else b -= a;

            return a;
        }

        /// <summary> Cel mai mare multiplu comun </summary>
        public static int CMMMC(int a, int b)
        {
            return a * b / CMMDC(a, b);
        }
    }
}