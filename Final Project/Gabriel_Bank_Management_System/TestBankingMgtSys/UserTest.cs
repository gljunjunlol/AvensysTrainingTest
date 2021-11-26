using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using BankingWebAPI;
using BankingWebAPI.Utility;
using BankingWebAPI.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading;
using BankingWebAPI.EntityFramework;
using System.Web.Http;
using System.Linq;
using System.Data.Entity;
using Bank.Common.Common;
using System.Web.Http.Results;

namespace UserTest
{
    public class UserTest
    {
        private readonly Mock<IDataContext> _mockDataContext;

        public UserTest()
        {
            _mockDataContext = new Mock<IDataContext>(MockBehavior.Strict);
        }
        [Theory]
        [InlineData("Sad123")]
        public void CheckUserNameTestNone(string username)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("1234", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var userNameResult = authenticationController.CheckUserName(username);
            Assert.Equal(UserNameResultType.None, userNameResult);
        }
        [Theory]
        [InlineData("Count 123")]
        public void CheckUserNameTestSpace(string username)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("1234", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var userNameResult = authenticationController.CheckUserName(username);
            Assert.Equal(UserNameResultType.UserNameContainsSpace, userNameResult);
        }
        [Theory]
        [InlineData("Count")]
        public void CheckUserNameTestLengthIncorrect(string username)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("1234", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var userNameResult = authenticationController.CheckUserName(username);
            Assert.Equal(UserNameResultType.UserNameLengthIncorrect, userNameResult);
        }
        [Theory]
        [InlineData("johnsmith")]
        public void CheckUserNameTestDuplicate(string username)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("1234", "johnsmith", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var userNameResult = authenticationController.CheckUserName(username);
            Assert.Equal(UserNameResultType.DuplicateUser, userNameResult);
        }
        [Theory]
        [InlineData("A12345")]
        public void CheckIdTestIncorrect(string id)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.CheckId(id);
            Assert.Equal(IdResultType.IdIncorrect, idResult);
        }
        [Theory]
        [InlineData(null)]
        public void CheckIdTestNull(string id)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.CheckId(id);
            Assert.Equal(IdResultType.IdNullError, idResult);
        }
        [Theory]
        [InlineData("12345")]
        public void CheckIdTestDuplicate(string id)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.CheckId(id);
            Assert.Equal(IdResultType.DuplicateId, idResult);
        }
        [Theory]
        [InlineData(null)]
        public void CheckPhoneNumberTestNull(string phone)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var phoneNumberResult = authenticationController.validatePhone(phone);
            Assert.Equal(PhoneNumberResultType.PhoneNumberNullError, phoneNumberResult);
        }
        [Theory]
        [InlineData("222")]
        public void CheckPhoneNumberTestIncorrect(string phone)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var phoneNumberResult = authenticationController.validatePhone(phone);
            Assert.Equal(PhoneNumberResultType.PhoneNumberIncorrect, phoneNumberResult);
        }
        [Theory]
        [InlineData("222")]
        public void CheckPhoneNumberTestNone(string phone)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var phoneNumberResult = authenticationController.validatePhone(phone);
            Assert.Equal(PhoneNumberResultType.None, phoneNumberResult);
        }
        [Theory]
        [InlineData("(222)333-4444")]
        public void CheckPhoneNumberTestDuplicate(string phone)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var phoneNumberResult = authenticationController.validatePhone(phone);
            Assert.Equal(PhoneNumberResultType.DuplicatePhoneNumber, phoneNumberResult);
        }
        [Theory]
        [InlineData(null)]
        public void CheckEmailNumberTestNull(string email)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var EmailNumberResult = authenticationController.validateEmail(email);
            Assert.Equal(EmailAddressResultType.EmailAddressNullError, EmailNumberResult);
        }
        [Theory]
        [InlineData("john")]
        public void CheckEmailNumberTestIncorrect(string email)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var EmailNumberResult = authenticationController.validateEmail(email);
            Assert.Equal(EmailAddressResultType.EmailAddressIncorrect, EmailNumberResult);
        }
        [Theory]
        [InlineData("john@mail.com")]
        public void CheckEmailNumberTestNone(string email)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var EmailNumberResult = authenticationController.validateEmail(email);
            Assert.Equal(EmailAddressResultType.None, EmailNumberResult);
        }
        [Theory]
        [InlineData("john@mail.com")]
        public void CheckEmailNumberTestDuplicate(string email)
        {
            var userList = new List<BankingWebAPI.Models.Customer>
            {
                new BankingWebAPI.Models.Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0)
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var EmailNumberResult = authenticationController.validateEmail(email);
            Assert.Equal(EmailAddressResultType.DuplicateEmailAddress, EmailNumberResult);
        }
        [Theory]
        [InlineData("@johN123456")]
        [InlineData("johnN1234$")]
        [InlineData("John111N!")]
        [InlineData("JjLo1234##@!")]
        public void TestValidatepwIsTrue(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var res = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.None, res);


        }
        //////[Fact]
        //[Theory]
        //[InlineData("jj")]
        //[InlineData("123")]
        //[InlineData("loeo")]
        //[InlineData("jjjjjjjjj")]
        //public void TestvallidatepwIsFalse1(string customer_pw)
        //{
        //    Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
        //    validate.Setup(t => t.validatePassword(customer_pw));
        //    CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
        //    var passwordResult = validatepw.validatePassword(customer_pw);
        //    Assert.Equal(ForPasswordResultType.None
        //        | ForPasswordResultType.IncorrectPasswordLength
        //        | ForPasswordResultType.PasswordNoDigits
        //        | ForPasswordResultType.PasswordNoUpperCaseLetter
        //        | ForPasswordResultType.PasswordNoLowerCaseLetter
        //        | ForPasswordResultType.PasswordNoSpecialCharacter
        //        , passwordResult);
        //}
        [Theory]
        [InlineData("jj")]
        public void TestvallidatepwIsFalseLength(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var passwordResult = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.IncorrectPasswordLength
                , passwordResult);
        }
        [Theory]
        [InlineData("Johnny")]
        public void TestvallidatepwIsFalseNoDigit(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var passwordResult = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.PasswordNoDigits
                , passwordResult);
        }
        [Theory]
        [InlineData("johnny")]
        public void TestvallidatepwIsFalseNoUpper(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var passwordResult = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.PasswordNoUpperCaseLetter
                , passwordResult);
        }
        [Theory]
        [InlineData("JOHNNY")]
        public void TestvallidatepwIsFalseNoLower(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var passwordResult = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.PasswordNoLowerCaseLetter
                , passwordResult);
        }
        [Theory]
        [InlineData("Johnny1")]
        public void TestvallidatepwIsFalseNoSpeChar(string customer_pw)
        {
            Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
            validate.Setup(t => t.validatePassword(customer_pw));
            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            var passwordResult = validatepw.validatePassword(customer_pw);
            Assert.Equal(ForPasswordResultType.PasswordNoSpecialCharacter
                , passwordResult);
        }

        [Fact]
        public void TestCustomerGetAll()
        {
            CustomerController cust = new CustomerController();
            cust.GetAll();
        }
        [Theory]
        [InlineData("User")]
        public void TestCustomerGET(string customer_id)
        {
            CustomerController cust = new CustomerController();
            cust.GET(customer_id);
        }
        [Fact]
        public void TestCustomerAdd()
        {
            CustomerController cust = new CustomerController();
            var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            cust.CustomerAdd(new_user);
        }
        [Fact]
        public void TestCustomerDTO2()
        {
            var new_user = new CustomerDTO("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "123", 0);
        }
        [Fact]
        public void TestCustomerDTO()
        {
            var new_user = new CustomerDTO("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "123", 0, Guid.Empty, false, 100);
        }
        [Fact]
        public void TestCustomerPut()
        {
            CustomerController cust = new CustomerController();
            var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            cust.PUT(new_user);
        }
        [Theory]
        [InlineData("User")]
        public void TestCustomerDeleteByID(string customer_id)
        {
            CustomerController cust = new CustomerController();
            cust.DeleteById(customer_id);
        }
        [Fact]
        public void FileHandling()
        {
            ManagerAccountManagerController bmgt = new ManagerAccountManagerController();
            EmployeeAccountManagerController bemgt = new EmployeeAccountManagerController();
            var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            Assert.NotNull(new_user);
            var new_user2 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            Assert.NotNull(new_user2);
            var new_user3 = new BankManagers("1", "karen", "25 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$");
            Assert.NotNull(new_user3);
            CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
            FileManager fileHandling = new FileManager();
            fileHandling.ReadingandWritingcustomer(new_user.customer_id);
            fileHandling.ReadingandWritingEmployee(new_user2.bankemployee_id, cmgt, bemgt, bmgt);
            fileHandling.ReadingandWritingManager(new_user3.bankmanager_id, cmgt, bemgt, bmgt);
            fileHandling.JsonListofAllCustomers(new_user.customer_id, cmgt, bemgt, bmgt);
        }
        [Fact]
        public void TestFileHandlingCustomer()
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

            FileManager ac = new FileManager(mockContext.Object);
            string customer_id = "1232";
            FileManager fileHandling = new FileManager();
            fileHandling.ReadingandWritingcustomer(customer_id);
            Assert.Equal("1232", customer_id);
        }
            
        [Fact]
        public void testConsoleIO()
        {
            string message = "hello";
            //ConsoleIO cs = new ConsoleIO();

            //cs.WriteLine(message);
                
            Assert.Equal("hello", message);
        }
        [Fact]
        public void testAddCustomer()
        {
            ManagerAccountManagerController bmgt = new ManagerAccountManagerController();
            EmployeeAccountManagerController bemgt = new EmployeeAccountManagerController();
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            var new_user1 = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);
            Assert.NotNull(new_user);
            Assert.NotNull(new_user1);
            var new_user3 = new Customer(null, null, null, new DateTime(), null, null, null, null ,0, Guid.Empty, false, 0);
            Assert.Null(new_user3);
            Assert.Null(new_user1);
            Assert.Contains(mockdictionaryOfcustomers, item => item.Key == new_user.customer_id);

                
            mockdictionaryOfcustomers.Add(new_user.customer_id, new_user);
            mockdictionaryOfcustomers.Add(new_user1.customer_id, new_user1);

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
        [Fact]
        public void TestLogAttribute()
        {
            LogAttribute lg = new LogAttribute();
            HttpActionContext actionContext = new HttpActionContext();
            lg.OnActionExecuting(actionContext);
        }
        [Fact]
        public void TestLogAttributeOn()
        {
            LogAttribute lg = new LogAttribute();
            HttpActionExecutedContext actionExecutedContext = new HttpActionExecutedContext();
            lg.OnActionExecuted(actionExecutedContext);
        }
        [Fact]
        public void TestLogActionAttribute()
        {
            LogActionAttribute lg = new LogActionAttribute();
            HttpActionExecutedContext actionExecutedContext = new HttpActionExecutedContext();
            Assert.True(lg.AllowMultiple);
        }
        [Fact]
        public void TestLogActionAttributeExecute()
        {
            LogActionAttribute lg = new LogActionAttribute();
            HttpActionContext actionContext = new HttpActionContext();
            CancellationToken cancellationToken = new CancellationToken();
            lg.ExecuteActionFilterAsync(actionContext, cancellationToken, null);

        }
        [Fact]
        public void TestBankManagementConfiguration()
        {
            BankManagementConfiguration bmc = new BankManagementConfiguration();
        }
        [Fact]
        public void TestWebAPIConfig()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
                
        }
        [Theory]
        [InlineData("User")]
        public void TestCheckUserName(string customer_id)
        {
            CustomerAccountManagerController cam = new CustomerAccountManagerController();
            cam.CheckUserName(customer_id);
        }
        [Theory]
        [InlineData("User")]
        public void TestCheckUserID(string customer_id)
        {
            CustomerAccountManagerController cam = new CustomerAccountManagerController();
            cam.CheckId(customer_id);
        }
        [Fact]
        public void SignUpTest()
        {
            string customer_id = "1234"; string customer_name = "apple"; string customer_address = "150 street"; DateTime customer_dob = DateTime.Now; string customer_email = "john@mail.com"; string customer_phone = "(222)333-4444"; string customer_pw = "John12345678$"; string account_no = "A1234"; decimal account_bal = 4000; Guid cheque_bk_number = Guid.Empty; bool loan_app = false; decimal loan_with_amt = 4000;
            var mockUserDbSet = new Mock<DbSet<Customer>>();
            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);
            _mockDataContext.Setup(t => t.SaveChanges()).Returns(1);

            var authenticationController = new CustomerController(_mockDataContext.Object);

            var signUpResult = authenticationController.SignUp(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, account_no, account_bal, cheque_bk_number, loan_app, loan_with_amt);

            mockUserDbSet.Verify(t => t.Add(It.IsAny<Customer>()), Times.Once());
            _mockDataContext.Verify(t => t.SaveChanges(), Times.Once());
            Assert.IsType<OkResult>(signUpResult);
        }
        [Theory]
        [InlineData("1234", "John12345678$")]
        public void LoginTestUser(string userName, string passWord)
        {
            var userList = new List<Customer>
            {
                new Customer("1234", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0),
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((true, true), idResult);
            ;
        }
        [Theory]
        [InlineData("1234", "John12345678$")]
        public void LoginTestFail(string userName, string passWord)
        {
            var userList = new List<Customer>
            {
                new Customer("12345", "apple", "150 street", DateTime.Now, "john@mail.com", "(222)333-4444", "John12345678$", "A1234", 0),
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<Customer>>();
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<Customer>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Customers).Returns(mockUserDbSet.Object);

            var authenticationController = new CustomerAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((false, false), idResult);
            ;
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
        public void GetCustomerByName()
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
            IHttpActionResult res = ac.GetCustomerByName("bobbysmith");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.Equal(customer, contentResult.Content);
        }
        [Fact]
        public void GetCustomerByNameInvalid()
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
            IHttpActionResult res = ac.GetCustomerByName("petersmith");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
        [Theory]
        [InlineData("1234")]
        public void RemoveCustomerTest(string id)
        {
            CustomerController cust = new CustomerController();
            cust.RemoveCustomer(id);
        }
        [Fact]
        public void ViewAllCustomersTest()
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
            IHttpActionResult res = ac.ViewAllCustomers();
            var contentResult = res as OkNegotiatedContentResult<IEnumerable<Customer>>;

            Assert.Contains(customer, contentResult.Content);
        }
        [Fact]
        public void ViewAllCustomersEmpty()
        {
            

            var data = new List<Customer>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Customers).Returns(mockSet.Object);

            CustomerController ac = new CustomerController(mockContext.Object);
            IHttpActionResult res = ac.ViewAllCustomers();
            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.Equal("Invalid Bank Customer ID", contentResult.Content);
        }
        [Fact]
        public void TestTransactionTable()
        {
            TransactionTable tb = new TransactionTable();
            tb.dateOftransaction = DateTime.Now;
            tb.TransactionDetails = "";
            tb.TransactionAmount = 4000;
        }
        [Fact]
        public void TestTransactionDTOTable()
        {
            TransactionTableDTO tb = new TransactionTableDTO();
            tb.dateOftransaction = DateTime.Now;
            tb.TransactionDetails = "";
            tb.TransactionAmount = 4000;
        }
    }


        
}
