using System;
using System.Collections.Generic;
using EBAlgorithms.DataStructures;

namespace EBAlgorithms {

    public class HeapSort<T> where T : IComparable {
        private List<T> list;
        private SortDirection sortDirection;

        public HeapSort(List<T> list) {
            this.list = list;
        }

        public void Sort(SortDirection sortDirection = SortDirection.Ascending) {
            Heap<T> heap;

            if (sortDirection == SortDirection.Ascending) {
                heap = new Heap<T>(list, HeapType.MaxHeap);
            } else {
                heap = new Heap<T>(list, HeapType.MinHeap);
            }

            heap.Sort();

            list = heap.ToList();
        }
    }       
}
