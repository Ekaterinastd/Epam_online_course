using NUnit.Framework;
using M4.Methods_in_details;

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
        public int CheckEuclideanAlgorithmTest(params int[] numbers)
        {
            return GCD.EuclideanAlgorithm(numbers);
        }
    }
}
