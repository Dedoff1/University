using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabTU3GUI
{
    public class ElGamal
    {
        public static Check checks = new Check();
        public static int[] primeArr = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293 };

        public short[] encrypt(int g, int k, int p, BigInteger y, byte[] text)
        {
            Random r = new Random();
            short[] ciphertext = new short[text.Length*2];
            for (int i = 0; i < text.Length; i++)
            {
                   short a = ((short)(fastPower(g,k)%p));
                //   short a = ((short)(PowerMod(g,k,p)));
                short b = ((short)(BigInteger.Multiply(fastPower(y, k),text[i]) % p));
                //short b = ((short)(BigInteger.Multiply(fastPower(y, k),text[i]) % p));

                ciphertext[i * 2] = a;
                ciphertext[i * 2 + 1] = b;
                do
                {
                    k = primeArr[r.Next(0, primeArr.Length-1)];
                } while (!checks.relPrime(k, p - 1));
                
            }
            return ciphertext;
        }

        public byte[] decrypt(int p, int x, byte[] ciphertext)
        {
            byte[] text = new byte[ciphertext.Length/4];
            for (int i = 0; i < ciphertext.Length/4; i++)
            {
                text[i] = (byte)(((((BigInteger)ciphertext[i * 4 + 2]<<8) + (BigInteger)ciphertext[i * 4 + 3]) * BigInteger.Pow((ciphertext[i*4]<<8) + ciphertext[i * 4 + 1], p-1-x)) % (BigInteger)p);
            }
            return text;
        }

        public BigInteger fastPower(BigInteger baseNumber, int power)
        {
            if (power == 0)
                return 1;
            else if (power % 2 == 0)
                return fastPower(baseNumber * baseNumber, power / 2);
            else
                return baseNumber * fastPower(baseNumber, power - 1);
        }

      /*  public long PowerMod(long a, long b, long m)
        {
            long result = 1;
            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    result = (result * a) % m;
                }
                b /= 2;
                a = (a * a) % m;
            }
            return result;
        }
      */
    }
}
