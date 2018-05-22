using System;

namespace DecoratorPattern
{
    abstract class Component
    {
        public abstract void MakeHouse();
        
    }
    class ConcreteComponent : Component
    {
        public override void MakeHouse()
        {            
            Console.WriteLine("Original House is complete. It is closed for modification.");            
        }
    }

    abstract class AbstractDecorator : Component
    {
        protected Component com ;
        public void SetTheComponent(Component c)
        {
            com = c;
        }
        public override void MakeHouse()
        {
            if (com != null)
            {
                com.MakeHouse();//Delegating the task
            }
        }
       
    }
    class ConcreteDecoratorEx1 : AbstractDecorator
    {
        public  override void MakeHouse()
        {            
            base.MakeHouse();
            Console.WriteLine("***Using a decorator***");
            //Decorating now.
            AddFloor();
            //You can put additional stuffs as per your need
        }
        private void AddFloor()
        {
            Console.WriteLine("I am making an additional floor on top of it.");
        }
    }
    class ConcreteDecoratorEx2 : AbstractDecorator
    {
        public  override void MakeHouse()
        {
            Console.WriteLine("");            
            base.MakeHouse();
            Console.WriteLine("***Using another decorator***");
            //Decorating now.          
            PaintTheHouse();
            //You can put additional stuffs as per your need
        }
        private void PaintTheHouse()
        {
            Console.WriteLine("Now I am painting the house.");         
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator pattern Demo***\n");
            ConcreteComponent cc = new ConcreteComponent();
            
            //ConcreteDecoratorEx1 decorator1 = new ConcreteDecoratorEx1();
            AbstractDecorator decorator1 = new ConcreteDecoratorEx1();
            decorator1.SetTheComponent(cc);
            decorator1.MakeHouse();

            //ConcreteDecoratorEx2 decorator2 = new ConcreteDecoratorEx2();
            AbstractDecorator decorator2 = new ConcreteDecoratorEx2();
            //Adding results from decorator1
            decorator2.SetTheComponent(decorator1);
            decorator2.MakeHouse();

            Console.ReadKey();
        }
    }
}
