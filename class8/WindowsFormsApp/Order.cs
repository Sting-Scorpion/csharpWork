using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp
{
    [Serializable]
    public class Order
    {
        //public properties
        [Key]
        public string OrderID { get; set; }
        public Client Buyer { get; set; }
        public List<OrderDetails> OrderDetail { get; set; } = new List<OrderDetails>();
        public double TotalPrice { get => OrderDetail.Sum(d => d.Amount); }

        public Order() { }
        public Order(Client buyer, string no)
        {
            this.OrderID = no;
            this.Buyer = buyer;
        }
       
        //override
        public override string ToString()
        {
            string det = "detail: ";
            OrderDetail.ForEach(x => det += "\n\t" + x);
            return det + "\nclient:" + Buyer + "\npro: \torder No: " + OrderID + "\n\ttotal price: " + TotalPrice;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            if (m != null && m.OrderID == OrderID && m.Buyer == Buyer) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(OrderID);
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
            return Convert.ToInt32(OrderID) - Convert.ToInt32(other.OrderID);
        }
        public IEnumerable<OrderDetails> FindTime(string m)
        {
            var n =
                from a in OrderDetail
                where a.Time == m
                select a;
            return n;
        }
        public IEnumerable<OrderDetails> FindMerchandise(String m)
        {
            var n =
                from a in OrderDetail
                where a.Goods.Name == m
                select a;
            return n;
        }
    }
}
