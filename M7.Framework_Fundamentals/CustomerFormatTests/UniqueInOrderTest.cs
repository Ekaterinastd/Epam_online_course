using M7.Framework_Fundamentals;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMethods
{
    [TestClass]
    public class UniqueInOrderTest
    {
        [TestMethod]
        public void CheckUniqueInOrderTest1()
        {
            CollectionAssert.AreEqual(new List<char>("ABCDAB"), UniqueInOrder.GetUniqueInOrder("AAAABBBCCDAABBB"));
        }

        [TestMethod]
        public void CheckUniqueInOrderTest2()
        {
            CollectionAssert.AreEqual(new List<char>("ABCcAD"), UniqueInOrder.GetUniqueInOrder("ABBCcAD"));
        }

        [TestMethod]
        public void CheckUniqueInOrderTest3()
        {
            CollectionAssert.AreEqual(new List<char>("123"), UniqueInOrder.GetUniqueInOrder("12233"));
        }

        [TestMethod]
        public void CheckUniqueInOrderTest4()
        {
            CollectionAssert.AreEqual(new List<double> { 1.1, 2.2, 3.3 }, UniqueInOrder.GetUniqueInOrder(new List<double> { 1.1, 2.2, 2.2, 3.3 }));
        }
    }
}
