using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[101];
            for(int i = 2; i < a.Length; i++)
            {
                a[i] = 1;
            }
            Eratosthenes.PrimeNumber(a);
            for (int i = 2; i < a.Length; i++)
                if (a[i] == 1) Console.Write(i + " ");
        }
    }
}
