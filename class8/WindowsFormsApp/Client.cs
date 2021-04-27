using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    [Serializable]
    public class Client
    {
        //公共属性
        public string Name { get; set; }
        public string Address { get; set; }

        //构造函数
        public Client() { }
        public Client(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
        //override
        public override string ToString()
        {
            return "\tclient name: " + Name + "\n\tclient's delivery address: " + Address;
        }
    }
}
