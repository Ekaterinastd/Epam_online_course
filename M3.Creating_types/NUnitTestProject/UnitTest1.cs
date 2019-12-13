using System;
using NUnit.Framework;
using M3.Creating_types;

namespace NUnitTestProject
{
    [TestFixture]
    public class FindNthRootNUnitTests
    {
        //[TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]//
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]//
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]//
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]//исправитьсильную неточность
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]//исправитьсильную неточность
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double CheckCorrectRootTest(double number, int degree, double accuracy)
        {
            return Methods.FindNthRoot(number, degree, accuracy);
        }

        [TestCase(-0.01, 2, 0.00001)]
        [TestCase(0.001, -2, 0.00001)]
        [TestCase(0.01, 2, -1)]
        public void CheckArgumentOutOfRangeExceptionTest(double number, int degree, double accuracy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Methods.FindNthRoot(number, degree, accuracy));
        }       
    }
}
