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
    public class TestViewModelID
    {
        public TestViewModelID()
        {

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestNone(string idNumber)
        {
            var expectedResult = IdResultType.None;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal(string.Empty, result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestDuplicate(string idNumber)
        {
            var expectedResult = IdResultType.DuplicateId;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal("Duplicate idNumber.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestUnhandled(string idNumber)
        {
            var expectedResult = IdResultType.UnhandledIdError;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal("Unexpected Error.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestNull(string idNumber)
        {
            var expectedResult = IdResultType.DuplicateId;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal("Input cannot be Null.", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestIncorrect(string idNumber)
        {
            var expectedResult = IdResultType.IdIncorrect;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal("Invalid ID Number", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckIDTestUnabletoFind(string idNumber)
        {
            var expectedResult = IdResultType.IdDataAccessError;
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

            var result = underTest.CheckIdNumber(idNumber);

            Assert.Equal("Unable to find file.", result);

        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestAddSavings(decimal x, decimal y)
        {
            BankViewModel.AddSavings(x, y);
            Assert.Equal(8000, x + y);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestSubtractSavings(decimal x, decimal y)
        {
            BankViewModel.SubtractSaving(x, y);
            Assert.Equal(0, x - y);
        }
        [Theory]
        [InlineData(4000, 40, 2)]
        public void TestMultiplySavings(decimal x, decimal y, decimal z)
        {
            BankViewModel.Multiply(x, y, z);
            Assert.Equal(320000, x * y * z);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestDivide(decimal x, decimal y)
        {
            BankViewModel.Divide(x, y);
            Assert.Equal(1, x / y);
        }
        [Fact]
        public void TestDivideByZero()
        {
            var num1 = 1;
            var num2 = 0;

            var ex = Assert.Throws<DivideByZeroException>(() => BankViewModel.Divide(num1, num2));
            string expectedErrorMessage = "Divide error";
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
        [Fact]
        public void TestModulusByZero()
        {
            var num1 = 1;
            var num2 = 0;
            var ex = Assert.Throws<DivideByZeroException>(() => BankViewModel.Modulus(num1, num2));
            string expectedErrorMessage = "Divide error";
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestModulus(decimal x, decimal y)
        {
            BankViewModel.Modulus(x, y);
            Assert.Equal(0, x % y);
        }
    }
}
