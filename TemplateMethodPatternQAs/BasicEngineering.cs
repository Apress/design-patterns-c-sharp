using System;

namespace TemplateMethodPatternQAs
{
   public abstract class BasicEngineering
    {
        public void Papers()
        {
            //Common Papers:
            Math();
            SoftSkills();
            if (IsAdditionalPapersNeeded())
            {
                AdditionalPapers();
            }
            //Specialized Paper:
            SpecialPaper();
            //AdditionalPapers2();
        }
        private void Math()
        {
            Console.WriteLine("Mathematics");
        }
        private void SoftSkills()
        {
            Console.WriteLine("SoftSkills");
        }
        private void AdditionalPapers()
        {
            Console.WriteLine("AdditionalPapers are needed in this stream.");
        }
        //public virtual void AdditionalPapers2()
        //{
        //    Console.WriteLine("AdditionalPapers2 ");
        //}
        public abstract void SpecialPaper();
        //A hook method-Additional Papers not needed.
        public virtual bool IsAdditionalPapersNeeded()
        {
            return true;
        }
    }
}
