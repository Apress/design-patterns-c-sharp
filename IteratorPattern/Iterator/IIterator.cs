using System;

namespace IteratorPattern.Iterator
{
    public interface IIterator
    {
        void First();//Reset to first element
        string Next();//get next element
        bool IsDone();//End of collection check
        string CurrentItem();//Retrieve Current Item
    }
}
