using System;
using System.Collections.Generic;


namespace MemoryLeakWithSimpleEventDemo
{
    public delegate string MyDelegate(string str);

    //class SimpleEventClass
    class SimpleEventClass:IDisposable
    {
        public int Id { get; set; }

        public event MyDelegate SimpleEvent;
        public bool disposed = false;

        public SimpleEventClass()
        {
            SimpleEvent += new MyDelegate(PrintText);
        }
        public string PrintText(string text)
        {
            return text;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Use this section to cleanup managed objects
                //In our case, we are just clearing the event subscription
                if (this.SimpleEvent != null)
                {
                    this.SimpleEvent -= new MyDelegate(PrintText);
                    Console.WriteLine("Unsubscribed");
                }
                //Use this section to cleanup unmanaged objects/resources(if any)
                //....
                disposed = true;
            }
        }

        ~SimpleEventClass()
        {
            Dispose(false);
        }

        static void Main(string[] args)
        {
            IDictionary<int, SimpleEventClass> col = new Dictionary<int, SimpleEventClass>();
            for (int currentObjectNo = 0; currentObjectNo < 500000; currentObjectNo++)
            {
                using (col[currentObjectNo] = new SimpleEventClass { Id = currentObjectNo })
                {
                    //col[currentObjectNo] = new SimpleEventClass { Id = currentObjectNo };
                    string result = col[currentObjectNo].SimpleEvent("Raising an event ");
                    Console.WriteLine(currentObjectNo);
                    //col[currentObjectNo].Dispose();
                    //We are indicating that the object is now ready for GC
                    col[currentObjectNo] = null;                
                 }
            }
            Console.ReadKey();
        }        
    }
}

