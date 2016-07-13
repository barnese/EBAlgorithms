using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests.DataStructureTests {

    [TestClass]
    public class QueueTests {
        Queue<String> queue = new Queue<String>();

        [TestMethod]
        public void Test_Queue_Enqueue() {
            queue.Enqueue("abc");
            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void Test_Queue_Dequeue() {
            var data = "abc";
            queue.Enqueue(data);
            var dequeuedData = queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
            Assert.AreEqual(data, dequeuedData);
        }
    }
}
