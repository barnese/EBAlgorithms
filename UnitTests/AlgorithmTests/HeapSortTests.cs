using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class HeapSortTests {

        [Fact]
        public void HeapSort_Integers() {
            var list = TestData.Numbers;

            list.HeapSort();

            Assert.True(list.IsSorted());

            list.HeapSort(SortDirection.Descending);

            Assert.True(list.IsSorted(SortDirection.Descending));
        }

        [Fact]
        public void HeapSort_Strings() {
            var list = TestData.Words;

            list.HeapSort();

            Assert.True(list.IsSorted());

            list.HeapSort(SortDirection.Descending);

            Assert.True(list.IsSorted(SortDirection.Descending));
        }
    }
}
