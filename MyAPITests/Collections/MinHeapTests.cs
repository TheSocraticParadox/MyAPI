using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class MinHeapTests
    {

        private MinHeap<int> getExampleHeap()
        {
            MinHeap<int>  h = new MinHeap<int>();
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
            Heap<int> h = new MinHeap<int>();
            h.Add(4);
            Assert.AreEqual(h.Peek(), 4);
            h.Add(5);
            Assert.AreEqual(h.Peek(), 4);
            h.Add(3);
            Assert.AreEqual(h.Peek(), 3);
            h.Add(1);
            Assert.AreEqual(h.Peek(), 1);
            h.Add(2);
            Assert.AreEqual(h.Peek(), 1);
        }

        [TestMethod]
        public void Remove()
        {
            Heap<int> h = getExampleHeap();
            Assert.AreEqual(1, h.Remove());
            Assert.AreEqual(2, h.Remove());
            Assert.AreEqual(3, h.Remove());
            Assert.AreEqual(4, h.Remove());
            Assert.AreEqual(5, h.Remove());
        }

        [TestMethod]
        public void RemoveAndAdd()
        {
            Heap<int> h = getExampleHeap();
            Assert.AreEqual(h.Remove(), 1);
            h.Add(-5);
            Assert.AreEqual(h.Remove(), -5);
            Assert.AreEqual(h.Remove(), 2);
        }
    }
}
