using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class CountingSortTests {

        [Fact]
        public void CountingSort_Integers() {
            var list = new List<int> { 55, 23, 74, 4, 40, 67, 89, 1, 20, 29, 54, 61, 72, 88, 99, 1, 3, 9, 30, 92 };

            list.CountingSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void CountingSort_Strings() {
            var list = new List<string> { "zebra", "cat", "walrus", "bird", "bobcat", "bear", "snake", "elephant", "giraffe" };

            list.CountingSort();

            Assert.True(list.IsSorted());
        }
    }
}
