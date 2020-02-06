using NUnit.Framework;
using M7.Framework_Fundamentals;

namespace TestMethods
{
    [TestFixture]
    public class ReverseWordsTests
    {
        [TestCase("The greatest victory is that which requires no battle",ExpectedResult = "battle no requires which that is victory greatest The")]
        public string ReverseWordsTest(string input)
        {
            return Words.ReverseWords(input);
        }
    }
}
