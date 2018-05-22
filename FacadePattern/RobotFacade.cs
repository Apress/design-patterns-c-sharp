using System;
using FacadePattern.RobotParts;

namespace FacadePattern
{
    public class RobotFacade
    {
        RobotColor rc;
        RobotHands rh ;
        RobotBody rb;
       public RobotFacade()
        {
             rc = new RobotColor();
             rh = new RobotHands();
             rb = new RobotBody();
                
        }
        public void ConstructMilanoRobot()
        {
            Console.WriteLine("Creation of a Milano Robot Start");
            rc.SetDefaultColor();
            rh.SetMilanoHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine(" Milano Robot Creation End");
            Console.WriteLine();
        }
        public void ConstructRobonautRobot()
        {
            Console.WriteLine("Initiating the creational process of a Robonaut Robot");
            rc.SetGreenColor();
            rh.SetRobonautHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine(" A Robonaut Robot is created");
            Console.WriteLine();
        }
        public void DestroyMilanoRobot()
        {
            Console.WriteLine(" Milano Robot's destruction process is started");
            rh.ResetMilanoHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();            
            Console.WriteLine(" Milano Robot's destruction process is over");
            Console.WriteLine();
        }
        public void DestroyRobonautRobot()
        {
            Console.WriteLine(" Initiating a Robonaut Robot's destruction process.");
            rh.ResetRobonautHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine(" A Robonaut Robot is destroyed");
            Console.WriteLine();
        }

    }
}
