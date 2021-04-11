using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            int[,] matrix2 = { { 1, 2, 3, 4 }, { 5, 1, 2, 2 }, { 9, 5, 1, 2 } };
            if (isToeplitz(matrix1))
                Console.WriteLine("1 Yes");
            else
                Console.WriteLine("1 No");
            if (isToeplitz(matrix2))
                Console.WriteLine("2 Yes");
            else
                Console.WriteLine("2 No");
        }
        static bool isToeplitz(int[,] a)
        {
            int a1 = a.Rank;
            int a2 = a.GetLength(0);
            for(int i = 0; i < a1; i++)
                for(int j = 0; j < a2; j++)
                {
                    if (a[i, j] != a[i + 1, j + 1])
                        return false;
                }
            return true;
        }
    }
}
