using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Models
{
    internal class SimpleListNode<T>
    {
        public T Value { get; private set; }

        public SimpleListNode<T>? Previous;
        public SimpleListNode<T>? Next;

        public SimpleListNode (T value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }

        
    }
}
