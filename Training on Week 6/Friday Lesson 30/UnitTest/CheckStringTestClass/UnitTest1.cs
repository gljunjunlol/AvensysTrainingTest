using Moq;
using NUnit.Framework;
using ValidStringParentheses;

namespace CheckStringTestClass
{
    public class TestCheckString
    {
        private Mock<ITakeInput> _mocktakeInput;

        [SetUp]
        public void Setup()
        {
            _mocktakeInput = new Mock<ITakeInput>();
        }


        [Test]
        [TestCase("{}{}{}")]
        [TestCase("{}{}{}")]
        [TestCase("{}{}{})")]
        public void TestCheckStringMethod(string str)
        {
            _mocktakeInput.Setup(t => t.TakeInputMethod()).Returns("{}[]{}");

            CheckString checkString = new CheckString(_mocktakeInput.Object);
            var res = checkString.checkValidString();
            Assert.IsTrue(res);
        }
        [Test]
        [TestCase("{}{}{})")]
        [TestCase("{}{}{})")]
        [TestCase("{}(({}{})")]
        public void TestCheckStringMethodIsFalse(string str)
        {
            _mocktakeInput.Setup(t => t.TakeInputMethod()).Returns("{}]{}");

            CheckString checkString = new CheckString(_mocktakeInput.Object);
            var res = checkString.checkValidString();
            Assert.IsFalse(res);
        }
        [TearDown]
        
        public void Teardown()
        {
            _mocktakeInput = null;
        }
    }
}