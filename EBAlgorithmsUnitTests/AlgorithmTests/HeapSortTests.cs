using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {

    [TestClass]
    public class HeapSortTests {

        [TestMethod]
        public void HeapSort_Integers() {
            var list = TestData.Numbers;

            list.HeapSort();

            Assert.IsTrue(list.IsSorted());

            list.HeapSort(SortDirection.Descending);

            Assert.IsTrue(list.IsSorted(SortDirection.Descending));
        }

        [TestMethod]
        public void HeapSort_Strings() {
            var list = TestData.Words;

            list.HeapSort();

            Assert.IsTrue(list.IsSorted());

            list.HeapSort(SortDirection.Descending);

            Assert.IsTrue(list.IsSorted(SortDirection.Descending));
        }
    }
}
