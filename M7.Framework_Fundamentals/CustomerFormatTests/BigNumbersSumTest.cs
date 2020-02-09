using NUnit.Framework;
using M7.Framework_Fundamentals;

namespace TestMethods
{
    [TestFixture]
    public class BigNumbersSumTest
    {
        [TestCase("23456789009876543456876", "123456798766394726798263723", ExpectedResult = "123480255555404603341720599")]
        [TestCase("", "123456798766394726798263723", ExpectedResult = "123456798766394726798263723")]
        [TestCase("", "", ExpectedResult = "0")]
        public string CheckSumTest(string n1, string n2)
        {
            return BigNumbers.GetSum(n1, n2);
        }
    }
}
