using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /*
     * A Min heap class
     */
    public abstract class Heap<T> where T:IComparable
    {

        private const int START_SPACE = 10;
        private int size;
        private T[] treeData;

        public Heap()
        {
            this.treeData = new T[START_SPACE];
            this.size = 0;
        }

        public void Add(T item)
        {
            EnsureThereIsSpaceToAdd();
            this.treeData[this.size] = item;
            BubbleUpItem(this.size);
            this.size++;
        }

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

        public T Peek()
        {
            if (this.size < 1)
                throw new IndexOutOfRangeException();
            return this.treeData[0];
        }

        public T Remove()
        {
            T ret = this.treeData[0];
            this.treeData[0] = this.treeData[this.size - 1];
            this.size--;
            Heapify(0);
            return ret;
        }

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

        private int LeftChild(int index)
        {
            int child = 2 * index + 1;
            return child;
        }

        private int RightChild(int index)
        {
            int child = 2 * index + 2;
             return child;
        }

        private static int Parent(int index)
        {
            if (index == 0)
                throw new IndexOutOfRangeException("Root node 0 has no parent");
            return (index-1) / 2;
        }

        private void Swap(int aIndex, int bIndex)
        {
            T tmp = this.treeData[aIndex];
            this.treeData[aIndex] = this.treeData[bIndex];
            this.treeData[bIndex] = tmp;
        }

        protected int Compare(int a, int b)
        {
            return CompareItems(this.treeData[a], this.treeData[b]);
        }


        protected abstract int CompareItems(T a, T b);

   
    }
}