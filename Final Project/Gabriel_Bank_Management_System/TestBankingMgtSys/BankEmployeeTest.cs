using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using BankingWebAPI.Interfaces;
using System.Linq;

namespace BankEmployeeTest
{
    public class BankEmployeeTest
    {
        //[Fact]
        //public void Test2()
        //{

        //}
        //Program _p;
        //public BankEmployeeTest()
        //{
        //    _p = new Program();
        //}

        ////[Fact]
        //[Fact]

        //public void TestAddBankEmployee()
        //{
            

        //}
        //[Fact]

        //public void TestListEmployee()
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    decimal expected = 0;
        //    Mock<IBankManagersManager> bankingmanagermock = new Mock<IBankManagersManager>();
        //    bankingmanagermock.Setup(t => t.TotalSavingsAccount(cmgt));
        //    BankManagersManager bankManagerTest = new BankManagersManager();
        //    decimal res = bankManagerTest.TotalSavingsAccount(cmgt);
        //    Assert.Equal(expected, res);

        //    EmployeeAccountManager eam = new EmployeeAccountManager();
        //    BankEmployeesManager bmgt = new BankEmployeesManager();
        //    bmgt.ListEmployees(eam);
            
        //    eam.dictionaryOfEmployees = new Dictionary<string, BankEmployees>();

            
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestRemoveEmployee(string empid)
        //{
            

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);
        //    var mockBankEmpManagement = new Mock<EmployeeAccountManagerController>();
        //    mockBankEmpManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>() { { empid, new BankEmployees() { bankemployee_id = empid } } });
        //    BankEmployeesManager bemgt = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemgt.RemoveEmployees(mockBankEmpManagement.Object);
        //    mockConsoleIO.Verify(t => t.WriteLine(empid + " has been removed"), Times.Once);

        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestNotExistDeleteEmployeeAccount(string empid)
        //{
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);
        //    var mockBankEmpManagement = new Mock<EmployeeAccountManager>();
        //    mockBankEmpManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>());
        //    BankEmployeesManager bemgt = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemgt.RemoveEmployees(mockBankEmpManagement.Object);
        //    mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        //}
        //[Fact]
        //public void TestSearchCustomerByID()
        //{

        //    string customer_id = "1";
        //    Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
        //    Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
        //    Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);
        //    mockdictionaryOfcustomers.Add(customer_id, cust);
        //    mockdictionaryOfcustomers.Add("2", cust2);
        //    Assert.True(mockdictionaryOfcustomers.Count == 2);
        //    Assert.True(mockdictionaryOfcustomers.ContainsKey("1"));
        //    Assert.False(mockdictionaryOfcustomers.ContainsKey("3"));
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    var mockCustomerManagement = new Mock<CustomersManager>();
           
        //    mockdictionaryOfcustomers.Add("7", cust2);
            
        //    TakingLoan takingloan = new TakingLoan(mockConsoleIO.Object);
        //    mockdictionaryOfcustomers.Add("3", cust);
        //    mockdictionaryOfcustomers.Add("4", cust2);
        //    Assert.NotNull(cust);
        //    Assert.NotNull(cust2);

        //}
        //[Fact]
        //public void TestSearchCustomerByName1()
        //{
            
        //    Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
        //    Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
        //    string customer_name2 = "mary";
        //    string customer_name = customer_name2.ToUpper();
        //    Assert.Equal("MARY", customer_name);
        //    Console.WriteLine(customer_name);



        //}
        //[Fact]
        //public void ListEmployees()
        //{
        //    BankEmployeesManager bgmt = new BankEmployeesManager();
            
        //}
        //[Fact]
        //public void TestperformOperation()
        //{

        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void SearchByIDExists(string itemid)
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManagerController>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    BankEmployeesManager bemp = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemp.SearchCustomerByID(mockCustomerManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("\n" + "ok found" + "\n"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void SearchByIDNotExists(string itemid)
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManagerController>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

        //    BankEmployeesManager bemp = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemp.SearchCustomerByID(mockCustomerManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void SearchByNameNotExists(string name)
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);

        //    var mockCustomerManagement = new Mock<CustomerAccountManagerController>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

        //    BankEmployeesManager bemp = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemp.SearchCustomerByName(mockCustomerManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void SearchByNameExists(string name)
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);

        //    var mockCustomerManagement = new Mock<CustomerAccountManagerController>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_name = name, customer_id = itemid } } });

        //    BankEmployeesManager bemp = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemp.SearchCustomerByName(mockCustomerManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine($"CUSTOMER ID: {itemid}"), Times.Once);
        //}
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserEmployeeLoginAccount(string empid)
        {
            string pw = "Hello12345678$";
            EmployeeAccountManagerController bemgt = new EmployeeAccountManagerController();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankEmployeesManagement = new Mock<EmployeeAccountManagerController>();

            mockBankEmployeesManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankingWebAPI.Models.BankEmployees>() { { empid, new BankEmployees() { bankemployee_id = empid } } });

            EmployeeAccountManagerController usr = new EmployeeAccountManagerController(mockConsoleIO.Object);
            usr.UserLogin(empid, pw);

            mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {bemgt.dictionaryOfEmployees[empid].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { bemgt.dictionaryOfEmployees[empid].bankemployee_id} { bemgt.dictionaryOfEmployees[empid].bankemployee_name} { bemgt.dictionaryOfEmployees[empid].bankemployee_designation} { bemgt.dictionaryOfEmployees[empid].bankemployee_yearsOfService}"), Times.Once);
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
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestUserEmployeeLoginAccountNotExists(string empid)
        //{
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

        //    var mockBankEmployeesManagement = new Mock<EmployeeAccountManager>();

        //    mockBankEmployeesManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>());

        //    EmployeeAccountManager usr = new EmployeeAccountManager(mockConsoleIO.Object);
        //    usr.UserLogin(mockBankEmployeesManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("Incorrect user or pw"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestListAllEmployees(string name)
        //{
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);
        //    mockConsoleIO.SetupSequence(t => t.ReadLine());
        //    var mockBankEmployeeManagement = new Mock<EmployeeAccountManager>();

        //    mockBankEmployeeManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>() { { itemid, new BankEmployees() { bankemployee_id = itemid } } });

        //    BankEmployeesManager bemp = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemp.ListEmployees(mockBankEmployeeManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine($"{itemid} {name} " + "\n Viewing all employees here"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //[InlineData("4")]
        //[InlineData("5")]
        //public void TestEmployeePerformOperation(string input)
        //{
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    BankEmployeesManager bemgt1 = new BankEmployeesManager(mockConsoleIO.Object);
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    bemgt1.PerformOperation(cmgt, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Screen 1"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //public void TestEmployeePerformOperationInternal(string input)
        //{
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    BankEmployeesManager bemgt1 = new BankEmployeesManager(mockConsoleIO.Object);
        //    bemgt1.performOperationinternal(cmgt, bemgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("1: Find customer by ID: "), Times.Once);
        //}
        [Fact]
        public void TestCreateEmployeeAccount1()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            //string employee_id = "1";



            Dictionary<string, BankEmployees> mockdictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            BankEmployees emp = new BankEmployees();
            BankEmployees emp1 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            mockdictionaryOfEmployees.Add("1", emp1);
            EmployeeAccountManagerController user = new EmployeeAccountManagerController(mockConsoleIO.Object);
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
        public void TestEmployeeAddNew()
        {
            BankEmployeeController emp = new BankEmployeeController();
            EmployeeAccountManagerController eam = new EmployeeAccountManagerController();
            var new_user = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            emp.EmployeeAddNew(eam, new_user);
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
        [Theory]
        [InlineData("User")]
        public void TestEmployeeNotNull(string bankemployee_id)
        {
            Assert.NotNull(bankemployee_id);
            //string updatedName = "hello1";
            //string bankemployee_id = "hello";
            //BankEmployeeController bec = new BankEmployeeController();
            //bec.Patch(bankemployee_id, updatedName);
            //Dictionary<string, BankEmployees> mockdictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            //BankEmployees new_user = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678");
            //mockdictionaryOfEmployees.Add(bankemployee_id, new_user);
            //BankEmployees existingEmployee = mockdictionaryOfEmployees[bankemployee_id];
            //Assert.Null(existingEmployee);
            



            //    BankEmployees emp = new BankEmployees();
            //    BankEmployees emp2 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678");
            //    mockdictionaryOfEmployees.Add("1", emp);
        }
    }
}
