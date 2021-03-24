using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program2
    {
        static void Main()
        {
			//未加入工厂设计模式！
            double allArea = 0;
            Shape[] shapes = new Shape[10];
            for(int i = 0; i < 10; i++)
            {
                if (i % 3 == 0) shapes[i] = new Square(i);
                if (i % 3 == 1) shapes[i] = new Rectangle(i - 1, i + 2);
                if (i % 3 == 2) shapes[i] = new Triangle(i - 1, i, i + 1);
                Console.Write("Shape " + (i + 1) + " is ");
                if (shapes[i].isLegal()) Console.WriteLine("legal.");
                else Console.WriteLine("illegal.");
                Console.WriteLine("\tIt's area is " + shapes[i].Area);
            }
            foreach(Shape s in shapes)
            {
                if (s.isLegal()) allArea += s.Area;
            }
            Console.WriteLine("All legal shapes' area is " + allArea);
        }
    }
}
