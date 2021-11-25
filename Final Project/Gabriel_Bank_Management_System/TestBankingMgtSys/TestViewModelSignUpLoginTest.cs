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
    public class TestViewModelSignUpLoginTest
    {
        public TestViewModelSignUpLoginTest()
        {

        }
        [Fact]
        public void SignUpTestFailed()
        {
            string customer_id = "1234"; string customer_name = "apple"; string customer_address = "150 street"; DateTime customer_dob = DateTime.Now; string customer_email = "john@mail.com"; string customer_phone = "(222)333-4444"; string customer_pw = "John12345678$"; string account_no = "A1234"; decimal account_bal = 4000; Guid cheque_bk_number = Guid.Empty; bool loan_app = false; decimal loan_with_amt = 4000;
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUp(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, account_no, account_bal, cheque_bk_number, loan_app, loan_with_amt);

            Assert.Equal("Error", result);
        }
        [Fact]
        public void SignUpTestSuccess()
        {
            string customer_id = "1234"; string customer_name = "johnsmith"; string customer_address = "150 street"; DateTime customer_dob = DateTime.Now; string customer_email = "john@mail.com"; string customer_phone = "(222)333-4444"; string customer_pw = "John12345678$"; string account_no = "A1234"; decimal account_bal = 4000; Guid cheque_bk_number = Guid.Empty; bool loan_app = false; decimal loan_with_amt = 4000;
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUp(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, account_no, account_bal, cheque_bk_number, loan_app, loan_with_amt);

            Assert.Equal("Account creation has been completed", result);
        }
        [Fact]
        public void SignUpEmployeeTestFailed()
        {
            string bankemployee_id = "1234"; string bankemployee_name = "georgesmith"; string bankemployee_address = "23"; DateTime bankemployee_dob = DateTime.Now; string bankemployee_designation = "loan employee"; string bankemployee_yos = "3"; string bankemployee_pw = "George12345678$";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUpEmployee(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);

            Assert.Equal("Error", result);
        }
        [Fact]
        public void SignUpEmployeeTestSuccess()
        {
            string bankemployee_id = "1234"; string bankemployee_name = "georgesmith"; string bankemployee_address = "23"; DateTime bankemployee_dob = DateTime.Now; string bankemployee_designation = "loan employee"; string bankemployee_yos = "3"; string bankemployee_pw = "George12345678$";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUpEmployee(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);

            Assert.Equal("Account creation has been completed", result);
        }
        [Fact]
        public void SignUpManagerTestFailed()
        {
            string bankmanager_id = "1234"; string bankmanager_name = "karensmith"; string bankmanager_address = "23"; DateTime bankmanager_dob = DateTime.Now; string bankmanager_designation = "loan employee"; string bankmanager_yos = "3"; string bankmanager_pw = "Karen12345678$";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUpManager(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);

            Assert.Equal("Error", result);
        }
        [Fact]
        public void SignUpManagerTestSuccess()
        {
            string bankmanager_id = "1234"; string bankmanager_name = "karensmith"; string bankmanager_address = "23"; DateTime bankmanager_dob = DateTime.Now; string bankmanager_designation = "loan employee"; string bankmanager_yos = "3"; string bankmanager_pw = "Karen12345678$";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SignUpManager(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);

            Assert.Equal("Account creation has been completed", result);
        }
        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginTestSuccessOwner(string userName, string passWord)
        {
            var expectedResult = (true, true);
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

            var result = underTest.CheckLogin(userName, passWord);

            Assert.Equal(("\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1.) Savings" +
                        "\n2.) Loan" +
                        "\n3.) Go Back.", true), result);
        }

        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginTestFailUser(string userName, string passWord)
        {
            var expectedResult = (true, false);
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

            var result = underTest.CheckLogin(userName, passWord);

            Assert.Equal((null, false), result);
        }
        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginTestEmployeeSuccessOwner(string userName, string passWord)
        {
            var expectedResult = (true, true);
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

            var result = underTest.CheckEmployeeLogin(userName, passWord);

            Assert.Equal(("\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1: Find customer by ID: " +
                        "\n2: Find customer by name" +
                        "\n3: Logout and go back", true), result);
        }

        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginTestEmployeeFailUser(string userName, string passWord)
        {
            var expectedResult = (true, false);
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

            var result = underTest.CheckEmployeeLogin(userName, passWord);

            Assert.Equal((null, false), result);
        }
        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginManagerTestSuccessOwner(string userName, string passWord)
        {
            var expectedResult = (true, true);
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

            var result = underTest.CheckManagerLogin(userName, passWord);

            Assert.Equal(("\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1: Find customer by ID: " +
                        "\n2: Find customer by name" +
                        "\n3: Advanced access" +
                        "\n4: Logout and go back", true), result);
        }

        [Theory]
        [InlineData("1232", "Test12345678$")]
        public void LoginManagerTestFailUser(string userName, string passWord)
        {
            var expectedResult = (true, false);
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

            var result = underTest.CheckManagerLogin(userName, passWord);

            Assert.Equal((null, false), result);
        }
    }
}
