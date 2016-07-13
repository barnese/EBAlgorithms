using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms.DataStructures {

    class LinkedListNode<T> {
        public T value;
        public LinkedListNode<T> next;

        public LinkedListNode(T value, LinkedListNode<T> next = null) {
            this.value = value;
            this.next = next;
        }
    }

    public class LinkedList<T> {
        private LinkedListNode<T> head;

        private LinkedListNode<T> lastNode
        {
            get
            {
                var node = head;

                while (node.next != null) {
                    node = node.next;
                }

                return node;
            }
        }

        public void Add(T value) {
            var newItem = new LinkedListNode<T>(value);

            if (head == null) {
                head = newItem;
            } else {
                lastNode.next = newItem;
            }
        }

        public int Count() {
            int count = 0;

            var node = head;

            while (node != null) {
                count++;
                node = node.next;
            }

            return count;
        }

        public void Delete(T value) {
            LinkedListNode<T> prev = null;
            var node = head;

            while (node != null) {
                if (node.value.Equals(value)) {
                    if (prev == null) {
                        head = node.next;
                    } else {
                        prev.next = node.next;
                    }

                    break;
                }

                prev = node;
                node = node.next;
            }
        }

        public string Describe() {
            var description = "[";
            var node = head;

            while (node != null) {
                description += node.value.ToString();

                if (node.next != null) {
                    description += ", ";
                }

                node = node.next;
            }

            description += "]";

            return description;
        }

        public T Get(int position) {
            var node = head;

            if (node == null) {
                return default(T);
            }

            for (int i = 0; i < position; i++) {
                node = node.next;
            }

            if (node == null) {
                return default(T);
            }

            return node.value;
        }

        public void InsertBefore(T beforeValue, T newValue) {
            var newNode = new LinkedListNode<T>(newValue);

            if (head == null) {
                head = newNode;
            } else {
                var node = head;
                LinkedListNode<T> prev = null;

                while (node != null) {
                    if (node.value.Equals(beforeValue)) {
                        if (prev != null) {
                            prev.next = newNode;
                        } else {
                            head = newNode;
                        }
                        newNode.next = node;
                        return;
                    }

                    prev = node;
                    node = node.next;
                }

                prev.next = newNode;
            }
        }
    }
}
