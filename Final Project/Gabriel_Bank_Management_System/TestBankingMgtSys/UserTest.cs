using System;
using Xunit;
using Gabriel_Bank_Management_System;
using Moq;
using System.Text.RegularExpressions;
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
using System.Threading.Tasks;
using System.Net.Http;
using BankingWebAPI.EntityFramework;
using System.Web.Http;

namespace UserTest
{
    public class UserTest
    {
        //Program _p;
        //public UserTest()
        //{
        //    _p = new Program();
        //}
        //[Fact]
        //public void TestCreateAccount()
        //{
        //    CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
        //    var customer_id = "1";
        //    var customer_name = "john";
        //    var customer_address = "23 hillview";


        //    var customer_dob = DateTime.Now;
        //    var customer_phone = "(222)333-4444";
        //    var customer_email = "something@mail.com";
        //    var mockConsoleIO = new Mock<IConsoleIO>();

        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_id);
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_name);
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_address);
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_dob.ToString());
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_phone);
        //    mockConsoleIO.Setup(t => t.ReadLine()).Returns(customer_email);
        //    CustomerAccountManagerController newuser = new CustomerAccountManagerController();
        //    newuser.validatePhone(customer_phone);
        //    newuser.validateEmail(customer_email);
        //    var user = new CustomerAccountManagerController(mockConsoleIO.Object);
        //    CustomerAccountManagerController.AddUser(cmgt);
        //}
        [Theory]
        [InlineData("123456")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestUserLoginAccount(string customerid)
        {
            string customer_pw = "Hello12345678$";
            CustomerAccountManagerController cmgt = new CustomerAccountManagerController();
            var mockConsoleIO = new Mock<IConsoleIO>();
            mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(customerid);

            var mockCustomerManagement = new Mock<CustomerAccountManagerController>();

            mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { customerid, new Customer() { customer_id = customerid } } });
            
            CustomerAccountManagerController usr = new CustomerAccountManagerController(mockConsoleIO.Object);
            //usr.UserLogin(mockCustomerManagement.Object);
            usr.UserLogin(customerid, customer_pw);

            mockConsoleIO.Verify(t => t.WriteLine($"Congratulations, {cmgt.dictionaryOfcustomers[customerid].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { cmgt.dictionaryOfcustomers[customerid].customer_id} { cmgt.dictionaryOfcustomers[customerid].customer_name}"), Times.Once);
        }
        [Theory]
        [InlineData("123456")]
        [InlineData("abcd")]
        [InlineData("12345")]
        public void TestCustomerAccount(string customerid)
        {
            Assert.NotNull(customerid);
            CustomerController cmgt = new CustomerController();
        }
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestUserLoginAccountNotExist(string itemid)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
        //    List<int> loginTries = new List<int>();
        //    CustomerAccountManager usr = new CustomerAccountManager(mockConsoleIO.Object);
        //    usr.UserLogin(mockCustomerManagement.Object, loginTries);

        //    mockConsoleIO.Verify(t => t.WriteLine("Incorrect user or pw"), Times.Once);


        //}
        //[Fact]
        //public void TestCreateUserLoginText()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();

        //    var output = new StringWriter();
        //    Console.SetOut(output);
        //    List<int> loginTries = new List<int>();
        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    CustomerAccountManager user = new CustomerAccountManager();
        //    user.UserLogin(cmgt, loginTries);
        //    int numberofTries = 4;
        //    Assert.Equal(output.ToString(), string.Format("Enter login id " + " (" + "number of tries left " + numberofTries + " )"));

        //}
        //[Fact]
        //public void TestCreateEmployeeText()
        //{
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    EmployeeAccountManager emp = new EmployeeAccountManager();
        //    emp.CreateUserAccount();
        //    Assert.Equal(output.ToString(), string.Format("Key in employee id"));

        //}
        //[Fact]
        //public void TestCreateEmployeeUserLoginText()
        //{

        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    EmployeeAccountManager emp1 = new EmployeeAccountManager();
        //    emp1.UserLogin(bemgt);
        //    int numberofTries = 4;
        //    Assert.Equal(output.ToString(), string.Format("Enter login id " + " (" + "number of tries left " + numberofTries + " )"));

        //}
        //[Fact]
        //public void TestCreateManagerUserLoginText()
        //{


        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    ManagerAccountManager emp1 = new ManagerAccountManager();
        //    BankManagersManager bmgt = new BankManagersManager();
        //    emp1.UserLogin(emp1);
        //    int numberofTries = 4;
        //    Assert.Equal(output.ToString(), string.Format("Enter login id " + " (" + "number of tries left " + numberofTries + " )"));

        //}
        //[Fact]
        //public void TestCreateBankManagerText()
        //{
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    ManagerAccountManager emp = new ManagerAccountManager();
        //    emp.CreateUserAccount();
        //    Assert.Equal(output.ToString(), string.Format("Key in manager id"));

        //}
        //[Fact]
        //public void TestCreateUserText()
        //{
        //    var output = new StringWriter();
        //    Console.SetOut(output);

        //    var input = new StringReader("12345");
        //    Console.SetIn(input);
        //    CustomerAccountManager emp = new CustomerAccountManager();
        //    emp.CreateUserAccount();


        //}




        //}

        //[Fact]
        //public void TestDeleteAccount()
        //{
        //    string customer_id = "1";
        //    Dictionary<string, Customer> mockdictionaryOfcustomers = new Dictionary<string, Customer>();
        //    Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
        //    Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);
        //    mockdictionaryOfcustomers.Add(customer_id, cust);
        //    mockdictionaryOfcustomers.Add("2", cust2);
        //    Assert.True(mockdictionaryOfcustomers.Count == 2);
        //    mockdictionaryOfcustomers.Add("3", cust2);

        //    Assert.True(mockdictionaryOfcustomers.ContainsKey("1"));
        //    mockdictionaryOfcustomers.Remove(customer_id);
        //    Assert.Null(mockdictionaryOfcustomers);
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //}


            //}
            //[Theory]
            //[InlineData("1")]
            //[InlineData("abcd")]
            //[InlineData("12345")]
            //public void TestDeleteCustomerAccount(string itemid)
            //{
            //    var mockConsoleIO = new Mock<IConsoleIO>();                       
            //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
            //    var mockCustomerManagement = new Mock<CustomerAccountManager>();            
            //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });
            //    CustomersManager cmgt = new CustomersManager(mockConsoleIO.Object);
            //    cmgt.RemoveCustomers(mockCustomerManagement.Object);
            //    mockConsoleIO.Verify(t => t.WriteLine(itemid + " has been removed"), Times.Once);
            //}
            //[Theory]
            //[InlineData("1")]
            //[InlineData("abcd")]
            //[InlineData("12345")]
            //public void TestNotExistDeleteCustomerAccount(string itemid)
            //{
            //    var mockConsoleIO = new Mock<IConsoleIO>();
            //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);
            //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
            //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());
            //    CustomersManager cmgt = new CustomersManager(mockConsoleIO.Object);
            //    cmgt.RemoveCustomers(mockCustomerManagement.Object);
            //    mockConsoleIO.Verify(t => t.WriteLine("Account doesn't exist"), Times.Once);
            //}
            ////[Fact]
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
                bool res = validatepw.validatePassword(customer_pw);
                Assert.True(res);


            }
            ////[Fact]
            [Theory]
            [InlineData("jj")]
            [InlineData("123")]
            [InlineData("loeo")]
            [InlineData("jjjjjjjjj")]
            public void TestvallidatepwIsFalse(string customer_pw)
            {
                Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
                validate.Setup(t => t.validatePassword(customer_pw));
                CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
                bool res = validatepw.validatePassword(customer_pw);
                Assert.False(res);
            }
            ////[Fact]
            [Theory]
            [InlineData("something@gmail.com")]
            [InlineData("john@mail.com")]
            [InlineData("mary@mail.com")]
            [InlineData("george@something.com")]
            public void TestvallidateEmailIsTrue(string email)
            {
                Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
                validate.Setup(t => t.validateEmail(email));
                CustomerAccountManagerController validatemail = new CustomerAccountManagerController();
                bool res = validatemail.validateEmail(email);
                Assert.True(res);
            }
            //[Fact]
            [Theory]
            [InlineData("something")]
            public void TestvallidateEmailIsFalse(string email)
            {
                Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
                validate.Setup(t => t.validateEmail(email));
                CustomerAccountManagerController validatemail = new CustomerAccountManagerController();
                bool res = validatemail.validateEmail(email);
                Assert.False(res);
                //CustomerAccountManagerController validatemail = new CustomerAccountManagerController();



                //Assert.Throws<EmailIncorrectException>(() => validatemail.validateEmail(""));
            }
            ////[Fact]
            [Theory]
            [InlineData("(222)111-4444")]
            [InlineData("(222)111-4445")]
            [InlineData("(222)111-4446")]
            [InlineData("(222)111-4447")]
            public void TestvallidatePhoneIsTrue(string phone)
            {            
                Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
                validate.Setup(t => t.validatePhone(phone));
                CustomerAccountManagerController validatephone = new CustomerAccountManagerController();
                bool res = validatephone.validatePhone(phone);
                Assert.True(res);
                Regex rgx = new Regex("[^A-Za-z0-9]");
            }
            ////[Fact]
            [Theory]
            [InlineData("222")]
            [InlineData("333")]
            [InlineData("444")]
            [InlineData("555")]
            public void TestvallidatePhoneIsFalse(string phone)
            {
                Mock<ICustomerAccountManager> validate = new Mock<ICustomerAccountManager>();
                validate.Setup(t => t.validatePhone(phone));
                CustomerAccountManagerController validatephone = new CustomerAccountManagerController();
                bool res = validatephone.validatePhone(phone);
                Assert.False(res);

                //Assert.Throws< PhoneIncorrectException> (() => validatephone.validatePhone(""));

                //Action testCode = () => { throw new PhoneIncorrectException(phone); };

                //var ex = Record.Exception(testCode);
                //Assert.NotNull(ex);
                //Assert.IsType<PhoneIncorrectException>(ex);
            }


            //}
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
            public void TestCustomerAddNew()
            {
                CustomerController cust = new CustomerController();
                CustomerAccountManagerController cam = new CustomerAccountManagerController();
                var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
                cust.CustomerAddNew(cam, new_user);
            }
            [Fact]
            public void TestCustomerUpdatedName()
            {
                CustomerController cust = new CustomerController();
                var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
                cust.updateName(new_user);
            }
            [Fact]
            public void TestCustomerPut()
            {
                CustomerController cust = new CustomerController();
                var new_user = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0, Guid.Empty, false, 100);
                cust.PUT(new_user);
            }
            [Fact]
            public void TestCustomerDelete()
            {
                Customer cust1 = new Customer();
                CustomerController cust = new CustomerController();
                cust.Delete(cust1);
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
                fileHandling.ReadingandWritingcustomer(new_user.customer_id, cmgt, bemgt, bmgt);
                fileHandling.ReadingandWritingEmployee(new_user2.bankemployee_id, cmgt, bemgt, bmgt);
                fileHandling.ReadingandWritingManager(new_user3.bankmanager_id, cmgt, bemgt, bmgt);
                fileHandling.JsonListofAllCustomers(new_user.customer_id, cmgt, bemgt, bmgt);
            }
            //[Fact]
            //public void FileHandlingTest()
            //{

            //    var mockConsoleIO = new Mock<IConsoleIO>();

            //    if (File.Exists("ID 12345 john.txt"))
            //    {

            //    }
            //    var mockRepo = new Mock<IFileManager>();

            //    FileManager user = new FileManager(mockConsoleIO.Object);
            //    string text = "ID 12345 john.txt";
            //    FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
            //    StreamWriter streamWriter = new StreamWriter(fs);

            //    FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
            //    StreamReader sr1 = new StreamReader(fs2);
            //    Dictionary<string, BankEmployees> mockdictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            //    BankEmployees emp = new BankEmployees();
            //    BankEmployees emp2 = new BankEmployees("1", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678");
            //    mockdictionaryOfEmployees.Add("1", emp);



            //}
            //[Fact]
            //public void ProgramTest()
            //{
            //    var mockConsoleIO = new Mock<IConsoleIO>();
            //    var greeter = new Program(mockConsoleIO.Object);


            //    Program p = new Program();
            //    p.Initialize();

            //}
            [Fact]
            public void testConsoleIO()
            {
                string message = "hello";
                ConsoleIO cs = new ConsoleIO();

                cs.WriteLine(message);
                
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
        //[Fact]
        //public void testAddEmployee()
        //{



        //}
        //[Fact]
        //public void testRemoveEmployee()
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    BankEmployeesManager bemgt1 = new BankEmployeesManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    bemgt1.AddBankEmployees(cmgt, bemgt, bmgt);



        //}
        //[Fact]
        //public void testAddManager()
        //{
        //    CustomersManager cmgt1 = new CustomersManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    BankEmployeesManager bemgt1 = new BankEmployeesManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    BankManagersManager bmgt1 = new BankManagersManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    bmgt1.AddBankManagers(cmgt, bemgt, bmgt);
        //    cmgt1.ListCustomers(cmgt);

        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void AddCustomers(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    CustomersManager cmgt = new CustomersManager(mockConsoleIO.Object);

        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });


        //    cmgt.AddCustomer(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("Account already exists"), Times.Once);
        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void AddCustomersNotExist(string itemid)
        //{
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    CustomersManager cmgt = new CustomersManager(mockConsoleIO.Object);

        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(itemid);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();

        //    mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>());


        //    cmgt.AddCustomer(mockCustomerManagement.Object, bemgt, bmgt);

        //    mockConsoleIO.Verify(t => t.WriteLine("User creation failed try again"), Times.Once);


        //}
        //[Fact]
        //public void CheckUserNotNull()
        //{


        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("abcd")]
        //[InlineData("12345")]
        //public void TestViewAllCustomers(string name)
        //{
        //    CustomersManager cmgt = new CustomersManager();
        //    string itemid = "1";
        //    string address = "23 road";
        //    DateTime dateofBirth = DateTime.Now;
        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    //mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(name);
        //    mockConsoleIO.SetupSequence(t => t.ReadLine());
        //    var mockCustomersManagement = new Mock<CustomerAccountManager>();

        //    mockCustomersManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    CustomersManager cmgt1 = new CustomersManager(mockConsoleIO.Object);
        //    cmgt1.ListCustomers(mockCustomersManagement.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine($"{itemid} {name} {address} {dateofBirth} " + "\n Listing all current customers in database: "), Times.Once);
        //}
        //[Fact]
        //public void IfInputMoreThan()
        //{
        //    CustomersManager cmgt1 = new CustomersManager();
        //    List<int> loginTries = new List<int>();
        //    Mock<ICustomerAccountManager> input = new Mock<ICustomerAccountManager>();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    cmgt.UserLogin(cmgt, loginTries);
        //    loginTries.Add(1);

        //    Assert.True(loginTries.Count > 3);

        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //[InlineData("4")]
        //public void TestLCustomerperformOperation(string input)
        //{
        //    List<int> loginTries = new List<int>();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);



        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    CustomersManager cmgt1 = new CustomersManager(mockConsoleIO.Object);
        //    cmgt1.PerformOperation(cmgt, bemgt, bmgt, loginTries);

        //    mockConsoleIO.Verify(t => t.WriteLine("Screen 1 -- customers only" + "\n1. Create User" + "\n2: Remove User" + "\nSeek help from bank operator" + "\n3: Ask user to log in" + "\n4: Return to home screen"), Times.Once);
        //}
        //[Theory]
        //[InlineData(null)]
        //public void TestAddCustomers(WebApiLibrary.Models.Customer new_user)
        //{
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    //Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);
        //    Mock<ICustomerAccountManager> user = new Mock<ICustomerAccountManager>();
        //    user.Setup(t => t.CreateUserAccount()).Returns(new_user);
        //    CustomersManager cmgt1 = new CustomersManager(user.Object);
        //    bool res = cmgt1.AddCustomer(cmgt, bemgt, bmgt);
        //    Assert.True(res);

        //}
        //[Theory]
        //[InlineData(null)]
        //public void TestAddEmployees(WebApiLibrary.Models.BankEmployees new_user)
        //{
        //    Mock<IEmployeeAccountManager> user = new Mock<IEmployeeAccountManager>();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    //Customer cust2 = new Customer("2", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "123", 0);

        //    user.Setup(t => t.CreateUserAccount()).Returns(new_user);
        //    BankEmployeesManager cmgt1 = new BankEmployeesManager(user.Object);
        //    bool res = cmgt1.AddBankEmployees(cmgt, bemgt, bmgt);
        //    Assert.True(res);

        //}
        //[Theory]
        //[InlineData("1")]
        //[InlineData("2")]
        //[InlineData("3")]
        //[InlineData("4")]
        //public void TestprogramperformOperation(string input)
        //{
        //    BankManagersManager bmgt1 = new BankManagersManager();
        //    ManagerAccountManager bmgt = new ManagerAccountManager();
        //    BankEmployeesManager bemgt1 = new BankEmployeesManager();
        //    EmployeeAccountManager bemgt = new EmployeeAccountManager();
        //    CustomersManager cmgt1 = new CustomersManager();
        //    CustomerAccountManager cmgt = new CustomerAccountManager();
        //    Program p = new Program();
        //    List<int> loginTries = new List<int>();

        //    var mockConsoleIO = new Mock<IConsoleIO>();
        //    mockConsoleIO.SetupSequence(t => t.ReadLine()).Returns(input);

        //    var mockCustomerManagement = new Mock<CustomerAccountManager>();
        //    var mockProgram = new Mock<Program>();
        //    //mockCustomerManagement.Setup(x => x.dictionaryOfcustomers).Returns(new Dictionary<string, Customer>() { { itemid, new Customer() { customer_id = itemid } } });

        //    Program tk = new Program(mockConsoleIO.Object);
        //    tk.performOperation(mockCustomerManagement.Object, cmgt1, bemgt, bemgt1, bmgt, bmgt1, loginTries, mockProgram.Object);

        //    mockConsoleIO.Verify(t => t.WriteLine("Starting Program.."), Times.Once);
    }


        
}
