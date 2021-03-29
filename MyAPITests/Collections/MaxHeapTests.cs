using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class MaxHeapTests
    {

        private MaxHeap<int> getExampleHeap()
        {
            MaxHeap<int> h = new MaxHeap<int>();
            h.Add(4);
            h.Add(5);
            h.Add(3);
            h.Add(1);
            h.Add(2);
            return h;
        }


        [TestMethod]
        public void Add()
        {
            getExampleHeap();
        }

        [TestMethod]
        public void Peek()
        {
            Heap<int> h = new MaxHeap<int>();
            h.Add(4);
            Assert.AreEqual(h.Peek(), 4);
            h.Add(5);
            Assert.AreEqual(h.Peek(), 5);
            h.Add(3);
            Assert.AreEqual(h.Peek(), 5);
            h.Add(1);
            Assert.AreEqual(h.Peek(), 5);
            h.Add(2);
            Assert.AreEqual(h.Peek(), 5);
        }

        [TestMethod]
        public void Remove()
        {
            Heap<int> h = getExampleHeap();
            Assert.AreEqual(5, h.Remove());
            Assert.AreEqual(4, h.Remove());
            Assert.AreEqual(3, h.Remove());
            Assert.AreEqual(2, h.Remove());
            Assert.AreEqual(1, h.Remove());
        }

        [TestMethod]
        public void RemoveAndAdd()
        {
            Heap<int> h = getExampleHeap();
            Assert.AreEqual(h.Remove(), 5);
            h.Add(50);
            Assert.AreEqual(h.Remove(), 50);
            Assert.AreEqual(h.Remove(), 4);
        }
    }
}
