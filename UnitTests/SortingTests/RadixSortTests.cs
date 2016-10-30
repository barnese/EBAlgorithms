using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class RadixSortTests {

        [Fact]
        public void TestSortingIntegers() {
            var list = TestData.Numbers;

            RadixSortInt.Sort(list);

            Assert.True(list.IsSorted());
        }
    }
}
