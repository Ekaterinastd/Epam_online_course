using Microsoft.VisualStudio.TestTools.UnitTesting;
using M2.Basic_Coding;

namespace MSUnitTests
{
    [TestClass]
    public class InsertNumberMSUnitTests
    {
        [TestMethod]
        public void EqualNumbersZeroBitsTest()
        {
            Assert.AreEqual(Program.InsertNumber(15, 15, 0, 0), 15);
        }

        [TestMethod]
        public void DifferentNumbersZeroBitsTest()
        {
            Assert.AreEqual(Program.InsertNumber(8, 15, 0, 0), 9);
        }

        [TestMethod]
        public void DifferentNumbersNoZeroBitsTest()
        {
            Assert.AreEqual(Program.InsertNumber(8, 15, 3, 8), 120);
        }
    }

    [TestClass]
    public class FilterDigitMSUnitTests
    {
        [TestMethod]
        public void CorrectArrayTest1()
        {
            CollectionAssert.AreEqual(Program.FilterDigit(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7), new int[] { 7, 7, 70, 17 });
        }

        [TestMethod]
        public void CorrectArrayTest2()
        {
            CollectionAssert.AreEqual(Program.FilterDigit(new int[] { 1, 2, 3, 4, 5, 68, 69, 70 }, 0), new int[] { 70 });
        }
    }
}
