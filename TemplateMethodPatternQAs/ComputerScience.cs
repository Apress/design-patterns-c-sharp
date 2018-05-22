using System;

namespace TemplateMethodPatternQAs
{
    public class ComputerScience:BasicEngineering
    {
       public override void SpecialPaper()
        {
            Console.WriteLine("Object Oriented Programming");
        }
        //Not tested the hook method:
        //Additional papers are needed
    }
}
