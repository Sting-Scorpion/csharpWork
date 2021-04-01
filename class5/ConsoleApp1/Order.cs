using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Order
    {
        //orders' info
        Client buyer;
        OrderDetails orderDetail;
        string no;

        //public properties
        public Client Buyer { get => buyer; }
        public OrderDetails OrderDetail { get => orderDetail; }
        public string No { get => no; }
        public double TotalPrice { get => orderDetail.Number * orderDetail.Goods.Price; }


        public Order(Client buyer, OrderDetails orderDetail, string no)
        {
            this.no = no;
            this.buyer = buyer;
            this.orderDetail = orderDetail;
        }
        public void AlterBuyer(Client b)
        {
            buyer = b;
        }

        //override
        public override string ToString()
        {
            return "detail:"+orderDetail.ToString() + "\nclient:" + Buyer.ToString() + "\npro: \torder No: " + No + "\n\ttotal price: " + TotalPrice;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            if (m != null && m.No == No && m.Buyer == Buyer && m.OrderDetail == OrderDetail) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(No);
        }
    }
}
