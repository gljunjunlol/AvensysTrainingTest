using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EvenLength;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("aaaa")]
        [DataRow("aaaa")]
        [DataRow("aaaa")]           // fail here if "aaasds"
        public void TestMethodTrue(string input)
        {
            Program p = new Program();
            Assert.IsTrue(p.myMethod(input));
        }

        [TestMethod]
        [DataRow("abcdefhi")]
        [DataRow("areeee")]
        [DataRow("aaasds")]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("aaasds")]
        public void TestMethodFalse(string input)
        {
            Program p = new Program();
            Assert.IsFalse(p.myMethod(input));
        }
    }
}
