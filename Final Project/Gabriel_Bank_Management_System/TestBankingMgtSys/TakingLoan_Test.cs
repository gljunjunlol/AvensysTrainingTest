using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using System.IO;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using BankingWebAPI.Interfaces;
using System.Linq;
using System.Data.Entity;
using BankingWebAPI.EntityFramework;
using System.Web.Http;
using System.Web.Http.Results;

namespace TakingLoan_Test
{
    public class TakingLoan_Test
    {
        private readonly Mock<IDataContext> _mockDataContext;

        public TakingLoan_Test()
        {
            _mockDataContext = new Mock<IDataContext>(MockBehavior.Strict);
        }
        [Fact]
        public void TestRead()
        {
            TakingLoanController tk = new TakingLoanController();
            tk.Read();
            tk.Write();
        }
        [Fact]
        public void TestTotalLoan()
        {
            //TakingLoanController tk = new TakingLoanController();
            //tk.TotalLoanAmount();

            Customer customer = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };

            var data = new List<Customer>
            {
                customer
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            TakingLoanController ac = new TakingLoanController(mockContext.Object);
            IHttpActionResult res = ac.TotalLoanAmount();
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestAddLoan(decimal x, decimal y)
        {
            TakingLoanController.AddLoan(x, y);
            Assert.Equal(8000, x + y);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestSubtractLoan(decimal x, decimal y)
        {
            TakingLoanController.SubtractLoan(x, y);
            Assert.Equal(0, x - y);
        }
        [Theory]
        [InlineData(4000, 40, 2)]
        public void TestMultiplyLoan(decimal x, decimal y, decimal z)
        {
            TakingLoanController.Multiply(x, y, z);
            Assert.Equal(320000, x * y * z);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestDivide(decimal x, decimal y)
        {
            TakingLoanController.Divide(x, y);
            Assert.Equal(1, x / y);
        }
        [Fact]
        public void TestDivideByZero()
        {
            var num1 = 1;
            var num2 = 0;

            var ex = Assert.Throws<DivideByZeroException>(() => TakingLoanController.Divide(num1, num2));
            string expectedErrorMessage = "Divide error";
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
        [Theory]
        [InlineData(4444, 12, 3)]
        public void TestLoanAmount(decimal loanamount, decimal monthsIn, decimal interestamount)
        {
            Customer customer = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };

            var data = new List<Customer>
            {
                customer
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            TakingLoanController ac = new TakingLoanController(mockContext.Object);
            IHttpActionResult res = ac.LoanAccount("1232", loanamount, monthsIn, interestamount);
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Theory]
        [InlineData("4444")]
        public void TestRepayLoan(string repayLoan)
        {
            Customer customer = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };

            var data = new List<Customer>
            {
                customer
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            TakingLoanController ac = new TakingLoanController(mockContext.Object);
            IHttpActionResult res = ac.RepayLoan("1232", repayLoan);
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void ViewLoanTest()
        {
            Customer customer = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };

            var data = new List<Customer>
            {
                customer
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            TakingLoanController ac = new TakingLoanController(mockContext.Object);
            IHttpActionResult res = ac.viewLoan("1232");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void ViewLoanInvalid()
        {
            Customer customer = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };

            var data = new List<Customer>
            {
                customer
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            TakingLoanController ac = new TakingLoanController(mockContext.Object);
            IHttpActionResult res = ac.viewLoan("petersmith");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
    }
}
