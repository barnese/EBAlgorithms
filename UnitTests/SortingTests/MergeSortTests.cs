using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class MergeSortTests {

        [Fact]
        public void MergeSort_Integers() {
            var list = TestData.Numbers;

            list.MergeSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void MergeSort_Strings() {
            var list = TestData.Words;

            list.MergeSort();

            Assert.True(list.IsSorted());
        }
    }
}
