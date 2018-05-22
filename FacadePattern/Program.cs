using System;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo***\n");
            //Creating Robots
            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();
            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();
            //Destroying robots
            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonautRobot();
            Console.ReadLine();
        }
    }
}
