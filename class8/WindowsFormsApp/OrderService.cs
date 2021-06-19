using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using WindowsFormsApp.Model;

namespace WindowsFormsApp
{
    [Serializable]
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();

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
            try
            {
                using (var db = new OrderingContext())
                {
                    Order post = new Order();
                    if(db.Orders.Count() != 0) {
                        post = db.Orders.FirstOrDefault(o => o.OrderID == obj.OrderID);
                    }
                    
                    if (post == null)
                    {
                        db.Orders.Add(obj);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }

            }
            catch (InvalidCastException e)
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            //bool q = true;
            //foreach (var i in orderList)
            //{
            //    if (i.OrderID == obj.OrderID)
            //    {
            //        q = false;
            //    }
            //}//check whether 'obj' has been added in orderList
            //if (!q)
            //{
            //    Console.WriteLine("Order is in the list.");
            //    return false;
            //}
            //orderList.Add(obj);
            //orderList.Sort((x, y) => x.OrderID.CompareTo(y.OrderID));
            //return true;
        }
        public bool DeleteOrder(Order obj)
        {
            try
            {
                using (var db = new OrderingContext())
                {
                    Order post = new Order();
                    if (db != null)
                    {
                        post = db.Orders.FirstOrDefault(o => o.OrderID == obj.OrderID);
                    }
                    if (post != null)
                    {
                        db.Orders.Remove(post);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            //if (!Exist(obj))
            //{
            //    Console.WriteLine("Order is not in the list.");
            //    return false;
            //}
            //orderList.Remove(obj);
            //return true;
        }
        public bool ModifyOrder(Order obj, Client c)
        {
            if (!DeleteOrder(obj))
            {
                return false;
            }
            obj.Buyer = c;
            if (!AddOrder(obj))
            {
                return false;
            }
            return true;
            //if (!Exist(obj))
            //{
            //    Console.WriteLine("Order is not in the list.");
            //    return false;
            //}
            ////Can only modify the order's buyer's info
            //orderList[orderList.IndexOf(obj)].Buyer = c;
            //return true;
        }

        //根据商品查找
        public IEnumerable<Order> FindMerchandise(string m)
        {
            try
            {
                using (var db = new OrderingContext())
                {
                    var n = db.Orders.
                        Where(a => a.FindMerchandise(m) != null)
                        .OrderBy(a => a.TotalPrice).OrderBy(a => a.OrderID);
                    return n;
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }
        //根据下单时间查找
        public IEnumerable<Order> FindTime(string m)
        {
            try
            {
                using (var db = new OrderingContext())
                {
                    var n = db.Orders.
                        Where(a => a.FindTime(m) != null)
                        .OrderBy(a => a.TotalPrice).OrderBy(a => a.OrderID);
                    return n;
                }
            }
            catch (FormatException e)
            {
                throw e;
            }

        }
        //根据买家查找
        public IEnumerable<Order> FindBuyer(string m)
        {
            try
            {
                using (var db = new OrderingContext())
                {
                    var n = db.Orders.
                         Where(a => a.Buyer.Name == m)
                         .OrderBy(a => a.TotalPrice).OrderBy(a => a.OrderID);
                    return n;
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }
        //全部
        public IEnumerable<Order> FindAll(string m)
        {
            try
            {
                using (var db = new OrderingContext())
                {
                    var n = db.Orders.
                        Where(a => a != null);
                    return n;
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        //序列化
        public bool Export()
        {
            string path = Environment.CurrentDirectory;
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
            string path = Environment.CurrentDirectory;
            return Import(path);
        }
        public bool Import(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            Stream stream = new FileStream(path/* + "\\Orders.xml"*/, FileMode.OpenOrCreate);
            var oL = (List<Order>)xml.Deserialize(stream);
            oL.ForEach(x => { if (!Exist(x)) orderList.Add(x); });//反序列化结果不重复地添加到已有list中
            stream.Close();
            return true;
        }
    }
}
