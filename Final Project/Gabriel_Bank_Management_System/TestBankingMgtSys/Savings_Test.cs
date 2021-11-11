using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Collections.Generic;
using System.IO;
using WebApiLibrary.Interfaces;

namespace TakingLoan_Test
{
    public class Savings_Test
    {
        //[Fact]
        //public void Test1()
        //{

        //}
        //Program _p;
        //public Savings_Test()
        //{
        //    _p = new Program();
        //}

        ////[Fact]
        //[Fact]

        //public void TestCustomerDeposit()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
            
            
        //    decimal expected = 5;
        //    Customer cust = new Customer();
            
        //    cust.customerBalance = 0;
        //    cust.deposit(5);
        //    cust.customerBalance = 5;
        //    Assert.Equal(expected, cust.customerBalance);

        //    string customer_id = "12345";
        //    var guid1 = Guid.NewGuid();
        //    string text1 = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
        //    FileStream fs1 = new FileStream(text1, FileMode.Append, FileAccess.Write);
        //    StreamWriter streamWriter1 = new StreamWriter(fs1);

            
        //    streamWriter1.WriteLine($"Dear Customer, cheque number issued is: " + customer_id + "," + cmgt.dictionaryOfcustomers[customer_id].customer_name + ", have issued cheque " + guid1);
        //    streamWriter1.WriteLine($"Dear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", cmgt.dictionaryOfcustomers[customer_id], cmgt.dictionaryOfcustomers[customer_id].customer_name, cmgt.dictionaryOfcustomers[customer_id].cheque_book_number);
        //    streamWriter1.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
        //    streamWriter1.Flush();
        //    streamWriter1.Close();
        //    fs1.Close();



        //}
        //[Fact]

        //public void Test_Adding_negative_funds()
        //{
        //    Customer cust = new Customer();
            
        //    cust.customerBalance = 1000;
        //    var account = new Customer();
        //    account.deposit(1000);

        //    Assert.Throws<ArgumentOutOfRangeException>(() => account.deposit(-1000));
        //}
        //[Fact]

        //public void Test_Withdraw_negative_funds()
        //{
        //    Customer cust = new Customer();

        //    cust.customerBalance = 1000;
        //    var account = new Customer();
            

        //    Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(-1000));
        //}
        //[Fact]

        //public void Test_Withdraw_More_Than_funds()
        //{
        //    Customer cust = new Customer();

        //    cust.customerBalance = 1000;
        //    var account = new Customer();
            

        //    Assert.Throws<ArgumentOutOfRangeException>(() => account.withdraw(2000));
        //}
        //[Fact]
        //public void TestCustomerWithdrawl()
        //{
            
        //    decimal expected = 5;
        //    Customer cust = new Customer();

        //    cust.customerBalance = 10;
        //    cust.withdraw(5);
        //    cust.customerBalance = 5;
        //    Assert.Equal(expected, cust.customerBalance);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestViewBalance(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
            
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Savings save = new Savings(mockConsoleIO.Object);
        //    save.ViewBalance(mockCustomerManagement.Object);
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    Savings saving = new Savings();
            
            
        //    Assert.Equal(output.ToString(), string.Format("Key in customer id"));

            

            
            

        //    mockConsoleIO.Verify(t => t.WriteLine("Customer balance is " + cmgt.dictionaryOfcustomers[itemid].customerBalance), Times.Once);





        //}
        //[Fact]
        //public void TestperformOperation()
        //{
        //    //Savings savingtest = new Savings();
        //    //savingtest.performOperation();
        //    //string customer_id = "555";
        //    //Assert.True(CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id));
        //}
        //[Fact]
        //public void TestSavingdepositText()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    Savings saving = new Savings();
        //    saving.customerDeposit(cmgt, bemgt, bmgt);
            
        //    Assert.Equal(output.ToString(), string.Format("Key in customer id\r\nAccount id not found\r\n"));


        //    //var message = "The file or directory is not supported";
        //    //var parser = new Savings();
        //    //Assert.Throws<NotSupportedException>(() => parser.customerDeposit());
        //}
        //[Fact]
        //public void TestSavingwithdrawText()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    Savings saving = new Savings();
        //    saving.customerWithdrawl(cmgt, bemgt, bmgt);
            
        //    Assert.Equal(output.ToString(), string.Format("Key in customer id\r\nAccount id not found\r\n"));
        //}

        //[Fact]
        //public void Add_SimpleValuesShouldCalculate()
        //{
        //    decimal expected = 5;

        //    decimal actual = Savings.AddSavings(3, 2);

        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(4, 3, 7)]
        //[InlineData(21, 5.25, 26.25)]
        //public void Add_SimpleValuesShouldCalculate1(decimal x, decimal y, decimal expected)
        //{


        //    decimal actual = Savings.AddSavings(x, y);

        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8, 4, 2)]
        //public void Divide_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = Savings.Divide(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8, 4, 4)]
        //public void Subtract_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = Savings.SubtractSaving(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Fact]
        //public void Divide_DivideByZero()
        //{
        //    decimal expected = 0;
        //    decimal actual = Savings.Divide(15, 0);
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
        //    decimal actual = Savings.Multiply(x, y, z);
        //    Assert.Equal(expected, actual);
        //}
        //[Theory]
        //[InlineData(8, 4, 0)]
        //public void Modulus_SimpleValuesShouldCalculate(decimal x, decimal y, decimal expected)
        //{
        //    decimal actual = Savings.Modulus(x, y);
        //    Assert.Equal(expected, actual);
        //}
        //[Fact]
        //public void Modulus_DivideByZero()
        //{
            
            
        //    var num1 = 1;
        //    var num2 = 0;
            
        //    var ex = Assert.Throws<DivideByZeroException>(() => Savings.Modulus(num1, num2));
        //    string expectedErrorMessage = "Divide error";
        //    Assert.Equal(expectedErrorMessage, ex.Message);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestCustomerDeposits(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Savings save = new Savings(mockConsoleIO.Object);
        //    save.customerDeposit(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Key in amount for deposit - we will use cheque if more than 5k"), Times.Once);

        //    decimal firstValue = 6000;
        //    decimal secondValue = 5000;
        //    Assert.True(firstValue > secondValue);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestCustomerDepositsNotExists(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

        //    Savings save = new Savings(mockConsoleIO.Object);
        //    save.customerDeposit(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Account id not found"), Times.Once);

            
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestCustomerWithdrawal(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Savings save = new Savings(mockConsoleIO.Object);
        //    save.customerWithdrawl(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal"), Times.Once);

            
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestCustomerWithdrawalNotExists(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());

        //    Savings save = new Savings(mockConsoleIO.Object);
        //    save.customerWithdrawl(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Account id not found"), Times.Once);


        //}
        //[Theory]
        //[InlineData(5000)]
        //[InlineData(500)]
        //public void TestCustomerDepositLimit(decimal withdrawalamount)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
            
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(withdrawalamount.ToString());

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Savings tk = new Savings(mockConsoleIO.Object);
        //    tk.customerDeposit(mockCustomerManagement.Object, bemgt, bmgt);

            
        //}
        //[Theory]
        //[InlineData(6000)]
        //public void TestDepositLimit(decimal deposit)
        //{
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(deposit.ToString());

        //    var mockCustomerManagement = new Mock<CustomersManager>();
            
        //    Savings tk = new Savings();
        //    tk.DepositLimit();
        //    Assert.True(deposit > tk.DepositLimit());
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //[InlineData("4")]
        //public void TestSavingsperformOperation(string input)
        //{
        //    Savings save = new Savings();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Savings tk = new Savings(mockConsoleIO.Object);
        //    tk.performOperation(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("In Savings account, key in operation" + "\n1: withdraw money" + "\n2: deposit money" + "\n3: view the balance" + "\n4: Exit savings operation"), Times.Once);
        //}
        //[Theory]
        //[InlineData(2000)]
        //public void TestTakeDepositInput(decimal str)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    Mock<ISavings> input = new Mock<ISavings>();
        //    input.Setup(t => t.TakeDepositInput()).Returns(str);

        //}
        //[Theory]
        //[InlineData(6000)]
        //public void TestTakeDepositInputIsMore(decimal str)
        //{
        //    decimal depositAmount = 6000;
        //    CustomersManager cmgt = new CustomersManager();
        //    Mock<ISavings> input = new Mock<ISavings>();
        //    input.Setup(t => t.TakeDepositInput()).Returns(str);
        //    Mock<ISavings> input2 = new Mock<ISavings>();
        //    input2.Setup(t => t.DepositLimit()).Returns(depositAmount);
            

        //    Assert.True(str > depositAmount);

        //}
    }
}
