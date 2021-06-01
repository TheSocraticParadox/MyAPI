using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    public class BTree<T> where T : IComparable
    {
        private class SplitResult<T> where T:IComparable
        {
            public bool wasSplit = false;
            public T mid;
            public BTreeNode<T> left;
            public BTreeNode<T> right;
        }

        private BTreeNode<T> root;
        private int order;
        private int depth;
        private int count;

        public BTree(int order)
        {
            this.root = new BTreeNode<T>(order);
            this.root.isLeaf = true;
            this.order = order;
            this.count = 0;
            this.depth = 0;
        }

        public void Add(T key)
        {
            SplitResult<T> res = this.root.Add(key);
            if(res.wasSplit)
            {
                this.root = new BTreeNode<T>(this.order);
                this.root.isLeaf = false;
                this.root.AddSplitToBranch(res);
            }
            Console.WriteLine("After intsert:\n" + this.root.getPrintable());
        }

        public bool Contains(T key)
        {
            return root.Contains(key);
        }


        public T Remove(T key)
        {
            return default(T);
        }


        private class BTreeNode<T> where T : IComparable
        {
            protected int count;
            protected int order;
            protected T[] data;
            protected BTreeNode<T>[] children;
            public bool isLeaf;

            public BTreeNode(int order)
            {
                this.order = order;
                this.count = 0;
                this.data = new T[order];
                this.children = new BTreeNode<T>[order + 1];
                this.isLeaf = true;
            }

            public bool IsFull()
            {
                return this.count == this.order;
            }




            public SplitResult<T> Add(T val)
            {
                if (this.isLeaf)
                    return AddToLeaf(val);
                else
                {
                    SplitResult<T> split = this.children[findChild(val)].Add(val);
                    if (split.wasSplit)
                        return this.AddSplitToBranch(split);
                    return new SplitResult<T>();
                }
            }

            private SplitResult<T> AddToLeaf(T val)
            {
                if (!this.isLeaf)
                    throw new Exception("Must add to leaf node");

                T tmp;
                for (int i = 0; i < this.count; i++)
                {
                    if (this.data[i].CompareTo(val) > 0)
                    {
                        tmp = this.data[i];
                        this.data[i] = val;
                        val = tmp;
                    }
                }
                this.data[this.count] = val;
                this.count++;

                if (this.IsFull())
                {
                    return this.Split();
                }
                return new SplitResult<T>();
            }

            public SplitResult<T> AddSplitToBranch(SplitResult<T> r)
            {
                int insPos = 0;
                int cur = 0;
                while (cur < this.count)
                {
                    if (this.data[cur].CompareTo(r.mid) >= 0)
                        break;
                    cur++;
                }
                insPos = cur;
                for (cur = this.count; cur > insPos; cur--) 
                {
                    this.data[cur] = this.data[cur - 1];
                    this.children[cur+1] = this.children[cur];
                }
                this.data[insPos] = r.mid;
                this.children[insPos] = r.left;
                this.children[insPos + 1] = r.right;
                this.count++;

                if (this.IsFull())
                    return this.Split();
                return new SplitResult<T>(); 
            }

            private SplitResult<T> Split()
            {
                SplitResult<T> ret = new SplitResult<T>();
                ret.left = new BTreeNode<T>(this.order);
                ret.right = new BTreeNode<T>(this.order);

                ret.left.isLeaf = this.isLeaf;
                ret.right.isLeaf = this.isLeaf;

                int l = 0;
                int r = 0;
                int mid = this.count / 2;
                for (int i = 0; i < this.count; i++)
                {
                    if (i < mid)
                    {
                        ret.left.data[l] = this.data[i];
                        ret.left.children[l] = this.children[i];
                        ret.left.count++;
                        l++;
                    }
                    if (i == mid)
                    {
                        ret.mid = this.data[i];
                        ret.left.children[l] = this.children[i];
                    }
                    if (i > mid)
                    {
                        ret.right.data[r] = this.data[i];
                        ret.right.children[r] = this.children[i];
                        ret.right.count++;
                        r++;
                    }
                }
                ret.right.children[r] = this.children[this.count];
                ret.wasSplit = true;
                return ret;
            }

            public bool Contains(T val)
            {
                if(this.isLeaf)
                {
                    for(int i = 0; i < this.count; i++)
                        if (this.data[i].CompareTo(val) == 0)
                            return true;
                }
                else
                {
                    for (int i = 0; i < this.count; i++)
                        if (this.data[i].CompareTo(val) > 0)
                            return this.children[i].Contains(val);
                    return this.children[this.count].Contains(val);
                }
                return false;
            }

            private int findChild(T val)
            {
                for (int i = 0; i < this.count; i++)
                {
                    if (this.data[i].CompareTo(val) > 0)
                        return i;
                }
                return this.count;
            }

            public string getPrintable()
            {
                string log = "[";
                for(int i = 0; i < this.count; i++)
                {
                    if (log != "[")
                        log += ",";
                    if(this.children[i] != null)
                        log += this.children[i].getPrintable();
                    log += this.data[i].ToString();
                }
                if (this.children[this.count] != null)
                    log += this.children[this.count].getPrintable();
                //log += "(" + this.count + "\\" + this.order + ")";
                log += "]";
                return log;
            }

            public string PrintNodeState()
            {
                string log = "[";
                foreach(T a in this.data)
                {
                    log += a.ToString() + ",";
                }
                log += "]";
                log += "(" + this.count + "\\" + this.order + ")";
                return log;
            }
        }
    }
}
