using System;
using System.Collections;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures { 
    public enum HashFunction {
        Division,
        Multiplication,
        Universal
    }

    public class HashEntry<K, V> where K : IComparable {
        public K Key;
        public V Value;

        public HashEntry(K key, V value) {
            this.Key = key;
            this.Value = value;
        }
    }

    public class HashMap<K, V> : IEnumerable<HashEntry<K, V>> where K : IComparable {

        #region Properties
        private int size = 255;
        private LinkedList<HashEntry<K, V>>[] table;
        private HashFunction hashFunction;

        public int Count
        {
            get
            {
                var count = 0;

                foreach (var list in table) {
                    if (list != null) {
                        count += list.Count;
                    }
                }

                return count;
            }
        }
        #endregion

        #region Constructors
        public HashMap() {
            CommonInit();
        }

        public HashMap(HashFunction hashFunction) {
            this.hashFunction = hashFunction;
            CommonInit();
        }

        public HashMap(int size, HashFunction hashFunction = HashFunction.Division) {
            this.size = size;
            this.hashFunction = hashFunction;
            CommonInit();
        }

        private void CommonInit() {
            table = new LinkedList<HashEntry<K, V>>[size];
        }
        #endregion

        #region Indexers and Enumerators

        // Defines an indexer which allows client code to use [] notation for the get and put operations.
        public V this[K key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Put(key, value);
            }
        }

        public IEnumerator<HashEntry<K, V>> GetEnumerator() {
            for (var i = 0; i < table.Length; i++) {
                if (table[i] != null) {
                    foreach (var item in table[i]) {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion

        #region Operations
        public bool ContainsKey(K key) {
            int hash = GetHashCode(key);
            var containsKey = false;

            if (table[hash] != null) {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        containsKey = true;
                        break;
                    }
                }
            }

            return containsKey;
        }

        public void Delete(K key) {
            int hash = GetHashCode(key);

            if (table[hash] != null) {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        table[hash].Delete(item);
                    }
                }
            }
        }

        public V Get(K key) {
            int hash = GetHashCode(key);

            if (table[hash] != null) {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        return item.Value;
                    }
                }
            }

            throw new Exception("Key not found!");
        }

        public int GetHashCode(K key) {
            int hash;
            var k = key.GetHashCode();
            var m = size;

            switch (hashFunction) {
                case HashFunction.Division:
                    hash = k % m;
                    break;
                case HashFunction.Multiplication: {
                    var a = 0.6180339887;
                    hash = (int)Math.Floor(m * (k * a % 1));
                    break;
                }
                default: { // Universal
                    var p = Math.Pow(2, 31) - 1; // a Mersenne prime number > size of universe of keys.
                    var a = 14348907; // Randomly chosen from 0, ..., p-1
                    var b = 243; // Randomly chosen from 0, ..., p-1
                    hash = (int)((a * k + b) % p) % m;
                    break;
                }
            }

            return Math.Abs(hash);
        }

        public void Put(K key, V value) {
            int hash = GetHashCode(key);
            var found = false;

            if (table[hash] == null) {
                table[hash] = new LinkedList<HashEntry<K, V>>();
            } else {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        item.Value = value;
                        found = true;
                        break;
                    }
                }
            }

            if (!found) {
                table[hash].Add(new HashEntry<K, V>(key, value));
            }
        }

        #endregion
    }
}
