using System;
using System.Linq;//For Contains() method below

namespace ProxyPatternQAs
{
    /// <summary>
    /// Abstract class Subject
    /// </summary>
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }
    /// <summary>
    /// ConcreteSubject class
    /// </summary>
    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("ConcreteSubject.DoSomeWork()");
        }
    }
    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject cs;
        string[] registeredUsers;
        string currentUser;
        public Proxy(string currentUser)
        {
            //Avoiding to instantiate inside the constructor
            //cs = new ConcreteSubject();
            //Registered users
            registeredUsers =new string[]{ "Admin","Rohit","Sam"};
            this.currentUser = currentUser;
        }
        public override void DoSomeWork()
        {
            Console.WriteLine("\nProxy call happening now...");
            Console.WriteLine("{0} wants to invoke a proxy method.",currentUser);
            if (registeredUsers.Contains(currentUser))
            {
                //Lazy initialization:We'll not instantiate until the method is called
                if (cs == null)
                {
                    cs = new ConcreteSubject();
                }
                cs.DoSomeWork();
            }
            else
            {
                Console.WriteLine("Sorry {0}, you do not have access.", currentUser);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Proxy Pattern Demo***");
            //Authorized user-Admin
            Proxy px1 = new Proxy("Admin");
            px1.DoSomeWork();
            //Unwanted User- Robin
            Proxy px2 = new Proxy("Robin");
            px2.DoSomeWork();
            Console.ReadKey();
        }
    }
}
