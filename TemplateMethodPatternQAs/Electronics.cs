using System;

namespace TemplateMethodPatternQAs
{
    public class Electronics:BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Digital Logic and Circuit Theory");
        }
        //Using the hook method
        public override bool IsAdditionalPapersNeeded()
        {
            return false;
        }
        ////Without using hook method- not a good approach in this case
        //public override void AdditionalPapers2()
        //{
        //    //empty body
        //}
    }
}
