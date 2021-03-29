using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// A base heap class to share most of the functionality of the min and max heap
    /// </summary>
    /// <typeparam name="T">The comparable type for the heap</typeparam>
    public abstract class Heap<T> where T:IComparable
    {

        private const int START_SPACE = 10;
        private int size;
        private T[] treeData;

        /// <summary>
        /// Creates a new heap and allocates START_SPACE slots to begin with
        /// </summary>
        public Heap()
        {
            this.treeData = new T[START_SPACE];
            this.size = 0;
        }

        /// <summary>
        /// Adds an item to the heap by adding the item to the end of the array, then
        /// bubbling up the value until it is in the correct position
        /// </summary>
        public void Add(T item)
        {
            EnsureThereIsSpaceToAdd();
            this.treeData[this.size] = item;
            BubbleUpItem(this.size);
            this.size++;
        }

        /// <summary>
        /// Bubbles up an item until it is in the correct position by 
        /// comparing it to it's parent and swapping them if necessary
        /// </summary>
        private void BubbleUpItem(int index)
        {
            if (index == 0)
                return;
            if(Compare(index, Parent(index))<0)
            {
                Swap(index, Parent(index));
                BubbleUpItem(Parent(index));
            }
        }
        
        /// <summary>
        /// Ensures that there is space in the tree data to add a new node, if not, 
        /// the tree data size is doubled
        /// </summary>
        private void EnsureThereIsSpaceToAdd()
        {
            if(this.size == this.treeData.Length - 1)
            {
                T[] newData = new T[this.treeData.Length * 2];
                for (int i = 0; i < this.treeData.Length; i++)
                    newData[i] = this.treeData[i];
                this.treeData = newData;
            }
        }

        /// <summary>
        /// Gets the min/max item from the root of the heap without removing it
        /// </summary>
        /// <returns>The item at the root</returns>
        public T Peek()
        {
            if (this.size < 1)
                throw new IndexOutOfRangeException();
            return this.treeData[0];
        }

        /// <summary>
        /// Removes the min/max item from the root, replaces it with the last item
        /// in the tree, heapifies, and returns the removed root
        /// </summary>
        /// <returns></returns>
        public T Remove()
        {
            T ret = this.treeData[0];
            this.treeData[0] = this.treeData[this.size - 1];
            this.size--;
            Heapify(0);
            return ret;
        }

        /// <summary>
        /// Fixes the heap from the given node by swapping it for it's left or right child
        /// (whichever is smaller), and repeating the process down the tree until all 
        /// nodes are placed correctly
        /// </summary>
        /// <param name="index"></param>
        private void Heapify(int index)
        {
            int cur = index;
            int left = LeftChild(cur);
            int right = RightChild(cur);
            int smallest = cur;
            if (left < this.size && Compare(left, smallest) < 0)
                smallest = left;
            if (right < this.size && Compare(right, smallest) < 0)
                smallest = right;
            if(smallest != cur)
            {
                Swap(cur, smallest);
                Heapify(smallest);
            }
        }

        /// <summary>
        /// Helper method to get the left child of a node
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int LeftChild(int index)
        {
            int child = 2 * index + 1;
            return child;
        }

        /// <summary>
        /// Helper method to get the right child of a node
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int RightChild(int index)
        {
            int child = 2 * index + 2;
             return child;
        }

        /// <summary>
        /// Helper method to get the parent of a node
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int Parent(int index)
        {
            if (index == 0)
                throw new IndexOutOfRangeException("Root node 0 has no parent");
            return (index-1) / 2;
        }

        /// <summary>
        /// Helper method to swap two nodes in the tree at the specified indexes
        /// </summary>
        /// <param name="aIndex"></param>
        /// <param name="bIndex"></param>
        private void Swap(int aIndex, int bIndex)
        {
            T tmp = this.treeData[aIndex];
            this.treeData[aIndex] = this.treeData[bIndex];
            this.treeData[bIndex] = tmp;
        }

        /// <summary>
        /// Function to compare two nodes. This calls the abstract compare function
        /// which allows the min/max heaps to implement their respective comparison logic
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected int Compare(int a, int b)
        {
            return CompareItems(this.treeData[a], this.treeData[b]);
        }

        /// <summary>
        /// Override to implement the compare logic for a min or max heap
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected abstract int CompareItems(T a, T b);

   
    }
}