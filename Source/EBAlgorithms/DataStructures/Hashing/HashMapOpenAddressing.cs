using System;
using System.Collections;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Hash map using open addressing implementation.
    /// </summary>
    public class HashMapOpenAddressing<K, V> : IEnumerable<HashEntry<K, V>> where K : IComparable {

        #region Properties
        private int size = 128;
        private HashEntry<K, V>[] table;

        public int Count {
            get {
                int count = 0;

                foreach (var entry in table) {
                    if (entry != null && !entry.IsDeleted) {
                        count++;
                    }
                }

                return count;
            }
        }
        #endregion

        #region Constructors
        public HashMapOpenAddressing() {
            CommonInit();
        }

        public HashMapOpenAddressing(int size) {
            this.size = size;
            CommonInit();
        }

        private void CommonInit() {
            table = new HashEntry<K, V>[size];
        }
        #endregion

        #region Indexers and Enumerators

        // Defines an indexer which allows client code to use [] notation for the get and put operations.
        public V this[K key] {
            get {
                return Get(key);
            }
            set {
                Put(key, value);
            }
        }

        public IEnumerator<HashEntry<K, V>> GetEnumerator() {
            for (var i = 0; i < table.Length; i++) {
                yield return table[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion

        #region Operations
        public bool ContainsKey(K key) {
            try {
                Get(key);
                return true;
            } catch {
                return false;
            }
        }

        public void Delete(K key) {
            var entry = GetEntry(key);

            if (entry != null) {
                entry.IsDeleted = true;
            }
        }

        public V Get(K key) {
            var entry = GetEntry(key);

            if (entry == null) {
                throw new Exception("Key not found!");
            }

            return entry.Value;
        }

        private HashEntry<K, V> GetEntry(K key) {
            int i = 0;
            int firstHashCode = int.MinValue;
            int hashCode = GetHashCode(key, i);
            HashEntry<K, V> entry = null;

            while (hashCode != firstHashCode && table[hashCode] == null) {
                if (firstHashCode == int.MinValue) {
                    firstHashCode = hashCode;
                }

                if (table[hashCode] != null) {
                    if (table[hashCode].Key.CompareTo(key) == 0) {
                        break;
                    }
                }

                hashCode = GetHashCode(key, ++i);
            }

            if (hashCode != firstHashCode && table[hashCode] != null) {
                entry = table[hashCode];
            }

            return entry;
        }

        private int GetHashCode(K key, int i) {
            var k = Math.Abs(key.GetHashCode());
            return (k + i) % size;
        }

        public void Put(K key, V value) {
            int i = 0;
            int firstHashCode = int.MinValue;
            int hashCode = GetHashCode(key, i);

            while (hashCode != firstHashCode && table[hashCode] != null && table[hashCode].Key.CompareTo(key) != 0) {
                if (firstHashCode == int.MinValue) {
                    firstHashCode = hashCode;
                }

                if (table[hashCode].IsDeleted) {
                    table[hashCode] = new HashEntry<K, V>(key, value);
                    return;
                }

                hashCode = GetHashCode(key, ++i);
            }

            if (firstHashCode != hashCode) {
                if (table[hashCode] == null) {
                    table[hashCode] = new HashEntry<K, V>(key, value);
                } else if (!table[hashCode].IsDeleted && table[hashCode].Key.CompareTo(key) == 0) {
                    table[hashCode].Value = value;
                }
            }
        }
        #endregion
    }
}
