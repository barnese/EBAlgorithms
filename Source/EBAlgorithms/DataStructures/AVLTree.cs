using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {

    public class AVLTree<T> : BinarySearchTree<T> where T : IComparable {

        public AVLTree() { }

        public AVLTree(IEnumerable<T> keys) {
            foreach (var key in keys) {
                Add(key);
            }
        }

        public override BinarySearchTreeNode<T> Add(T key) {
            var node = base.Add(key);
            Rebalance(node);
            return node;
        }

        public override BinarySearchTreeNode<T> Delete(T key) {
            var node = base.Delete(key);
            Rebalance(node.parent);
            return node;
        }

        private void Rebalance(BinarySearchTreeNode<T> node) {
            while (node != null) {
                UpdateNodeHeight(node);

                if (GetNodeHeight(node.left) >= 2 + GetNodeHeight(node.right)) {
                    if (GetNodeHeight(node.left.left) >= GetNodeHeight(node.left.right)) {
                        RotateRight(node);
                    } else {
                        RotateLeft(node.left);
                        RotateRight(node);
                    }
                } else if (GetNodeHeight(node.right) >= 2 + GetNodeHeight(node.left)) {
                    if (GetNodeHeight(node.right.right) >= GetNodeHeight(node.right.left)) {
                        RotateLeft(node);
                    } else {
                        RotateRight(node.right);
                        RotateLeft(node);
                    }
                }

                node = node.parent;
            }
        }

        private void RotateLeft(BinarySearchTreeNode<T> node) {
            var temp = node.right;
            temp.parent = node.parent;

            if (temp.parent == null) {
                root = temp;
            } else {
                if (temp.parent.left?.key.CompareTo(node.key) == 0) {
                    temp.parent.left = temp;
                } else if (temp.parent.right?.key.CompareTo(node.key) == 0) {
                    temp.parent.right = temp;
                }
            }

            node.right = temp.left;
            if (node.right != null) {
                node.right.parent = node;
            }

            temp.left = node;
            node.parent = temp;
            UpdateNodeHeight(node);
            UpdateNodeHeight(temp);
        }

        private void RotateRight(BinarySearchTreeNode<T> node) {
            var temp = node.left;
            temp.parent = node.parent;

            if (temp.parent == null) {
                root = temp;
            } else {
                if (temp.parent.left?.key.CompareTo(node.key) == 0) {
                    temp.parent.left = temp;
                } else if (temp.parent.right?.key.CompareTo(node.key) == 0) {
                    temp.parent.right = temp;
                }
            }

            node.left = temp.right;
            if (node.left != null) {
                node.left.parent = node;
            }

            temp.right = node;
            node.parent = temp;
            UpdateNodeHeight(node);
            UpdateNodeHeight(temp);
        }

        private int GetNodeHeight(BinarySearchTreeNode<T> node) {
            if (node == null) {
                return -1;
            } else {
                return node.height;
            }
        }

        private void UpdateNodeHeight(BinarySearchTreeNode<T> node) {
            node.height = Math.Max(GetNodeHeight(node.left), GetNodeHeight(node.right)) + 1;
        }
    }
}
