using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class QuickSortTests {

        [Fact]
        public void TestSortingIntegers() {
            var numberOfValues = 100;
            var list = TestData.GetRandomIntList(numberOfValues, 0, numberOfValues, false);
           
            list.QuickSort();

            Assert.True(list.IsSorted());
        }
    }
}
