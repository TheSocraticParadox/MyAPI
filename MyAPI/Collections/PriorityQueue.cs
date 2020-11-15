using System;
using MyAPI.Collections;
using System.Text;
using System.Collections.Generic;
using System.Transactions;

namespace MyAPI.Collections
{
    public class PriorityQueue<T>: IEnumerable<T> where T:IComparable
    {
        private List<T> data;

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        public PriorityQueue()
        {
            data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.AddOrdered(item);
        }

        public T Dequeue()
        {
            return data.RemoveFirst();
        }

        public T Peek()
        {
            return data.Item(0);
        }

        public void Clear()
        {
            data.Clear();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
