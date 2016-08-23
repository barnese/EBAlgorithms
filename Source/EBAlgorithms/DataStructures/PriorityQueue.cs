using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public class PriorityQueuePair<T> : IComparable {
        public T Value;
        public int Priority;

        public PriorityQueuePair(T value, int priority) {
            Value = value;
            Priority = priority;
        }

        public int CompareTo(object obj) {
            PriorityQueuePair<T> otherPair = obj as PriorityQueuePair<T>;
            if (otherPair != null) {
                return this.Priority.CompareTo(otherPair.Priority);
            } else
                throw new ArgumentException("Object is not a PriorityQueuePair<T>");
        }

        public override string ToString() {
            return String.Format("({0}:{1})", Value, Priority);
        }
    }

    public enum PriorityQueueComparator {
        MinPriorityFirst = 1,
        MaxPriorityFirst = -1
    }

    public class PriorityQueue<T> where T : IComparable {
        private Heap<PriorityQueuePair<T>> heap;

        public PriorityQueue(PriorityQueueComparator comparator = PriorityQueueComparator.MaxPriorityFirst) {
            heap = new Heap<PriorityQueuePair<T>>((HeapType)comparator);
        } 

        public void Add(T item, int priority) {
            var pair = new PriorityQueuePair<T>(item, priority);
            heap.Add(pair);
        }

        public int Count { get { return heap.Count; } }

        public string Describe() {
            return heap.Describe();
        }

        public T RemoveRoot() {
            var pair = heap.RemoveRoot();
            return pair.Value;
        }
    }
}
