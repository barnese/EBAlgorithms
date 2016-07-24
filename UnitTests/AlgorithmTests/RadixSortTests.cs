using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class RadixSortTests {

        [Fact]
        public void RadixSort_Integers() {
            var list = TestData.Numbers;

            RadixSortInt.Sort(list);

            Assert.True(list.IsSorted());
        }
    }
}
