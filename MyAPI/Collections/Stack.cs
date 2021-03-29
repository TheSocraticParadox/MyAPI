using System;
using System.Text;
using System.Xml.Schema;

namespace MyAPI.Collections
{
    /// <summary>
    /// Implementation of a first in last out stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private List<T> data;

        /// <summary>
        /// The number of elements in the stack
        /// </summary>
        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        /// <summary>
        /// Creates a new stack
        /// </summary>
        public Stack()
        {
            data = new List<T>();
        }

        /// <summary>
        /// Adds an item to the top of the stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            data.AddFirst(item);
        }

        /// <summary>
        /// Removes an item from the top of the stack and returns it
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            return data.RemoveFirst();
        }

        /// <summary>
        /// Rreturns the item from the top of the stack without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return data.Item(0);
        }

        /// <summary>
        /// Removes all elements from the stack
        /// </summary>
        public void Clear()
        {
            data.Clear();
        }

        /// <summary>
        /// Gets an iterator for all elements in the stack starting from the most recent
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Gets an iterator for all elements in the stack starting from the most recent
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
