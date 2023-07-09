namespace Alg_Numerici
{
    class Prime
    {
        /// <summary> Check if n is prime </summary>
        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
                if (n % i == 0)
                    return false;
            
            return true;
        }

        /// <summary> Find first n prime numbers </summary>
        public static int[] FirstNPrimes(int n)
        {
            int[] primes = new int[n];

            int poz = 0, candidate = 2;
            while (poz < n)
            {
                if (IsPrime(candidate))
                    primes[poz++] = candidate;
                
                if (candidate == 2) candidate++;
                else candidate += 2;
            }

            return primes;
        }

        /// <summary> Find all primes numbers <= n </summary>
        public static bool[] EratostheneSieve(int n)
        {
            bool[] sieve = new bool[n];

            for (int i = 0; i < n; i++)
                sieve[i] = true;

            sieve[0] = false;
            sieve[1] = false;

            int poz = 2;
            while (poz <= n)
            {
                if (sieve[poz])
                    for (int i = 2; i <= n; i++)
                        sieve[poz * i] = false;

                poz++;
            }

            return sieve;
        }
    }
}