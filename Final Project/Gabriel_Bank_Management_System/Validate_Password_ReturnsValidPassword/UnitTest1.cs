using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;

namespace Validate_Password_ReturnsValidPassword
{
    public class UnitTest1
    {
        Program _p;
        public UnitTest1()
        {
            _p = new Program();
        }
        //[Fact]
        [Theory]
        [InlineData("@johN123456")]
        [InlineData("johnN1234$")]
        [InlineData("John111N!")]
        [InlineData("JjLo1234##@!")]
        public void Test1(string customer_pw)
        {
            Mock<IValidatePw> validate = new Mock<IValidatePw>();
            validate.Setup(t => t.ValidatePwMethod()).Returns(customer_pw);
            HandleAccountOpening validatepw = new HandleAccountOpening(validate.Object);
            bool res = validatepw.validatePassword();
            Assert.True(res);


        }
        //[Fact]
        [Theory]
        [InlineData("jj")]
        [InlineData("123")]
        [InlineData("loeo")]
        [InlineData("jjjjjjjjj")]
        public void Test2(string customer_pw)
        {
            Mock<IValidatePw> validate = new Mock<IValidatePw>();
            validate.Setup(t => t.ValidatePwMethod()).Returns(customer_pw);
            HandleAccountOpening validatepw = new HandleAccountOpening(validate.Object);
            bool res = validatepw.validatePassword();
            Assert.False(res);
        }
    }
}
