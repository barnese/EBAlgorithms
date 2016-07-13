using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms.DataStructures {
    public class Heap<T> where T : IComparable {

        private List<T> list;

        public Heap() {
            list = new List<T>();
        }

        public Heap(List<T> list) {
            this.list = list;
        }

        public int Count {
            get {
                return list.Count;
            }
        }

        public void Add(T item) {
            // TODO
        }

        public void Swap(int leftIndex, int rightIndex) {
            T temp = list[rightIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}
