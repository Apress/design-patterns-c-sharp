using System;
using System.Collections.Generic;//We have used List<Observer> here
namespace ObserverPattern
{
    interface IObserver
    {
        void Update(int i);
    }
    class ObserverType1 : IObserver
    {
        string nameOfObserver;
        public ObserverType1(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine(" {0} has received an alert: Someone has updated myValue in Subject to: {1}", nameOfObserver,i);
        }
    }
    class ObserverType2 : IObserver
    {
        string nameOfObserver;
        public ObserverType2(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine(" {0} notified: myValue in Subject at present: {1}", nameOfObserver, i);
        }
    }

    interface ISubject
    {
        void Register(IObserver o);
        void Unregister(IObserver o);
        void NotifyRegisteredUsers(int i);
    }
    class Subject:ISubject
    {
        List<IObserver> observerList = new List<IObserver>();
        private int flag;
        public int Flag
        {
            get 
            { 
                return flag;
            }
            set
            {
                flag = value;
                //Flag value changed.So notify observer/s.
                NotifyRegisteredUsers(flag);
            }
        }
        public void Register(IObserver anObserver)
        { 
            observerList.Add(anObserver);
        }
        public void Unregister(IObserver anObserver)
        {
            observerList.Remove(anObserver);
        }
        public void NotifyRegisteredUsers(int i) 
        {
            foreach (IObserver observer in observerList)
            {
                observer.Update(i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ***Observer Pattern Demo***\n");
            //We have 3 observers- 2 of them are ObserverType1, 1 of them is of ObserverType2
            IObserver myObserver1 = new ObserverType1("Roy");
            IObserver myObserver2 = new ObserverType1("Kevin");
            IObserver myObserver3 = new ObserverType2("Bose");
            Subject subject = new Subject();
            //Registering the observers-Roy,Kevin,Bose
            subject.Register(myObserver1);
            subject.Register(myObserver2);
            subject.Register(myObserver3);
            Console.WriteLine(" Setting Flag = 5 ");
            subject.Flag = 5;           
            //Unregistering an observer(Roy))
            subject.Unregister(myObserver1);
            //No notification this time Roy.Since it is unregistered.
            Console.WriteLine("\n Setting Flag = 50 ");            
            subject.Flag = 50;
            //Roy is registering himself again
            subject.Register(myObserver1);
            Console.WriteLine("\n Setting Flag = 100 ");
            subject.Flag = 100;
            Console.ReadKey();
        }
    }
}

