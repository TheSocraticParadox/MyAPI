using System;
using System.Collections.Generic;
using System.Text;

namespace MyAPI.Collections
{
    /// <summary>
    /// HashMap
    /// Represenet a set of key value pair stored in a hash table
    /// </summary>
    public class HashMap<K, V> where K : IComparable
    {
        private int count;
        private int containers;
        private List<KeyValue<K, V>>[] data;

        /// <summary>
        /// Creates a data structure for storing key-value pairs
        /// </summary>
        public HashMap()
        {
            this.count = 0;
            this.containers = 2;
            this.data = new List<KeyValue<K, V>>[containers];
        }


        /// <summary>
        /// Computes the range-restricted hash for a key
        /// </summary>
        private int ComputeHash(K key)
        {
            return Math.Abs(key.GetHashCode() % containers);
        }

        /// <summary>
        /// Doubles the container size for the hashset and rehashes all data into the new container
        /// </summary>
        private void DoubleContainerSize()
        {
            List<KeyValue<K, V>>[] oldData = this.data;
            this.containers = this.containers * 2;
            this.data = new List<KeyValue<K, V>>[containers];
            this.count = 0;
            foreach (List<KeyValue<K, V>> l in oldData)
                if (l != null)
                    foreach (KeyValue<K, V> kv in l)
                        this.Add(kv.Key, kv.Value);
        }

        /// <summary>
        /// Adds a key value pair to the hashset
        /// </summary>
        public void Add(K key, V value)
        {
            if (count > containers)
                DoubleContainerSize();
            int hash = ComputeHash(key);
            if (this.data[hash] == null)
                this.data[hash] = new List<KeyValue<K, V>>();
            this.data[hash].AddLast(new KeyValue<K, V>(key, value));
            count++;
        }

        /// <summary>
        /// Given a key, gets the value stored under that key
        /// </summary>
        public V Get(K key)
        {
            int hash = ComputeHash(key);
            foreach (KeyValue<K, V> kv in this.data[hash])
                if (kv.Key.CompareTo(key) == 0)
                    return kv.Value;
            throw new IndexOutOfRangeException("Key not found");
        }

        /// <summary>
        /// Given a key, removes the key value pair from the HashSet
        /// </summary>
        public V Remove(K key)
        {
            int hash = ComputeHash(key);
            foreach (KeyValue<K, V> kv in this.data[hash])
                if (kv.Key.CompareTo(key) == 0)
                {
                    count--;
                    return this.data[hash].Remove(kv).Value;
                }
            throw new IndexOutOfRangeException("Key not found");
        }

        /// <summary>
        /// Checks if a key is present in the hashset
        /// </summary>
        public bool Contains(K key)
        {
            int hash = ComputeHash(key);
            foreach (KeyValue<K, V> kv in this.data[hash])
                if (kv.Key.CompareTo(key) == 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Private class for a key value pair
        /// </summary>
        private class KeyValue<T, U>
        {
            public T Key;
            public U Value;
            public KeyValue(T k, U v)
            {
                this.Key = k;
                this.Value = v;
            }
        }
    }
}
