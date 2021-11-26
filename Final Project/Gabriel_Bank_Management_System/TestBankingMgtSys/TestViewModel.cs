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
using System.IO;

namespace TestBankingMgtSys
{
    public class TestViewModel
    {
        public TestViewModel()
        {

        }
        [Theory]
        [InlineData("1234")]
        public void CheckRemoveCustomerTestNone(string idNumber)
        {
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

            var result = underTest.RemoveCustomers(idNumber);

            Assert.Equal("Error has occured", result);

        }
        [Theory]
        [InlineData("12345")]
        public void CheckRemoveCustomerTest(string idNumber)
        {
            var expectedResult = true;
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

            var result = underTest.RemoveCustomers(idNumber);

            Assert.Equal("Removed customer", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckRemoveEmployeeTest(string idNumber)
        {
            var expectedResult = true;
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

            var result = underTest.RemoveEmployees(idNumber);

            Assert.Equal(idNumber + " has been removed", result);

        }
        
        [Theory]
        [InlineData("12345")]
        public void CheckRemoveEmployeeTestNone(string idNumber)
        {
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

            var result = underTest.RemoveEmployees(idNumber);

            Assert.Equal("Account doesn't exist", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckRemoveManagerTestNone(string idNumber)
        {
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

            var result = underTest.DeleteManager(idNumber);

            Assert.Equal("Error has occured", result);

        }
        [Theory]
        [InlineData("1234")]
        public void CheckRemoveManagerTest(string idNumber)
        {
            var expectedResult = true;
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

            var result = underTest.DeleteManager(idNumber);

            Assert.Equal(idNumber + " has been removed", result);

        }

        [Fact]
        public void CheckCustomerWithdrawal()
        {
            string customer_id = "1232"; decimal withdrawAmountKeyedInByCustomer = 500;
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.customerWithdrawl(customer_id, withdrawAmountKeyedInByCustomer);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void CheckCustomerFailWithdrawal()
        {
            string customer_id = "1232"; decimal withdrawAmountKeyedInByCustomer = 500;
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

            var result = underTest.customerWithdrawl(customer_id, withdrawAmountKeyedInByCustomer);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void CheckCustomerDeposit()
        {
            string customer_id = "1232"; decimal depositAmountKeyedInByCustomer = 500;
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.customerDeposit(customer_id, depositAmountKeyedInByCustomer);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void CheckCustomerFailDeposit()
        {
            string customer_id = "1232"; decimal depositAmountKeyedInByCustomer = 500;
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

            var result = underTest.customerDeposit(customer_id, depositAmountKeyedInByCustomer);

            Assert.Equal("Error", result);

        }
        [Theory]
        [InlineData("1")]
        public void ParseInputStringIntTestSuccess(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputStringInt(input, out var output);
            Assert.Equal(Convert.ToInt32(input), output);
        }

        [Theory]
        [InlineData("aa")]
        public void ParseInputStringIntTestFormat(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            underTest.ParseInputStringInt(input, out var output);
            Assert.Null(output);
        }

        [Theory]
        [InlineData("12321313781731381832781371283182731")]
        public void ParseInputStringIntOverflow(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputStringInt(input, out var output);
            Assert.Null(output);
        }
        [Theory]
        [InlineData("1")]
        public void ParseInputStringTestSuccess(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputString(input, out var output);
            Assert.Equal(Convert.ToInt32(input), output);
        }
        [Theory]
        [InlineData("aa")]
        public void ParseInputStringTestFormat(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            underTest.ParseInputString(input, out var output);
            Assert.Null(output);
        }

        [Theory]
        [InlineData("111111111111111111111111111111111111111111111111111111111111111111111111111111111111111")]
        public void ParseInputStringDecimalOverflow(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputDecimal(input, out var output);
            Assert.Null(output);
        }
        [Theory]
        [InlineData("1")]
        public void ParseInputStringDecimalSuccess(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputDecimal(input, out var output);
            Assert.Null(output);
        }
        [Theory]
        [InlineData("bb")]
        public void ParseInputStringDecimalFormat(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputDecimal(input, out var output);
            Assert.Null(output);
        }
        [Theory]
        [InlineData("13 Oct 1986")]
        public void ParseInputDateTestSuccess(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            underTest.ParseInputDate(input, out var output);
            Assert.Equal(Convert.ToDateTime(input), output);
        }

        [Theory]
        [InlineData("aa")]
        public void ParseInputDateTestFormat(string input)
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Test")
                });

            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            underTest.ParseInputDate(input, out var output);
            Assert.Null(output);
        }
        [Fact]
        public void CheckLoanAccount()
        {
            string customer_id = "1232"; decimal loanamount = 4000; decimal monthsIn = 3; decimal interestamount = 400;
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.LoanAccount(customer_id, loanamount, monthsIn, interestamount);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TestLoanAccountFailed()
        {
            string customer_id = "1232"; decimal loanamount = 4000; decimal monthsIn = 3; decimal interestamount = 400;
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

            var result = underTest.LoanAccount(customer_id, loanamount, monthsIn, interestamount);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void ViewLoanTest()
        {
            string customer_id = "1234";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.ViewLoan(customer_id);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void ViewLoanTestNone()
        {
            string customer_id = "1234";
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

            var result = underTest.ViewLoan(customer_id);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestRepayLoan()
        {
            string customer_id = "1232"; string repayLoan = "500";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.RepayLoan(customer_id, repayLoan);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TestRepayLoanNone()
        {
            string customer_id = "1232"; string repayLoan = "500";
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

            var result = underTest.RepayLoan(customer_id, repayLoan);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestLimitDeposit()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    //StatusCode = HttpStatusCode.BadRequest,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            BankViewModel mv = new BankViewModel(new HttpClient(mockMessageHandler.Object));
            mv.DepositLimit();
        }
        [Fact]
        public void CheckViewBalance()
        {
            string customer_id = "1232";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.ViewBalance(customer_id);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void CheckViewBalanceNone()
        {
            string customer_id = "1232";
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

            var result = underTest.ViewBalance(customer_id);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestListCustomer()
        {
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.ListCustomers();

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TestListCustomersNone()
        {
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

            var result = underTest.ListCustomers();

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestListEmployee()
        {
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.ListEmployees();

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TestListEmployeeeNone()
        {
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

            var result = underTest.ListEmployees();

            Assert.Equal("Error", result);

        }
        [Fact]
        public void SearchCustomerByIDTest()
        {
            string customer_id = "1232";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SearchCustomerByID(customer_id);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void SearchCustomerByIDFailed()
        {
            string customer_id = "1232";
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

            var result = underTest.SearchCustomerByID(customer_id);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void SearchCustomerByName()
        {
            string customer_id = "1232";
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.SearchCustomerByName(customer_id);

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void SearchCustomerByNameFailed()
        {
            string customer_id = "1232";
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

            var result = underTest.SearchCustomerByName(customer_id);

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TotalLoanAccountTest()
        {
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.TotalLoanAmount();

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TotalLoanAccountTestFailed()
        {
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

            var result = underTest.TotalLoanAmount();

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TotalSavingsTest()
        {
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.TotalSavingsAccount();

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TotalSavingsAccountFailed()
        {
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

            var result = underTest.TotalSavingsAccount();

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestViewManagers()
        {
            var expectedResult = true;
            var json = JsonConvert.SerializeObject(expectedResult);

            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    //Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
            var underTest = new BankViewModel(new HttpClient(mockMessageHandler.Object));

            var result = underTest.ViewManagers();

            Assert.Equal("Successful", result);

        }
        [Fact]
        public void TestViewManagersNone()
        {
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

            var result = underTest.ViewManagers();

            Assert.Equal("Error", result);

        }
        [Fact]
        public void TestFormatDecimalConvert()
        {
            Type objecttype = typeof(String);
            FormatDecimalConverter fdc = new FormatDecimalConverter();
            fdc.CanConvert(objecttype);
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);
            object value = new object();

            JsonSerializer serializer = new JsonSerializer();
            fdc.WriteJson(writer, value, serializer);
        }
        [Fact]
        public void TestFormatDecimalConvertRead()
        {
            FormatDecimalConverter fdc = new FormatDecimalConverter();
            Assert.False(fdc.CanRead);
        }
        [Fact]
        public void TestFormatDecimalConvertJsonRead()
        {
            Type objecttype = typeof(String);
            FormatDecimalConverter fdc = new FormatDecimalConverter();
            fdc.CanConvert(objecttype);
            string _input = "hello";
            StringReader sw = new StringReader(_input);
            JsonReader reader = new JsonTextReader(sw);
            object value = new object();

            JsonSerializer serializer = new JsonSerializer();
            fdc.ReadJson(reader, objecttype, value, serializer);
        }
    }
}
