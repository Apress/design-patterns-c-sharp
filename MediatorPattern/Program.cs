using System;
using System.Collections.Generic;

namespace MediatorPattern
{
    interface IMediator
    {
        void Register(Friend friend);
        void Send(Friend friend, string msg);        
    }
    // ConcreteMediator
    class ConcreteMediator : IMediator
    {
        //private Friend friend1,friend2,boss;        
        List<Friend> participants = new List<Friend>();        
        public void Register(Friend friend)
        {
            participants.Add(friend);
        }       
        public void DisplayDetails()
        {
            Console.WriteLine("At present ,registered Participants are:");
            foreach (Friend friend in participants)
            {
                
                Console.WriteLine("{0}", friend.Name);
            }
        }
        public void Send(Friend friend, string msg)
        {
            if (participants.Contains(friend))
            {
                Console.WriteLine(String.Format("[{0}] posts: {1} Last message posted {2}", friend.Name, msg, DateTime.Now));
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("An outsider named {0} trying to send some messages", friend.Name);
            }
        }
    }
    // Friend
    abstract class Friend
    {
        protected IMediator mediator;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Constructor 
        public Friend(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
    // Friend1-first participant
    class Friend1 : Friend
    {
        public Friend1(IMediator mediator, string name)
            : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this,msg);
        }        
    }
    // Friend2-Second participant
    class Friend2 : Friend
    {
        // Constructor 
        public Friend2(IMediator mediator, string name)
            : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }        
    }
    /* Friend3-Third Participant.He is the boss.*/
    class Boss : Friend
    {
        // Constructor 
        public Boss(IMediator mediator, string name)
            : base(mediator)
        {
            this.Name = name;
        }
        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }        
    }
    // Friend4-4th participant who will not register himself to the mediator.
    //Still he will try to send a message.
    class Unknown : Friend
    {
        // Constructor 
        public Unknown(IMediator mediator, string name)
            : base(mediator)
        {
            this.Name = name;
        }

        public void Send(string msg)
        {
            mediator.Send(this, msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Mediator Pattern Demo***\n");

            ConcreteMediator mediator = new ConcreteMediator();

            Friend1 Amit = new Friend1(mediator, "Amit");
            Friend2 Sohel = new Friend2(mediator, "Sohel");
            Boss Raghu = new Boss(mediator, "Raghu");

            //Registering participants
            mediator.Register(Amit);
            mediator.Register(Sohel);
            mediator.Register(Raghu);
            //Displaying the participant's list
            mediator.DisplayDetails();

            Console.WriteLine("Communication starts among participants...");
            Amit.Send("Hi Sohel,can we discuss the mediator pattern?");
            Sohel.Send("Hi Amit,Yup, we can discuss now.");
            Raghu.Send("Please get back to work quickly.");

            //An outsider/unknown person tries to participate
            Unknown unknown = new Unknown(mediator, "Jack");
            unknown.Send("Hello Guys..");

            // Wait for user 
            Console.Read();
        }
    }
}
