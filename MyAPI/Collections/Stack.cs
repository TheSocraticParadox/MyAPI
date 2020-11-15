using System;
using System.Text;
using System.Xml.Schema;

namespace MyAPI.Collections
{
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private List<T> data;

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        public Stack()
        {
            data = new List<T>();
        }

        public void Push(T item)
        {
            data.AddFirst(item);
        }

        public T Pop()
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
