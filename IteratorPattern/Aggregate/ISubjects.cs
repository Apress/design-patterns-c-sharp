using System;
using IteratorPattern.Iterator;

namespace IteratorPattern.Aggregate
{
    public interface ISubjects
    {
        IIterator CreateIterator();        
    }
}
