using Microsoft.VisualStudio.TestTools.UnitTesting;
using M10.Generics_and_Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTreeTests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void InOrderTraversalStringTest1()
        {
            var tree = new BinarySearchTree<string>();
            tree.Add("d");
            tree.Add("f");
            tree.Add("e");
            tree.Add("b");
            tree.Add("a");
            tree.Add("c");
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "a", "b", "c", "d", "e", "f" }, actualy);
        }

        [TestMethod]
        public void InOrderTraversalStringTest2()
        {
            var tree = new BinarySearchTree<string> { "o", "h", "w", "b", "k", "c", "j", "m", "v", "x", "z" };
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "b", "c", "h", "j", "k", "m", "o", "v", "w", "x", "z" }, actualy);
        }

        [TestMethod]
        public void InOrderTraversalStringTest3()
        {
            var tree = new BinarySearchTree<string> { "o", "h", "w", "b", "k", "c", "j", "m", "v", "x", "z" };
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "b", "c", "h", "j", "k", "m", "o", "v", "w", "x", "z" }, actualy);
        }

        [TestMethod]
        public void InOrderTraversalPointTest4()
        {
            var tree = new BinarySearchTree<Point>((a, b) => a.X.CompareTo(b.X)) { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) };
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Point[] { new Point(-1, 2), new Point(0, 0), new Point(1, 2), new Point(10, 2) }, actualy);
        }

        [TestMethod]
        public void InOrderTraversalBookTest1()
        {
            var tree = new BinarySearchTree<Book>()
            { new Book("Book1", 10, 1990),
                new Book("Book3", 18, 1999),
                new Book("Book4", 1, 1980),
                new Book("Book2", 9, 2000) };
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book1", 10, 1990), new Book("Book2", 9, 2000), new Book("Book3", 18, 1999), new Book("Book4", 1, 1980) }, actualy);
        }

        [TestMethod]
        public void InOrderTraversalBookTest2()
        {
            var tree = new BinarySearchTree<Book>((x, y) => x.Amount.CompareTo(y.Amount))
            { new Book("Book1", 10, 1990),
                new Book("Book3", 30, 1999),
                new Book("Book4", 40, 1980),
                new Book("Book2", 20, 2000)
            };
            var actualy = tree.InOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book1", 10, 1990), new Book("Book2", 20, 2000), new Book("Book3", 30, 1999), new Book("Book4", 40, 1980) }, actualy);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            tree.Remove("b");
            CollectionAssert.AreEqual(new string[] { "a", "c", "d", "e", "f" }, tree.InOrderTraversal().ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void RemoveExceptionTest()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            tree.Remove("k");
        }

        [TestMethod]
        public void ClearTest1()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            tree.Clear();
            CollectionAssert.AreEqual(new string[] { }, tree.InOrderTraversal().ToArray());
        }

        [TestMethod]
        public void ClearTest2()
        {
            var tree = new BinarySearchTree<string>();
            tree.Clear();
            CollectionAssert.AreEqual(new string[] { }, tree.InOrderTraversal().ToArray());
        }

        [TestMethod]
        public void ContainsStringTest1()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            Assert.AreEqual(true, tree.Contains("e"));
        }

        [TestMethod]
        public void ContainsStringTest2()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            Assert.AreEqual(false, tree.Contains("m"));
        }
        [TestMethod]
        public void ContainsPointTest1()
        {
            var tree = new BinarySearchTree<Point>((a, b) => a.X.CompareTo(b.X)) { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) };
            Assert.AreEqual(true, tree.Contains(new Point(1, 2)));
        }

        [TestMethod]
        public void ContainsPointTest2()
        {
            var tree = new BinarySearchTree<Point>((a, b) => a.X.CompareTo(b.X)) { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) };
            Assert.AreEqual(false, tree.Contains(new Point(1, 20)));
        }

        [TestMethod]
        public void ContainsBookTest1()
        {
            var tree = new BinarySearchTree<Book>()
            { new Book("Book1", 10, 1990),
                new Book("Book3", 18, 1999),
                new Book("Book4", 1, 1980),
                new Book("Book2", 9, 2000) };
            Assert.AreEqual(true, tree.Contains(new Book("Book4", 1, 1980)));
        }

        [TestMethod]
        public void ContainsBookTest2()
        {
            var tree = new BinarySearchTree<Book>()
            { new Book("Book1", 10, 1990),
                new Book("Book3", 18, 1999),
                new Book("Book4", 1, 1980),
                new Book("Book2", 9, 2000) };
            Assert.AreEqual(false, tree.Contains(new Book("Book89", 1, 1980)));
        }

        [TestMethod]
        public void PreOrderTraversalStringTest1()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            var actualy = tree.PreOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "d", "b", "a", "c", "f", "e" }, actualy);
        }

        [TestMethod]
        public void PreOrderTraversalStringTest2()
        {
            var tree = new BinarySearchTree<string> { "o", "h", "w", "b", "k", "c", "j", "m", "v", "x", "z" };
            var actualy = tree.PreOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "o", "h", "b", "c", "k", "j", "m", "w", "v", "x", "z" }, actualy);
        }

        [TestMethod]
        public void PreOrderTraversalPointTest()
        {
            var tree = new BinarySearchTree<Point>((a, b) => a.X.CompareTo(b.X)) { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) };
            var actualy = tree.PreOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Point[] { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) }, actualy);
        }

        [TestMethod]
        public void PreOrderTraversalBookTest1()
        {
            var tree = new BinarySearchTree<Book>()
            {
                new Book("Book3", 18, 1999),
                new Book("Book2", 9, 2000),
                new Book("Book1", 10, 1990),
                new Book("Book4", 1, 1980)
            };
            var actualy = tree.PreOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book3", 18, 1999), new Book("Book2", 9, 2000), new Book("Book1", 10, 1990), new Book("Book4", 1, 1980) }, actualy);
        }

        [TestMethod]
        public void PreOrderTraversalBookTest2()
        {
            var tree = new BinarySearchTree<Book>((x, y) => x.Amount.CompareTo(y.Amount))
            {
                new Book("Book3", 30, 1999),
                new Book("Book2", 20, 2000),
                new Book("Book1", 10, 1990),
                new Book("Book4", 40, 1980)
            };
            var actualy = tree.PreOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book3", 30, 1999), new Book("Book2", 20, 2000), new Book("Book1", 10, 1990), new Book("Book4", 40, 1980) }, actualy);
        }

        [TestMethod]
        public void PostOrderTraversalStringTest1()
        {
            var tree = new BinarySearchTree<string> { "d", "f", "e", "b", "a", "c" };
            var actualy = tree.PostOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "a", "c", "b", "e", "f", "d" }, actualy);
        }

        [TestMethod]
        public void PostOrderTraversalStringTest2()
        {
            var tree = new BinarySearchTree<string> { "o", "h", "w", "b", "k", "c", "j", "m", "v", "x", "z" };
            var actualy = tree.PostOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new string[] { "c", "b", "j", "m", "k", "h", "v", "z", "x", "w", "o" }, actualy);
        }

        [TestMethod]
        public void PostOrderTraversalPointTest()
        {
            var tree = new BinarySearchTree<Point>((a, b) => a.X.CompareTo(b.X)) { new Point(1, 2), new Point(0, 0), new Point(-1, 2), new Point(10, 2) };
            var actualy = tree.PostOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Point[] { new Point(-1, 2), new Point(0, 0), new Point(10, 2), new Point(1, 2) }, actualy);
        }

        [TestMethod]
        public void PostOrderTraversalBookTest1()
        {
            var tree = new BinarySearchTree<Book>()
            {
                new Book("Book3", 18, 1999),
                new Book("Book2", 9, 2000),
                new Book("Book1", 10, 1990),
                new Book("Book4", 1, 1980)
            };
            var actualy = tree.PostOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book1", 10, 1990), new Book("Book2", 9, 2000), new Book("Book4", 1, 1980), new Book("Book3", 18, 1999) }, actualy);
        }

        [TestMethod]
        public void PostOrderTraversalBookTest2()
        {
            var tree = new BinarySearchTree<Book>((x, y) => x.Amount.CompareTo(y.Amount))
            {
                new Book("Book3", 30, 1999),
                new Book("Book2", 20, 2000),
                new Book("Book1", 10, 1990),
                new Book("Book4", 40, 1980)
            };
            var actualy = tree.PostOrderTraversal().ToArray();
            CollectionAssert.AreEqual(new Book[] { new Book("Book1", 10, 1990), new Book("Book2", 20, 2000), new Book("Book4", 40, 1980), new Book("Book3", 30, 1999) }, actualy);
        }
    }
}
