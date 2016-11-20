using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class StackUnitTest
    {
        [TestMethod]
        public void StackTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.IsTrue(stack.Length==2);
            Assert.IsTrue(stack.Pop()==2);
            Assert.IsTrue(stack.Peek() == 1);
            Assert.IsTrue(stack.Pop() == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StackTest_ThrowsException()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.IsTrue(stack.Length == 2);
            Assert.IsTrue(stack.Pop() == 2);
            Assert.IsTrue(stack.Peek() == 1);
            Assert.IsTrue(stack.Pop() == 1);
            stack.Pop();
        }
    }
}
