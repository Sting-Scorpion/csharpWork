using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            //string a0 = "1000001";

            //Client a1 = new Client("张三", "北京东路100号");
            //Merchandise m1 = new Merchandise("菲力牛排", 128.88);
            //Client a2 = new Client("李四", "南京西路666号");
            //Merchandise m2 = new Merchandise("豆腐巧克力", 15);

            //OrderDetails b1 = new OrderDetails(m1, 2, DateTime.Now);
            //Thread.Sleep(3000);
            //OrderDetails b2 = new OrderDetails(m2, 10, DateTime.Now);
            //Thread.Sleep(3000);
            //OrderDetails b3 = new OrderDetails(m2, 5, DateTime.Now);

            //Order b11 = new Order(a1, a0);
            //b11.AddDetails(b1);
            //b11.AddDetails(b3);//牛排2，巧克力5
            //Order b21 = new Order(a2, (Convert.ToInt32(a0) + 1).ToString());
            //b21.AddDetails(b2);//巧克力10

            //foreach (var i in service.FindAll())
            //    Console.WriteLine(i + "\n");
            //service.Export();


            //service.Import();
            //foreach(var i in service.FindAll())
            //{
            //    Console.WriteLine(i + "\n");
            //}
        }
    }
}
