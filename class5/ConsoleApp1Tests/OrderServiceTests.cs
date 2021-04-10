using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        static OrderService service = new OrderService();
        static Order b11;
        static Merchandise m1;
        static OrderDetails b1;
        static Client a1;
        static TestContext context;

        [ClassInitialize]
        public static void Init(TestContext testcontext)
        {
            context = testcontext;
            string a0 = "1000001";
            a1 = new Client("张三", "北京东路100号");
            m1 = new Merchandise("菲力牛排", 128.88);
            b1 = new OrderDetails(m1, 2, DateTime.Now);
            b11 = new Order(a1, a0);
            b11.AddDetails(b1);

            Client a2 = new Client("李四", "南京西路666号");
            Merchandise m2 = new Merchandise("豆腐巧克力", 15);
            OrderDetails b2 = new OrderDetails(m2, 10, DateTime.Now);
            Order b21 = new Order(a2, (Convert.ToInt32(a0) + 1).ToString());
            b21.AddDetails(b2);

            service.AddOrder(b11);
            service.AddOrder(b21);
        }
        [TestMethod()]
        public void ExistTest1()
        {
            bool n = service.Exist(b11);
            Assert.IsTrue(n);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService se = new OrderService();
            var n = se.AddOrder(b11);
            Assert.IsTrue(n);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService se = Clone(service);
            var n = se.DeleteOrder(b11);
            Assert.IsTrue(n);
        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            OrderService se = Clone(service);
            Client c = new Client("wanng", "Fifth Avenue");
            var n = se.ModifyOrder(b11, c);
            Assert.IsTrue(n);
        }

        [TestMethod()]
        public void FindMerchandiseTest()
        {
            var n = service.FindMerchandise(m1);
            Assert.IsNotNull(n);
        }

        [TestMethod()]
        public void FindTimeTest()
        {
            var n = service.FindTime(b11.OrderDetail[0].Time);
            Assert.IsNotNull(n);
        }

        [TestMethod()]
        public void FindBuyerTest()
        {
            var n = service.FindBuyer(a1);
            Assert.IsNotNull(n);
        }

        [TestMethod()]
        public void ExportTest()
        {
            var n = service.Export();
            Assert.IsTrue(n);
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService se = new OrderService();
            var n = se.Import();
            Assert.IsTrue(n);
        }

        public static OrderService Clone(OrderService l)
        {
            OrderService os = new OrderService();
            foreach(var i in l.FindAll())
            {
                Order or = new Order();
                foreach(var j in i.OrderDetail)
                {
                    int n = j.Number;
                    DateTime d = j.Time;
                    string n1 = j.Goods.Name;
                    double n2 = j.Goods.Price;
                    Merchandise m = new Merchandise(n1, n2);
                    OrderDetails od = new OrderDetails(m, n, d);
                    or.AddDetails(od);
                }
                or.Buyer = i.Buyer;
                or.No = i.No;
                os.AddOrder(or);
            }
            return os;
        }
    }
}