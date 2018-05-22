using System;
namespace GarbageCollectionQuiz1
{
    class MyClass : IDisposable
    {
        public void DoSomething()
        {
            Console.WriteLine("MyClass.DoSomething");
        }
        public void Dispose()
        {
            //GC.SuppressFinalize(this);
            Console.WriteLine("MyClass.Dispose() is called");
        }
        ~MyClass()
        {
            Console.WriteLine("MyClass.Destructor is Called..");
            System.Threading.Thread.Sleep(15000);            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Quiz on Garbage Collections***");
            MyClass myOb = new MyClass();
            myOb.DoSomething();
            myOb.Dispose();
            Console.ReadKey();
        }
    }
}

