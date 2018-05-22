using System;
using System.Collections.Generic;

namespace MediatorPatternQAs
{
    interface IMediator
    {
        //Our intention is to pass a message from 'fromFriend' to 'toFriend'.
        void Send(Friend fromFriend, Friend toFriend, string msg);
    }
    // ConcreteMediator
    class ConcreteMediator : IMediator
    {
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

                Console.WriteLine("{0} .Status:{1}", friend.Name, friend.Status);
            }
        }
        //Mediator is maintaining the control logic.
        //Message will go from fromFriend to toFriend if toFriend is Online only.
        //But only registered users can post messages.
        public void Send(Friend fromFriend,Friend toFriend, string msg)
        {
            if (participants.Contains(fromFriend))
            {
                if (toFriend.Status == "On")
                {
                    Console.WriteLine(String.Format("[{0}->{1}] : {2} Last message posted {3}", fromFriend.Name, toFriend.Name, msg, DateTime.Now));
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine(String.Format("[{0}->{1}] : {2}, you cannot post messages now. {3} is offline.", fromFriend.Name, toFriend.Name, fromFriend.Name, toFriend.Name));

                }
            }
            else
            {
                Console.WriteLine("An outsider named {0} trying to send some messages", fromFriend.Name);
            }
        }
    }
    // Friend
    abstract class Friend
    {
        protected IMediator mediator;
        private string name;
        private string status;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
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
            this.Status = "On";
        }
        //Message will go to the intended friend.
        public void Send(Friend intendedFriend,string msg)
        {
            mediator.Send(this,intendedFriend, msg);
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
            this.Status = "On";
        }
        //Message will go to the intended friend.
        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this,intendedFriend, msg);
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
            this.Status = "On";
        }
        //Message will go to the intended friend.
        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this,intendedFriend, msg);
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
            this.Status = "On";
        }

        public void Send(Friend intendedFriend, string msg)
        {
            mediator.Send(this, intendedFriend, msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Modified Mediator Pattern Demo***\n");

            ConcreteMediator mediator = new ConcreteMediator();

            Friend1 Amit = new Friend1(mediator, "Amit");
            Friend2 Sohel = new Friend2(mediator, "Sohel");
            Boss Raghu = new Boss(mediator, "Raghu");
           
            mediator.Register(Amit);
            mediator.Register(Sohel);
            mediator.Register(Raghu);
            mediator.DisplayDetails();

            Amit.Send(Sohel,"Hi Sohel,can we discuss the mediator pattern?");
            Sohel.Send(Amit,"Hi Amit,Yup, we can discuss now.");
            Raghu.Send(Amit,"Please get back to work quickly.");
            Raghu.Send(Sohel, "Please get back to work quickly.");

            //Changing the status of Sohel
            Sohel.Status = "Off";
            //Checking Current Status
            mediator.DisplayDetails();
            Amit.Send(Sohel,"I am testing to send a message when Sohel is in Off state");
            
            //Sohel is coming online again.
            Sohel.Status = "On";
            //Checking Current Status
            mediator.DisplayDetails();
            Amit.Send(Sohel,"I am testing to send a message when Sohel in On state again");
            //Amit is going offline.
            Amit.Status = "Off";
            //Checking Current Status
            mediator.DisplayDetails();

            Raghu.Send(Amit, "Can you please come here?");
            Raghu.Send(Sohel, "Can you please come here?");

            //An outsider/unknown person tries to participate
            Unknown unknown = new Unknown(mediator, "Jack");
            unknown.Send(Amit,"Hello Amit..");

            // Wait for user 
            Console.Read();
        }
    }
}
