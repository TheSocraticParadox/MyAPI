using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /*
     * Uses the compare from the heap base class to implement a max heap by swapping the result of the compareTo
     */
    public class MaxHeap<T> : Heap<T> where T : IComparable
    {
        protected override int CompareItems(T a, T b)
        {
            return -a.CompareTo(b);
        }
    }
}
