using System;

namespace ComplexNum
{
    class Complex
    {
        /// <summary> Partea reala </summary>
        double re;

        /// <summary> Partea imaginara </summary>
        double im;

        // -----------------------------------------------------------------------

        public Complex(double re, double im) { this.re = re; this.im = im; }

        public Complex() { }
        
        // -----------------------------------------------------------------------

        /// <summary>  </summary>
        public string View()
        {
            if (re == 0)
            {
                if (im == 0) return "0";
                else return im + "i";
            }
            else
            {
                if (im == 0) return re.ToString();
                else if (im > 0) return re + "+" + im + "i";
                else return re.ToString() + im.ToString() + "i";
            } 
        }

        /// <summary> Conjugarea unui nr imaginar </summary>
        public Complex Conj() => new Complex(this.re, -this.im);

        public double Mod() => Math.Sqrt(re * re + im * im);

        // -----------------------------------------------------------------------

        public static Complex operator +(Complex A, Complex B) => new Complex(A.re + B.re, A.im + B.im);

        public static Complex operator -(Complex A, Complex B) => new Complex(A.re - B.re, A.im - B.im);

        public static Complex operator *(Complex A, Complex B)
        => new Complex(A.re * B.re - A.im * B.im, A.im * B.re + A.re * B.im);

        public static Complex operator /(Complex A, Complex B)
        {
            Complex conjB = B.Conj();

            Complex up = A * conjB;
            Complex down = B * conjB;

            return new Complex(up.re / down.re, up.im / down.re);
        }
    }
}