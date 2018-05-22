using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Strategy Pattern Demo***");
            IChoice ic = null;
            Context cxt = new Context();
            //For simplicity,we are considering 2 user inputs only.
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("\nEnter ur choice(1 or 2)");
                string c = Console.ReadLine();                
                if (c.Equals("1"))
                {
                    ic = new FirstChoice();
                }
                else
                {
                    ic = new SecondChoice();
                }                
                cxt.SetChoice(ic);
                cxt.ShowChoice();               
            }
            Console.ReadKey();
        }
    }
}
