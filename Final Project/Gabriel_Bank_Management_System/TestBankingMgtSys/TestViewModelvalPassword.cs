using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gabriel_Bank_Management_System.ViewModel;
using Gabriel_Bank_Management_System.Utility;
using Bank.Common.Common;
using Newtonsoft.Json;
using System.Net.Http;
using Moq.Protected;
using System.Threading;
using System.Net;

namespace TestBankingMgtSys
{
    public class TestViewModelvalPassword
    {
        public TestViewModelvalPassword()
        {

        }
        [Theory]
        [InlineData("George12345678$")]
        public void CheckPasswordTest(string customer_pw)
        {
            var expectedResult = ForPasswordResultType.PasswordNoDigits |
                ForPasswordResultType.PasswordNoUpperCaseLetter |
                ForPasswordResultType.PasswordNoLowerCaseLetter |
                ForPasswordResultType.PasswordNoSpecialCharacter |
                ForPasswordResultType.IncorrectPasswordLength;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.validatePassword(customer_pw);
            IList<string> outputList = new List<string>()
            {
                "Password not met - 6 - 24 chars",
                "Password not met - need lower case",
                "Password not met - need upper case",
                "Password not met - need to include digits",
                "Password not met - need to include special characters"
            };
            Assert.Equal(outputList, result);

        }
        [Theory]
        [InlineData("George12345678$")]
        public void CheckPasswordTestNone(string customer_pw)
        {
            var expectedResult = UserNameResultType.None;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.validatePassword(customer_pw);
            IList<string> outputList = new List<string>()
            {
                "Password not met - need lower case",
                "Password not met - need upper case"
            };
            Assert.Equal(outputList, result);

        }
    }
}
