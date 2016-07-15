using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {

    [TestClass]
    public class MergeSortTests {

        [TestMethod]
        public void MergeSort_Integers() {
            var list = TestData.Numbers;

            list.MergeSort();

            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void MergeSort_Strings() {
            var list = TestData.Words;

            list.MergeSort();

            Assert.IsTrue(list.IsSorted());
        }
    }
}
