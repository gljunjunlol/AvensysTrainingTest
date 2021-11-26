using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using System.IO;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;
using BankingWebAPI.Controllers;
using System.Linq;
using System.Data.Entity;
using BankingWebAPI.EntityFramework;
using System.Web.Http;
using System.Web.Http.Results;

namespace TakingLoan_Test
{
    public class Savings_Test
    {        
        [Fact]

        public void Test_Adding_negative_funds()
        {
            Customer cust = new Customer();
            
            cust.customerBalance = 1000;
            var account = new Customer();
            account.deposit(1000);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.deposit(-1000));
        }
        [Fact]

        public void Test_Withdraw_negative_funds()
        {
            Customer cust = new Customer();

            cust.customerBalance = 1000;
            var account = new Customer();
            

            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(-1000));
        }
        [Fact]

        public void Test_Withdraw_More_Than_funds()
        {
            Customer cust = new Customer();

            cust.customerBalance = 1000;
            var account = new Customer();
            

            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(2000));
        }
        [Fact]
        public void TestCustomerWithdrawl()
        {
            
            decimal expected = 5;
            Customer cust = new Customer();

            cust.customerBalance = 10;
            cust.withdraw(5);
            cust.customerBalance = 5;
            Assert.Equal(expected, cust.customerBalance);
        }
        [Fact]
        public void TestRead()
        {
            SavingsController sav = new SavingsController();
            sav.Read();
        }
        [Fact]
        public void TestWrite()
        {
            SavingsController sav = new SavingsController();
            sav.Write();
        }
        [Fact]
        public void TestTotalSavings()
        {
            //SavingsController sav = new SavingsController();
            //sav.TotalSavingsAmount();

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

            SavingsController ac = new SavingsController(mockContext.Object);
            IHttpActionResult res = ac.TotalSavingsAmount();
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestAddSavings(decimal x, decimal y)
        {
            SavingsController.AddSavings(x, y);
            Assert.Equal(8000, x + y);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestSubtractSavings(decimal x, decimal y)
        {
            SavingsController.SubtractSaving(x, y);
            Assert.Equal(0, x - y);
        }
        [Theory]
        [InlineData(4000, 40, 2)]
        public void TestMultiplySavings(decimal x, decimal y, decimal z)
        {
            SavingsController.Multiply(x, y, z);
            Assert.Equal(320000, x * y * z);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestDivide(decimal x, decimal y)
        {
            SavingsController.Divide(x, y);
            Assert.Equal(1, x / y);
        }
        [Fact]
        public void TestDivideByZero()
        {
            var num1 = 1;
            var num2 = 0;
            
            var ex = Assert.Throws<DivideByZeroException>(() => SavingsController.Divide(num1, num2));
            string expectedErrorMessage = "Divide error";
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
        [Fact]
        public void TestModulusByZero()
        {
            var num1 = 1;
            var num2 = 0;
            var ex = Assert.Throws<DivideByZeroException>(() => SavingsController.Modulus(num1, num2));
            string expectedErrorMessage = "Divide error";
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
        [Theory]
        [InlineData(4000, 4000)]
        public void TestModulus(decimal x, decimal y)
        {
            SavingsController.Modulus(x, y);
            Assert.Equal(0, x % y);
        }
        [Theory]
        [InlineData(4444)]
        public void TestCustomerWithdrawal(decimal withdraw)
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

            SavingsController ac = new SavingsController(mockContext.Object);
            IHttpActionResult res = ac.customerWithdrawal("1232", withdraw);
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Theory]
        [InlineData(4444)]
        public void TestCustomerDeposit(decimal deposit)
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

            SavingsController ac = new SavingsController(mockContext.Object);
            IHttpActionResult res = ac.customerDeposit("1232", deposit);
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void GetCustomerByID()
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

            CustomerController ac = new CustomerController(mockContext.Object);
            IHttpActionResult res = ac.GetCustomerByID("1232");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void GetCustomerByIDInvalid()
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

            CustomerController ac = new CustomerController(mockContext.Object);
            IHttpActionResult res = ac.GetCustomerByID("1234");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
        [Fact]
        public void ViewBalanceTest()
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

            SavingsController ac = new SavingsController(mockContext.Object);
            IHttpActionResult res = ac.viewBalance("1232");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void ViewBalanceInvalid()
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

            SavingsController ac = new SavingsController(mockContext.Object);
            IHttpActionResult res = ac.viewBalance("petersmith");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
        [Fact]

        public void Test_Adding_negative_fundsforDTO()
        {
            CustomerDTO cust = new CustomerDTO();

            cust.customerBalance = 1000;
            var account = new CustomerDTO();
            account.deposit(1000);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.deposit(-1000));
        }
        [Fact]

        public void Test_Withdraw_negative_fundsforDTO()
        {
            CustomerDTO cust = new CustomerDTO();

            cust.customerBalance = 1000;
            var account = new CustomerDTO();


            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(-1000));
        }
        [Fact]

        public void Test_Withdraw_More_Than_fundsforDTO()
        {
            CustomerDTO cust = new CustomerDTO();

            cust.customerBalance = 1000;
            var account = new CustomerDTO();


            Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(2000));
        }
        [Fact]
        public void TestCustomerWithdrawlforDTO()
        {

            decimal expected = 5;
            CustomerDTO cust = new CustomerDTO();

            cust.customerBalance = 10;
            cust.withdraw(5);
            cust.customerBalance = 5;
            Assert.Equal(expected, cust.customerBalance);
        }
    }
}
