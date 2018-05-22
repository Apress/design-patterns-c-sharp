using System;

namespace VisitorPattern
{
    interface IOriginalInterface
    {
        void Accept(IVisitor visitor);
    }
     class MyClass : IOriginalInterface
    {
         private int myInt = 5;//Initial or default value

         public int MyInt
         {
             get
             {
                 return myInt;
             }
             set
             {
                 myInt = value;
             }
         }
        public void Accept(IVisitor visitor) 
        {             
            Console.WriteLine("Initial value of the integer:{0}", myInt);
            visitor.Visit(this);
            Console.WriteLine("\nValue of the integer now:{0}", myInt);                   
        }
    }

    interface IVisitor
    {
        void Visit(MyClass myClassElement);
    }
    class Visitor : IVisitor
    {
        public void Visit(MyClass myClassElement)
        {
            Console.WriteLine("Visitor is trying to change the integer value.");            
             myClassElement.MyInt = 100;
            Console.WriteLine("Exiting from Visitor.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Visitor Pattern Demo***\n");
            IVisitor visitor = new Visitor();
            MyClass myClass = new MyClass();
            myClass.Accept(visitor);            
            Console.ReadLine();
        }
    }
}
