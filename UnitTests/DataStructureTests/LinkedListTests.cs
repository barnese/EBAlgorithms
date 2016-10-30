using Xunit;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests {

    public class LinkedListTests {
        private LinkedList<int> list = new LinkedList<int>();

        public LinkedListTests() {
            list.Add(2);
            list.Add(4);
            list.Add(6);
        }

        [Fact]
        public void TestAdd() {
            Assert.Equal("[2, 4, 6]", list.Describe());
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestContainsValue() {
            Assert.True(list.Contains(4));
        }

        [Fact]
        public void TestDeletingValue() {
            list.Delete(4);
            Assert.Equal(2, list.Count);
            Assert.False(list.Contains(4));
        }

        [Fact]
        public void TestDescribingList() {
            Assert.Equal(list.Describe(), "[2, 4, 6]");
        }

        [Fact]
        public void TestGettingValue() {
            Assert.Equal(4, list.Get(1));
        }

        [Fact]
        public void TestInsertingValueBefore() {
            list.InsertBefore(2, 3);
            Assert.Equal(4, list.Count);
            Assert.Equal(3, list.Get(0));
        }
    }
}
