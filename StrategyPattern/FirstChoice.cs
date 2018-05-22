using System;

namespace StrategyPattern
{
    public class FirstChoice:IChoice
    {
        public void MyChoice()
        {
            Console.WriteLine("Traveling to Japan");
        }
    }
}
