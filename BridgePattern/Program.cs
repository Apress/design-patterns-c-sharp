using System;

namespace BridgePattern
{
    //Implementor
    public interface IState
    {
        void MoveState();        
    }
    //ConcreteImplementor-1
    public class OnState : IState
    {
    public void MoveState()
       {
        Console.Write("On State");
       }
    }
    //ConcreteImplementor-2
    public class OffState : IState
    {
        public void MoveState()
        {
            Console.Write("Off State");
        }
    }
    //Abstraction
    public abstract class ElectronicGoods
    {
        //Composition - implementor
        protected IState state;

        //Alternative approach to properties :
        //we can also pass an implementor (as input argument) inside a constructor.
        //public ElectronicGoods(IState state)
        //{
        //    this.state = state;
        //}
        public IState State
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
        abstract public void MoveToCurrentState();
    }
    //Refined Abstraction
    public class Television : ElectronicGoods
    {

        //public Television(IState state) : base(state)
        //{
        //}
        /*Implementation specific:
         * We are delegating the implementation to the Implementor object*/
         public override void MoveToCurrentState()
        {
            Console.Write("\n Television is functioning at : ");
            state.MoveState();
          } 
    }
    public class VCD : ElectronicGoods
    {

        //public VCD(IState state) : base(state)
        //{
        //}
        /*Implementation specific:
        * We are delegating the implementation to the Implementor object*/
        public override void MoveToCurrentState()
        {
            Console.Write("\n VCD is functioning at : ");
            state.MoveState();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Bridge Pattern Demo***");

            Console.WriteLine("\n Dealing with a Television:");
            
            //ElectronicGoods eItem = new Television(presentState);
            ElectronicGoods eItem = new Television();
            IState presentState = new OnState();
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            //Verifying Off state of the Television now
            presentState = new OffState();
            //eItem = new Television(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            Console.WriteLine("\n \n Dealing with a VCD:");
            presentState = new OnState();
            //eItem = new VCD(presentState);
            eItem = new VCD();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            presentState = new OffState();
            //eItem = new VCD(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            Console.ReadLine();
        }
    }
}
