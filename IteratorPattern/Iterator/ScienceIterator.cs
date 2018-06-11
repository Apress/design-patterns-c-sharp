using System;
using System.Collections.Generic;
using System.Linq;//for: Subjects.ElementAt(position++);

namespace IteratorPattern.Iterator
{
    public class ScienceIterator:IIterator
    {
        private LinkedList<string> Subjects;
        private int position;
       
        public ScienceIterator(LinkedList<string> subjects)
        {
          this.Subjects = subjects;
          position = 0;
        }       

        public void First()
        {
            position = 0;
        }

        public string Next()
        {
            return Subjects.ElementAt(position++);
        }

        public bool IsDone()
        {
           if (position < Subjects.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string CurrentItem()
        {
            return Subjects.ElementAt(position);
        }       
    }
}
