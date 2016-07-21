using Xunit;
using EBAlgorithms.DataStructures;
using System.Linq;

namespace EBAlgorithmsUnitTests {

    public class AVLTreeTests {

        private void TestTreeInsertDelete(int[] numbers, int? numberToAdd, int? numberToDelete, int[] expected) {
            var tree = new AVLTree<int>(numbers);

            if (numberToAdd != null) {
                tree.Add(numberToAdd.Value);
            }

            if (numberToDelete != null) {
                tree.Delete(numberToDelete.Value);
            }

            int[] result = new int[expected.Length];
            int i = 0;
            tree.TraverseInOrder((node) => {
                result[i++] = node.key;
            });

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void AVLTree_Insert_LeftRotate() {
            int[] numbers = { 1, 2 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, 3, null, expected);
        }

        [Fact]
        public void AVLTree_Insert_RightRotate() {
            int[] numbers = { 3, 2 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, 1, null, expected);
        }

        [Fact]
        public void AVLTree_Insert_DoubleLeftRotate() {
            int[] numbers = { 1, 3 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, 2, null, expected);
        }

        [Fact]
        public void AVLTree_Insert_DoubleRightRotate() {
            int[] numbers = { 3, 1 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, 2, null, expected);
        }

        [Fact]
        public void AVLTree_Delete_LeftRotate() {
            int[] numbers = { 2, 1, 3, 4 };
            int[] expected = { 3, 2, 4 };

            TestTreeInsertDelete(numbers, null, 1, expected);
        }

        [Fact]
        public void AVLTree_Delete_RightRotate() {
            int[] numbers = { 3, 2, 4, 1 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, null, 4, expected);
        }

        [Fact]
        public void AVLTree_Delete_DoubleLeftRotate() {
            int[] numbers = { 2, 1, 4, 3 };
            int[] expected = { 3, 2, 4 };

            TestTreeInsertDelete(numbers, null, 1, expected);
        }

        [Fact]
        public void AVLTree_Delete_DoubleRightRotate() {
            int[] numbers = { 3, 1, 4, 2 };
            int[] expected = { 2, 1, 3 };

            TestTreeInsertDelete(numbers, null, 4, expected);
        }

        [Fact]
        public void AVLTree_InsertDelete_Case1() {
            char[] chars = { 'c', 'b', 'e', 'a', 'd', 'f' };
            char[] expected = { 'e', 'c', 'f', 'b', 'd', 'g' };

            var tree = new AVLTree<char>(chars);

            tree.Delete('a');
            tree.Add('g');

            char[] result = new char[expected.Length];
            int i = 0;
            tree.TraverseInOrder((node) => {
                result[i++] = node.key;
            });

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void AVLTree_InsertDelete_Case2() {
            char[] chars = { 'e', 'c', 'f', 'b', 'd', 'g' };
            char[] expected = { 'c', 'b', 'e', 'a', 'd', 'f' };

            var tree = new AVLTree<char>(chars);

            tree.Delete('g');
            tree.Add('a');

            char[] result = new char[expected.Length];
            int i = 0;
            tree.TraverseInOrder((node) => {
                result[i++] = node.key;
            });

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void AVLTree_InsertDelete_Case3() {
            char[] chars = { 'e', 'c', 'j', 'a', 'd', 'h', 'k', 'b', 'g', 'i', 'l' };
            char[] expected = { 'h', 'e', 'j', 'c', 'g', 'i' ,'k', 'a', 'd', 'f', 'l' };

            var tree = new AVLTree<char>(chars);

            tree.Delete('b');
            tree.Add('f');

            char[] result = new char[expected.Length];
            int i = 0;
            tree.TraverseInOrder((node) => {
                result[i++] = node.key;
            });

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void AVLTree_InsertDelete_Case4() {
            char[] chars = { 'h', 'c', 'k', 'b', 'e', 'i', 'l', 'a', 'd', 'f', 'j' };
            char[] expected = { 'e', 'c', 'h', 'b', 'd', 'f', 'k', 'a', 'g', 'i', 'l' };

            var tree = new AVLTree<char>(chars);

            tree.Delete('j');
            tree.Add('g');

            char[] result = new char[expected.Length];
            int i = 0;
            tree.TraverseInOrder((node) => {
                result[i++] = node.key;
            });

            Assert.True(result.SequenceEqual(expected));
        }
    }
}
