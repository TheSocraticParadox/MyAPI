using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;
using System;

namespace MyAPITests.Collections
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Enqueue()
        {
           Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            Assert.AreEqual(4, q.Length);

            int i = 1;
            foreach(int x in q)
            {
                Assert.AreEqual(i, x);
                i++;
            }
        }

        [TestMethod]
        public void Dequeue()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Assert.AreEqual(3, q.Length);
            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(2, q.Length);
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(1, q.Length);
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(0, q.Length);
        }

        [TestMethod]
        public void Peek()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Assert.AreEqual(1, q.Peek());
            q.Dequeue();
            Assert.AreEqual(2, q.Peek());
            q.Dequeue();
            Assert.AreEqual(3, q.Peek());
            q.Dequeue();
            Assert.ThrowsException<IndexOutOfRangeException>(() => { q.Peek(); });
        }

        [TestMethod]
        public void Clear()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Clear();
            Assert.AreEqual(0, q.Length);
            Assert.ThrowsException<IndexOutOfRangeException>(() => { q.Peek(); });

        }
    }
}
