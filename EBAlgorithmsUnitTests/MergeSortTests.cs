﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {

    [TestClass]
    public class MergeSortTests {

        [TestMethod]
        public void MergeSort_Integers() {
            var list = new List<int> { 1, 99, 4, 23, 89, 54, 55, 29, 20, 67, 74, 9, 3, 88, 61, 40, 92, 30, 1, 72 };

            list.MergeSort();

            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void MergeSort_Strings() {
            var list = new List<string> { "zebra", "cat", "walrus", "bird", "bobcat", "bear", "snake", "elephant", "giraffe" };

            list.MergeSort();

            Assert.IsTrue(list.IsSorted());
        }
    }
}
