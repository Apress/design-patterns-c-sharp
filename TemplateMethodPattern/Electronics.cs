using System;

namespace TemplateMethodPattern
{
    public class Electronics:BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Digital Logic and Circuit Theory");
        }       
    }
}
