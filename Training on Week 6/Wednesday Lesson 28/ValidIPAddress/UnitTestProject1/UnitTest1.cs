using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ValidIPAddress;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1ForValidInput(string IP)
        {
            Program P = new Program();
            var result = P.ValidIPAddress(IP);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("192.135.256.1")]        // 1 test multiple data rows
        [DataRow("192.qwe.256.1")]
        [DataRow("192.256.1")]
        [DataRow("192.135.256.1.9")]
        public void TestMethod1ForInvalidInput(string IP)
        {
            Program P = new Program();
            var result = P.ValidIPAddress(IP);

            Assert.IsFalse(result);
        }
    }
}
