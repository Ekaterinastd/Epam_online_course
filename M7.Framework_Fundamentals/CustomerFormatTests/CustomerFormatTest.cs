using M7.Framework_Fundamentals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMethods
{
    [TestClass]
    public class CustomerFormatTest
    {
        [TestMethod]
        public void CheckFormatTest1()
        {
            var customer = new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 };
            Assert.AreEqual("Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100", customer.ToString());
        }

        [TestMethod]
        public void CheckFormatTest2()
        {
            var customer = new Customer() { Revenue = 1000000 };
            Assert.AreEqual("Customer record: 1,000,000.00", customer.ToString());
        }

        [TestMethod]
        public void CheckFormatTest3()
        {
            var customer = new Customer() { ContactPhone = "+1 (425) 555-0100" };
            Assert.AreEqual("Customer record: +1 (425) 555-0100", customer.ToString());
        }

        [TestMethod]
        public void CheckFormatTest4()
        {
            var customer = new Customer() { Name = "Jeffrey Richter" };
            Assert.AreEqual("Customer record: Jeffrey Richter", customer.ToString());
        }

        [TestMethod]
        public void CheckFormatTest5()
        {
            var customer = new Customer() { Name = "Jeffrey Richter", Revenue = 1000000 };
            Assert.AreEqual("Customer record: Jeffrey Richter, 1000000", customer.ToString());
        }
    }
}
