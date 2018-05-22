using System;
using System.Collections.Generic;
using System.Threading;

namespace FlyweightPatternModified
{
    //Our interface
    interface IRobot
    {
        void Print();
    }

    /**
     The 'ConcreteFlyweight' class-SmallRobot
     */
    class Robot : IRobot
    {
        String robotType;
        public String colorOfRobot;
        public Robot(String robotType)
        {
            this.robotType = robotType;
        }
        public void SetColor(String colorOfRobot)
        {
            this.colorOfRobot = colorOfRobot;
        }
        public void Print()
        {
            Console.WriteLine(" This is a " + robotType + " type robot with " + colorOfRobot + "color");
        }
    }

    // The 'FlyweightFactory' class
     
    class RobotFactory
    {
        Dictionary<string, IRobot> shapes = new Dictionary<string, IRobot>();
        public int TotalObjectsCreated()
        {
            return shapes.Count;
        }

        public IRobot GetRobotFromFactory(String robotType)
        {
            IRobot robotCategory = null;
            if (shapes.ContainsKey(robotType))
            {
                robotCategory = shapes[robotType];
            }
            else
            {
                switch (robotType)
                {
                    case "Small":
                        Console.WriteLine("We do not have Small Robot at present.So we are creating a Small Robot now.");
                        robotCategory = new Robot("Small");
                        shapes.Add("Small", robotCategory);
                        break;
                    case "Large":
                        Console.WriteLine("We do not have Large Robot at present.So we are creating a Large Robot now.");
                        robotCategory = new Robot("Large");
                        shapes.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception(" Robot Factory can create only king and queen type robots");
                }
            }
            return robotCategory;
        }

    }
    //FlyweightPattern is in action.
     
    class Program
    {
        static void Main(string[] args)
        {
            RobotFactory myfactory = new RobotFactory();
            Console.WriteLine("\n***Flyweight Pattern Example Modified***\n");
            Robot shape;
            /*Here we are trying to get 3 Small type robots*/
            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myfactory.GetRobotFromFactory("Small");
                /*Not required to add sleep().But it is included to 
                 increase the probability of getting a new random number
                 to see the variations in the output.*/
                Thread.Sleep(1000);
                shape.SetColor(GetRandomColor());
                shape.Print();
            }
            /*Here we are trying to get 3 Large type robots*/
            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myfactory.GetRobotFromFactory("Large");
                /*Not required to add sleep().But it is included to 
                 increase the probability of getting a new random number
                 to see the variations in the output.*/
                Thread.Sleep(1000);
                shape.SetColor(GetRandomColor());
                shape.Print();
            }
            int NumOfDistinctRobots = myfactory.TotalObjectsCreated();
            //System.out.println("\nDistinct Robot objects created till now= "+ NumOfDistinctRobots);		
            Console.WriteLine("\n Finally no of Distinct Robot objects created: " + NumOfDistinctRobots);
            Console.ReadKey();
        }
        static string GetRandomColor()
        {
            Random r = new Random();
            /*You can supply any number of your choice in nextInt argument.
             * we are simply checking the random number generated is an even number
             * or and odd number.And based on that we are choosing the color.
             * For simplicity, we'll use only two color-red and green
             */
            int random = r.Next(100);
            if (random % 2 == 0)
            {
                return "red";
            }
            else
            {
                return "green";
            }
        }
    }
}





   

