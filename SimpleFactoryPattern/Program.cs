using System;

namespace SimpleFactoryPattern
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
            Console.WriteLine("Dogs prefer barking...");
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
            Console.WriteLine("Tigers prefer hunting...");
        }
    }
    //We could simply put all the stuffs in the SimpleFactory class.For a "Factory method"
    //pattern, we are forced to defer the instantiation process to the subclass.
    //But we do not want to code to "concrete class".Also the following mechanism provides us
    //the flexibility to put some common behavior in the abstract class.
    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal();
    }
    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimal CreateAnimal()
        {
            IAnimal intendedAnimal=null;
            Console.WriteLine("Enter your choice( 0 for Dog, 1 for Tiger)");
            string b1 = Console.ReadLine();
            int input;
            if (int.TryParse(b1, out input))
            {
                Console.WriteLine("You have entered {0}", input);
                switch (input)
                {
                    case 0:
                        intendedAnimal = new Dog();
                        break;
                    case 1:
                        intendedAnimal = new Tiger();
                        break;
                    default:
                        Console.WriteLine("You must enter either 0 or 1");
                        //We'll throw a runtime exception for any other choices. 
                        throw new ApplicationException(String.Format(" Unknown Animal cannot be instantiated"));                        
                }
            }
            return intendedAnimal;
        }       
    }
    //A client is interested to get an animal who can speak and perform an action.
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo***\n");
            IAnimal preferredType=null;
            ISimpleFactory simpleFactory = new SimpleFactory();            
            #region The code region that will vary based on users preference            
            preferredType = simpleFactory.CreateAnimal();            
            #endregion

            #region The codes that do not change frequently
            preferredType.Speak();
            preferredType.Action();
            #endregion

            Console.ReadKey();
        }
    }
}
