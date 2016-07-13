using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsUnitTests.DataStructureTests {

    [TestClass]
    public class LinkedListTests {
        private LinkedList<int> list = new LinkedList<int>();

        [TestMethod]
        public void Test_LinkedList_Add() {
            list.Add(10);
            Assert.AreEqual(list.Count(), 1);
        }

        [TestMethod]
        public void Test_LinkedList_Delete() {
            list.Add(5);
            list.Delete(5);
            Assert.AreEqual(list.Count(), 0);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(2);
            Assert.AreEqual(list.Count(), 2);
        }

        [TestMethod]
        public void Test_LinkedList_Describe() {
            list.Add(2);
            list.Add(4);
            list.Add(6);

            Assert.AreEqual(list.Describe(), "[2, 4, 6]");
        }

        [TestMethod]
        public void Test_LinkedList_Get() {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(list.Get(1), 2);
        }

        [TestMethod]
        public void Test_LinkedListInsert_Before() {
            list.InsertBefore(0, 3);
            Assert.AreEqual(list.Count(), 1);

            list.InsertBefore(1, 3);
            Assert.AreEqual(list.Count(), 2);
        }
    }
}
