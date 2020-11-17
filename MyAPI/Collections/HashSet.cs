using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// An unordered set of values
    /// </summary>
    public class HashSet<T>
    {
        private int size;
        private int length;
        private List<T>[] data;

        /// <summary>
        /// The number of elements in the HashSet
        /// </summary>
        public int Length
        {
            get { return this.length; }
        }

        /// <summary>
        /// Creates a new HashSet
        /// </summary>
        public HashSet()
        {
            this.length = 0;
            this.size = 1;
            this.data = new List<T>[this.size];
        }

        /// <summary>
        /// Reduces the size of the hashtable by 1/2
        /// </summary>
        private void Shrink()
        {
            int oldSize = this.size;
            List<T>[] oldData = this.data;
            this.size = size / 2;
            this.length = 0;
            this.data = new List<T>[this.size];
            for (int i = 0; i < oldData.Length; i++)
                if (oldData[i] != null)
                    foreach (T cur in oldData[i])
                        this.Add(cur);
        }

        /// <summary>
        /// Doubles the size of the hashtable and rehashes all entries
        /// </summary>
        private void Expand()
        {
            int oldSize = this.size;
            List<T>[] oldData = this.data;
            this.size = size * 2;
            this.length = 0;
            this.data = new List<T>[this.size];
            for(int i = 0; i < oldData.Length; i++)
                if (oldData[i] != null)
                    foreach (T cur in oldData[i])
                        this.Add(cur);
        }

        /// <summary>
        /// Computes the hash for a given value and constrains it to the size of the hashtable
        /// </summary>
        private int ComputeHash(T data)
        {
            return Math.Abs(data.GetHashCode() % this.size);
        }

        /// <summary>
        /// Adds a value to the hashset
        /// </summary>
        public void Add(T data)
        {
            if ((this.length + 1) >= this.size)
                Expand();
            int hash = ComputeHash(data);
            if (this.data[hash] == null)
                this.data[hash] = new List<T>();
            this.data[hash].AddLast(data);
            this.length++;
        }

        /// <summary>
        /// Removes a value from the hashset
        /// </summary>
        public T Remove(T data)
        {
            int hash = ComputeHash(data);
            if (this.data[hash] == null)
                throw new IndexOutOfRangeException("Key not found");
            T ret = this.data[hash].Remove(data);
            this.length--;
            if (this.length < this.size / 2)
                Shrink();
            return ret;
        }

        /// <summary>
        /// Checks if a given value is present in the hashset
        /// </summary>
        public bool Contains(T data)
        {
            int hash = ComputeHash(data);
            if (this.data[hash] == null)
                return false;
            foreach (T cur in this.data[hash])
                if (cur.Equals(data))
                    return true;
            return false;
        }

        /// <summary>
        /// Clears all values from the hashset
        /// </summary>
        public void Clear()
        {
            this.length = 0;
            this.size = 1;
            this.data = new List<T>[this.size];
        }

    }
}
