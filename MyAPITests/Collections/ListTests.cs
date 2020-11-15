using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void AddFirst()
        {
            List<int> test = new List<int>();
            test.AddFirst(1);
            test.AddFirst(2);
            test.AddFirst(3);
            test.AddFirst(4);

            Assert.AreEqual(4, test.Length, "Length incorrect");
            int cur = 4;
            foreach (int i in test)
            {
                Assert.AreEqual(cur, i);
                cur--;
            }
        }


        [TestMethod]
        public void AddLast()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);

            Assert.AreEqual(3, test.Length, "Length incorrect");
            int cur = 1;
            foreach (int i in test)
            {
                Assert.AreEqual(i, cur);
                cur++;
            }

        }

        [TestMethod]
        public void AddFirstAndLast()
        {
            List<int> test = new List<int>();
            test.AddFirst(2);
            test.AddLast(3);
            test.AddFirst(1);
            test.AddLast(4);

            Assert.AreEqual(4, test.Length, "Length incorrect");
            int cur = 1;
            foreach (int i in test)
            {
                Assert.AreEqual(i, cur);
                cur++;
            }
        }


        [TestMethod]
        public void Remove()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);
            test.AddLast(5);
            test.Remove(1);
            test.Remove(3);
            test.Remove(5);
            Assert.IsFalse(test.Contains(1));
            Assert.IsTrue(test.Contains(2));
            Assert.IsFalse(test.Contains(3));
            Assert.IsTrue(test.Contains(4));
            Assert.IsFalse(test.Contains(5));

        }

        [TestMethod]
        public void RemoveFirst()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);

            int val = test.RemoveFirst();
            Assert.AreEqual(1, val);
            Assert.AreEqual(3, test.Length);
        }

        [TestMethod]
        public void RemoveLast()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);

            int val = test.RemoveLast();
            Assert.AreEqual(4, val);
            Assert.AreEqual(3, test.Length);
        }

        [TestMethod]
        public void Contains()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);

            Assert.IsTrue(test.Contains(3));
            Assert.IsFalse(test.Contains(7));
        }

        [TestMethod]
        public void Item()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);

            Assert.AreEqual(1, test.Item(0));
            Assert.AreEqual(2, test.Item(1));
            Assert.AreEqual(3, test.Item(2));
            Assert.AreEqual(4, test.Item(3));
        }

        [TestMethod]
        public void Clear()
        {
            List<int> test = new List<int>();
            test.AddLast(1);
            test.AddLast(2);
            test.AddLast(3);
            test.AddLast(4);

            test.Clear();

            Assert.AreEqual(0, test.Length);
            foreach (int i in test)
                Assert.Fail("List should be empty");

            test.AddFirst(5);
            Assert.AreEqual(1, test.Length);
        }
    }
}
