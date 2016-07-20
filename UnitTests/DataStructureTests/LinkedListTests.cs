using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {

    public class LinkedListTests {
        private LinkedList<int> list = new LinkedList<int>();

        [Fact]
        public void LinkedList_Add() {
            list.Add(10);
            Assert.Equal(list.Count, 1);
        }

        [Fact]
        public void LinkedList_Delete() {
            list.Add(5);
            list.Delete(5);
            Assert.Equal(list.Count, 0);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(2);
            Assert.Equal(list.Count, 2);
        }

        [Fact]
        public void LinkedList_Describe() {
            list.Add(2);
            list.Add(4);
            list.Add(6);

            Assert.Equal(list.Describe(), "[2, 4, 6]");
        }

        [Fact]
        public void LinkedList_Get() {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(list.Get(1), 2);
        }

        [Fact]
        public void LinkedListInsert_Before() {
            list.InsertBefore(0, 3);
            Assert.Equal(list.Count, 1);

            list.InsertBefore(1, 3);
            Assert.Equal(list.Count, 2);
        }
    }
}
