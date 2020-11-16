using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void Add()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            Assert.AreEqual(lst.Get(0), "One");
            Assert.AreEqual(lst.Get(1), "Two");
            Assert.AreEqual(lst.Get(2), "Three");
            Assert.AreEqual(lst.Get(3), "Four");
        }

        [TestMethod]
        public void Length()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            Assert.AreEqual(lst.Length, 4);
        }

        [TestMethod]
        public void Remove()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            Assert.AreEqual(lst.Get(0), "One");
            Assert.AreEqual(lst.Get(1), "Two");
            Assert.AreEqual(lst.Get(2), "Three");
            Assert.AreEqual(lst.Get(3), "Four");
            lst.Remove(0);
            lst.Remove(2);
            lst.Remove(3);
            Assert.AreEqual(lst.Get(0), "Two");
        }

        [TestMethod]
        public void Get()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            Assert.AreEqual(lst.Get(0), "One");
            Assert.AreEqual(lst.Get(1), "Two");
            Assert.AreEqual(lst.Get(2), "Three");
            Assert.AreEqual(lst.Get(3), "Four");
        }
        
        [TestMethod]
        public void Set()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            lst.Set(0, "_one");
            lst.Set(3, "_four");
            lst.Set(1, "_two");
            Assert.AreEqual(lst.Get(0), "_one");
            Assert.AreEqual(lst.Get(1), "_two");
            Assert.AreEqual(lst.Get(2), "Three");
            Assert.AreEqual(lst.Get(3), "_four");
        }

        [TestMethod]
        public void ToArray()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");

            string[] test = lst.ToArray();

            int i = 0;
            foreach (string s in test)
            {
                Assert.AreEqual(s, lst.Get(i));
                i++;
            }    
        }

        [TestMethod]
        public void Clear()
        {
            ArrayList<string> lst = new ArrayList<string>();
            lst.Add("One");
            lst.Add("Two");
            lst.Add("Three");
            lst.Add("Four");
            lst.Clear();
            Assert.AreEqual(lst.Length, 0);
            Assert.AreEqual(lst.ToArray().Length, 0);

        }
    }
}
