using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    [TestClass]
    public class InsertionSortTests {
        [TestMethod]
        public void InsertionSort_Integers() {
            var list = new List<int> { 5, 2, 4, 6, 1, 3 };

            var sortedList = InsertionSort<int>.Sort(list);

            Assert.IsTrue(InsertionSort<int>.IsSorted(sortedList));
        }

        [TestMethod]
        public void InsertionSort_Strings() {
            var words = new List<string> { "zebra", "dog", "fish", "snake", "groundhog", "cat", "rabbit", "bear" };

            var sortedWords = InsertionSort<string>.Sort(words);

            Assert.IsTrue(InsertionSort<string>.IsSorted(sortedWords));
        }
    }
}
