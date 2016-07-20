using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {
    
    public class BinarySearchTreeTests {

        private BinarySearchTree<int> tree = new BinarySearchTree<int>();
        private int[] numbers = { 41, 20, 65, 11, 29, 50, 26 };
        private int height = 4;

        public BinarySearchTreeTests() {
            foreach (int number in numbers) {
                tree.Add(number);
            }            
        }

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
    }
}
