using System;
using MyAPI.Collections;
using System.Text;
using System.Collections.Generic;
using System.Transactions;

namespace MyAPI.Collections
{
    /// <summary>
    /// An implementation of a priority queue where the most important item is 
    /// always dequeued first
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>: IEnumerable<T> where T:IComparable
    {
        private List<T> data;

        /// <summary>
        /// The size of the queue
        /// </summary>
        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        /// <summary>
        /// Creates a new priority queue
        /// </summary>
        public PriorityQueue()
        {
            data = new List<T>();
        }

        /// <summary>
        /// Adds an item to the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            data.AddOrdered(item);
        }

        /// <summary>
        /// Removes the largest item from the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return data.RemoveFirst();
        }

        /// <summary>
        /// Returns the largest item from the queue without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return data.Item(0);
        }

        /// <summary>
        /// Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            data.Clear();
        }

        /// <summary>
        /// Gets an enumerator for the queue so items can be iterated in 
        /// order of priority
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Gets a non-generic enumerator
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
