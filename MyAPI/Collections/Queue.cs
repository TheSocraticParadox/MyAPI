using System;
using System.Text;
using System.Xml.Schema;

namespace MyAPI.Collections
{
    /// <summary>
    /// Implementation of a FIFO queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private List<T> data;

        /// <summary>
        /// The number of elements in the queue
        /// </summary>
        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        /// <summary>
        /// An Implementation of a FIFO queue
        /// </summary>
        public Queue()
        {
            data = new List<T>();
        }

        /// <summary>
        /// Adds a new item to the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            data.AddLast(item);
        }

        /// <summary>
        /// Removes the earliest item added to the queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return data.RemoveFirst();
        }

        /// <summary>
        /// Returns the earliest item from the queue without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return data.Item(0);
        }

        /// <summary>
        /// Removes all elements from the queue
        /// </summary>
        public void Clear()
        {
            data.Clear();
        }

        /// <summary>
        /// Gets an enumerator for the queue in order of FIFO
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for the queue in order of FIFO
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
