using NUnit.Framework;
using M4.Methods_in_details;
using System;

namespace TestMetods
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(100, 45, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(78, 294, 570, 36, ExpectedResult = 6)]
        [TestCase(78, 294, 0, 36, ExpectedResult = 6)]
        public int CheckEuclideanAlgorithmTest(params int[] numbers)
        {
            return GCD.EuclideanAlgorithm(numbers);
        }

        [TestCase(0, 0)]
        [TestCase(0, 0, 0, 0)]
        public void CheckExceptionEuclideanAlgorithmTest(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCD.EuclideanAlgorithm(numbers));
        }

        [TestCase(17, 7, ExpectedResult = 1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(100, 45, ExpectedResult = 5)]
        [TestCase(0, 15, ExpectedResult = 15)]
        [TestCase(78, 294, 570, 36, ExpectedResult = 6)]
        [TestCase(78, 294, 0, 36, ExpectedResult = 6)]
        public int CheckSteinAlgorithmTest(params int[] numbers)
        {
            return GCD.SteinAlgoritm(numbers);
        }

        [TestCase(0, 0)]
        [TestCase(0, 0, 0, 0)]
        public void CheckExceptionSteinAlgorithmTest(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCD.SteinAlgoritm(numbers));
        }       
    }
}
