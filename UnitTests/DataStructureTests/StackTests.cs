using Xunit;
using EBAlgorithms.DataStructures;
using System;

namespace EBAlgorithmsUnitTests {
    public class StackTests {
        private Stack<char> stack = new Stack<char>();

        [Fact]
        public void Stack_PushPeekPop() {
            Assert.True(stack.IsEmpty);

            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('d');
            stack.Push('e');

            Assert.Equal(5, stack.Count);
            Assert.Equal('e', stack.Peek());

            var item = stack.Pop();
            Assert.Equal('e', item);
            Assert.Equal(4, stack.Count);

            stack.Pop();
            stack.Pop();
            stack.Pop();
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
