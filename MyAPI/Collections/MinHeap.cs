using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// Overrides heap compare to create a min heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : Heap<T> where T : IComparable
    {
        /// <summary>
        /// uses the compareto function to compare items in min heap format
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected override int CompareItems(T a, T b)
        {
            return a.CompareTo(b);
        }
    }
}
