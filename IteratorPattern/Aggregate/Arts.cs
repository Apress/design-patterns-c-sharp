using System;
using IteratorPattern.Iterator;

namespace IteratorPattern.Aggregate
{
    public class Arts:ISubjects
    {
        private string[] Subjects;
       
        public Arts()
        {           
            Subjects = new[] { "Bengali", "English" };
        }

        public IIterator CreateIterator()
        {
            return new ArtsIterator(Subjects);
        }
    }
}
