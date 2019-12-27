using M4.Methods_in_details;
using NUnit.Framework;

namespace TestMetods
{
    [TestFixture]
    public class NullableExtensionTests
    {
        [TestCase(78, ExpectedResult = false)]
        [TestCase("Kathy", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public bool CheckCorrectTest(object x)
        {
            return x.IsNull();
        }
    }
}
