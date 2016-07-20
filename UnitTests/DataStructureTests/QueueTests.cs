using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {

    public class QueueTests {
        Queue<string> queue = new Queue<string>();

        [Fact]
        public void Queue_Enqueue() {
            queue.Enqueue("abc");
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Queue_Dequeue() {
            var data = "abc";
            queue.Enqueue(data);
            var dequeuedData = queue.Dequeue();
            Assert.True(queue.IsEmpty());
            Assert.Equal(data, dequeuedData);
        }
    }
}
