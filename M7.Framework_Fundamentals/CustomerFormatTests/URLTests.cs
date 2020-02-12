using NUnit.Framework;
using M7.Framework_Fundamentals;

namespace TestMethods
{
    [TestFixture]
    public class URLTests
    {
        [TestCase("www.example.com", "key=value", ExpectedResult = "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]
        [TestCase("www.sitefortest.com?section=ocean&name=feature&key=oldValue", "name=netezza", ExpectedResult = "www.sitefortest.com?section=ocean&name=netezza&key=oldValue")]
        public string URLTest(string url, string parameter)
        {
            return URL.AddOrChangeUrlParameter(url, parameter);
        }
    }
}
