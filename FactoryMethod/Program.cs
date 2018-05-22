using System;

namespace FactoryMethodPattern
{
    public interface IAnimal
    {
        void Speak();
        void Action();
    }
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...\n");
        }
    }
    public class Tiger : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...\n");
        }
    }
    public abstract class IAnimalFactory
    {
        //Remember the GoF definition which says "....Factory method lets a class defer instantiation to subclasses."
        //Following method will create a Tiger or Dog.But at this point it does not know whether 
        //it will get a Dog or a Tiger.It will be decided by the subclasses i.e.DogFactory or TigerFactory.
        //So, the following method is acting like a factory (of creation).
        //protected abstract IAnimal CreateAnimal();
        public abstract IAnimal CreateAnimal();        
    }
    public class DogFactory : IAnimalFactory
    {
        //protected override IAnimal CreateAnimal()
        public override IAnimal CreateAnimal()
        {
            //Creating a Dog
            return new Dog();               
        }
    }
    public class TigerFactory : IAnimalFactory
    {
        //protected override IAnimal CreateAnimal()
        public override IAnimal CreateAnimal()
        {
            //Creating a Tiger
            return new Tiger();
        }
    }
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Pattern Demo***\n");
            // Creating a Tiger Factory 
            IAnimalFactory tigerFactory =new TigerFactory();
            // Creating a tiger using the Factory Method
            IAnimal aTiger = tigerFactory.CreateAnimal();
            aTiger.Speak();
            aTiger.Action();

            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            // Creating a dog using the Factory Method 
            IAnimal aDog = dogFactory.CreateAnimal();
            aDog.Speak();
            aDog.Action();
            
            Console.ReadKey();
        }
    }
}
