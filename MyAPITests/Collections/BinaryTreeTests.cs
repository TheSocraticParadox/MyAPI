using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;

namespace MyAPITests.Collections
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void AddRoot()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(1);
            int[] res = myTree.AsArray();
            Assert.AreEqual(1, res[0]);
        }

        [TestMethod]
        public void AddLeaves()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(2);
            myTree.Add(1);
            myTree.Add(3);
            myTree.Add(4);
            int[] res = myTree.AsArray();
            Assert.AreEqual(2, res[0]);
            Assert.AreEqual(1, res[1]);
            Assert.AreEqual(3, res[2]);
            Assert.AreEqual(4, res[6]);
        }

        [TestMethod]
        public void RemoveLeafNode()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(2);
            myTree.Add(1);
            myTree.Add(3);
            myTree.Add(4);
            Assert.IsTrue(myTree.Contains(1));
            myTree.Remove(1);
            Assert.IsFalse(myTree.Contains(1));
            Assert.IsTrue(myTree.Contains(2));
            Assert.IsTrue(myTree.Contains(3));
            Assert.IsTrue(myTree.Contains(4));
        }

        [TestMethod]
        public void RemoveBranchWithOneChild()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(2);
            myTree.Add(1);
            myTree.Add(3);
            myTree.Add(4);
            Assert.IsTrue(myTree.Contains(3));
            myTree.Remove(3);
            Assert.IsFalse(myTree.Contains(3));
            Assert.IsTrue(myTree.Contains(1));
            Assert.IsTrue(myTree.Contains(2));
            Assert.IsTrue(myTree.Contains(4));
        }


        [TestMethod]
        public void RemoveBranchWithTwoChildren()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(1);
            myTree.Add(3);
            myTree.Add(2);
            myTree.Add(4);
            Assert.IsTrue(myTree.Contains(2));
            myTree.Remove(2);
            Assert.IsFalse(myTree.Contains(2));
            Assert.IsTrue(myTree.Contains(1));
            Assert.IsTrue(myTree.Contains(3));
            Assert.IsTrue(myTree.Contains(4));
        }


        [TestMethod]
        public void Contains()
        {
            BinaryTree<int> myTree = new BinaryTree<int>();
            myTree.Add(2);
            myTree.Add(1);
            myTree.Add(3);
            myTree.Add(4);
            int[] res = myTree.AsArray();
            Assert.IsTrue(myTree.Contains(4));
            Assert.IsTrue(myTree.Contains(2));
            Assert.IsTrue(myTree.Contains(3));
            Assert.IsTrue(myTree.Contains(1));
            Assert.IsFalse(myTree.Contains(17));
        }
    }
}
