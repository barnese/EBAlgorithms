using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {

    [TestClass]
    public class InsertionSortTests {

        [TestMethod]
        public void InsertionSort_Integers() {
            var list = TestData.Numbers;

            list.InsertionSort();

            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_Strings() {
            var list = TestData.Words;

            list.InsertionSort();

            Assert.IsTrue(list.IsSorted());
        }
    }
}
