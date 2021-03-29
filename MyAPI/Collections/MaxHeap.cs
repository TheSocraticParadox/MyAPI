using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// Overrides heap compare to implement a max heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> : Heap<T> where T : IComparable
    {
        /// <summary>
        /// Uses the inverse of the compare to to flip the min heap logic to max heap logic
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected override int CompareItems(T a, T b)
        {
            return -a.CompareTo(b);
        }
    }
}
