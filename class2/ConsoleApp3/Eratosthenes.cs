using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Eratosthenes
    {
        public static void PrimeNumber(int[] a)
        {
            for(int i = 2; i< a.Length; i++)
            {
                if(a[i] == 1)
                {
                    int j = i + 1;
                    while (j <= 100)
                    {
                        if (a[j] == 1 && j % i == 0) a[j] = 0;
                        j++;
                    }
                }
            }
        }
    }
}
