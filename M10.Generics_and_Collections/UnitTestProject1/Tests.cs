using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M10.Generics_and_Collections;
using System.Collections.Generic;
using System.Linq;

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
            Assert.AreEqual(BinarySearch.BinarySearchGeneric(new int[] { 1, 2, 3, 4, 6, 7, 8 }, 5), -1);
        }
    }

    [TestClass]
    public class GetWordsFrequencyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(WordsFrequency.GetWordsFrequency("AA z d v sd aa sd c z aa c"), new Dictionary<string, double>() { ["aa"] = 3.0 / 11, ["z"] = 2.0 / 11, ["d"] = 1.0 / 11, ["v"] = 1.0 / 11, ["sd"] = 2.0 / 11, ["c"] = 2.0 / 11 });
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
            Assert.AreEqual(ReversePolishNotation.GetReversePolishNotation("5 1 2 + 4 * + 3 -"), 14);
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

    [TestClass]
    public class FibonacciNumbersTest
    {
        [TestMethod]
        public void TestMethod1() => CollectionAssert.AreEqual(FibonacciNumbers.GetFibonacciNumbers().Take(7).ToArray(),
            new int[] { 0, 1, 1, 2, 3, 5, 8 });

        [TestMethod]
        public void TestMethod2() => CollectionAssert.AreEqual(FibonacciNumbers.GetFibonacciNumbers().Skip(10).Take(10).ToArray(),
            new int[] { 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181 });
    }

    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void EnqueueTest()
        {
            var queue = new M10.Generics_and_Collections.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, queue.ToArray());
        }

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            var queue = new M10.Generics_and_Collections.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            CollectionAssert.AreEqual(new int[] { 2, 3 }, queue.ToArray());
        }

        [TestMethod]
        public void EmptyQueueTest()
        {
            var queue = new M10.Generics_and_Collections.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            CollectionAssert.AreEqual(new int[0], queue.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestException()
        {
            var queue = new M10.Generics_and_Collections.Queue<int>();
            queue.Dequeue();
        }
    }

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void EnqueueTest()
        {
            var stack = new M10.Generics_and_Collections.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, stack.ToArray());
        }

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            var stack = new M10.Generics_and_Collections.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            CollectionAssert.AreEqual(new int[] { 2, 1 }, stack.ToArray());
        }

        [TestMethod]
        public void EmptyQueueTest()
        {
            var stack = new M10.Generics_and_Collections.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            CollectionAssert.AreEqual(new int[0], stack.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestException()
        {
            var stack = new M10.Generics_and_Collections.Stack<int>();
            stack.Pop();
        }
    }

    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void AddElementsTest()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            var arr1 = new int[] { 1, 2, 3 };
            var arr2 = new int[] { 10, 20, 30 };
            set.Add(arr1);
            set.Add(arr2);
            CollectionAssert.AreEqual(new List<int[]> { arr1, arr2 }, set.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddSameElementsTest()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            var arr1 = new int[] { 1, 2, 3 };
            set.Add(arr1);
            set.Add(arr1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddEmptyTest()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            set.Add(null);
        }

        [TestMethod]
        public void RemoveElementsTest()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            set.Add(arr1);
            set.Add(arr2);
            set.Remove(arr1);
            CollectionAssert.AreEqual(new List<int[]> { arr2 }, set.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveElementsExceptionTest()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 9 };
            set.Add(arr1);
            set.Add(arr2);
            set.Remove(arr3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveElementsTest2()
        {
            var set = new Set<int[]>() { _Set = new List<int[]>() };
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            set.Add(arr2);
            set.Remove(arr1);
        }

        [TestMethod]
        public void UnionElementsTest()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr2, arr3 } };            
            CollectionAssert.AreEqual(new List<int[]> { arr1, arr2, arr3 }, set1.Union(set1,set2).ToList());
        }

        [TestMethod]
        public void DifferenceElementsTest1()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr2, arr3 } };
            CollectionAssert.AreEqual(new List<int[]> { arr1, arr3 }, set1.Difference(set1, set2).ToList());
        }

        [TestMethod]
        public void DifferenceElementsTest2()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr2, arr1 } };
            CollectionAssert.AreEqual(new List<int[]> { }, set1.Difference(set1, set2).ToList());
        }

        [TestMethod]
        public void IntersectionElementsTest()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr3, arr1 } };
            CollectionAssert.AreEqual(new List<int[]> { arr1 }, set1.Intersection(set1, set2).ToList());
        }

        [TestMethod]
        public void IntersectionElementsTest2()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr3 } };
            CollectionAssert.AreEqual(new List<int[]> { }, set1.Intersection(set1, set2).ToList());
        }

        [TestMethod]
        public void SubsetElementsTest()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2, arr3 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr3 } };
            Assert.AreEqual(true, set1.Subset(set1, set2));
        }

        [TestMethod]
        public void SubsetElementsTest2()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 10, 20, 30 };
            var arr3 = new int[] { 100 };
            var arr4 = new int[] { 9, 9 };
            var set1 = new Set<int[]>() { _Set = new List<int[]>() { arr1, arr2, arr4 } };
            var set2 = new Set<int[]>() { _Set = new List<int[]>() { arr3, arr4 } };
            Assert.AreEqual(false, set1.Subset(set1, set2));
        }
    }
}
