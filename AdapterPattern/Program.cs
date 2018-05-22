using System;

namespace AdapterPattern
{
    class Rect
    {
        public double length;
        public double width;
    }
    class Calculator
    {
        public double GetArea(Rect rect)
        {
            return rect.length * rect.width;
        }
    }
    class Triangle
    {
        public double baseT;//base
        public double height;//height
        public Triangle(int b, int h)
        {
            this.baseT = b;
            this.height = h;
        }
    }
    class CalculatorAdapter
    {
        public double GetArea(Triangle triangle)
        {
            Calculator c = new Calculator();
            Rect rect = new Rect();
            //Area of Triangle=0.5*base*height
            rect.length = triangle.baseT;
            rect.width = 0.5 * triangle.height;
            return c.GetArea(rect);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern Demo***\n");
            CalculatorAdapter cal = new CalculatorAdapter();
            Triangle t = new Triangle(20, 10);
            Console.WriteLine("Area of Triangle is " + cal.GetArea(t) + " Square unit");
            Console.ReadKey();
        }
    }
}
