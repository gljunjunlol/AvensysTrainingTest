using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using BankingWebAPI.Interfaces;
using System.Linq;
using System.Data.Entity;
using BankingWebAPI.EntityFramework;
using System.Web.Http;
using System.Web.Http.Results;

namespace BankEmployeeTest
{
    public class BankEmployeeTest
    {
        private readonly Mock<IDataContext> _mockDataContext;

        public BankEmployeeTest()
        {
            _mockDataContext = new Mock<IDataContext>(MockBehavior.Strict);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserEmployeeLoginAccount(string empid)
        {
            string pw = "Hello12345678$";
            EmployeeAccountManagerController bemgt = new EmployeeAccountManagerController();
            //var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankEmployeesManagement = new Mock<EmployeeAccountManagerController>();

            mockBankEmployeesManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankingWebAPI.Models.BankEmployees>() { { empid, new BankEmployees() { bankemployee_id = empid } } });
            //mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {bemgt.dictionaryOfEmployees[empid].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { bemgt.dictionaryOfEmployees[empid].bankemployee_id} { bemgt.dictionaryOfEmployees[empid].bankemployee_name} { bemgt.dictionaryOfEmployees[empid].bankemployee_designation} { bemgt.dictionaryOfEmployees[empid].bankemployee_yearsOfService}"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserBankEmployee(string empid)
        {
            Assert.NotNull(empid);
            BankEmployeeController bemgt = new BankEmployeeController();
            
        }
        [Fact]
        public void TestCreateEmployeeAccount1()
        {
            //var mockConsoleIO = new Mock<IConsoleIO>();
            //string employee_id = "1";



            Dictionary<string, BankEmployees> mockdictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            BankEmployees emp = new BankEmployees();
            BankEmployees emp1 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            mockdictionaryOfEmployees.Add("1", emp1);
            foreach (var employee in mockdictionaryOfEmployees)
            {
                Console.WriteLine("{0} > {1}", employee.Key, employee.Value);
                Console.WriteLine(" Viewing all employees here");
            }
        }
        [Fact]
        public void TestEmployeeGetAll()
        {
            BankEmployeeController emp = new BankEmployeeController();
            emp.GetAll();
        }
        [Theory]
        [InlineData("User")]
        public void TestEmployeeGET(string customer_id)
        {
            BankEmployeeController emp = new BankEmployeeController();
            emp.GET(customer_id);
        }
        [Theory]
        [InlineData("1111")]
        public void TestEmployeePATCH(string customer_id)
        {
            string updatedName = "Hello";
            BankEmployeeController emp = new BankEmployeeController();
            emp.Patch(customer_id, updatedName);
        }
        [Fact]
        public void TestEmployeeAddTo()
        {
            BankEmployeeController emp = new BankEmployeeController();
            BankEmployees emp1 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            emp.EmployeeAddTo(emp1);
        }
        [Fact]
        public void TestEmployeeAdd()
        {
            BankEmployeeController emp = new BankEmployeeController();
            var new_user = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            emp.EmployeeAdd(new_user);
        }
        [Fact]
        public void TestEmployeeAddDTO()
        {
            var new_user = new BankEmployeesDTO("1", "george", "23 hillview", DateTime.Now, "loan employee", "3");
            BankEmployeesDTO emp = new BankEmployeesDTO();
            BankEmployeeBranchDTO empBranch = new BankEmployeeBranchDTO();
            empBranch.bankemployee_id = "1234";
            empBranch.bank_branch = "South Branch";
        }
        [Fact]
        public void TestEmployeeAddDTO2()
        {
            BankEmployeesDTO emp = new BankEmployeesDTO();
            emp.ToString();
            BankEmployeesDTO emp1 = new BankEmployeesDTO(new BankEmployees());
        }
        [Fact]
        public void TestEmployeePut()
        {
            BankEmployeeController emp = new BankEmployeeController();
            var new_user = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            emp.PUT(new_user);
        }
        [Theory]
        [InlineData("1111")]
        public void TestEmployeeDelete(string customer_id)
        {
            BankEmployees employee = new BankEmployees();
            BankEmployeeController emp = new BankEmployeeController();
            emp.Delete(customer_id, employee);
        }
        [Theory]
        [InlineData("1111")]
        public void TestEmployeeDeleteByID(string customer_id)
        {
            BankEmployeeController emp = new BankEmployeeController();
            emp.DeleteById(customer_id);
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

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.CustomerByID("1232");
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

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.CustomerByID("1234");
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

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.CustomerByName("bobbysmith");
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

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.CustomerByName("petersmith");
            var contentResult = res as OkNegotiatedContentResult<Customer>;

            Assert.IsType<BadRequestErrorMessageResult>(res);
        }
        [Fact]
        public void SignUpTest()
        {
            string bankemployee_id = "1234"; string bankemployee_name = "georgesmith"; string bankemployee_address = "23"; DateTime bankemployee_dob = DateTime.Now; string bankemployee_designation = "loan employee"; string bankemployee_yos = "3"; string bankemployee_pw = "George12345678$";
            var mockUserDbSet = new Mock<DbSet<BankEmployees>>();
            _mockDataContext.Setup(t => t.Employees).Returns(mockUserDbSet.Object);
            _mockDataContext.Setup(t => t.SaveChanges()).Returns(1);

            var authenticationController = new BankEmployeeController(_mockDataContext.Object);

            var signUpResult = authenticationController.SignUp(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);

            mockUserDbSet.Verify(t => t.Add(It.IsAny<BankEmployees>()), Times.Once());
            _mockDataContext.Verify(t => t.SaveChanges(), Times.Once());
            Assert.IsType<OkResult>(signUpResult);
        }
        [Theory]
        [InlineData("1234")]
        public void DeleteEmployeeTest(string id)
        {
            BankEmployeeController emp = new BankEmployeeController();
            emp.DeleteEmployee(id);
        }
        [Fact]
        public void ViewAllEmployeesTest()
        {
            BankEmployees employee = new BankEmployees() { bankemployee_id = "1111", bankemployee_name = "jamesmith", bankemployee_address = "23 hillview", bankemployee_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankemployee_designation = "Relationship Associate", bankemployee_yearsOfService = "3", bankemployee_pw = "pw"};

            var data = new List<BankEmployees>
            {
                employee
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BankEmployees>>();
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Employees).Returns(mockSet.Object);

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.ViewAllEmployees();
            var contentResult = res as OkNegotiatedContentResult<IEnumerable<BankEmployees>>;

            Assert.Contains(employee, contentResult.Content);
        }
        [Fact]
        public void ViewAllEmployeesEmpty()
        {
            var data = new List<BankEmployees>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BankEmployees>>();
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<BankEmployees>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(x => x.Employees).Returns(mockSet.Object);

            BankEmployeeController ac = new BankEmployeeController(mockContext.Object);
            IHttpActionResult res = ac.ViewAllEmployees();
            var contentResult = res as OkNegotiatedContentResult<string>;

            Assert.Equal("Invalid Employee ID", contentResult.Content);
        }
        [Theory]
        [InlineData("1234", "George12345678$")]
        public void LoginTestEmployeeFail(string userName, string passWord)
        {
            var userList = new List<BankEmployees>
            {
                new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$")
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<BankEmployees>>();
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Employees).Returns(mockUserDbSet.Object);

            var authenticationController = new EmployeeAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((false, false), idResult);
            ;
        }
        [Theory]
        [InlineData("1234", "George12345678$")]
        public void LoginTestEmployee(string userName, string passWord)
        {
            var userList = new List<BankEmployees>
            {
                new BankEmployees("1234", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$")
            }.AsQueryable();

            var mockUserDbSet = new Mock<DbSet<BankEmployees>>();
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.Provider).Returns(userList.Provider);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.Expression).Returns(userList.Expression);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.ElementType).Returns(userList.ElementType);
            mockUserDbSet.As<IQueryable<BankEmployees>>().Setup(t => t.GetEnumerator()).Returns(userList.GetEnumerator());

            _mockDataContext.Setup(t => t.Employees).Returns(mockUserDbSet.Object);

            var authenticationController = new EmployeeAccountManagerController(_mockDataContext.Object);

            var idResult = authenticationController.Login(userName, passWord);
            Assert.Equal((true, true), idResult);
            ;
        }
    }
}
