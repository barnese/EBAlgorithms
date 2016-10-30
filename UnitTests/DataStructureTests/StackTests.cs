using Xunit;
using EBAlgorithms.DataStructures;
using System;

namespace EBAlgorithmsUnitTests {
    public class StackTests {
        [Fact]
        public void TestIsEmpty() {
            Stack<char> stack = new Stack<char>();
            Assert.True(stack.IsEmpty);

            stack.Push('a');

            Assert.False(stack.IsEmpty);
        }

        [Fact]
        public void TestPush() {
            Stack<char> stack = new Stack<char>();
            Assert.True(stack.IsEmpty);

            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('d');
            stack.Push('e');

            Assert.Equal(5, stack.Count);
            Assert.Equal('e', stack.Peek());
        }

        [Fact]
        public void TestPeek() {
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');

            Assert.Equal('b', stack.Peek());
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void TestPop() {
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Pop();

            Assert.True(stack.Count == 1);
            Assert.Equal('a', stack.Peek());

            stack.Pop();

            Assert.True(stack.IsEmpty);

            try {
                stack.Pop();
            } catch (Exception ex) {
                Assert.Contains("No items to pop", ex.Message);
            }
        }
    }
}
