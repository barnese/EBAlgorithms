using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class HeapSortTests {
        private List<int> list = TestData.Numbers;

        [Fact]
        public void HeapSort_IntegersAscending() {
            list.HeapSort(SortDirection.Ascending);
            Assert.True(list.IsSorted(SortDirection.Ascending));
        }

        [Fact]
        public void HeapSort_IntegersDescending() {
            list.HeapSort(SortDirection.Descending);
            Assert.True(list.IsSorted(SortDirection.Descending));
        }
    }
}
