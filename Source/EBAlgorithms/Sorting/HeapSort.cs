using System;
using System.Collections.Generic;
using EBAlgorithms.DataStructures;

namespace EBAlgorithms {

    public class HeapSort<T> where T : IComparable {
        private List<T> list;

        public HeapSort(List<T> list) {
            this.list = list;
        }

        public void Sort(SortDirection sortDirection = SortDirection.Ascending) {
            Heap<T> heap = new Heap<T>(list, (HeapType)((int)sortDirection * -1));

            heap.Sort();

            list = heap.ToList();
        }
    }       
}
