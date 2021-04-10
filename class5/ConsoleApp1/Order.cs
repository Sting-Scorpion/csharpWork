using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Order
    {
        //public properties
        public Client Buyer { get; set; }
        public List<OrderDetails> OrderDetail { get; } = new List<OrderDetails>();
        public string No { get; set; }
        public double TotalPrice { get => OrderDetail.Sum(d => d.Amount); }

        public Order() { }
        public Order(Client buyer, string no)
        {
            this.No = no;
            this.Buyer = buyer;
        }
       
        //override
        public override string ToString()
        {
            string det = "detail: ";
            OrderDetail.ForEach(x => det += "\n\t" + x);
            return det + "\nclient:" + Buyer + "\npro: \torder No: " + No + "\n\ttotal price: " + TotalPrice;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            if (m != null && m.No == No && m.Buyer == Buyer) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(No);
        }
        public bool AddDetails(OrderDetails orderDetail)
        {
            if (this.OrderDetail.Contains(orderDetail))
            {
                //throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist in order {No}");
                return false;
            }
            OrderDetail.Add(orderDetail);
            return true;
        }
        public bool RemoveDetails(OrderDetails orderDetail)
        {
            if (this.OrderDetail.Contains(orderDetail))
            {
                OrderDetail.Remove(orderDetail);
                return true;
            }
            return false;
        }
        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return Convert.ToInt32(No) - Convert.ToInt32(other.No);
        }
        public IEnumerable<OrderDetails> FindTime(DateTime m)
        {
            var n =
                from a in OrderDetail
                where a.Time == m
                select a;
            return n;
        }
        public IEnumerable<OrderDetails> FindMerchandise(Merchandise m)
        {
            var n =
                from a in OrderDetail
                where a.Goods == m
                select a;
            return n;
        }
    }
}
