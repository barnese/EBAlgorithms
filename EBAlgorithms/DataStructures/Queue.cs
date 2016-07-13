using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms.DataStructures {

    class QueueNode<T> {
        public T data;
        public QueueNode<T> next = null;

        public QueueNode(T data) {
            this.data = data;
        }
    }

    /// <summary>
    /// Defines a generic queue using a linked list implementation.
    /// </summary>
    public class Queue<T> {
        private QueueNode<T> front;
        private QueueNode<T> rear;

        public string Describe() {
            var description = "[";
            var node = front;

            while (node != null) {
                description += node.data.ToString();

                if (node.next != null) {
                    description += ", ";
                }

                node = node.next;
            }

            description += "]";

            return description;
        }

        public T Dequeue() {
            if (front == null) {
                return default(T);
            }

            T dequeuedNode = front.data;

            if (front == rear) {
                front = rear = null;
            } else {
                front = front.next;
            }

            return dequeuedNode;
        }

        public void Enqueue(T data) {
            var node = new QueueNode<T>(data);
            node.data = data;

            if (IsEmpty()) {
                front = rear = node;
            } else {
                rear.next = node;
                rear = node;
            }
        }

        public bool IsEmpty() {
            return front == null && rear == null;
        }
    }
}
