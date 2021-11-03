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
            CustomersManagement cmgt = new CustomersManagement();
            Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, true, 0);
            
            
            
            decimal expected = 0;
            Mock<IBankManagersManagement> bankingmanagermock = new Mock<IBankManagersManagement>();
            BankManagersManagement bankManagerTest = new BankManagersManagement();
            bankingmanagermock.Setup(t => t.TotalLoanAmount(cmgt));
            bankingmanagermock.Verify(t => t.TotalLoanAmount(cmgt), Times.Once);
            decimal res = bankManagerTest.TotalLoanAmount(cmgt);
            Assert.Equal(expected, res);
            BankManagersManagement bmgt = new BankManagersManagement();
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            string customer_id = "1";
            FileHandling fh = new FileHandling();
            fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
        }
        [Theory]
        [InlineData(3000)]
        public void TestViewCustomerTotalLoanAmt1(decimal totalloanamount)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(totalloanamount.ToString());

            var mockCustomerManagement = new Mock<CustomersManagement>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());


            bmgt.TotalLoanAmount(mockCustomerManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F")), Times.Once);
        }
        [Theory]
        [InlineData(3000)]
        public void TestViewCustomerTotalSavingsAmt1(decimal totalsavingsofCustomers)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(totalsavingsofCustomers.ToString());

            var mockCustomerManagement = new Mock<CustomersManagement>();

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
            Mock<IBankManagersManagement> bankingmanagermock = new Mock<IBankManagersManagement>();
            BankManagersManagement bankManagerTest = new BankManagersManagement();
            CustomersManagement cmgt = new CustomersManagement();
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
            CustomersManagement cmgt = new CustomersManagement();
            decimal expected = 0;
            Customer cust = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 100);
            Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 100);
            decimal actual = cust.loan_amount + cust2.loan_amount;



            mockdictionaryOfcustomers.Add("1", cust);
            Mock<IBankManagersManagement> bankingmanagermock = new Mock<IBankManagersManagement>();
            bankingmanagermock.Setup(t => t.TotalLoanAmount(cmgt));
            
            BankManagersManagement bankManagerTest = new BankManagersManagement();
            decimal res = bankManagerTest.TotalLoanAmount(cmgt);
            Assert.Equal(expected, actual);




        }
        [Fact]
        public void TestViewManagers()
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            bmgt.ViewManagers(bmgt);
        }
        [Fact]
        public void TestDeleteManagers()
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            HandleAccountOpeningBankManager handle = new HandleAccountOpeningBankManager();
            handle.DeleteUserAccount();
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserBankManagerLogin(string empid)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankManagersManagement = new Mock<BankManagersManagement>();

            mockBankManagersManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>() { { empid, new BankManagers() { bankmanager_id = empid } } });

            HandleAccountOpeningBankManager usr = new HandleAccountOpeningBankManager(mockConsoleIO.Object);
            usr.UserLogin(mockBankManagersManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {bmgt.dictionaryOfManagers[empid].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { bmgt.dictionaryOfManagers[empid].bankmanager_id} { bmgt.dictionaryOfManagers[empid].bankmanager_name} { bmgt.dictionaryOfManagers[empid].bankmanager_designation} { bmgt.dictionaryOfManagers[empid].bankmanager_yearsOfService}"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserBankManagerLoginNotExists(string empid)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(empid);

            var mockBankManagersManagement = new Mock<BankManagersManagement>();

            mockBankManagersManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>());

            HandleAccountOpeningBankManager usr = new HandleAccountOpeningBankManager(mockConsoleIO.Object);
            usr.UserLogin(mockBankManagersManagement.Object);

            mockConsoleIO.Verify(t => t.WriteLine("Incorrect user or pw"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestListAllManagers(string name)
        {
            BankManagersManagement bemgt = new BankManagersManagement();
            string itemid = "1";
            var mockConsoleIO = new Mock<IConsoleIO>();
            //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);
            mockConsoleIO.SetupSequence(t => t.ReadLine());
            var mockBankManagerManagement = new Mock<BankManagersManagement>();

            mockBankManagerManagement.Setup(x => x.dictionaryOfManagers).Returns(new Dictionary<string, BankManagers>() { { itemid, new BankManagers() { bankmanager_id = itemid } } });

            BankManagersManagement bemp = new BankManagersManagement(mockConsoleIO.Object);
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
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            BankManagersManagement bmgt = new BankManagersManagement();
            CustomersManagement cmgt = new CustomersManagement();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankManagersManagement bmgt1 = new BankManagersManagement(mockConsoleIO.Object);
            bmgt1.performOperationAdvanced(cmgt, bemgt, bmgt);

            mockConsoleIO.Verify(t => t.WriteLine("Select Option (Involving Manager access only)"), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void TestManagerPerformOperationInternal(string input)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            CustomersManagement cmgt = new CustomersManagement();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

            BankManagersManagement bmgt1 = new BankManagersManagement(mockConsoleIO.Object);
            bmgt1.performOperationAdvancedInternal(cmgt, bemgt, bmgt);

            mockConsoleIO.Verify(t => t.WriteLine("1: Find customer by ID: "), Times.Once);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        public void TestManagerPerformOperationInternal1(string input)
        {
            BankManagersManagement bmgt = new BankManagersManagement();
            BankEmployeesManagement bemgt = new BankEmployeesManagement();
            CustomersManagement cmgt = new CustomersManagement();

            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



            //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

            BankManagersManagement bmgt1 = new BankManagersManagement(mockConsoleIO.Object);
            bmgt1.performOperationAdvancedInternal1(cmgt, bemgt, bmgt);

            mockConsoleIO.Verify(t => t.WriteLine("1. List of total customers / 1: View all users (customers)"), Times.Once);
        }
    }
}
