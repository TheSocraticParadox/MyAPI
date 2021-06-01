using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class BTreeTests
    {
        [TestMethod]
        public void Add()
        {
            BTree<int> tree = new BTree<int>(4);
            tree.Add(0);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);
            tree.Add(8);
            tree.Add(10);
            tree.Add(12);
            tree.Add(-1);
            tree.Add(1);
            tree.Add(10);
            tree.Add(13);
        }

        [TestMethod]
        public void Get()
        {
            BTree<int> tree = new BTree<int>(5);
            tree.Add(0);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);
            tree.Add(8);
            tree.Add(10);
            tree.Add(12);
            tree.Add(-1);
            tree.Add(1);
            tree.Add(10);
            tree.Add(13);


            Assert.IsTrue(tree.Contains(2));
            Assert.IsFalse(tree.Contains(3));
            Assert.IsTrue(tree.Contains(2));
            Assert.IsFalse(tree.Contains(225));
            Assert.IsTrue(tree.Contains(-1));
            Assert.IsFalse(tree.Contains(9));
            Assert.IsTrue(tree.Contains(13));

        }

        [TestMethod]
        public void Remove()
        {
            BTree<int> tree = new BTree<int>(3);
            tree.Add(0);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);
            tree.Add(8);
            tree.Add(10);
            tree.Add(12);
            tree.Add(-1);
            tree.Add(1);
            tree.Add(10);
            tree.Add(13);

            Assert.IsTrue(tree.Contains(-1));
            tree.Remove(-1);
            Assert.IsFalse(tree.Contains(1));

            Assert.IsTrue(tree.Contains(13));
            tree.Remove(13);
            Assert.IsFalse(tree.Contains(13));

            Assert.IsTrue(tree.Contains(8));
            tree.Remove(8);
            Assert.IsFalse(tree.Contains(8));

        }



    }
}
