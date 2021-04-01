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
            string a0 = "1000001";
            Client a = new Client("张三", "北京东路100号");
            Merchandise b = new Merchandise("菲力牛排", 128.88);
            Client c = new Client("李四", "南京西路666号");
            Merchandise d = new Merchandise("豆腐巧克力", 15);
            OrderDetails b1 = new OrderDetails(b, 2, DateTime.Now);
            Thread.Sleep(10000);
            OrderDetails d1 = new OrderDetails(d, 10, DateTime.Now);
            Thread.Sleep(1000);
            Order b11 = new Order(a, b1, a0);
            Order d11 = new Order(c, d1, (Convert.ToInt32(a0) + 1).ToString());
            Order ex = new Order(a, d1, (Convert.ToInt32(a0) + 2).ToString());
            if (service.AddOrder(d11)) Console.WriteLine("Success");
            if (service.AddOrder(b11)) Console.WriteLine("success");
            //if (service.AddOrder(d11)) Console.WriteLine("Success");
            //foreach (var i in service.FindAll())
            //    Console.WriteLine(i + "\n");

            //if (service.DeleteOrder(ex)) Console.WriteLine("sUccess");
            //if (service.DeleteOrder(d11)) Console.WriteLine("success");
            if (service.AddOrder(ex)) Console.WriteLine("sUccess");
            //foreach (var i in service.FindAll())
            //    Console.WriteLine(i + "\n");
            foreach(var i in service.FindBuyer(a))
                Console.WriteLine(i+"\n");
        }
    }
}
