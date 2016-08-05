using System;
using System.Collections;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures { 
    public enum HashFunction {
        Division,
        Multiplication,
        Universal
    }

    public class HashMap<K, V> : IEnumerable<HashEntry<K, V>> where K : IComparable {

        #region Properties
        private const int baseSize = 251;
        private int size = baseSize;
        private bool userSizePreferred = false;
        private LinkedList<HashEntry<K, V>>[] table;
        private HashFunction hashFunction;

        public int Count {
            get {
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

            userSizePreferred = true;

            // Adjust the size of the table so that it is a prime for better hashing.
            size = MathHelpers.FindClosestPrime(size);

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

            if (table[hash] != null) {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Delete(K key) {
            int hash = GetHashCode(key);

            if (table[hash] != null) {
                foreach (var item in table[hash]) {
                    if (item.Key.CompareTo(key) == 0) {
                        table[hash].Delete(item);
                        break;
                    }
                }

                ResizeTableIfNecessary();
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

            switch (hashFunction) {
                case HashFunction.Division: {
                    hash = k % size;
                    break;
                }
                case HashFunction.Multiplication: {
                    // TODO: Verify correctness.
                    var a = 0.6180339887;
                    hash = (int)Math.Floor(size * (k * a % 1));
                    break;
                }
                default: { // Universal
                    // TODO: Verify correctness.
                    var p = Math.Pow(2, 31) - 1; // a Mersenne prime number > size of universe of keys.
                    var a = 14348907; // Randomly chosen from 0, ..., p-1
                    var b = 243; // Randomly chosen from 0, ..., p-1
                    hash = (int)((a * k + b) % p) % size;
                    break;
                }
            }

            return Math.Abs(hash);
        }

        public void Put(K key, V value) {
            Put(table, key, value, true);
        }

        private void Put(LinkedList<HashEntry<K, V>>[] table, K key, V value, bool resizeTableIfNecessary) {
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

                if (resizeTableIfNecessary) {
                    ResizeTableIfNecessary();
                }
            }
        }

        private void ResizeTableIfNecessary() {
            var itemCount = Count;

            if (itemCount >= table.Length) {
                // Double the table size.
                AdjustTableSize(2);
            } else if (!userSizePreferred && itemCount > baseSize && itemCount <= table.Length / 4) {
                // Halve the table size.
                AdjustTableSize(0.5);
            }
        }

        private void AdjustTableSize(double adjustmentFactor) {
            // Adjust table size by adjustment factor then find closest prime for better hashing.
            size = MathHelpers.FindClosestPrime((int)Math.Floor(size * adjustmentFactor));

            var newTable = new LinkedList<HashEntry<K, V>>[size];

            foreach (var list in table) {
                if (list != null) {
                    foreach (var item in list) {
                        Put(newTable, item.Key, item.Value ,false);
                    }
                }
            }

            table = newTable;
        }

        #endregion
    }
}
