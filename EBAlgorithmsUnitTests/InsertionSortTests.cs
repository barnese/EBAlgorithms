﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    [TestClass]
    public class InsertionSortTests {
        [TestMethod]
        public void InsertionSort_Integers() {
            var list = new List<int> { 1, 99, 4, 23, 89, 54, 55, 29, 20, 67, 74, 9, 3, 88, 61, 40, 92, 30, 1, 72 };

            var sortedList = InsertionSort<int>.Sort(list);

            Assert.IsTrue(InsertionSort<int>.IsSorted(sortedList));
        }

        [TestMethod]
        public void InsertionSort_Strings() {
            var list = new List<string> { "zebra", "cat", "walrus", "bird", "bobcat", "bear", "snake", "elephant", "giraffe" };

            var sortedList = InsertionSort<string>.Sort(list);

            Assert.IsTrue(InsertionSort<string>.IsSorted(sortedList));
        }
    }
}
