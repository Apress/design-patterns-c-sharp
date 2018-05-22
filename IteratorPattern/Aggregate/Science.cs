using System;
using IteratorPattern.Iterator;
using System.Collections.Generic;//for Linked List

namespace IteratorPattern.Aggregate
{
    public class Science:ISubjects
    {
        private LinkedList<string> Subjects;
        
        public Science()
        {
            Subjects = new LinkedList<string>();
            //You can add in your preferred order
            Subjects.AddLast("Maths");
            Subjects.AddLast("Comp. Sc.");
            Subjects.AddLast("Physics");
            //Subjects.AddFirst("Maths");
            //Subjects.AddFirst("Comp. Sc.");
            //Subjects.AddFirst("Physics");
        }

        public IIterator CreateIterator()
        {
            return new ScienceIterator(Subjects);
        }
    }
}
