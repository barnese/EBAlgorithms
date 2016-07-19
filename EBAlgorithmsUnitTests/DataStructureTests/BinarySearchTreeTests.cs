using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests.DataStructureTests {
    [TestClass]
    public class BinarySearchTreeTests {

        private BinarySearchTree<int> tree = new BinarySearchTree<int>();
        private int[] numbers = { 41, 20, 65, 11, 29, 50, 26 };
        private int height = 4;

        [TestInitialize]
        public void Initialize() {
            foreach (int number in numbers) {
                tree.Add(number);
            }
        }

        [TestMethod]
        public void BinarySearchTree_Add() {
            Assert.AreEqual(tree.Count, numbers.Length);

            foreach (int number in numbers) {
                Assert.IsTrue(tree.ContainsKey(number));
            }
        }

        [TestMethod]
        public void BinarySearchTree_Delete() {
            foreach (int number in numbers) {
                tree.Delete(number);
                Assert.IsFalse(tree.ContainsKey(number));
            }

            Assert.AreEqual(tree.Count, 0);
        }

        [TestMethod]
        public void BinarySearchTree_Height() {
            Assert.AreEqual(tree.Height, height);
        }
    }
}
