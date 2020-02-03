using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polinomial;


namespace PolinomialTests
{
    [TestClass]
    public class PolinomTests
    {
        [TestMethod]
        public void PolinomSumTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 3 }, { 1, 3 }, { 2, 7 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 5 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 3 }, { 1, 3 }, { 2, 7 }, { 3, 5 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 3 }, { 1, 2 }, { 2, 7 }, { 3, 5 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumWithEmptyTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>()};
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 }, { 3, 5 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumWithEmptyTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumWithEmptyTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> () };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> ()}, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumExceptionTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { -1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            Assert.ThrowsException<ArgumentException>(()=>p1 + p2);
        }

        [TestMethod]
        public void PolinomSubtractionTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -1 }, { 1, 1}, { 2, -1 } } }, p1 - p2);
        }

        public void PolinomSubtractionTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 5 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -1 }, { 1, 1 }, { 2, -1 }, { 3, 5 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubtractionTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -1 }, { 1, 2 }, { 2, -1 }, { 3, -5 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubWithEmptyTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -2 }, { 1, -1 }, { 2, -4 }, { 3, -5 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubWithEmptyTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -1 }, { 1, -2 }, { 2, -3 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubWithEmptyTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double>() }, p1 - p2);
        }
    }
}
