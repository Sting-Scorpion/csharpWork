using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Merchandise
    {
       //公共属性，获取对应值
        public string Name { get; set; }
        public double Price { get; set; }

        //构造函数初始化
        public Merchandise() { }
        public Merchandise(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        //override
        public override string ToString()
        {
            return "\tmerchandise name: " + Name + "\n\tmerchandise price: " + Price;
        }
    }
}
