using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class HeapTests {
        [Fact] 
        public void HeapTests_MinHeap() {
            var heap = new Heap<int>(new List<int> { 4, 6, 1, 2, 5, 3 }, HeapType.MinHeap);
            var result = heap.Describe();
            var expected = "1 2 3 6 5 4";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HeapTests_MaxHeap() {
            var heap = new Heap<int>(new List<int> { 12, 7, 6, 10, 8, 20 }, HeapType.MaxHeap);
            var result = heap.Describe();
            var expected = "20 10 12 7 8 6";
            Assert.Equal(expected, result);
        }
    }
}