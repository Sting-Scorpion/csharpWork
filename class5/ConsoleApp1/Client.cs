using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Client
    {
        //客户信息
        string name, address;

        //公共属性
        public string Name { get => name; }
        public string Address { get => address; }

        //构造函数
        public Client(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
        //override
        public override string ToString()
        {
            return "\tclient name: " + Name + "\n\tclient's delivery address: " + address;
        }
    }
}
