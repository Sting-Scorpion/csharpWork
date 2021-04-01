using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OrderService
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
            foreach(var i in orderList)
            {
                if(i.No == obj.No)
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
            orderList.Sort((x, y) => x.No.CompareTo(y.No));
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
            orderList[orderList.IndexOf(obj)].AlterBuyer(c);
            return true;
        }

        public IEnumerable<Order> FindMerchandise(Merchandise m)
        {
            var n =
                from a in orderList
                where a.OrderDetail.Goods == m
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //根据商品查找
        public IEnumerable<Order> FindTime(DateTime m)
        {
            var n =
                from a in orderList
                where a.OrderDetail.Time == m
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //根据下单时间查找
        public IEnumerable<Order> FindBuyer(Client m)
        {
            var n =
                from a in orderList
                where a.Buyer == m
                orderby a.TotalPrice, a.No
                select a;
            return n;
        }
        //根据买家查找
        public IEnumerable<Order> FindAll()
        {
            var n =
                from a in orderList
                where a != null
                select a;
            return n;
        }
    }
}
