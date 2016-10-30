using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {
    public class QueueTests {
        [Fact]
        public void TestDequeue() {
            Queue<string> queue = new Queue<string>();
            var data = "abc";
            queue.Enqueue(data);
            var dequeuedData = queue.Dequeue();
            Assert.True(queue.IsEmpty());
            Assert.Equal(data, dequeuedData);
        }

        [Fact]
        public void TestEnqueue() {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("abc");
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void TestIsEmpty() {
            Queue<string> queue = new Queue<string>();
            Assert.True(queue.IsEmpty());

            queue.Enqueue("abc");

            Assert.False(queue.IsEmpty());
        }
    }
}
