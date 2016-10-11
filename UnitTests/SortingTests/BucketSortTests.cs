using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class BucketSortTests {

        [Fact]
        public void BucketSort_OneValue() {
            var list = new List<float> { 0.52F };
            BucketSort.Sort(list);
            Assert.True(list.IsSorted());
        }

        [Fact]
        public void BucketSort_Floats() {
            var list = new List<float> { 0.43F, 0.23F, 0.98F, 0.22F, 0.64F, 0.52F, 0.13F, 0.88F, 0.74F };
            BucketSort.Sort(list);
            Assert.True(list.IsSorted());
        }
    }
}
