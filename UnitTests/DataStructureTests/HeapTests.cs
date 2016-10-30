using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class HeapTests {
        [Fact] 
        public void TestCreatingAMinHeap() {
            var heap = new Heap<int>(new List<int> { 4, 6, 1, 2, 5, 3 }, HeapType.MinHeap);
            var result = heap.Describe();
            var expected = "1 2 3 6 5 4";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCreatingAMaxHeap() {
            var heap = new Heap<int>(new List<int> { 12, 7, 6, 10, 8, 20 }, HeapType.MaxHeap);
            var result = heap.Describe();
            var expected = "20 10 12 7 8 6";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAdd() {
            var heap = new Heap<int>(new List<int> { 1, 3, 6, 5, 9, 8 }, HeapType.MinHeap);
            heap.Add(-2);
            Assert.Equal("-2 3 1 5 9 8 6", heap.Describe());
        }

        [Fact]
        public void TestRemoveMax() {
            var heap = new Heap<int>(new List<int> { 8, 7, 6, 3, 1, 4 }, HeapType.MaxHeap);
            var item = heap.RemoveRoot();
            Assert.Equal(8, item);
            Assert.Equal("7 4 6 3 1", heap.Describe());
        }

        [Fact]
        public void TestRemoveMin() {
            var heap = new Heap<int>(new List<int> { 13, 14, 16, 19, 21, 19, 68, 65, 26, 32, 31 }, HeapType.MinHeap);
            Assert.Equal(13, heap.RemoveRoot());
            Assert.Equal("14 19 16 26 21 19 68 65 31 32", heap.Describe());
        }
    }
}