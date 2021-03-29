using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    public class Graph<T>
    {
        private List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        public void Add(T data)
        {
            nodes.AddLast(new GraphNode<T>(data));
        }

        public T Remove(T data)
        {
            GraphNode<T> rem = null;
            foreach(GraphNode<T> n in nodes)
            {
                if (n.data.Equals(data))
                    rem = n;
            }
            if(rem != null)
            {
                nodes.Remove(rem);
                return rem.data;
            }
            throw new IndexOutOfRangeException("Could not find data in graph: " + data.ToString());
        }

        private void Remove(GraphNode<T> data)
        {
            this.nodes.Remove(data);
            foreach (GraphNode<T> n in this.nodes)
                n.adj.Remove(data);
        }

        public bool Contains(T data)
        {
            if (Find(data) == default(GraphNode<T>))
                return false;
            return true;
        }

        private GraphNode<T> Find(T data)
        {
            foreach (GraphNode<T> n in nodes)
                if (n.data.Equals(data))
                    return n;
            return default(GraphNode<T>);
        }


        public void Connect(T one, T two)
        {
            GraphNode<T> a = Find(one);
            if (a == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            GraphNode<T> b = Find(two);
            if (b == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            a.adj.AddLast(b);
        }

        public bool IsConnected(T one, T two)
        {
            GraphNode<T> a = Find(one);
            if (a == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            GraphNode<T> b = Find(two);
            if (b == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            return a.adj.Contains(b);
        }

        public void Disconnect(T one, T two)
        {
            GraphNode<T> a = Find(one);
            if (a == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            GraphNode<T> b = Find(two);
            if (b == default(GraphNode<T>))
                throw new IndexOutOfRangeException();
            a.adj.Remove(b);
        }

        private class GraphNode<T>
        {
            public T data;
            public List<GraphNode<T>> adj = new List<GraphNode<T>>();

            public GraphNode(T data)
            {
                this.data = data;
            }
        }
    }
}
