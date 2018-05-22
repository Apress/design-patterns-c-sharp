using System;

namespace MementoPattern
{
    /// <summary>
    /// Memento class
    /// </summary>
    class Memento
    {
        private string state;
        //If we want the state to be same when a memento is created for the first time,
        //we could prefer constructor( as shown below) instead of using a settter method in this case.
        //public Memento(string state)
        //{
        //    this.state = state;
        //}
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }       
    }

    /// <summary>
    ///  Originator class
    /// </summary>
    /*  WikiPedia notes( for your reference):
    ///  Make an object (originator) itself responsible for:
    1.Saving its internal state to a(memento) object and
    2.Restoring to a previous state from a(memento) object.
      Only the originator that created a memento is allowed to access it.*/
    class Originator
    {
        private string state;
        Memento myMemento;
        //public Originator()
        //{
        //    //this.State = "Initial state";            
        //}
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine(" Current State : {0} ", state);
            }
        }

        // Originator will supply the memento in respond to caretaker's request
        public Memento GetTheMemento()
        {
            //Creating a memento with the current state
            myMemento = new Memento();
            myMemento.State = state;
            return myMemento;
        }

        // Back to old state( Restore)
        public void RevertToState(Memento previousMemento)
        {
            Console.WriteLine("Restoring to previous state...");
            this.state = previousMemento.State;
            Console.WriteLine(" Current State : {0} ", state);
        }
    }



    /// <summary>
    /// The 'Caretaker' class.
    /// WikiPedia notes( for your reference):
    /// A client (caretaker) can request a memento from the originator 
    ///to save the internal state of the originator) and
    ///pass a memento back to the originator (to restore to a previous state)
    ///This enables to save and restore the internal state of an originator 
    ///without violating its encapsulation
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Memento Pattern Demo***\n");
            //Originator is initialized with a state
            Originator originatorObject = new Originator();
            Memento mementoObject;
            originatorObject.State = " Initial state ";
            //Console.WriteLine("Current State : {0} ", originatorObject.State);

            mementoObject = originatorObject.GetTheMemento();            
            //Making a new state
            originatorObject.State=" Intermediary state ";

            // Restore to the previous state
            originatorObject.RevertToState(mementoObject);
            //Console.WriteLine("Current State : {0} ", originatorObject.State);
            
            // Wait for user's input
            Console.ReadKey();
        }
    }
}
