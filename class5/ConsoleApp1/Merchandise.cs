using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Merchandise
    {
        //商品信息
        string name;
        double price;

        //公共属性，获取对应值
        public string Name { get => name; }
        public double Price { get => price; }

        //构造函数初始化
        public Merchandise(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        //override
        public override string ToString()
        {
            return "\tmerchandise name: " + Name + "\n\tmerchandise price: " + Price;
        }
    }
}
