using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OrderDetails
    {
        //订单信息
        Merchandise goods;
        int number;
        DateTime time;

        //公共属性
        public Merchandise Goods { get => goods; }
        public int Number { get => number; }
        public DateTime Time { get => time; }

        //构造函数
        public OrderDetails(Merchandise goods, int num, DateTime time)
        {
            this.goods = goods;
            this.number = num;
            this.time = time;
        }
        //override
        public override string ToString()
        {
            return Goods.ToString() + "\n\tquantity: " + Number + "\n\torder time: " + time;
        }
        public override bool Equals(object obj)
        {
            OrderDetails m = obj as OrderDetails;
            return m != null && m.Goods == Goods && m.Number == Number;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
