using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using System.IO;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace TakingLoan_Test
{
    public class TakingLoan_Test
    {
        //[Fact]
        //public void Test1()
        //{

        //}
        //Program _p;
        //public TakingLoan_Test()
        //{
        //    _p = new Program();
        //}
        //[Theory]
        //[InlineData(1000)]
        
        //public void TestCalculateLoanAmt(decimal amt)
        //{
        //    TakingLoan taking = new TakingLoan();
        //    taking.CalculateLoanAmount(1000, 12, 5);
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(amt.ToString());
        //    taking.CalculateLoanAmount(1000, 5, 3);
        //    mockConsoleIO.Verify(t => t.WriteLine("Enter loan application amount"), Times.Once());


        //    TakingLoan tk = new TakingLoan();
        //    decimal expected = 1050;

        //    decimal result = tk.CalculateLoanAmount(1000, 12, 5);

        //    Assert.Equal(expected, result);
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
            
            
            
        //    Assert.Equal(output.ToString(), string.Format("Key in customer id"));
            
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestLoanAccount(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManagerController>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, WebApiLibrary.Models.Customer >() { { itemid, new WebApiLibrary.Models.Customer() { customer_id = itemid } } });
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.LoanAccount(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine("Loan application : ID : " + cmgt.dictionaryOfcustomers[itemid] + " " + cmgt.dictionaryOfcustomers[itemid].customer_name), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestLoanAccountNotExists(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.LoanAccount(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine("Already applied for loan which is unpaid"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestViewLoanAccount(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.ViewLoan(mockCustomerManagement.Object);
        //    mockConsoleIO.Verify(t => t.WriteLine("Current loan is at $" + cmgt.dictionaryOfcustomers[itemid].loan_amount.ToString("F")), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestViewLoanAccountNotExists(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.ViewLoan(mockCustomerManagement.Object);
        //    mockConsoleIO.Verify(t => t.WriteLine("Current loan is at $0"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestAddLoanAccount(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.AddLoan(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine(itemid), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestAddLoanAccountNotExists(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.AddLoan(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine("Sorry cant take additional loan as previous loan is still outstanding"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestRepayLoanAccount(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.RepayLoan(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine("Current loan is at " + cmgt.dictionaryOfcustomers[itemid].loan_amount.ToString("F") + "\nE.g. key in 100 to repay 100 or / key in  6% to repay 6%"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestRepayLoanAccountNotExist(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.RepayLoan(mockCustomerManagement.Object, bemgt, bmgt);
        //    mockConsoleIO.Verify(t => t.WriteLine("No loan to repay"), Times.Once);
        //}
        //[Fact]
        //public void TestOfDateTime()
        //{
        //    var firstValue = DateTime.Now;
        //    var secondValue = DateTime.Now;
        //    Assert.False(firstValue > secondValue);
        //}

        ////[Fact]
        //[Fact]
        //public void TestTakingLoan()
        //{
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    string customer_id = "1";
        //    TakingLoan takingloan = new TakingLoan(mockConsoleIO.Object);
        //    Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
        //    Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0, Guid.Empty, false, 100);
        //    Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0);
        //    mockdictionaryOfcustomers.Add("1", cust);
        //    mockdictionaryOfcustomers.Add("2", cust2);
        //    Assert.NotNull(cust);
        //    Assert.NotNull(cust2);
        //    Assert.True(mockdictionaryOfcustomers.ContainsKey(customer_id));
        //    Assert.True(mockdictionaryOfcustomers[customer_id].customer_loan_applied == false);
        //    foreach (var customer in mockdictionaryOfcustomers)
        //    {
        //        Console.WriteLine("{0} > {1}", customer.Key, customer.Value);
        //        Console.WriteLine(" Viewing all customers here");
        //    }

        //    if (mockdictionaryOfcustomers.ContainsKey(customer_id))
        //    {
        //        Assert.Contains(mockdictionaryOfcustomers, item => item.Key == customer_id);
        //        if (mockdictionaryOfcustomers[customer_id].customer_loan_applied == false)
        //        {
        //            try
        //            {
        //                ManagerAccountManager bmgt = new ManagerAccountManager();
        //                EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //                CustomerAccountManager cmgt = new CustomerAccountManager();
        //                var output = new StringWriter();
        //                Console.SetOut(output);

        //                var input = new StringReader("12345");
        //                Console.SetIn(input);
        //                TakingLoan taking = new TakingLoan();
        //                taking.LoanAccount(cmgt, bemgt, bmgt);
                        
        //                Assert.Equal(output.ToString(), string.Format("Key in customer id"));
        //                Assert.True(mockdictionaryOfcustomers[customer_id].customer_loan_applied == true);
        //                //Assert.Equal(CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = true, true);
        //                FileManager fh = new FileManager();
        //                fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
        //            }
        //            catch (NotSupportedException ex)
        //            {
        //                Assert.Contains("The file or directory is not supported", ex.Message);
        //            }
        //            catch (UnauthorizedAccessException)
        //            {
        //                Console.WriteLine("You do not have permission to create this file.");
        //            }
        //            catch (IOException)
        //            {
        //                Console.WriteLine($"The file already exist ");
        //            }
        //            catch (Exception)
        //            {

        //            }
        //            finally
        //            {

        //            }
        //        }
        //    }
            


            


        //    //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(customer_id);
        //    //mockConsoleIO.Verify(t => t.WriteLine("Enter customer ID"), Times.Once());

        //    //mockConsoleIO.Verify(t => t.WriteLine("Already applied for loan which is unpaid"), Times.Once());



        //}
        
        //[Fact]
        //public void TestViewLoan()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    TakingLoan taking = new TakingLoan();
        //    taking.ViewLoan(cmgt);
            
        //    Assert.Equal(output.ToString(), string.Format("Enter customer ID\r\nAccount doesn't exist in our database record\r\n"));
        //}
        //[Fact]
        //public void TestAddLoan()
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    TakingLoan taking = new TakingLoan();
        //    taking.AddLoan(cmgt, bemgt, bmgt);
            
        //    Assert.Equal(output.ToString(), string.Format("Enter customer ID\r\n"));
        //}
        //[Fact]
        //public void TestRepaylLoan()
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    //TakingLoan takingloantest = new TakingLoan();
        //    //takingloantest.RepayLoan();

        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    TakingLoan taking = new TakingLoan();
        //    taking.RepayLoan(cmgt, bemgt, bmgt);
        //    Assert.Equal(output.ToString(), string.Format("Enter customer ID\r\nAccount doesn't exist in our database record\r\n"));
        //}
        //[Fact]
        //public void TestPerformOperation()
        //{
        //}
        //[Fact]
        //public void Add_SimpleValuesShouldCalculate()
        //{
        //    decimal expected = 5;

        //    decimal actual = TakingLoan.AddLoan(3, 2);

        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(4,3,7)]
        //[InlineData(21, 5.25, 26.25)]
        //public void Add_SimpleValuesShouldCalculate1(decimal x, decimal y, decimal expected)
        //{


        //    decimal actual = TakingLoan.AddLoan(x, y);

        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8, 4, 2)]
        //public void Divide_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = TakingLoan.Divide(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8,4,4)]
        //public void Subtract_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = TakingLoan.SubtractLoan(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Fact]
        //public void Divide_DivideByZero()
        //{
        //    decimal expected = 0;
        //    decimal actual = TakingLoan.Divide(15, 0);
        //    var num1 = 1;
        //    var num2 = 0;
        //    Assert.Equal(expected, actual);
        //    var ex = Assert.Throws<DivideByZeroException>(() => TakingLoan.Divide(num1, num2));
        //    string expectedErrorMessage = "Divide by Zero Error";
        //    Assert.Equal(expectedErrorMessage, ex.Message);
        //}
        //[Theory]
        //[InlineData(8, 4, 2, 64)]
        //public void Multiply_SimpleValuesShouldCalculate(decimal x, decimal y, decimal z, decimal expected)
        //{
        //    decimal actual = TakingLoan.Multiply(x, y, z);
        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8, 4, 0)]
        //public void Modulus_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = TakingLoan.Modulus(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Fact]
        //public void Modulus_DivideByZero()
        //{
        //    decimal expected = 0;
        //    decimal actual = TakingLoan.Modulus(15, 0);
        //    var num1 = 1;
        //    var num2 = 0;
        //    Assert.Equal(expected, actual);
        //    var ex = Assert.Throws<DivideByZeroException>(() => TakingLoan.Modulus(num1, num2));
        //    string expectedErrorMessage = "Divide error";
        //    Assert.Equal(expectedErrorMessage, ex.Message);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestCalculateLoan(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    decimal amount = 1000;
        //    decimal interest = 5;
        //    int month = 2;
        //    tk.CalculateLoanAmount(amount, interest, month);
        //    mockConsoleIO.Verify(t => t.WriteLine("Enter loan application amount"), Times.Once);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void TestRepayLoanBool(bool loan_applied)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_loan_applied = loan_applied, customer_id = itemid } } });

        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.RepayLoan(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Current loan is at " + cmgt.dictionaryOfcustomers[itemid].loan_amount.ToString("F") + "\nE.g. key in 100 to repay 100 or / key in  6% to repay 6%"), Times.Once);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void TestLoanAccountBool(bool loan_applied)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_loan_applied = loan_applied, customer_id = itemid } } });

        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.LoanAccount(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Loan application : ID : " + cmgt.dictionaryOfcustomers[itemid] + " " + cmgt.dictionaryOfcustomers[itemid].customer_name), Times.Once);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void TestViewLoanAccountBool(bool loan_applied)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_loan_applied = loan_applied, customer_id = itemid } } });

        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.ViewLoan(mockCustomerManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("Current loan is at $" + cmgt.dictionaryOfcustomers[itemid].loan_amount.ToString("F")), Times.Once);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void TestAddLoanAccountBool(bool loan_applied)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    string itemid = "1";
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_loan_applied = loan_applied, customer_id = itemid } } });

        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.AddLoan(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine(itemid), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //[InlineData("4")]
        //[InlineData("5")]
        //public void TestLoanperformOperation(string input)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    TakingLoan tk1 = new TakingLoan();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    TakingLoan tk = new TakingLoan(mockConsoleIO.Object);
        //    tk.performOperation(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Taking loan here"), Times.Once);
        //}
        [Fact]
        public void TestRead()
        {
            TakingLoanController tk = new TakingLoanController();
            tk.Read();
            tk.Write();
        }
        [Theory]
        [InlineData("User")]
        public void TestViewLoan(string customer_id)
        {
            TakingLoanController tk = new TakingLoanController();
            tk.ViewLoan(customer_id);
        }
        [Fact]
        public void TestTotalLoan()
        {
            TakingLoanController tk = new TakingLoanController();
            tk.TotalLoanAmount();
        }        
        //[Theory]
        //[InlineData("User")]
        //public void TestLoanPatch(string customer_id)
        //{
        //    bool loan_applied = false;
        //    decimal loan_amount = 4000;
        //    TakingLoanController tk = new TakingLoanController();
        //    tk.Patch(customer_id, loan_applied, loan_amount);
        //}
    }
}
