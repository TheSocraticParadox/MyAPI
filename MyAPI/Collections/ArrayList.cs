using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// Dynamically sized array that expands and contracts as needed
    /// </summary>
    public class ArrayList<T>
    {
        private int size;
        private int length;
        private T[] data;

        /// <summary>
        /// The length of the ArrayList
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
        }

        /// <summary>
        /// Creates a new ArrayList
        /// </summary>
        public ArrayList()
        {
            this.length = 0;
            this.size = 1;
            this.data = new T[size];
        }

        /// <summary>
        /// Helper function that doubles the array size to allow for more items
        /// </summary>
        private void Expand()
        {
            size *= 2;
            T[] n = new T[size];
            for (int i = 0; i < this.data.Length; i++)
                n[i] = this.data[i];
            this.data = n;
        }

        /// <summary>
        /// Helper function that halves the array size to conserve memory for less items
        /// </summary>
        private void Shrink()
        {
            if (size == 1)
                return;
            size /= 2;
            T[] n = new T[size];
            for (int i = 0; i < this.data.Length; i++)
                n[i] = this.data[i];
            this.data = n;
        }

        /// <summary>
        /// Adds a value to the end of the arraylist
        /// </summary>
        public void Add(T value)
        {
            if (length + 1 >= size)
                Expand();
            this.data[length] = value;
            this.length++;
        }

        /// <summary>
        /// Removes an item from the ArrayList
        /// </summary>
        public void Remove(int index)
        {
            for(int i = index; i < this.length - 1; i++)
                this.data[i] = this.data[i + 1];
            if (this.length < this.size / 2)
                Shrink();
        }

        /// <summary>
        /// Gets the item at the specified index
        /// </summary>
        public T Get(int index)
        {
            if (index < 0 || index >= this.length)
                throw new IndexOutOfRangeException();
            return this.data[index];
        }

        /// <summary>
        /// Sets the value at the specified index
        /// </summary>
        public void Set(int index, T data)
        {

            if (index < 0 || index >= this.length)
                throw new IndexOutOfRangeException();
            this.data[index] = data ;
        }

        /// <summary>
        /// Clears the ArrayList and resets the length to 0
        /// </summary>
        public void Clear()
        {
            this.size = 1;
            this.length = 0;
            this.data = new T[this.size];
        }

        /// <summary>
        /// Converts the ArrayList to a standard array
        /// </summary>
        public T[] ToArray()
        {
            T[] ret = new T[this.length];
            for (int i = 0; i < this.length; i++)
                ret[i] = this.data[i];
            return ret;
        }
    }
}
