using NUnit.Framework;
using M7.Framework_Fundamentals;

namespace TestMethods
{
    [TestFixture]
    public class TitileCaseTests
    {
        [TestCase("a clash of KINGS", "a an the of", ExpectedResult = "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", ExpectedResult = "The Wind in the Willows")]
        [TestCase("the quick bRown fox", ExpectedResult = "The Quick Brown Fox")]
        public string TitileCaseTest(string input, string minorWords="")
        {
            return TitleCase.GetTitle(input, minorWords);
        }
    }
}
