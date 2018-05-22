using System;

namespace TemplateMethodPatternQAs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Template Method Pattern QAs***\n");
            BasicEngineering bs = new ComputerScience();
            Console.WriteLine("Computer Sc  Papers:");
            bs.Papers();
            Console.WriteLine();
            bs = new Electronics();
            Console.WriteLine("Electronics Papers:");
            bs.Papers();
            Console.ReadLine();
        }
    }
}
