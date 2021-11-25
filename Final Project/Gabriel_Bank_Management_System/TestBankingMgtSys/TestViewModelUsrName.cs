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
    public class TestViewModelUsrName
    {
        public TestViewModelUsrName()
        {

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestNone(string userName)
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal(string.Empty, result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestDuplicate(string userName)
        {
            var expectedResult = UserNameResultType.DuplicateUser;
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal("Duplicate Username.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestUnhandled(string userName)
        {
            var expectedResult = UserNameResultType.UnhandledUserError;
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal("Unexpected Error.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestContainsSpace(string userName)
        {
            var expectedResult = UserNameResultType.UserNameContainsSpace;
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal("Please Create A Username Without Space.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestLength(string userName)
        {
            var expectedResult = UserNameResultType.UserNameLengthIncorrect;
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal("Please create a username between 6 to 24 characters.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckUsernameTestDataAccessError(string userName)
        {
            var expectedResult = UserNameResultType.UserNameDataAccessError;
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

            var result = underTest.CheckUserName(userName);

            Assert.Equal("Unable to find file.", result);

        }
    }
}
