using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M10.Generics_and_Collections;
using System.Collections.Generic;

namespace TestMethods
{
    [TestClass]
    public class BinarySearchGenericTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, 6), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, 10), -1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, 1), 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }, 8), 7);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new List<int>() { 1, 2, 3, 4, 6, 7, 8 }, 5), -1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new int [] { 1, 2, 3, 4, 6, 7, 8 }, 5), -1);
        }
    }

    [TestClass]
    public class GetWordsFrequencyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(WordsFrequency.GetWordsFrequency("AA z d v sd aa sd c z aa c"),new Dictionary<string, double>() { ["aa"] = 3.0 / 11, ["z"] = 2.0 / 11,["d"] = 1.0 / 11, ["v"] = 1.0 / 11, ["sd"] = 2.0 / 11, ["c"] = 2.0 / 11 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            CollectionAssert.AreEqual(WordsFrequency.GetWordsFrequency("AA, z ! d v sd aa sd c z aa c."), new Dictionary<string, double>() { ["aa"] = 3.0 / 11, ["z"] = 2.0 / 11, ["d"] = 1.0 / 11, ["v"] = 1.0 / 11, ["sd"] = 2.0 / 11, ["c"] = 2.0 / 11 });
        }

        [TestMethod]
        public void GetExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => WordsFrequency.GetWordsFrequency(""));
        }
    }

    [TestClass]
    public class ReversePolishNotationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(ReversePolishNotation.GetReversePolishNotation("5 1 2 + 4 * + 3 -"),14);
        }

        [TestMethod]
        public void GetException()
        {
            Assert.ThrowsException<ArgumentException>(() => ReversePolishNotation.GetReversePolishNotation("5 1 2+ 4 * + 3 -"));
        }

        [TestMethod]
        public void EmptyStringTest()
        {
            Assert.AreEqual(ReversePolishNotation.GetReversePolishNotation(""), 0);
        }

        [TestMethod]
        public void EmptyStringTest2()
        {
            Assert.AreEqual(ReversePolishNotation.GetReversePolishNotation(" "), 0);
        }
    }
 }
