using System;

namespace CommandPatternQAs
{
    public interface ICommand
    {
        void Do();
        void UnDo();
    }
    public class AdditionCommand : ICommand
    {
        private IReceiver receiver;
        public AdditionCommand(IReceiver recv)
        {
            receiver = recv;
        }
        public void Do()
        {
            receiver.OptionalTasksPriorProcessing();
            receiver.Add2WithNumber();            
            receiver.OptionalTasksPostProcessing();
        }
        public void UnDo()
        {
            Console.WriteLine("Trying undoing addition...");
            receiver.Remove2FromNumber();
            Console.WriteLine("Undo request processed.");
        }
    }
    //To deal with multiple receivers , we are using interfaces here
    public interface IReceiver
    {
        //It will add 2 with a number
        void Add2WithNumber();
        //It will substract 2 from a number
        void Remove2FromNumber();
        //Optional methods
        //PreProcessing task/s
        void OptionalTasksPriorProcessing();
        //PostProcessing task/s
        void OptionalTasksPostProcessing();
    }
    //Receiver Class
    public class Receiver1 : IReceiver
    {
        int myNumber;
        public int MyNumber
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }
        public Receiver1()
        {
            myNumber = 10;
            Console.WriteLine("Receiver1 initialized with {0}", myNumber);
            Console.WriteLine("The objects of receiver1 cannot set beyond {0}", myNumber);
        }
        //PreProcessing task/s
        public void OptionalTasksPriorProcessing()
        {
            Console.WriteLine("Receiver1.OptionalTaskPriorProcessing");
        }
        //PostProcessing task/s
        public void OptionalTasksPostProcessing()
        {
            Console.WriteLine("Receiver1.OptionalTaskPostProcessing\n");
        }
        public void Add2WithNumber()
        {
            int presentNumber = this.MyNumber;
            this.MyNumber = this.MyNumber + 2;
            Console.WriteLine("{0}+2={1}", presentNumber, this.MyNumber);
        }
        public void Remove2FromNumber()
        {
            int presentNumber = this.MyNumber;
            //We started with number 10.We'll not decrese further.
            if (presentNumber > 10)
            {
                this.MyNumber = this.MyNumber - 2;
                Console.WriteLine("{0}-2={1}", presentNumber, this.MyNumber);
            }
            else
            {
                Console.WriteLine("Nothing more to undo...");
            }
        }
    }
    //Receiver Class
    public class Receiver2 : IReceiver
    {
        int myNumber;
        public int MyNumber
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }
        public Receiver2()
        {
            myNumber = 75;
            Console.WriteLine("Receiver2 initialized with {0}", myNumber);
            Console.WriteLine("The objects of receiver2 cannot set beyond {0}", myNumber);
        }
        //PreProcessing task/s
        public void OptionalTasksPriorProcessing()
        {
            Console.WriteLine("Receiver2.OptionalTaskPriorProcessing");
        }
        //PostProcessing task/s
        public void OptionalTasksPostProcessing()
        {
            Console.WriteLine("Receiver2.OptionalTaskPostProcessing");
        }
        public void Add2WithNumber()
        {
            int presentNumber = this.MyNumber;
            this.MyNumber = this.MyNumber + 2;
            Console.WriteLine("{0}+2={1}", presentNumber, this.MyNumber);
        }
        public void Remove2FromNumber()
        {
            int presentNumber = this.MyNumber;
            //We started with number 75.We'll not decrese further.
            if (presentNumber > 75)
            {
                this.MyNumber = this.MyNumber - 2;
                Console.WriteLine("{0}-2={1}", presentNumber, this.MyNumber);
            }
            else
            {
                Console.WriteLine("Nothing more to undo...");
            }
        }
    }

    //Invoker class
    public class Invoker
    {
        ICommand commandToBePerformed;
        public void SetCommand(ICommand command)
        {
            this.commandToBePerformed = command;
        }
        public void ExecuteCommand()
        {
            commandToBePerformed.Do();
        }
        public void UndoCommand()
        {
            commandToBePerformed.UnDo();
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Command Pattern Q&As***");
            Console.WriteLine("***A simple demo with undo supported operations***\n");
            /*Client holds  both the Invoker and Command Objects*/
            Invoker invoker = new Invoker();
            //Testing receiver -Receiver1
            IReceiver intendedreceiver = new Receiver1();
            ICommand currentCmd = new AdditionCommand(intendedreceiver);
            invoker.SetCommand(currentCmd);
            //Executed the command 2 times
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();            
            //Trying to undo 3 times
            invoker.UndoCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();

            Console.WriteLine("\nTesting receiver-Receiver2");
            intendedreceiver = new Receiver2();
            currentCmd = new AdditionCommand(intendedreceiver);
            invoker.SetCommand(currentCmd);
            //Executed the command 1 time
            invoker.ExecuteCommand();            
            //Trying to undo 2 times
            invoker.UndoCommand();
            invoker.UndoCommand();            
            Console.ReadKey();
        }
    }
}
