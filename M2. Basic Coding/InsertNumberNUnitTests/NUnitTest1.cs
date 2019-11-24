using NUnit.Framework;
using M2.Basic_Coding;
using System;

namespace NUnitTests
{
    [TestFixture]
    public class InsertNumberNUnitTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        public int CheckCorrectInsertTest(int firstNum, int secondNum, int i, int j)
        {
            return Program.InsertNumber(firstNum, secondNum, i, j); 
        }

        [TestCase(8, 15, 8, 3)]
        public void CheckCorrectIndexTest(int firstNum, int secondNum, int i, int j)
        {
            Assert.That(() => Program.InsertNumber(firstNum, secondNum, i, j), Throws.TypeOf<ArgumentException>());
        }
    }

    [TestFixture]
    public class FindNextBiggerNumberNUnitTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int CheckCorrectNumberTest(int number)
        {
            return Program.FindNextBiggerNumber(number);
        }
    }

    [TestFixture]
    public class FilterDigitNUnitTests
    {
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 68, 69, 70}, 0, ExpectedResult = new int[] { 70 })]
        public int[] CheckCorrectArrayTest(int[] array, int num)
        {
            return Program.FilterDigit(array, num);
        }

        [TestCase(new int[] { 1, 2, 3, 5, 68, 69, 70 }, 4)]
        public void CheckCorrectDataTest(int[] array, int num)
        {
            Assert.That(() => Program.FilterDigit(array, num), Throws.TypeOf<ArgumentException>());
        }
    }
}
