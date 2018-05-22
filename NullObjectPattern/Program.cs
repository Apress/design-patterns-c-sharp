using System;
namespace NullObjectPattern
{
    interface IVehicle
    {
        void Travel();
    }
    class Bus : IVehicle
    {
        public static int busCount = 0;
        public Bus()
        {
            busCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Bus");
        }
    }
    class Train : IVehicle
    {
        public static int trainCount = 0;
        public Train()
        {
            trainCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Train");
        }
    }
    class NullVehicle : IVehicle
    {
        private static readonly NullVehicle instance = new NullVehicle();
        public static int nullVehicleCount = 0;
        public static NullVehicle Instance
        {
            get
            {
                //Console.WriteLine("We already have an instance now.Use it.");
                return instance;
            }
        }
        public void Travel()
        {
            //Do Nothing
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Null Object Pattern Demo***\n");
            //IVehicle vehicle = null;
            string input = String.Empty;
            int totalObjects = 0;

            while (input !="exit")
            {
                //Console.WriteLine("Enter your choice( Type 'a' for Bus, 'b' for Train )");
                Console.WriteLine("Enter your choice( Type 'a' for Bus, 'b' for Train.Type 'exit' to quit) ");
                input = Console.ReadLine();
                IVehicle vehicle = null;
                switch (input)
                {
                    case "a":
                        vehicle = new Bus();
                        break;
                    case "b":
                        vehicle = new Train();
                        break;
                    default:
                        vehicle = NullVehicle.Instance;
                        if (input == "exit")
                        {
                            Console.WriteLine("Closing the application.Press Enter at end.");
                        }
                        break;
                }
                //totalObjects = Bus.busCount + Train.trainCount;
                totalObjects = Bus.busCount + Train.trainCount+ NullVehicle.nullVehicleCount;
                //ride the vehicle
                //if (vehicle != null)
                //{
                    vehicle.Travel();
                //}

                Console.WriteLine("Total objects created in the system ={0}", totalObjects);
                }
            Console.ReadKey();
        }
    }   
}
