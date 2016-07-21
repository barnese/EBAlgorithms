using System;

namespace EBAlgorithms.DataStructures {

    public class BinarySearchTreeNode<T> where T : IComparable {
        public T key;
        public BinarySearchTreeNode<T> left;
        public BinarySearchTreeNode<T> right;
        public BinarySearchTreeNode<T> parent;
        public int height;

        public BinarySearchTreeNode(T key) {
            this.key = key;
        }
    }

    public class BinarySearchTree<T> where T : IComparable {

        public BinarySearchTreeNode<T> root = null;

        /// <summary>
        /// Counts the number of nodes in the tree.
        /// </summary>
        public int Count
        {
            get
            {
                return CountNodes(root);
            }
        }

        /// <summary>
        /// Determines the height of the tree, which is the number of edges in the longest path from root to leaf node.
        /// </summary>
        public int Height
        {
            get
            {
                return root == null ? 0 : FindHeight(root);
            }
        }

        /// <summary>
        /// Gets the minimum key in the three.
        /// </summary>
        public T MinKey
        {
            get
            {
                var node = FindMinNode(root);
                return node != null ? node.key : default(T);
            }
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public BinarySearchTree() { }

        /// <summary>
        /// Constructor taking an array of keys to add.
        /// </summary>
        public BinarySearchTree(T[] keys) {
            foreach (var key in keys) {
                Add(key);
            }
        }

        /// <summary>
        /// Adds a key into the tree.
        /// </summary>
        /// <returns>The node added.</returns>
        public virtual BinarySearchTreeNode<T> Add(T key) {
            BinarySearchTreeNode<T> addedNode;
            root = Add(key, root, out addedNode);
            return addedNode;
        }

        private BinarySearchTreeNode<T> Add(T key, BinarySearchTreeNode<T> node, out BinarySearchTreeNode<T> addedNode) {
            if (node == null) {
                node = new BinarySearchTreeNode<T>(key);
                addedNode = node;
            } else if (key.CompareTo(node.key) <= 0) {
                node.left = Add(key, node.left, out addedNode);
                node.left.parent = node;
            } else {
                node.right = Add(key, node.right, out addedNode);
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
        /// <returns>The deleted node.</returns>
        public virtual BinarySearchTreeNode<T> Delete(T key) {
            BinarySearchTreeNode<T> deletedNode;
            root = Delete(key, root, out deletedNode);
            return deletedNode;
        }

        private BinarySearchTreeNode<T> Delete(T key, BinarySearchTreeNode<T> node, out BinarySearchTreeNode<T> deletedNode) {
            if (node == null) {
                deletedNode = node;
                return node;
            }

            if (key.CompareTo(node.key) < 0) {
                node.left = Delete(key, node.left, out deletedNode);
            } else if (key.CompareTo(node.key) > 0) {
                node.right = Delete(key, node.right, out deletedNode);
            } else {
                // Found the node with the given key to be deleted.
                deletedNode = node;

                if (node.left == null) {
                    return node.right;
                } else if (node.right == null) {
                    return node.left;
                }

                var successor = FindMinNode(node.right);
                node.key = successor.key;
                node.right = Delete(node.key, node.right, out deletedNode);
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

        /// <summary>
        /// Finds the level of a given node.
        /// </summary>
        private int FindLevel(BinarySearchTreeNode<T> node) {
            return FindLevel(root, node, 1);
        } 

        private int FindLevel(BinarySearchTreeNode<T> root, BinarySearchTreeNode<T> node, int level) {
            if (root == null) {
                return 0;
            }

            if (root.key.CompareTo(node.key) == 0) {
                return level;
            }

            int nextLevel = FindLevel(root.left, node, level + 1);
            if (nextLevel != 0) {
                return nextLevel;
            }

            nextLevel = FindLevel(root.right, node, level + 1);
            return nextLevel;
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
        /// tree.TraverseInOrder((n) => {
        ///     Console.Write("{0} ", n.key);
        /// });
        /// </example>
        public void TraverseInOrder(Action<BinarySearchTreeNode<T>> callback) {
            // Use a queue to achieve level-order/breadth-first traversal.
            var queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(root);

            while (!queue.IsEmpty()) {
                var node = queue.Dequeue();

                callback(node);

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
