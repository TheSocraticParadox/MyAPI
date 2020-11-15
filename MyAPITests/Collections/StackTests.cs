using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;
using System;

namespace MyAPITests.Collections
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Push()
        {
            Stack<int> q = new Stack<int>();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            q.Push(4);

            Assert.AreEqual(4, q.Length);

            int i = 4;
            foreach (int x in q)
            {
                Assert.AreEqual(i, x);
                i--;
            }
        }

        [TestMethod]
        public void Pop()
        {
            Stack<int> q = new Stack<int>();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            Assert.AreEqual(3, q.Length);
            Assert.AreEqual(3, q.Pop());
            Assert.AreEqual(2, q.Length);
            Assert.AreEqual(2, q.Pop());
            Assert.AreEqual(1, q.Length);
            Assert.AreEqual(1, q.Pop());
            Assert.AreEqual(0, q.Length);
        }

        [TestMethod]
        public void Peek()
        {
            Stack<int> q = new Stack<int>();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            Assert.AreEqual(3, q.Peek());
            q.Pop();
            Assert.AreEqual(2, q.Peek());
            q.Pop();
            Assert.AreEqual(1, q.Peek());
            q.Pop();
            Assert.ThrowsException<IndexOutOfRangeException>(() => { q.Peek(); });
        }

        [TestMethod]
        public void Clear()
        {
            Stack<int> q = new Stack<int>();
            q.Push(1);
            q.Push(2);
            q.Push(3);
            q.Clear();
            Assert.AreEqual(0, q.Length);
            Assert.ThrowsException<IndexOutOfRangeException>(() => { q.Peek(); });
        }
    }
}
