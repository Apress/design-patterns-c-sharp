using System;
namespace AdapterPattern_Modified
{
    interface RectInterface
    {
        void AboutRectangle();
        double CalculateAreaOfRectangle();        
    }
    class Rect : RectInterface
    {
        public double Length;
        public double Width;
        public Rect(double l, double w)
        {
            this.Length = l;
            this.Width = w;
        }

        public double CalculateAreaOfRectangle()
        {
            return Length * Width;
        }

        public void AboutRectangle()
        {
            Console.WriteLine(" Actually, I am a Rectangle");
        }
    }
    

    interface TriInterface
    {
        void AboutTriangle();
        double CalculateAreaOfTriangle();
    }
    class Triangle : TriInterface
    {
        public double BaseLength;//base
        public double Height;//height
        public Triangle(double b, double h)
        {
            this.BaseLength = b;
            this.Height = h;
        }

        public double CalculateAreaOfTriangle()
        {
            return 0.5 * BaseLength * Height;
        }
        public void AboutTriangle()
        {
            Console.WriteLine(" Actually, I am a Triangle");
        }
    }
   
    /*TriangleAdapter is implementing RectInterface.
     So, it needs to implement all the methods defined
    in the target interface.*/
    class TriangleAdapter:RectInterface
    {
        Triangle triangle;//Adaptee
        public TriangleAdapter(Triangle t)
        {
            this.triangle = t;
        }

        public void AboutRectangle()
        {
            triangle.AboutTriangle();
        }

        public double CalculateAreaOfRectangle()
        {
            return triangle.CalculateAreaOfTriangle();          
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adapter Pattern Modified Demo***\n");
            //CalculatorAdapter cal = new CalculatorAdapter();
            Rect r = new Rect(20, 10);
            Console.WriteLine("Area of Rectangle is :{0} Square unit", r.CalculateAreaOfRectangle());
            Triangle t = new Triangle(20, 10);
            Console.WriteLine("Area of Triangle is :{0} Square unit", t.CalculateAreaOfTriangle());
            RectInterface adapter = new TriangleAdapter(t);
            //Passing a Triangle instead of a Rectangle
            Console.WriteLine("Area of Triangle using the triangle adapter is :{0} Square unit", GetArea(adapter));
            Console.ReadKey();
        }
        /*GetArea(RectInterface r) method  does not know that through TriangleAdapter , 
        it is getting a Triangle instead of a Rectangle*/
        static double GetArea(RectInterface r)
        {
            r.AboutRectangle();
            return r.CalculateAreaOfRectangle();
        }        
    }
}
