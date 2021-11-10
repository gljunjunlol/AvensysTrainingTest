using System;
using Xunit;
using Gabriel_Bank_Management_System;
using System.Linq;
using System.Collections.Generic;
using Moq;
using System.IO;

namespace BankManagerTest
{
    public class BankManagerTest
    {
        [Fact]
        public void Test2()
        {

        }
        Program _p;
        public BankManagerTest()
        {
            _p = new Program();
        }

        //[Fact]
        [Fact]

        public void TestViewCustomerTotalLoanAmt()
        {
            CustomerAccountManager cmgt = new CustomerAccountManager();
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, true, 0);
            
            
            
            decimal expected = 0;
            Mock<IBankManagersManager> bankingmanagermock = new Mock<IBankManagersManager>();
            BankManagersManager bankManagerTest = new BankManagersManager();
            bankingmanagermock.Setup(t => t.TotalLoanAmount(cmgt));
            bankingmanagermock.Verify(t => t.TotalLoanAmount(cmgt), Times.Once);
            decimal res = bankManagerTest.TotalLoanAmount(cmgt);
            Assert.Equal(expected, res);
            ManagerAccountManager bmgt = new ManagerAccountManager();
            EmployeeAccountManager bemgt = new EmployeeAccountManager();
            string customer_id = "1";
            FileManager fh = new FileManager();
            fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
        }
        [Theory]
        [InlineData(3000)]
        public void TestViewCustomerTotalLoanAmt1(decimal totalloanamount)
        {
            BankManagersManager bmgt = new BankManagersManager();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(totalloanamount.ToString());

            var mockCustomerManagement = new Mock<CustomerAccountManager>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());


            bmgt.TotalLoanAmount(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F")), Times.Once);
        }
        [Theory]
        [InlineData(3000)]
        public void TestViewCustomerTotalSavingsAmt1(decimal totalsavingsofCustomers)
        {
            BankManagersManager bmgt = new BankManagersManager();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(totalsavingsofCustomers.ToString());

            var mockCustomerManagement = new Mock<CustomerAccountManager>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());


            bmgt.TotalSavingsAccount(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Total savings of the bank  " + totalsavingsofCustomers.ToString("F")), Times.Once);
        }
        [Fact]

        public void TestViewCustomerTotalSaving()
        {
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, true, 0);
            Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, true, 0);
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            Mock<IBankManagersManager> bankingmanagermock = new Mock<IBankManagersManager>();
            BankManagersManager bankManagerTest = new BankManagersManager();
            CustomerAccountManager cmgt = new CustomerAccountManager();
            bankingmanagermock.Setup(t => t.TotalSavingsAccount(cmgt));
            mockdictionaryOfcustomers.Add("1", cust);
            mockdictionaryOfcustomers.Add("2", cust);
            var res = mockdictionaryOfcustomers["1"].customerBalance = 100;
            var res2 = mockdictionaryOfcustomers["2"].customerBalance = 100;
            var res3 = res + res2;
            decimal expected = 200;
            
            Assert.Equal(expected, res3);

            

            
            

        }
        [Fact]

        public void TestperformOperationAdvanced()
        {
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            CustomerAccountManager cmgt = new CustomerAccountManager();
            decimal expected = 0;
            Customer cust = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 100);
            Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 100);
            decimal actual = cust.loan_amount + cust2.loan_amount;



            mockdictionaryOfcustomers.Add("1", cust);
            Mock<IBankManagersManager> bankingmanagermock = new Mock<IBankManagersManager>();
            bankingmanagermock.Setup(t => t.TotalLoanAmount(cmgt));
            
            BankManagersManager bankManagerTest = new BankManagersManager();
            decimal res = bankManagerTest.TotalLoanAmount(cmgt);
            Assert.Equal(expected, actual);




        }
        [Fact]
        public void TestViewManagers()
        {
            BankManagersManager bmgt1 = new BankManagersManager();
            ManagerAccountManager bmgt = new ManagerAccountManager();
            bmgt1.ViewManagers(bmgt);
        }
        [Fact]
        public void TestDeleteManagers()
        {
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserBankManagerLogin(string empid)
        {
            ManagerAccountManager bmgt = new ManagerAccountManager();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankManagersManagement = new Mock<ManagerAccountManager>();

            mockBankManagersManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>() { { empid, new BankManagers() { bankmanager_id = empid } } });

            ManagerAccountManager usr = new ManagerAccountManager(mockConsoleIO.Object);
            usr.UserLogin(mockBankManagersManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {bmgt.dictionaryOfManagers[empid].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { bmgt.dictionaryOfManagers[empid].bankmanager_id} { bmgt.dictionaryOfManagers[empid].bankmanager_name} { bmgt.dictionaryOfManagers[empid].bankmanager_designation} { bmgt.dictionaryOfManagers[empid].bankmanager_yearsOfService}"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserBankManagerLoginNotExists(string empid)
        {
            ManagerAccountManager bmgt = new ManagerAccountManager();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankManagersManagement = new Mock<ManagerAccountManager>();

            mockBankManagersManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>());

            ManagerAccountManager usr = new ManagerAccountManager(mockConsoleIO.Object);
            usr.UserLogin(mockBankManagersManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Incorrect user or pw"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestListAllManagers(string name)
        {
            ManagerAccountManager bemgt = new ManagerAccountManager();
            string itemid = "1";
            var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);
            mockConsoleIO.SetupSequence(t => t.ReadLine());
            var mockBankManagerManagement = new Mock<ManagerAccountManager>();

            mockBankManagerManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>() { { itemid, new BankManagers() { bankmanager_id = itemid } } });

            BankManagersManager bemp = new BankManagersManager(mockConsoleIO.Object);
            bemp.ViewManagers(mockBankManagerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"{itemid} {name} " + "\n Viewing all managers here"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void TestManagerPerformOperation(string input)
        {
            BankEmployeesManager bemgt1 = new BankEmployeesManager();
            EmployeeAccountManager bemgt = new EmployeeAccountManager();
            ManagerAccountManager bmgt = new ManagerAccountManager();
            CustomersManager cmgt1 = new CustomersManager();
            CustomerAccountManager cmgt = new CustomerAccountManager();
            BankManagersManager bmgt2 = new BankManagersManager();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankManagersManager bmgt1 = new BankManagersManager(mockConsoleIO.Object);
            bmgt1.performOperationAdvanced(cmgt, cmgt1, bemgt, bemgt1, bmgt, bmgt2);

            mockConsoleIO.Verify(t => t.WriteLine("Select Option (Involving Manager access only)"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void TestManagerPerformOperationInternal(string input)
        {
            ManagerAccountManager bmgt = new ManagerAccountManager();
            BankEmployeesManager bemgt1 = new BankEmployeesManager();
            EmployeeAccountManager bemgt = new EmployeeAccountManager();
            CustomersManager cmgt1 = new CustomersManager();
            CustomerAccountManager cmgt = new CustomerAccountManager();
            BankManagersManager bmgt2 = new BankManagersManager();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

            BankManagersManager bmgt1 = new BankManagersManager(mockConsoleIO.Object);
            bmgt1.performOperationAdvancedInternal(cmgt, cmgt1, bemgt, bemgt1, bmgt, bmgt2);

            mockConsoleIO.Verify(t => t.WriteLine("1: Find customer by ID: "), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void TestManagerPerformOperationInternal1(string input)
        {
            ManagerAccountManager bmgt = new ManagerAccountManager();
            BankEmployeesManager bemgt1 = new BankEmployeesManager();
            EmployeeAccountManager bemgt = new EmployeeAccountManager();
            CustomersManager cmgt1 = new CustomersManager();
            CustomerAccountManager cmgt = new CustomerAccountManager();
            BankManagersManager bmgt2 = new BankManagersManager();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankManagersManager bmgt1 = new BankManagersManager(mockConsoleIO.Object);
            bmgt1.performOperationAdvancedInternal1(cmgt, cmgt1, bemgt, bemgt1, bmgt, bmgt2);

            mockConsoleIO.Verify(t => t.WriteLine("1. List of total customers / 1: View all users (customers)"), Times.Once);
        }
    }
}
