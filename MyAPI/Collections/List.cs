using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MyAPI.Collections
{
    /// <summary>
    /// Dynamic sized doubly linked list
    /// </summary>
    public class List<T> : IEnumerable<T>
    {
        private int count;
        internal ListNode<T> head;
        internal ListNode<T> tail;


        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        public int Length
        {
            get
            {
                return count;
            }
        }

        public List()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        /// <summary>
        /// Adds an item to the beginning of the list
        /// </summary>
        public void AddFirst(T data)
        {
            ListNode<T> add = new ListNode<T>(data);
            if(count == 0)
            {
                this.head = add;
                this.tail = add;
            }
            else
            {
                add.Next = this.head;
                this.head = add;
            }
            count++;
        }

        /// <summary>
        /// Adds an item to the end of the list
        /// </summary>
        public void AddLast(T data)
        {
            ListNode<T> add = new ListNode<T>(data);
            if (count == 0)
            {
                this.head = add;
                this.tail = add;
            }
            else
            {
                add.Prev = this.tail;
                add.Next = null;
                this.tail.Next = add;
                this.tail = add;
            }
            count++;
        }

        /// <summary>
        /// Adds a item in order(Note: requires list be sorted)
        /// </summary>
        internal void AddOrdered(IComparable item)
        {
            if(count == 0 || item.CompareTo(this.head.Data) > 0)
            {
                AddFirst((T)item);
                return;
            }

            ListNode<T> cur = this.head;
            ListNode<T> n = new ListNode<T>((T)item);
            while (cur.Next != null && item.CompareTo(cur.Next.Data) < 0)
                cur = cur.Next;
            n.Prev = cur;
            n.Next = cur.Next;
            cur.Next = n;
            if (cur.Next != null)
                cur.Next.Prev = n;
            count++;
        }

        /// <summary>
        /// Removes a specified item from the list
        /// </summary>
        /// <returns></returns>
        public T Remove(T item)
        {
            ListNode<T> cur = this.head;
            while (cur != null && !cur.Data.Equals(item))
                cur = cur.Next;
            if(cur != null)
            {
                if (cur.Prev == null)
                    this.head = cur.Next;
                else
                    cur.Prev.Next = cur.Next;

                if (cur.Next == null)
                    this.tail = cur.Prev;
                else
                    cur.Next.Prev = cur.Prev;

                cur.Next = null;
                cur.Prev = null;
                count--;
                return cur.Data;
            }
            throw new IndexOutOfRangeException("Remove failed. Element not found: " + item.ToString());
            
        }

        /// <summary>
        /// Removes the first item from the list and returns it
        /// </summary>
        public T RemoveFirst()
        {
            if (this.count == 0)
                throw new Exception("Cannot remove from empty list");
            ListNode<T> ret = this.head;
            this.head = this.head.Next;
            count--;
            if(count > 0)
                this.head.Prev = null;
            return ret.Data;
        }

        /// <summary>
        /// Removes the last item from the list and returns it
        /// </summary>
        public T RemoveLast()
        {
            if (this.count == 0)
                throw new Exception("Cannot remove from empty list");
            ListNode<T> ret = this.tail;
            this.tail = this.tail.Prev;
            count--;
            if (this.tail != null)
                this.tail.Next = null;
            return ret.Data;
        }

        /// <summary>
        /// Checks if the list contains an item
        /// </summary>
        public bool Contains(T value)
        {
            foreach(T cur in this)
                if (value.Equals(cur))
                    return true;
            return false;
        }

        /// <summary>
        /// Get the item at the specified index
        /// </summary>
        public T Item(int index)
        {
            int i = 0;
            foreach(T cur in this)
            {
                if (i == index)
                    return cur;
                i++;
            }
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Clears all items from the list
        /// </summary>
        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this.head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(this.head);
        }
    }

    /// <summary>
    /// Represents a node in the list
    /// </summary>
    public class ListNode<T>
    {
        public T Data;
        public ListNode<T> Next;
        public ListNode<T> Prev;

        public ListNode(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }

        public ListNode(T data, ListNode<T> prev, ListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }
    }

    /// <summary>
    /// The list enumerator
    /// </summary>
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private ListNode<T> start;
        private ListNode<T> currentNode;

        T IEnumerator<T>.Current
        {
            get
            {
                return currentNode.Data;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return currentNode.Data;
            }
        }

        public ListEnumerator(ListNode<T> root)
        {
            start = root;
            currentNode = null;
        }

        public void Dispose()
        {
            start = null;
            currentNode = null;
        }

        public bool MoveNext()
        {
            if (start == null)
                return false;
            if (currentNode == null)
                currentNode = start;
            else
                currentNode = currentNode.Next;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
        }
    }
}
