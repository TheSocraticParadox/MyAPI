using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    public class BTree<T> 
    {
        private int order;
        private int depth;
        private int count;

        public BTree(int order)
        {
            this.order = order;
            this.count = 0;
            this.depth = 0;
        }

        public void Add(T key)
        {

        }

        public bool Contains(T key)
        {
            return false;
        }


        public T Remove(T key)
        {
            return default(T);
        }


        private class BTreeNode<T>
        {
            int count;
            int order;
            T[] data;
            BTreeNode<T>[] children = null;
            
            public BTreeNode(int order)
            {
                this.order = order;
                this.count = 0;
                this.data = new T[order + 1];

            }

            public T Add(T data)
            {
                if (this.count + 1 > this.order)
                {
                    //split and return center
                    return default(T);
                }
                else
                {
                    this.data[this.count] = data;
                    return default(T);
                }

            }
        }


    }
}
