using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class GraphTests
    {

        [TestMethod]
        public void Add()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);
        }

        [TestMethod]
        public void Remove()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            test.Remove(4);
            Assert.IsFalse(test.Contains(4));
            test.Remove(1);
            Assert.IsFalse(test.Contains(1));
            test.Remove(6);
            Assert.IsFalse(test.Contains(6));

            Assert.IsTrue(test.Contains(2));
            Assert.IsTrue(test.Contains(3));
            Assert.IsTrue(test.Contains(5));
        }

        [TestMethod]
        public void Contains()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            Assert.IsTrue(test.Contains(1));
            Assert.IsTrue(test.Contains(2));
            Assert.IsTrue(test.Contains(3));
            Assert.IsTrue(test.Contains(4));
            Assert.IsTrue(test.Contains(5));
            Assert.IsTrue(test.Contains(6));
        }

        [TestMethod]
        public void Connect()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            test.Connect(1, 5);
            test.Connect(2, 3);
        }


        [TestMethod]
        public void IsConnected()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            test.Connect(1, 5);
            test.Connect(2, 3);

            Assert.IsTrue(test.IsConnected(1, 5));
            Assert.IsTrue(test.IsConnected(2, 3));
            Assert.IsFalse(test.IsConnected(1, 4));
            Assert.IsFalse(test.IsConnected(1, 1));
        }

        [TestMethod]
        public void Disconnect()
        {
            Graph<int> test = new Graph<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            test.Connect(1, 5);
            test.Connect(2, 3);

            Assert.IsTrue(test.IsConnected(1, 5));
            Assert.IsTrue(test.IsConnected(2, 3));
            Assert.IsFalse(test.IsConnected(1, 4));
            Assert.IsFalse(test.IsConnected(1, 1));


            test.Disconnect(1, 5);
            Assert.IsFalse(test.IsConnected(1, 5));
        }
    }
}
