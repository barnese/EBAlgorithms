using System;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Defines a generic hash map entry object.
    /// </summary>
    public class HashEntry<K, V> where K : IComparable {
        public K Key;
        public V Value;
        public bool IsDeleted = false;

        public HashEntry(K key, V value) {
            this.Key = key;
            this.Value = value;
        }
    }
}
