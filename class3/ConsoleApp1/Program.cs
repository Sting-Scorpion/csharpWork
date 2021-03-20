using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Shape
    {
        protected double side1, side2;
        protected double area;
        public Shape(double a, double b)
        {
            side1 = a;
            side2 = b;
        }
        public virtual double Area
        {
            get { return side1 * side2; }
        }
        public abstract bool isLegal();
    }
    class Rectangle : Shape
    {
        public Rectangle(double length, double height): base(length, height)
        {

        }
        public override bool isLegal()
        {
            if (Area != 0)
                return true;
            return false;
        }
    }
    class Square : Rectangle
    {
        public Square(double side): base(side, side)
        {

        }

    }
    class Triangle : Shape
    {
        double side3;
        public Triangle(double side1, double side2, double side3) : base(side1, side2)
        {
            this.side3 = side3;
        }
        public override double Area
        {
            get { return Math.Sqrt((side1 + side2 + side3) * (side2 + side3 - side1) * (side3 + side1 - side2) * (side1 + side2 - side3) / 16); }
        }
        
        public override bool isLegal()
        {
            if (side1 + side2 <= side3) return false;
            if (side2 + side3 <= side1) return false;
            if (side3 + side1 <= side2) return false;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Square(3);
            Shape d = a;
            Console.WriteLine(a.Area + a.isLegal().ToString());
            Console.WriteLine(d.Area + d.isLegal().ToString());
        }
    }
}
