using System;

//Modifying the IAnimalFactory class and calling methods as per the design in Client.
namespace FactoryMethodPatternBeautification
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
    //Modifying the IAnimalFactory class.
    public abstract class IAnimalFactory
    {
        public IAnimal MakeAnimal()
        {
            Console.WriteLine("AnimalFactory.MakeAnimal()-You cannot ignore parent rules.");
            /*
            At this point,it doesn't know whether it will get a Dog or a Tiger.
            It will be decided by the subclasses i.e.DogFactory or TigerFactory.
            But it knows that it will Speak and it will have a preferred way of Action.
            */
            IAnimal animal = CreateAnimal();
            animal.Speak();
            animal.Action();
            return animal;
        }        
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
            Console.WriteLine("***Beautification to Factory Pattern Demo***\n");
            // Creating a tiger  using the Factory Method 
            IAnimalFactory tigerFactory = new TigerFactory();
            IAnimal aTiger = tigerFactory.MakeAnimal();
            //IAnimal aTiger = tigerFactory.CreateAnimal();
            //aTiger.Speak();
            //aTiger.Action();

            // Creating a dog  using the Factory Method 
            IAnimalFactory dogFactory = new DogFactory();
            IAnimal aDog = dogFactory.MakeAnimal();
            //IAnimal aDog = dogFactory.CreateAnimal();
            //aDog.Speak();
            //aDog.Action();

            Console.ReadKey();
        }
    }
}
