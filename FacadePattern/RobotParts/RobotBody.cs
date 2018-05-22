using System;

namespace FacadePattern.RobotParts
{
    public class RobotBody
    {
        public void CreateHands()
        {
            Console.WriteLine(" Hands manufactured");
        }
        public void CreateRemainingParts()
        {
            Console.WriteLine(" Remaining parts (other than hands) are created");
        }
        public void DestroyHands()
        {
            Console.WriteLine(" The robot's hands are destroyed");
        }
        public void DestroyRemainingParts()
        {
            Console.WriteLine(" The robot's remaining parts are destroyed");
        }
    }
}
