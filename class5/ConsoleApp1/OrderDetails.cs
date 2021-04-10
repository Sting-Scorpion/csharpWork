using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class OrderDetails
    {
        //公共属性
        public Merchandise Goods { get; set; }
        public int Number { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get => Goods.Price * Number; }

        //构造函数
        public OrderDetails() { }
        public OrderDetails(Merchandise goods, int num, DateTime time)
        {
            this.Goods = goods;
            this.Number = num;
            this.Time = time;
        }
        //override
        public override string ToString()
        {
            return Goods + "\n\tquantity: " + Number + "\n\tamount: " + Amount + "\n\torder time: " + Time;
        }
        public override bool Equals(object obj)
        {
            OrderDetails m = obj as OrderDetails;
            return m != null && m.Goods == Goods && m.Number == Number;
        }
        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Merchandise>.Default.GetHashCode(Goods);
        }
    }
}
