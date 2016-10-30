using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class MergeSortTests {

        [Fact]
        public void TestSortingIntegers() {
            var list = TestData.Numbers;

            list.MergeSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void TestSortingStrings() {
            var list = TestData.Words;

            list.MergeSort();

            Assert.True(list.IsSorted());
        }
    }
}
