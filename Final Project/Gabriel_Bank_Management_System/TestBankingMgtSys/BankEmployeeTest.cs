using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;

namespace BankEmployeeTest
{
    public class BankEmployeeTest
    {
        [Fact]
        public void Test2()
        {

        }
        Program _p;
        public BankEmployeeTest()
        {
            _p = new Program();
        }

        //[Fact]
        [Fact]

        public void TestAddBankEmployee()
        {
            

        }
        [Fact]

        public void TestListEmployee()
        {
            CustomersManagement cmgt = new CustomersManagement();
            decimal expected = 0;
            Mock<IBankManagersManagement> bankingmanagermock = new Mock<IBankManagersManagement>();
            bankingmanagermock.Setup(t => t.TotalSavingsAccount(cmgt));
            BankManagersManagement bankManagerTest = new BankManagersManagement();
            decimal res = bankManagerTest.TotalSavingsAccount(cmgt);
            Assert.Equal(expected, res);

            BankEmployeesManagement bmgt = new BankEmployeesManagement();
            bmgt.ListEmployees(bmgt);
            bmgt.References();
            bmgt.dictionaryOfEmployees = new Dictionary<string, BankEmployees>();

            //Mock<IValidatePw> validate = new Mock<IValidatePw>();
            //validate.Setup(t => t.ValidatePwMethod()).Returns(customer_pw);
            //HandleAccountOpening validatepw = new HandleAccountOpening(validate.Object);
            //bool res = validatepw.validatePassword();
            //Assert.True(res);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestRemoveEmployee(string empid)
        {
            

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);
            var mockBankEmpManagement = new Mock<BankEmployeesManagement>();
            mockBankEmpManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>() { { empid, new BankEmployees() { bankemployee_id = empid } } });
            BankEmployeesManagement bemgt = new BankEmployeesManagement(mockConsoleIO.Object);
            bemgt.RemoveEmployees(mockBankEmpManagement.Object);
            mockConsoleIO.Verify(t => t.WriteLine(empid + " has been removed"), Times.Once);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestNotExistDeleteEmployeeAccount(string empid)
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);
            var mockBankEmpManagement = new Mock<BankEmployeesManagement>();
            mockBankEmpManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>());
            BankEmployeesManagement bemgt = new BankEmployeesManagement(mockConsoleIO.Object);
            bemgt.RemoveEmployees(mockBankEmpManagement.Object);
            mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        }
        [Fact]
        public void TestSearchCustomerByID()
        {

            string customer_id = "1";
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);
            mockdictionaryOfcustomers.Add(customer_id, cust);
            mockdictionaryOfcustomers.Add("2", cust2);
            Assert.True(mockdictionaryOfcustomers.Count == 2);
            Assert.True(mockdictionaryOfcustomers.ContainsKey("1"));
            Assert.False(mockdictionaryOfcustomers.ContainsKey("3"));
            var mockConsoleIO = new Mock<IConsoleIO>();
            var mockCustomerManagement = new Mock<CustomersManagement>();
           
            mockdictionaryOfcustomers.Add("7", cust2);
            
            TakingLoan takingloan = new TakingLoan(mockConsoleIO.Object);
            mockdictionaryOfcustomers.Add("3", cust);
            mockdictionaryOfcustomers.Add("4", cust2);
            Assert.NotNull(cust);
            Assert.NotNull(cust2);

        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        public void TestSearchCustomerByIDNotExists(string customer_id)
        {
            CustomersManagement customersmanagement = new CustomersManagement();
            Dictionary<string, BankEmployees> mockdictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            //var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(customer_id);

            //var mockCustomerManagement = new Mock<CustomersManagement>();
            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
            //BankEmployeesManagement bmgt = new BankEmployeesManagement(mockConsoleIO.Object);
            //bmgt.SearchCustomerByID(mockCustomerManagement.Object);
            //CustomersManagement cmgt = new CustomersManagement();
            //mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);



        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        public void TestSearchCustomerByName(string name)
        {
            //string id = "1";
            //var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);

            //var mockCustomerManagement = new Mock<CustomersManagement>();
            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { id, new Customer() { customer_name = name, customer_id = id } } });
            //BankEmployeesManagement bmgt = new BankEmployeesManagement(mockConsoleIO.Object);
            //bmgt.SearchCustomerByName(mockCustomerManagement.Object);
            //CustomersManagement cmgt = new CustomersManagement();
            //mockConsoleIO.Verify(t => t.WriteLine("CUSTOMER ID: " + cmgt.dictionaryOfcustomers[id].customer_id), Times.Once);



        }
        [Fact]
        public void TestSearchCustomerByName1()
        {
            
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
            string customer_name2 = "mary";
            string customer_name = customer_name2.ToUpper();
            Assert.Equal("MARY", customer_name);
            Console.WriteLine(customer_name);



        }
        [Fact]
        public void ListEmployees()
        {
            BankEmployeesManagement bgmt = new BankEmployeesManagement();
            
        }
        [Fact]
        public void TestperformOperation()
        {

        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void SearchByIDExists(string itemid)
        {
            CustomersManagement cmgt = new CustomersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

            var mockCustomerManagement = new Mock<CustomersManagement>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankEmployeesManagement bemp = new BankEmployeesManagement(mockConsoleIO.Object);
            bemp.SearchCustomerByID(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("\n" + "ok found" + "\n"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void SearchByIDNotExists(string itemid)
        {
            CustomersManagement cmgt = new CustomersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

            var mockCustomerManagement = new Mock<CustomersManagement>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

            BankEmployeesManagement bemp = new BankEmployeesManagement(mockConsoleIO.Object);
            bemp.SearchCustomerByID(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void SearchByNameNotExists(string name)
        {
            CustomersManagement cmgt = new CustomersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);

            var mockCustomerManagement = new Mock<CustomersManagement>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

            BankEmployeesManagement bemp = new BankEmployeesManagement(mockConsoleIO.Object);
            bemp.SearchCustomerByName(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void SearchByNameExists(string name)
        {
            CustomersManagement cmgt = new CustomersManagement();
            string itemid = "1";
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);

            var mockCustomerManagement = new Mock<CustomersManagement>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_name = name, customer_id = itemid } } });

            BankEmployeesManagement bemp = new BankEmployeesManagement(mockConsoleIO.Object);
            bemp.SearchCustomerByName(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"CUSTOMER ID: {itemid}"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserEmployeeLoginAccount(string empid)
        {
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankEmployeesManagement = new Mock<BankEmployeesManagement>();

            mockBankEmployeesManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>() { { empid, new BankEmployees() { bankemployee_id = empid } } });

            HandleAccountOpeningEmployee usr = new HandleAccountOpeningEmployee(mockConsoleIO.Object);
            usr.UserLogin(mockBankEmployeesManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {bemgt.dictionaryOfEmployees[empid].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { bemgt.dictionaryOfEmployees[empid].bankemployee_id} { bemgt.dictionaryOfEmployees[empid].bankemployee_name} { bemgt.dictionaryOfEmployees[empid].bankemployee_designation} { bemgt.dictionaryOfEmployees[empid].bankemployee_yearsOfService}"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserEmployeeLoginAccountNotExists(string empid)
        {
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankEmployeesManagement = new Mock<BankEmployeesManagement>();

            mockBankEmployeesManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>());

            HandleAccountOpeningEmployee usr = new HandleAccountOpeningEmployee(mockConsoleIO.Object);
            usr.UserLogin(mockBankEmployeesManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Incorrect user or pw"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestListAllEmployees(string name)
        {
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            string itemid = "1";
            var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);
            mockConsoleIO.SetupSequence(t => t.ReadLine());
            var mockBankEmployeeManagement = new Mock<BankEmployeesManagement>();

            mockBankEmployeeManagement.Setup(x => x.dictionaryOfEmployees).Returns(new Dictionary<string, BankEmployees>() { { itemid, new BankEmployees() { bankemployee_id = itemid } } });

            BankEmployeesManagement bemp = new BankEmployeesManagement(mockConsoleIO.Object);
            bemp.ListEmployees(mockBankEmployeeManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"{itemid} {name} " + "\n Viewing all employees here"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        public void TestEmployeePerformOperation(string input)
        {
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            CustomersManagement cmgt = new CustomersManagement();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

            

            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankEmployeesManagement bemgt1 = new BankEmployeesManagement(mockConsoleIO.Object);
            BankManagersManagement bmgt = new BankManagersManagement();
            bemgt1.PerformOperation(cmgt, bemgt, bmgt);

            mockConsoleIO.Verify(t => t.WriteLine("Screen 1"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void TestEmployeePerformOperationInternal(string input)
        {
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            CustomersManagement cmgt = new CustomersManagement();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankEmployeesManagement bemgt1 = new BankEmployeesManagement(mockConsoleIO.Object);
            bemgt1.performOperationinternal(cmgt, bemgt);

            mockConsoleIO.Verify(t => t.WriteLine("1: Find customer by ID: "), Times.Once);
        }
    }
}
