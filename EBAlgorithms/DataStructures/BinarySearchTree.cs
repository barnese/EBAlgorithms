using System;

namespace EBAlgorithms.DataStructures {

    public class BinarySearchTreeNode<T> {
        public T key;
        public BinarySearchTreeNode<T> left;
        public BinarySearchTreeNode<T> right;
        public BinarySearchTreeNode<T> parent;

        public BinarySearchTreeNode(T key, BinarySearchTreeNode<T> left = null, BinarySearchTreeNode<T> right = null) {
            this.key = key;

            if (left != null) {
                this.left = left;
                this.left.parent = this;
            }

            if (right != null) {
                this.right = right;
                this.right.parent = this;
            }
        }
    }

    public class BinarySearchTree<T> where T : IComparable {

        private BinarySearchTreeNode<T> root = null;

        /// <summary>
        /// Counts the number of nodes in the tree.
        /// </summary>
        public int Count {
            get {
                return CountNodes(root);
            }
        }

        /// <summary>
        /// Determines the height of the tree, which is the number of edges in the longest path from root to leaf node.
        /// </summary>
        public int Height {
            get {
                return root == null ? 0 : FindHeight(root);
            }
        }

        /// <summary>
        /// Gets the minimum key in the three.
        /// </summary>
        public T MinKey {
            get {
                var node = FindMinNode(root);
                return node != null ? node.key : default(T);
            }
        }

        /// <summary>
        /// Adds a key into the tree.
        /// </summary>
        public void Add(T key) {
            root = Add(key, root);
        }

        private BinarySearchTreeNode<T> Add(T key, BinarySearchTreeNode<T> node) {
            if (node == null) {
                node = new BinarySearchTreeNode<T>(key);
            } else if (key.CompareTo(node.key) <= 0) {
                node.left = Add(key, node.left);
                node.left.parent = node;
            } else {
                node.right = Add(key, node.right);
                node.right.parent = node;
            }

            return node;
        }

        /// <summary>
        /// Determines if the given key exists in the tree.
        /// </summary>
        public bool ContainsKey(T key) {
            return ContainsKey(key, root);
        }

        private bool ContainsKey(T key, BinarySearchTreeNode<T> node) {
            if (node == null) {
                return false;
            }

            if (node.key.CompareTo(key) == 0) {
                return true;
            } else if (key.CompareTo(node.key) <= 0) {
                return ContainsKey(key, node.left);
            } else {
                return ContainsKey(key, node.right);
            }
        }

        private int CountNodes(BinarySearchTreeNode<T> node) {
            if (node == null) {
                return 0;
            }

            return 1 + CountNodes(node.left) + CountNodes(node.right);
        }

        /// <summary>
        /// Deletes the node with the given key.
        /// </summary>
        public void Delete(T key) {
            root = Delete(key, root);
        } 

        private BinarySearchTreeNode<T> Delete(T key, BinarySearchTreeNode<T> node = null) {
            if (node == null) {
                return node;
            }

            if (key.CompareTo(node.key) < 0) {
                node.left = Delete(key, node.left);
            } else if (key.CompareTo(node.key) > 0) {
                node.right = Delete(key, node.right);
            } else {
                // Found the node with the given key to be deleted.
                if (node.left == null) {
                    return node.right;
                } else if (node.right == null) {
                    return node.left;
                }

                var successor = FindMinNode(node.right);
                node.key = successor.key;
                node.right = Delete(node.key, node.right);
            }

            return node;
        }
      
        /// <summary>
        /// Finds the height (in terms of edges) of the given node.
        /// </summary>
        private int FindHeight(BinarySearchTreeNode<T> node) {
            if (node == null) {
                return 0;
            }

            return Math.Max(FindHeight(node.left), FindHeight(node.right)) + 1;
        }

        private BinarySearchTreeNode<T> FindMinNode(BinarySearchTreeNode<T> node) {
            while (node.left != null) {
                node = node.left;
            }

            return node;
        }

        /// <summary>
        /// Traverses the tree from the root returning a callback for each node.
        /// </summary>
        /// <example>
        /// tree.TraverseInOrder((k) => {
        ///     Console.Write("{0} ", k);
        /// });
        /// </example>
        public void TraverseInOrder(Action<T> callback) {
            // Use a queue to achieve level-order/breadth-first traversal.
            var queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(root);

            while (!queue.IsEmpty()) {
                var node = queue.Dequeue();

                callback(node.key);

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
        }
    }
}
