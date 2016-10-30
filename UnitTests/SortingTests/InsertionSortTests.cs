using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class InsertionSortTests {

        [Fact]
        public void TestSortingIntegers() {
            var list = TestData.Numbers;

            list.InsertionSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void TestSortingStrings() {
            var list = TestData.Words;

            list.InsertionSort();

            Assert.True(list.IsSorted());
        }
    }
}
