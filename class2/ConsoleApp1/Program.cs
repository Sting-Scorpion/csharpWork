using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// 分解素因数
        /// 待改进：函数返回值为数组
        ///解决：返回值为List的函数，递归嵌套，每出一个因子Add一个进入List
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Resolve a1 = new Resolve();
            Console.Write("Input a number: ");
            a1.Num = Convert.ToInt32(Console.ReadLine());
            a1.ResolveNum(a1.Num, 2);
        }
    }
    class Resolve
    {
        int num;
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        public void ResolveNum(int a, int i)
        {
            if(a < 1)
            {
                Console.WriteLine("Cannot Resolve");
                return;
            }
            if (a == 1) return;
            if(a % i == 0)
            {
                Console.Write(i + " ");
                a /= i;
            }
            else
            {
                i++;
            }
            ResolveNum(a, i);
        }
    }
}
