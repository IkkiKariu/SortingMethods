using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Models
{
    internal class SimpleList<T>
    {
        public SimpleListNode<T>? Head { get; private set; } = null;
        public SimpleListNode<T>? Tail { get; private set; } = null;

        public int Count { get; private set; } = 0;

        public bool IsEmpty()
        {
            return Head == null ? true : false;
        }

        public void Append(T value)
        {
            SimpleListNode<T> newNode = new SimpleListNode<T>(value);

            if (Head != null)
            {
                if (Tail != null)
                {
                    newNode.Previous = Tail;
                    Tail.Next = newNode;

                    Tail = newNode;
                }
                else
                {
                    newNode.Previous = Head;
                    Head.Next = newNode;

                    Tail = newNode;
                }
            }
            else
            {
                Head = newNode;
            }

            Count++;
        }

        public void InsertFirst(T value)
        {
            SimpleListNode<T> newNode = new SimpleListNode<T>(value);

            if (Head != null)
            {
                newNode.Next = Head;
                Head.Previous = newNode;

                Head = newNode;
            }
            else
            {
                Head = newNode;
            }

            Count++;
        }

        //public bool Remove(T value, uint occurences=1)
        //{
        //    uint count = 0;
        //
        //    if (!IsEmpty())
        //    {
        //        SimpleListNode<T> current = Head;
        //
        //        if (Tail != null)
        //        {
        //            if (Tail.Value == value)
        //            {
        //                SimpleListNode<T> currentTail = Tail;
        //
        //                Tail.Previous.Next = null;
        //                Tail = Tail.Previous != Head ? Tail.Previous : null;
        //
        //                currentTail.Previous = null;
        //
        //                count++;
        //
        //                return true;
        //            }
        //
        //            while (current != Tail && count < occurences)
        //            {
        //                if (current.Value == value)
        //                {
        //                    count++;
        //                    current.
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (Head.Value == value)
        //            {
        //                count++;
        //
        //                Head = null;
        //                return true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
