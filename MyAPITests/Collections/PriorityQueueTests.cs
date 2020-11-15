using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;
using System;

namespace MyAPITests.Collections
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void Enqueue()
        {
            PriorityQueue<int> test = new MyAPI.Collections.PriorityQueue<int>();
            test.Enqueue(3);
            test.Enqueue(2);
            test.Enqueue(4);
            test.Enqueue(1);
            int x = 4;
            foreach (int i in test)
            {
                Assert.AreEqual(x, i);
                x--;
            }
        }


        [TestMethod]
        public void Dequeue()
        {
            PriorityQueue<int> test = new MyAPI.Collections.PriorityQueue<int>();
            test.Enqueue(3);
            test.Enqueue(2);
            test.Enqueue(4);
            test.Enqueue(1);
            Assert.AreEqual(4, test.Dequeue());
            Assert.AreEqual(3, test.Dequeue());
            Assert.AreEqual(2, test.Dequeue());
            Assert.AreEqual(1, test.Dequeue());



        }


    }
}
