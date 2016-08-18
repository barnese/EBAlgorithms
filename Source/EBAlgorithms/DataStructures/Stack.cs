using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Generic stack.
    /// </summary>
    public class Stack<T> {
        private List<T> stackList = new List<T>();
        private int topIndex = -1;

        public int Count {
            get { return stackList.Count; }
        }

        public bool IsEmpty {
            get { return stackList.Count == 0; }
        }

        public string Describe() {
            var description = "";

            for (var i = stackList.Count - 1; i >= 0; i--) {
                description += stackList[i].ToString();

                if (i > 0) {
                    description += ", ";
                }
            }

            return description;
        }

        public T Peek() {
            return stackList[topIndex];
        }

        public T Pop() {
            if (topIndex < 0) {
                throw new Exception("No items to pop.");
            }

            var item = stackList[topIndex];
            stackList.RemoveAt(topIndex);
            topIndex--;
            return item;
        }

        public void Push(T item) {
            stackList.Add(item);
            topIndex++;
        }
    }
}
