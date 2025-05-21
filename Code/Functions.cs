using System;
using System.Numerics;

namespace ElectronicDigitalSignature
{
    public static class Functions
    {
        public const int h0 = 100;

        public static bool IsPrime(BigInteger n)
        {
            if (n <= 1) return false;
            if (n == 2 || n == 3) return true;
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

        static BigInteger HashFunc(BigInteger h, BigInteger m, BigInteger q)
        {
            return FastPow((h + m), 2, q);
        }

        public static BigInteger GetHash(byte[] data, BigInteger q)
        {
            BigInteger h = h0;
            foreach (var m in data)
            {
                h = HashFunc(h, m, q);
            }
            return h;
        }

        public static (BigInteger, BigInteger, BigInteger) GetSignature(byte[] data, BigInteger q, BigInteger p, BigInteger x, BigInteger k, BigInteger g)
        {
            BigInteger h = GetHash(data, q);
            BigInteger r = FastPow(g, k, p) % q;
            BigInteger s = (FastPow(k, q - 2, q) * (h + x * r)) % q;

            return (h, r, s);
        }
    }
}
