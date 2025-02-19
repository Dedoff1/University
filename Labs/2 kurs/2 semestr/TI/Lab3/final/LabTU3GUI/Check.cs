using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabTU3GUI
{
    public class Check
    {

        public ElGamal elGamal = new ElGamal();
        public bool prime(int x)
        {

            if (x <= 1)
            {
                return false;
            }
            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool relPrime(int a, int b)
        {
            
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a == 1 ? true : false;
        }

       
        public int [] generators(int p)
        {
            int[] generators = new int[p];
            int k = 0;

            int q = p - 1;

            int[] primDs = primDiv(q);

            for (int g = 2; g < p; g++)
            {
                    bool isGenerator = true;

                    foreach (int primeDivisor in primDs)
                    {
                        int exp = q / primeDivisor;
                        if (elGamal.fastPower(g, exp) % p == 1)
                        {
                            isGenerator = false;
                            break;
                        }
                    }

                    if (isGenerator)
                    {
                        generators[k] = g;
                        k++;
                    }
                
            }
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = generators[i];
            }

            return arr;
        }

        public int[] primDiv(int n)
        {
            int[] primDs = new int[n];
            int j = 0;

            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    primDs[j] = i;
                    j++;
                    n /= i;
                }
            }

            if (n > 1)
            {
                primDs[j] = n;
                j++;
            }
            int[] arr = new int[j]; 
            for (int i = 0; i <j; i++)
            {
                arr[i]= primDs[i];
            }

            return arr;
        }


    }

}
