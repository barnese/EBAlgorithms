using System;
using System.Collections;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {

    class LinkedListNode<T> {
        public T value;
        public LinkedListNode<T> next;

        public LinkedListNode(T value, LinkedListNode<T> next = null) {
            this.value = value;
            this.next = next;
        }
    }

    public class LinkedList<T> : IEnumerable<T> {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count = 0;

        public void Add(T value) {
            var newItem = new LinkedListNode<T>(value);

            if (head == null) {
                head = newItem;
                tail = head;
            } else {
                tail.next = newItem;
                tail = tail.next;
            }

            count++;
        }

        public bool Contains(T value) {
            var node = head;

            while (node != null) {
                if (node.value.Equals(value)) {
                    return true;
                }

                node = node.next;
            }

            return false;
        } 

        public int Count {
            get {               
                return count;
            }
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

                    count--;
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
                throw new Exception("List is empty.");
            }

            for (int i = 0; i < position; i++) {
                node = node.next;
            }

            if (node == null) {
                throw new Exception("Not found.");
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
                        count++;
                        return;
                    }

                    prev = node;
                    node = node.next;
                }

                prev.next = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator() {
            var node = head;

            while (node != null) {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
