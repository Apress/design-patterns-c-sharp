using System;

namespace TemplateMethodPattern
{
   public abstract class BasicEngineering
    {
        public void Papers()
        {
            //Common Papers:
            Math();
            SoftSkills();
            //Specialized Paper:
            SpecialPaper();
        }
        private void Math()
        {
            Console.WriteLine("Mathematics");
        }
        private void SoftSkills()
        {
            Console.WriteLine("SoftSkills");
        }
        public abstract void SpecialPaper();
    }
}
