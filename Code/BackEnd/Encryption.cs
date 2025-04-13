using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace OpenKey.BackEnd
{
    public static class Encryption
    {
        public static BigInteger p, q, b;

        public static BigInteger[] plaintext, ciphertext; 

        public static void Encrypt()
        {
            BigInteger n = p * q;
            ciphertext = new BigInteger[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                BigInteger m = plaintext[i];
                ciphertext[i] = m * (m + b) % n;
            }
        }

        public static void Decrypt()
        {
            BigInteger n = p * q;
            ciphertext = new BigInteger[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                BigInteger c = plaintext[i];
                BigInteger D = (b * b + 4 * c) % n;

                BigInteger mp = Algorithm.FastPow(D, (p + 1) / 4, p);
                BigInteger mq = Algorithm.FastPow(D, (q + 1) / 4, q);

                (BigInteger yp, BigInteger yq) = Algorithm.ExtendedEuclidean(p, q);

                BigInteger[] d = new BigInteger[4];
                d[0] = (yp * p * mq + yq * q * mp) % n;
                if (d[0] < 0) { d[0] += n; }
                d[1] = n - d[0];
                d[2] = (yp * p * mq - yq * q * mp) % n;
                if (d[2] < 0) { d[2] += n; }
                d[3] = n - d[2];

                BigInteger[] m = new BigInteger[4];
                for (int j = 0; j < 4; j++)
                {
                    m[j] = ((d[j] - b + ((d[j] - b) % 2 != 0 ? n : 0)) / 2) % n;
                    if (m[j] < 0) { m[j] += n; }
                    if (m[j] < 256)
                    {
                        ciphertext[i] = m[j];
                        break;
                    }
                }
            }
        }
    }
}