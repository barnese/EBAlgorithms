using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {
    public class PriorityQueueTests {
        [Fact]
        public void TestAddRemove() {
            var queue = new PriorityQueue<char>(PriorityQueueComparator.MaxPriorityFirst);
            queue.Add('E', 5);
            queue.Add('C', 2);
            queue.Add('J', 9);
            queue.Add('M', 3);

            var item = queue.RemoveRoot();

            Assert.Equal('J', item);
            Assert.Equal(3, queue.Count);
        }
    }
}