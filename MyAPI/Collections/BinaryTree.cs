using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;

namespace MyAPI.Collections
{
    public class BinaryTree<T> where T:IComparable
    {
        private int count;
        private BinaryTreeNode<T> Root;

        public int Size
        {
            get { return count; }
        }

        public void Add(T data)
        {
            this.Root = Add(data, this.Root);
        }

        private BinaryTreeNode<T> Add(T data, BinaryTreeNode<T> curRoot)
        {
            if (curRoot == null)
            {
                count++;
                return new BinaryTreeNode<T>(data);
            }
            else
            {
                if (data.CompareTo(curRoot.Data) < 0)
                {
                    curRoot.Left = Add(data, curRoot.Left);
                    curRoot.Left.Parent = curRoot;
                    return curRoot;
                }
                else if (data.CompareTo(curRoot.Data) > 0)
                {
                    curRoot.Right = Add(data, curRoot.Right);
                    curRoot.Right.Parent = curRoot;
                    return curRoot;
                }
                else
                {
                    return curRoot;
                }
            }
        }

        public T Remove(T data)
        {
            return Remove(data, this.Root);
        }

        private T Remove(T data, BinaryTreeNode<T> start)
        {
            BinaryTreeNode<T> rem = Find(start, data);
            if (rem == null)
                throw new IndexOutOfRangeException("Cannot remove node because it was not present in the tree");
            if (rem.Left == null && rem.Right == null)
            {
                if (rem.Parent == null)
                    this.Root = null;
                else if (rem.Parent.Left == rem)
                {
                    rem.Parent.Left = null;
                }
                else if (rem.Parent.Right == rem)
                {
                    rem.Parent.Right = null;
                }
            }
            else if (rem.Left != null)
            {
                if (rem.Parent.Left == rem)
                    rem.Parent.Left = rem.Left;
                else
                    rem.Parent.Right = rem.Left;
            }
            else if (rem.Right != null)
            {
                if (rem.Parent.Left == rem)
                    rem.Parent.Left = rem.Right;
                else
                    rem.Parent.Right = rem.Right;
            }
            else
            {
                BinaryTreeNode<T> sucessor = GetSucessor(rem);
                T oldData = rem.Data;
                rem.Data = sucessor.Data;
                Remove(sucessor.Data, rem.Right);
                return oldData;
            }


            rem.Left = null;
            rem.Right = null;
            rem.Parent = null;
            return rem.Data;
        }

        private BinaryTreeNode<T> GetSucessor(BinaryTreeNode<T> n)
        { 
            BinaryTreeNode<T> ret = n.Right;
            while (ret.Left != null)
                ret = ret.Left;
            return ret;
        }


        public T[] AsArray()
        {
            T[] ret = new T[(int)Math.Pow(2, this.Size)];
            BuildArray(this.Root, 1, ret);
            return ret ;
        }

        private void BuildArray(BinaryTreeNode<T> cur, int curIdx, T[] arr)
        {
            if (cur == null)
                return;
            arr[curIdx - 1] = cur.Data;
            BuildArray(cur.Left, 2 * curIdx, arr);
            BuildArray(cur.Right, 2 * curIdx + 1, arr);
        }


        public bool Contains(T data)
        {
            return Find(this.Root, data) != null;
        }

        private BinaryTreeNode<T> Find(BinaryTreeNode<T> cur, T data)
        {
            if (cur == null)
                return null;
            if (cur.Data.CompareTo(data) == 0)
                return cur; ;
            return Find(cur.Left, data) ?? Find(cur.Right, data);
        }
    }


    public class BinaryTreeNode<T> where T:IComparable
    {
        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
        public T Data;
        public BinaryTreeNode<T> Parent;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;
    }
}
