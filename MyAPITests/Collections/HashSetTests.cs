using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void Add()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
        }

        [TestMethod]
        public void Remove()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            set.Remove("One");
            set.Remove("Three");
            set.Remove("Five");
            Assert.IsFalse(set.Contains("One"));
            Assert.IsFalse(set.Contains("Three"));
            Assert.IsFalse(set.Contains("Five"));
            Assert.IsTrue(set.Contains("Two"));
            Assert.IsTrue(set.Contains("Four"));
        }

        [TestMethod]
        public void Contains()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.IsTrue(set.Contains("One"));
            Assert.IsFalse(set.Contains("one"));
            Assert.IsTrue(set.Contains("Five"));
            Assert.IsFalse(set.Contains("five"));
            Assert.IsTrue(set.Contains("Three"));
        }

        [TestMethod]
        public void Length()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.AreEqual(set.Length, 5);
        }

        [TestMethod]
        public void Clear()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("One");
            set.Add("Two");
            set.Add("Three");
            set.Add("Four");
            set.Add("Five");
            Assert.AreEqual(set.Length, 5);
            set.Clear();
            Assert.AreEqual(set.Length, 0);
            Assert.IsFalse(set.Contains("One"));
            Assert.IsFalse(set.Contains("Two"));
            Assert.IsFalse(set.Contains("Three"));
            Assert.IsFalse(set.Contains("Four"));
            Assert.IsFalse(set.Contains("Five"));
        }
    }
}
