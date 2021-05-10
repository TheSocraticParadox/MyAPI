using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPI.Collections;
using System;

namespace MyAPITests.Collections
{
    [TestClass]
    public class TrieTests
    {

        private Trie CreateTrie()
        {
            Trie t = new Trie();
            t.Insert("apple");
            t.Insert("orange");
            t.Insert("banana");
            return t;
        }


        [TestMethod]
        public void Insert()
        {
            CreateTrie();
        }

        [TestMethod]
        public void Contains()
        {
            Trie t = CreateTrie();
            Assert.IsTrue(t.Contains("apple"));
            Assert.IsTrue(t.Contains("orange"));
            Assert.IsTrue(t.Contains("banana"));
            Assert.IsFalse(t.Contains("watermelon"));
            Assert.IsFalse(t.Contains("peach"));
        }

        [TestMethod]
        public void ContainsCaseInsensitive()
        {
            Trie t = CreateTrie();
            Assert.IsTrue(t.Contains("APPLE"));
            Assert.IsTrue(t.Contains("OrAnGe"));
            Assert.IsTrue(t.Contains("bananA"));
            Assert.IsFalse(t.Contains("WaTerMeLon"));
            Assert.IsFalse(t.Contains("PEACH"));
        }

        [TestMethod]
        public void StartsWith()
        {
            Trie t = CreateTrie();
            Assert.IsTrue(t.StartsWith("app"));
            Assert.IsTrue(t.StartsWith("or"));
            Assert.IsTrue(t.StartsWith("ban"));
        }

        [TestMethod]
        public void StartsWithCaseInsensitive()
        {
            Trie t = CreateTrie();
            Assert.IsTrue(t.StartsWith("App"));
            Assert.IsTrue(t.StartsWith("oR"));
            Assert.IsTrue(t.StartsWith("BAN"));
        }


        [TestMethod]
        public void GetSuggestion()
        {
            Trie t = CreateTrie();
            Assert.AreEqual("apple", t.GetSuggestion("app"));
            Assert.AreEqual("banana", t.GetSuggestion("ban"));
            Assert.AreEqual("orange", t.GetSuggestion("orang"));
            Assert.AreEqual("xxx", t.GetSuggestion("xxx"));
        }

        [TestMethod]
        public void GetSuggestionCaseInsensitive()
        {
            Trie t = CreateTrie();
            Assert.AreEqual("apple", t.GetSuggestion("aPp"));
            Assert.AreEqual("banana", t.GetSuggestion("BAN"));
            Assert.AreEqual("orange", t.GetSuggestion("oraNG"));
            Assert.AreEqual("xxx", t.GetSuggestion("xXX"));
        }
    }
}
