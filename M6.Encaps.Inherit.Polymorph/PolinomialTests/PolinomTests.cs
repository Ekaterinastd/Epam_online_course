﻿using System;
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
        public void PolinomSumTest4()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 0 }, { 1, 0 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 3 }, { 2, 7 }, { 3, 5 } } }, p1 + p2);
        }

        [TestMethod]
        public void PolinomSumTest5()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 0 }, { 1, 0}, { 2, 0 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } }, p1 + p2);
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
        public void PolinomSubtractionTest4()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 0 }, { 1, 0 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 0 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -2 }, { 2, 3 }, { 3, -5 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubtractionTest5()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 0 }, { 1, 0 }, { 2, 0 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, -2 }, { 2, -4 }, { 3, -5 } } }, p1 - p2);
        }

        [TestMethod]
        public void PolinomSubExceptionTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { -1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            Assert.ThrowsException<ArgumentException>(() => p1 - p2);
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

        [TestMethod]
        public void PolinomMultiplicationTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 5 }, { 2, 12 }, { 3, 11 }, { 4, 12 } } }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultiplicationTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 0 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, -4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 2 }, { 3, 5 }, { 4, -12 }, { 5, 15 } } }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultiplicationTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, -4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 4 }, { 2, 2 }, { 3, -3 }, { 4, -2 }, { 5, 15 } } }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultiplicationTest4()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 0 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 0 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 4 }, { 2, 6 }, { 3, 10 }, { 5, 15 } } }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultiplicationTest5()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 0 }, { 1, 0 }, { 2, 0 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 2, 4 }, { 3, 5 } } };
            var res = p1 * p2;
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double> () }, res);
        }

        [TestMethod]
        public void PolinomMultExceptionTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { -1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            Assert.ThrowsException<ArgumentException>(() => p1 * p2);
        }

        [TestMethod]
        public void PolinomMultWithEmptyTest1()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 2 }, { 1, 1 }, { 2, 4 }, { 3, 5 } } };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double>() }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultWithEmptyTest2()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double> { { 0, 1 }, { 1, 2 }, { 2, 3 } } };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double>() }, p1 * p2);
        }

        [TestMethod]
        public void PolinomMultWithEmptyTest3()
        {
            var p1 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            var p2 = new Polinom() { Coefficiencts = new Dictionary<int, double>() };
            Assert.AreEqual(new Polinom() { Coefficiencts = new Dictionary<int, double>() }, p1 * p2);
        }
    }
}
