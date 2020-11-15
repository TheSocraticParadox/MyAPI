using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class HashMapTests
    {
        [TestMethod]
        public void Add()
        {
            HashMap<string, int> test = new HashMap<string, int>();
            test.Add("One", 1);
            test.Add("Two", 2);
            test.Add("Three", 3);
            test.Add("Four", 4);
            test.Add("Five", 5);
        }

        [TestMethod]
        public void Get()
        {
            HashMap<string, int> test = new HashMap<string, int>();
            test.Add("One", 1);
            test.Add("Two", 2);
            test.Add("Three", 3);
            test.Add("Four", 4);
            test.Add("Five", 5);

            Assert.AreEqual(test.Get("One"), 1);
            Assert.AreEqual(test.Get("Two"), 2);
            Assert.AreEqual(test.Get("Three"), 3);
            Assert.AreEqual(test.Get("Four"), 4);
            Assert.AreEqual(test.Get("Five"), 5);

        }

        [TestMethod]
        public void Remove()
        {
            HashMap<string, int> test = new HashMap<string, int>();
            test.Add("One", 1);
            test.Add("Two", 2);
            test.Add("Three", 3);
            test.Add("Four", 4);
            test.Add("Five", 5);

            test.Remove("One");
            test.Remove("Three");
            test.Remove("Five");

            Assert.IsFalse(test.Contains("One"));
            Assert.AreEqual(test.Get("Two"), 2);
            Assert.IsFalse(test.Contains("Three"));
            Assert.AreEqual(test.Get("Four"), 4);
            Assert.IsFalse(test.Contains("Five"));
        }
    }
}
