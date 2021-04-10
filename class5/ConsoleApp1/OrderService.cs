using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace ConsoleApp1
{
    [Serializable]
    public class OrderService
    {
        List<Order> orderList = new List<Order>();

        public double TotalPrice
        {
            get
            {
                double sum = 0;
                foreach (var i in orderList) sum += i.TotalPrice;
                return sum;
            }
        }
        public double Coupon
        {
            get
            {
                if (TotalPrice >= 1000)
                    return 150;
                if (TotalPrice >= 400)
                    return 40;
                if (TotalPrice >= 200)
                    return 15;
                return 0;
            }
        }
        public double FinalPrice { get => TotalPrice - Coupon; }

        public bool Exist(Order obj)
        {
            int r = orderList.IndexOf(obj);//find the location of 'obj' in orderList
            return r != -1;//if 'obj' not exist, r equals -1
        }
        public bool AddOrder(Order obj)
        {
            bool q = true;
            foreach (var i in orderList)
            {
                if (i.No == obj.No)
                {
                    q = false;
                }
            }//check whether 'obj' has been added in orderList
            if (!q)
            {
                Console.WriteLine("Order is in the list.");
                return false;
            }
            orderList.Add(obj);
            orderList.Sort((x, y) => x.No.CompareTo(y.No));
            return true;
        }
        public bool DeleteOrder(Order obj)
        {
            if (!Exist(obj))
            {
                Console.WriteLine("Order is not in the list.");
                return false;
            }
            orderList.Remove(obj);
            return true;
        }
        public bool ModifyOrder(Order obj, Client c)
        {
            if (!Exist(obj))
            {
                Console.WriteLine("Order is not in the list.");
                return false;
            }
            //Can only modify the order's buyer's info
            orderList[orderList.IndexOf(obj)].Buyer = c;
            return true;
        }

        //根据商品查找
        public IEnumerable<Order> FindMerchandise(Merchandise m)
        {
            var n =
                from a in orderList
                where a.FindMerchandise(m) != null
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //根据下单时间查找
        public IEnumerable<Order> FindTime(DateTime m)
        {
            var n =
                from a in orderList
                where a.FindTime(m) != null
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //根据买家查找
        public IEnumerable<Order> FindBuyer(Client m)
        {
            var n =
                from a in orderList
                where a.Buyer == m
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //全部
        public IEnumerable<Order> FindAll()
        {
            var n =
                from a in orderList
                where a != null
                select a;
            return n;
        }

        //序列化
        public bool Export()
        {
            string path = System.Environment.CurrentDirectory;
            return Export(path);
        }
        public bool Export(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            Stream stream = new FileStream(path + "\\Orders.xml", FileMode.OpenOrCreate);
            xml.Serialize(stream, orderList);
            //stream.Close();
            return true;
        }
        //反序列化
        public bool Import()
        {
            string path = System.Environment.CurrentDirectory;
            return Import(path);
        }
        public bool Import(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            Stream stream = new FileStream(path + "\\Orders.xml", FileMode.OpenOrCreate);
            var oL = (List<Order>)xml.Deserialize(stream);
            oL.ForEach(x => { if (!Exist(x)) orderList.Add(x); });//反序列化结果不重复地添加到已有list中
            stream.Close();
            //using(FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    List<Order> orders = (List<Order>)xml.Deserialize(fs);
            //    orders.ForEach(x => orderList.Add(x));
            //}
            return true;
        }
    }
}
