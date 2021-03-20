using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// 找数组的最大最小值，平均值及求和
        /// 待改进：用多返回值函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DealIntArray deal = new DealIntArray();
            deal.Str();
            Console.WriteLine("The max num in array is " + deal.StrMax());
            Console.WriteLine("The min num in array is " + deal.StrMin());
            Console.WriteLine("The sum of array is " + deal.StrSum());
            Console.WriteLine("The average of array is " + deal.StrAve());
        }
    }
    class DealIntArray
    {
        int[] str;
        public void Str()
        {
            var str1 = Console.ReadLine().Split().ToArray();
            str = Array.ConvertAll<string, int>(str1, s => int.Parse(s));
        }
        public int StrMax()
        {
            if (StrEmpty()) return 0;
            return str.Max();
        }
        public int StrMin()
        {
            if (StrEmpty()) return 0;
            return str.Min();
        }
        public int StrSum()
        {
            if (StrEmpty()) return 0;
            int sum = 0;
            foreach(var i in str)
            {
                sum += i;
            }
            return sum;
        }
        public double StrAve()
        {
            if (StrEmpty()) return 0;
            double sum = StrSum();
            double ave = sum / str.Length;
            return ave;
        }
        bool StrEmpty()
        {
            if (str.Length == 0)
            {
                Console.WriteLine("ArrayEmpty");
                return true;
            }
            else
                return false;
        }
    }
}
