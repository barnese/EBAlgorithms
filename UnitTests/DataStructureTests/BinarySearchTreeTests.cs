﻿using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    
    public class BinarySearchTreeTests {

        private static int[] numbers = { 6, 2, 7, 1, 4, 9, 3, 5, 8 };
        private BinarySearchTree<int> tree = new BinarySearchTree<int>(numbers);
        private int height = 4;

        [Fact]
        public void BinarySearchTree_Add() {
            Assert.Equal(tree.Count, numbers.Length);

            foreach (int number in numbers) {
                Assert.True(tree.ContainsKey(number));
            }
        }

        [Fact]
        public void BinarySearchTree_Delete() {
            foreach (int number in numbers) {
                tree.Delete(number);
                Assert.False(tree.ContainsKey(number));
            }

            Assert.Equal(tree.Count, 0);
        }

        [Fact]
        public void BinarySearchTree_Height() {
            Assert.Equal(tree.Height, height);
        }

        [Fact] 
        public void BinarySearchTree_LevelOrderTraversal() {
            var expected = new List<int> { 6, 2, 7, 1, 4, 9, 3, 5, 8 };

            var i = 0;
            tree.TraverseLevelOrder((node) => {
                Assert.Equal(node.key, expected[i++]);
            });
        }

        [Fact] 
        public void BinarySearchTree_InOrderTraversal() {
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var i = 0;
            tree.TraverseInOrder((node) => {
                Assert.Equal(node.key, expected[i++]);
            });
        }

        [Fact]
        public void BinarySearchTree_PreOrderTraversal() {
            var expected = new List<int> { 6, 2, 1, 4, 3, 5, 7, 9, 8 };

           var i = 0;
            tree.TraversePreOrder((node) => {
                Assert.Equal(node.key, expected[i++]);
            });
        }

        [Fact]
        public void BinarySearchTree_PostOrderTraversal() {
            var expected = new List<int> { 1, 3, 5, 4, 2, 8, 9, 7, 6 };

            var i = 0;
            tree.TraversePostOrder((node) => {
                Assert.Equal(node.key, expected[i++]);
            });
        }
    }
}
