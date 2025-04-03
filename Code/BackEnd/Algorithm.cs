using System;
using System.Numerics;

namespace OpenKey.BackEnd
{
    public static class Algorithm
    {
        public static bool IsPrime(BigInteger n)
        {
            if (n <= 1) return false; 
            if (n == 2) return true; 
            if (n % 2 == 0) return false;

            const int k = 20;
            int s = 0;
            BigInteger t = n - 1;
            while (t % 2 == 0)
            {
                s++;
                t /= 2;
            }

            Random random = new Random();
            for (int i = 0; i < k; i++)
            {
                BigInteger a = random.Next(2, int.TryParse(n.ToString(), out int max) ? max - 2 : 1000 - 2);
                BigInteger x = FastPow(a, t, n);
                if (!x.IsOne && x != n - 1)
                {
                    for (int j = 0; j < s - 1; j++)
                    {
                        x = x * x % n;
                        if (x.IsOne) return false;
                        if (x == n - 1) break;
                    }
                    if (x != n - 1) return false;
                }
            }
            return true;
        }

        public static BigInteger FastPow(BigInteger a, BigInteger z, BigInteger n)
        {
            BigInteger x = 1;
            while (z != 0)
            {
                while (z % 2 == 0)
                {
                    z = z / 2;
                    a = (a * a) % n;
                }
                z = z - 1;
                x = (x * a) % n;
            }
            return x;
        }

        public static (BigInteger x, BigInteger y) ExtendedEuclidean(BigInteger a, BigInteger b)
        {
            BigInteger d0 = a, d1 = b;
            BigInteger x0 = 1, x1 = 0;
            BigInteger y0 = 0, y1 = 1;
            while (d1 > 1)
            {
                BigInteger q = d0 / d1;
                BigInteger d2 = d0 % d1;
                BigInteger x2 = x0 - q * x1;
                BigInteger y2 = y0 - q * y1;
                d0 = d1;
                d1 = d2;
                x0 = x1;
                x1 = x2;
                y0 = y1;
                y1 = y2;
            }
            return (x1, y1);
        }
    }
}