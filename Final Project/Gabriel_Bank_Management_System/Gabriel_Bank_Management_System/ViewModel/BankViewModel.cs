using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI.Controllers;
using BankingWebAPI.Interfaces;
using Bank.Common.Common;
using BankingWebAPI.Models;
using System.Threading;
using BankingWebAPI.Utility;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using BankingWebAPI.EntityFramework;
using System.Data.Entity;

namespace Gabriel_Bank_Management_System.ViewModel
{
    internal class BankViewModel
    {
        CustomerAccountManagerController cam;


        private readonly HttpClient _bankClient;
        


        List<int> loginTries = new List<int>();
        Program p = new Program();

        internal BankViewModel()
        {
            _bankClient = new HttpClient();
#if DEBUG
            _bankClient.BaseAddress = new Uri("https://localhost:44360/");
#else
            _bankClient.BaseAddress = new Uri("http://mybankapi.me");
#endif

            var responseTask = _bankClient.GetAsync("api/Customer");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

            }

            cam = new CustomerAccountManagerController();

        }
        public string CheckIdNumber(string idNumber)
        {
            string output = string.Empty;
            IdResultType checkIdResult = cam.CheckId(idNumber);
            //IdResultType checkIdResult = IdResultType.UnhandledIdError;
            var responseTask = _bankClient.GetAsync("api/Authentication/checkid?idNumber=" + idNumber); // to call a web api
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IdResultType>();
                readTask.Wait();
                checkIdResult = readTask.Result;
            }
            switch (checkIdResult)
            {
                case IdResultType.None:
                    break;
                case IdResultType.DuplicateId:
                    output = "Duplicate idNumber.";
                    break;
                case IdResultType.IdIncorrect:
                    output = "Invalid ID Number";
                    break;
                case IdResultType.IdDataAccessError:
                    output = "Unable to find file.";
                    break;
                case IdResultType.UnhandledIdError:
                    output = "Unexpected Error.";
                    break;
            }
            return output;
        }

        public string CheckUserName(string userName)
        {
            string output = string.Empty;
            UserNameResultType checkUserNameResult = cam.CheckUserName(userName);
            //UserNameResultType checkUserNameResult = UserNameResultType.UnhandledUserError;
            var responseTask = _bankClient.GetAsync("api/Authentication/checkusername?username=" + userName);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<UserNameResultType>();
                readTask.Wait();
                checkUserNameResult = readTask.Result;
            }
            switch (checkUserNameResult)
            {
                case UserNameResultType.None:
                    break;
                case UserNameResultType.DuplicateUser:
                    output = "Duplicate Username.";
                    break;
                case UserNameResultType.UnhandledUserError:
                    output = "Unexpected Error.";
                    break;
                case UserNameResultType.UserNameContainsSpace:
                    output = "Please Create A Username Without Space.";
                    break;
                case UserNameResultType.UserNameDataAccessError:
                    output = "Unable to find file.";
                    break;
                case UserNameResultType.UserNameLengthIncorrect:
                    output = "Please create a username between 6 to 24 characters.";
                    break;
            }
            return output;
        }
        public bool validateEmail(string email)
        {
            bool checkEmailresult = cam.validateEmail(email);
            var responseTask = _bankClient.GetAsync("api/Authentication/checkemail?email=" + email);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkEmailresult = readTask.Result;
            }
            return checkEmailresult;
        }
        public bool validatePhone(string phone)
        {
            bool checkPhoneresult = cam.validatePhone(phone);
            var responseTask = _bankClient.GetAsync("api/Authentication/checkphonenumber?phone=" + phone);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkPhoneresult = readTask.Result;
            }
            return checkPhoneresult;
        }
        public bool validatePassword(string password)
        {
            bool checkPasswordresult = cam.validatePassword(password);
            var responseTask = _bankClient.GetAsync("api/Authentication/checkpassword?customer_pw=" + password);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkPasswordresult = readTask.Result;
            }
            return checkPasswordresult;
        }
        public BankingWebAPI.Models.Customer SignUp(string customer_id, string customer_name, string customer_address, DateTime customer_dob, string customer_email, string customer_phone, string customer_pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations");

            var new_user = new BankingWebAPI.Models.Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, account_no, 0, Guid.Empty, false, 0);
            return new_user;
        }
        public BankingWebAPI.Models.BankEmployees SignUpEmployee(string bankemployee_id, string bankemployee_name, string bankemployee_address, DateTime bankemployee_dob, string bankemployee_designation, string bankemployee_yos, string bankemployee_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new BankingWebAPI.Models.BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);
            return new_user;
        }
        public BankingWebAPI.Models.BankManagers SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new BankingWebAPI.Models.BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
            return new_user;
        }
        public bool UserLogin(CustomerAccountManagerController cam, List<int> loginTries, string customer_id, string customer_pw)
        {
            bool checkUserLoginResult = cam.UserLogin(customer_id, customer_pw);
            var responseTask = _bankClient.GetAsync("api/Authentication/login?customer_id=" + customer_id + "&customer_pw=" + customer_pw);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode && checkUserLoginResult == true)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkUserLoginResult = readTask.Result;
                return true;
            }
            return checkUserLoginResult;




            //if (cam.UserLogin(customer_id, customer_pw) == true)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool UserLogin(EmployeeAccountManagerController eam, List<int> loginTries, string bankemployee_id, string bankemployee_pw)
        {
            bool checkUserLoginResult = eam.UserLogin(bankemployee_id, bankemployee_pw);
            var responseTask = _bankClient.GetAsync("api/EmployeeAuthentication/employeelogin?bankemployee_id=" + bankemployee_id + "&bankemployee_pw=" + bankemployee_pw);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode && checkUserLoginResult == true)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkUserLoginResult = readTask.Result;
                return true;
            }
            return checkUserLoginResult;
            //if (eam.UserLogin(bankemployee_id, bankemployee_pw) == true)
            //{
            //    return true;
            //}
            //return false;
        }
        public bool UserLogin(ManagerAccountManagerController mam, List<int> loginTries, string bankmanager_id, string bankmanager_pw)
        {
            bool checkUserLoginResult = mam.UserLogin(bankmanager_id, bankmanager_pw);
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/managerlogin?bankmanager_id=" + bankmanager_id + "&bankmanager_pw=" + bankmanager_pw);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode && checkUserLoginResult == true)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                checkUserLoginResult = readTask.Result;
                return true;
            }
            return checkUserLoginResult;
            //if (mam.UserLogin(bankmanager_id, bankmanager_pw) == true)
            //{
            //    return true;
            //}
            //return false;
        }
        public void ParseInputString(string input, out int? value)
        {
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                value = null;
            }
            catch (ArgumentOutOfRangeException)
            {
                value = null;
            }
        }
        public decimal DepositLimit()
        {
            decimal maximumamount = 5000;
            return maximumamount;
        }
        public void customerDeposit(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal depositAmountKeyedInByCustomer, Customer existingCustomer)
        {


            if (depositAmountKeyedInByCustomer > DepositLimit())
            {
                var guid1 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid1; cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmountKeyedInByCustomer;

                Console.WriteLine("Amount is larger than 5000, we will process the cheque\n"); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].ToString() + "\n"); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customer_name.ToString()); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].cheque_book_number.ToString());

                using (ManagementContext bankContext = new ManagementContext())
                {
                    try
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = false;



                        bankContext.Customers.Attach(existingCustomer);
                        bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                        bankContext.SaveChanges();
                    }
                    finally
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = true;
                    }
                    Console.WriteLine("Updated cheque deposit to db");
                    Console.ReadLine();
                    bankContext.Customers.Add(existingCustomer);
                    bankContext.SaveChanges();
                    Console.WriteLine("End");
                    Console.ReadLine();


                }
                Console.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                FileManager fh = new FileManager();
                fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);


            }
            if (depositAmountKeyedInByCustomer <= DepositLimit())
            {
                Customer cust = new Customer();
                cust.deposit(depositAmountKeyedInByCustomer); cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmountKeyedInByCustomer;

                using (ManagementContext bankContext = new ManagementContext())
                {
                    try
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = false;
                        


                        bankContext.Customers.Attach(existingCustomer);
                        bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                        bankContext.SaveChanges();
                    }
                    finally
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = true;
                    }
                    Console.WriteLine("Updated deposit to db");
                    Console.ReadLine();
                    bankContext.Customers.Add(existingCustomer);
                    bankContext.SaveChanges();
                    Console.WriteLine("End");
                    Console.ReadLine();


                }
                Console.WriteLine($"Dear Customer, your deposit is: " + depositAmountKeyedInByCustomer.ToString("F") + " and current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                FileManager fh = new FileManager();
                fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);

            }
        }
        public void customerWithdrawl(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal withdrawAmountKeyedInByCustomer, Customer existingCustomer)
        {
            if (withdrawAmountKeyedInByCustomer <= 0)
            {
                Console.WriteLine("withdrawal amount should be more than 0");
            }
            else
            {
                if (cam.dictionaryOfcustomers[customer_id].customerBalance < withdrawAmountKeyedInByCustomer)
                {
                    Console.WriteLine("Your balance does not meet the requirement, insufficient funds in balance " + $"\nDear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance);
                }
                if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer <= DepositLimit())
                {
                    cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;

                    using (ManagementContext bankContext = new ManagementContext())
                    {
                        try
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = false;



                            bankContext.Customers.Attach(existingCustomer);
                            bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                            bankContext.SaveChanges();
                        }
                        finally
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = true;
                        }
                        Console.WriteLine("Updated withdrawal to db");
                        Console.ReadLine();
                        bankContext.Customers.Add(existingCustomer);
                        bankContext.SaveChanges();
                        Console.WriteLine("End");
                        Console.ReadLine();


                    }






                    Console.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer.ToString("F"));
                    Console.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                    Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                    FileManager fh = new FileManager();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);


                }
                if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer > DepositLimit())
                {

                    cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                    Console.WriteLine("Amount is larger than 5000, we will search for the cheque");

                    var guid2 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid2;

                    Console.WriteLine("{0} > {1} > {2}", cam.dictionaryOfcustomers[customer_id], cam.dictionaryOfcustomers[customer_id].customer_name, cam.dictionaryOfcustomers[customer_id].cheque_book_number);

                    using (ManagementContext bankContext = new ManagementContext())
                    {
                        try
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = false;



                            bankContext.Customers.Attach(existingCustomer);
                            bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                            bankContext.SaveChanges();
                        }
                        finally
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = true;
                        }
                        Console.WriteLine("Updated cheque withdrawal to db");
                        Console.ReadLine();
                        bankContext.Customers.Add(existingCustomer);
                        bankContext.SaveChanges();
                        Console.WriteLine("End");
                        Console.ReadLine();


                    }
                    Console.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                    Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                    FileManager fh = new FileManager();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);



                    Console.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                }
            }
        }
        public void ViewBalance(CustomerAccountManagerController cam, SavingsController sav, string customer_id)
        {
            string output = string.Empty;
            decimal viewBalanceResult = sav.ViewBalance(customer_id);
            var responseTask = _bankClient.GetAsync("api/Savings/customer/" + customer_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
                viewBalanceResult = readTask.Result;
            }       
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("Customer balance is " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
            }
            else
            {
                Console.WriteLine("Account id not found");
            }
        }
        public static decimal AddSavings(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractSaving(decimal x, decimal y)
        {
            return x - y;
        }
        public static decimal Multiply(decimal x, decimal y, decimal z)
        {
            return x * y * z;
        }
        public static decimal Divide(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }

        }
        public static decimal Modulus(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x % y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }
        }
        public void ListCustomers(CustomerAccountManagerController cam, CustomerController cust)
        {
            string output = string.Empty;
            Dictionary<string, Customer> viewAllCustomerResult = cust.GetAll();
            var responseTask = _bankClient.GetAsync("api/Customer");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Dictionary<string, Customer>>();
                readTask.Wait();
                viewAllCustomerResult = readTask.Result;
            }
            Console.WriteLine("\n Listing all current customers in database: ");
            foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            {
                Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} {kvp.Value.customer_address} {kvp.Value.customerBalance.ToString("F")} {kvp.Value.loan_amount.ToString("F")} {kvp.Value.customer_dateOfBirth}");

            }
        }
        public void RemoveCustomers(CustomerAccountManagerController cam, CustomerController cust, string customer_id)
        {
            string output = string.Empty;
            Dictionary<string, Customer> viewRemoveCustomerResult = cust.DeleteById(customer_id);
            var responseTask = _bankClient.DeleteAsync("api/Customer/Customer/DeleteById/" + customer_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Dictionary<string, Customer>>();
                readTask.Wait();
                viewRemoveCustomerResult = readTask.Result;
            }
            using (ManagementContext bankContext = new ManagementContext())
            {
                try
                {
                    bankContext.Configuration.ValidateOnSaveEnabled = false;


                    Customer existingCustomer = bankContext.Customers.Single(x => x.customer_id == customer_id);
                    //bankContext.Customers.Remove(existingCustomer);
                    //bankContext.Customers.Attach(existingCustomer);
                    bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                    bankContext.SaveChanges();
                }
                finally
                {
                    bankContext.Configuration.ValidateOnSaveEnabled = true;
                }
            }
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                

                Console.WriteLine(customer_id + " has been removed");
                cam.dictionaryOfcustomers.Remove(customer_id);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
                Console.ReadLine();
            }
        }
        public void ListEmployees(EmployeeAccountManagerController eam, BankEmployeeController bemp)
        {
            string output = string.Empty;
            Dictionary<string, BankEmployees> viewAllEmployeeResult = bemp.GetAll();
            var responseTask = _bankClient.GetAsync("api/BankEmployee");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Dictionary<string, BankEmployees>>();
                readTask.Wait();
                viewAllEmployeeResult = readTask.Result;
            }
            Console.WriteLine("\n Viewing all employees here");
            foreach (KeyValuePair<string, BankingWebAPI.Models.BankEmployees> kvp in eam.dictionaryOfEmployees)
            {
                Console.WriteLine($"{kvp.Value.bankemployee_id} {kvp.Value.bankemployee_name}");

            }

        }
        public void RemoveEmployees(EmployeeAccountManagerController eam, BankEmployeeController bemp, string bankemployee_id)
        {
            string output = string.Empty;
            Dictionary<string, BankEmployees> viewRemoveEmployeeResult = bemp.DeleteById(bankemployee_id);
            var responseTask = _bankClient.DeleteAsync("api/BankEmployee/DeleteById/" + bankemployee_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Dictionary<string, BankEmployees>>();
                readTask.Wait();
                viewRemoveEmployeeResult = readTask.Result;
            }

            if (eam.dictionaryOfEmployees.ContainsKey(bankemployee_id))
            {
                using (ManagementContext bankContext = new ManagementContext())
                {
                    try
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = false;


                        BankEmployees existingEmployee = eam.dictionaryOfEmployees.Where(x => x.Key == bankemployee_id).FirstOrDefault().Value;
                        bankContext.Employees.Attach(existingEmployee);
                        bankContext.Entry(existingEmployee).State = EntityState.Deleted;
                        bankContext.SaveChanges();
                    }
                    finally
                    {
                        bankContext.Configuration.ValidateOnSaveEnabled = true;
                    }
                }
                Console.WriteLine(bankemployee_id + " has been removed");
                eam.dictionaryOfEmployees.Remove(bankemployee_id);
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
            }
        }
        public void SearchCustomerByID(CustomerAccountManagerController cam, string customer_id)
        {
            
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("\n" + "ok found" + "\n");
                Console.WriteLine("CUSTOMER ID: " + cam.dictionaryOfcustomers[customer_id].customer_id);
                Console.WriteLine("CUSTOMER NAME: " + cam.dictionaryOfcustomers[customer_id].customer_name);
                Console.WriteLine("CUSTOMER ADDRESS: " + cam.dictionaryOfcustomers[customer_id].customer_address);
                Console.WriteLine("CUSTOMER DATEOFBIRTH: " + cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth);
                Console.WriteLine("CUSTOMER EMAIL: " + cam.dictionaryOfcustomers[customer_id].customer_email);
                Console.WriteLine("CUSTOMER PHONE: " + cam.dictionaryOfcustomers[customer_id].customer_phone);
                Console.WriteLine("CUSTOMER CHEQUE IF ANY: " + cam.dictionaryOfcustomers[customer_id].cheque_book_number);
                Console.WriteLine("CUSTOMER BALANCE: $" + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                Console.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + cam.dictionaryOfcustomers[customer_id].customer_loan_applied);
                Console.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
            }
        }
        public void SearchCustomerByName(CustomerAccountManagerController cam, string customer_name)
        {
            int permissionError = 0;
            foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            {
                if (kvp.Value.customer_name == customer_name)
                {
                    Console.WriteLine("\n" + "Search for " + customer_name + "\n");
                    Console.WriteLine($"CUSTOMER ID: {kvp.Value.customer_id}");
                    Console.WriteLine($"CUSTOMER NAME: {kvp.Value.customer_name}");
                    Console.WriteLine($"CUSTOMER ADDRESS: {kvp.Value.customer_address}");
                    Console.WriteLine($"CUSTOMER DATEOFBIRTH: {kvp.Value.customer_dateOfBirth}");
                    Console.WriteLine($"CUSTOMER EMAIL: {kvp.Value.customer_email}");
                    Console.WriteLine($"CUSTOMER PHONE: {kvp.Value.customer_phone}");
                    Console.WriteLine($"CUSTOMER CHEQUE IF ANY: {kvp.Value.cheque_book_number}");
                    Console.WriteLine($"CUSTOMER BALANCE: ${kvp.Value.customerBalance.ToString("F")}");
                    Console.WriteLine($"CUSTOMER LOAN APPLIED IF ANY: {kvp.Value.customer_loan_applied}");
                    Console.WriteLine($"CUSTOMER LOAN AMOUNT IF ANY: {kvp.Value.loan_amount.ToString("F")}\n");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    permissionError = 1;

                }
            }
            if (permissionError == 1)
            {
                Console.WriteLine("Account doesn't exist");
            }
        }
        public decimal TotalLoanAmount(CustomerAccountManagerController cam, TakingLoanController tk)
        {
            string output = string.Empty;
            decimal viewTotalLoanAmountResult = tk.TotalLoanAmount();
            var responseTask = _bankClient.GetAsync("api/TakingLoan");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
                viewTotalLoanAmountResult = readTask.Result;
            }
            foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            {
                Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} Loan amt: {kvp.Value.loan_amount.ToString("F")}");

            }
            var totalloanamount = cam.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            Console.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F"));
            return totalloanamount;

        }
        public decimal TotalSavingsAccount(CustomerAccountManagerController cam, SavingsController sav)
        {
            string output = string.Empty;
            decimal viewTotalSavingsAmountResult = sav.TotalSavingsAmount();
            var responseTask = _bankClient.GetAsync("api/Savings");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
                viewTotalSavingsAmountResult = readTask.Result;
            }
            foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            {
                Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} Customer balance: {kvp.Value.customerBalance.ToString("F")}");

            }
            var totalsavingsofCustomers = cam.dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            Console.WriteLine("Total savings of the bank " + totalsavingsofCustomers.ToString("F"));
            return totalsavingsofCustomers;
        }
        public void ViewManagers(ManagerAccountManagerController mam)
        {
            Console.WriteLine("\n Viewing all managers here");
            foreach (KeyValuePair<string, BankingWebAPI.Models.BankManagers> kvp in mam.dictionaryOfManagers)
            {
                Console.WriteLine($"{kvp.Value.bankmanager_id} {kvp.Value.bankmanager_name}");

            }
        }
        public void LoanAccount(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal loanamount, decimal monthsIn, decimal interestamount)
        {
            // principal loan amount * interest rate * number of years in term = total interest paid
            var months = Divide(monthsIn, 12);

            var interests = Divide(interestamount, 100);

            decimal totalloanamount = AddLoan(loanamount, Multiply(loanamount, interests, months));
            cam.dictionaryOfcustomers[customer_id].customer_loan_applied = true; cam.dictionaryOfcustomers[customer_id].loan_amount = totalloanamount;
            using (ManagementContext bankContext = new ManagementContext())
            {
                Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                try
                {
                    bankContext.Configuration.ValidateOnSaveEnabled = false;



                    bankContext.Customers.Attach(existingCustomer);
                    bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                    bankContext.SaveChanges();
                }
                finally
                {
                    bankContext.Configuration.ValidateOnSaveEnabled = true;
                }
                Console.WriteLine("Updated loan approval to db");
                Console.ReadLine();
                bankContext.Customers.Add(existingCustomer);
                bankContext.SaveChanges();
                Console.WriteLine("End");
                Console.ReadLine();


            }

            Console.WriteLine("Total loan calculated after interest\n" + totalloanamount.ToString("F") + "\nChecking for approval....\nLoan of: $" + totalloanamount.ToString("F") + " will repay in" + monthsIn + " installments or $" + (totalloanamount / monthsIn).ToString("F") + " monthly");
            //decimal totalloanamount = CalculateLoanAmount(0, 0, 0);
            Console.WriteLine("Loan application : ID : " + cam.dictionaryOfcustomers[customer_id] + " " + cam.dictionaryOfcustomers[customer_id].customer_name);

            
            FileManager fh = new FileManager(); fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
        }

        public void ViewLoan(CustomerAccountManagerController cam, TakingLoanController tk, string customer_id)
        {
            string output = string.Empty;
            decimal viewLoanResult = tk.ViewLoan(customer_id);
            var responseTask = _bankClient.GetAsync("api/TakingLoan/customer/" + customer_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
                viewLoanResult = readTask.Result;
            }
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cam.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    Console.WriteLine("Current loan is at $" + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                }
                else
                {
                    Console.WriteLine("Current loan is at $0");
                }

            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }
        }
        public void RepayLoan(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, string repayLoan)
        {


            if (repayLoan.Contains("%") == true)
            {
                var charsToRemove = new string[] { "%" };
                foreach (var c in charsToRemove)
                {
                    repayLoan = repayLoan.Replace(c, string.Empty);
                }
                decimal repayLoanParse = decimal.Parse(repayLoan);
                decimal amountToRepay = Multiply(repayLoanParse, Divide(cam.dictionaryOfcustomers[customer_id].loan_amount, 100), 1);
                Console.WriteLine("Amount to repay is: $" + amountToRepay.ToString("F"));
                decimal remainingLoanLeft = SubtractLoan(cam.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);
                if (amountToRepay > cam.dictionaryOfcustomers[customer_id].loan_amount)
                {
                    Console.WriteLine("Exceed loan repayment, key again");
                }
                else
                {


                    Console.WriteLine("Loan amount left: $" + remainingLoanLeft.ToString("F"));
                    cam.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;

                    using (ManagementContext bankContext = new ManagementContext())
                    {
                        Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                        try
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = false;



                            bankContext.Customers.Attach(existingCustomer);
                            bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                            bankContext.SaveChanges();
                        }
                        finally
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = true;
                        }
                        Console.WriteLine("Updated loan repayment to db");
                        Console.ReadLine();
                        bankContext.Customers.Add(existingCustomer);
                        bankContext.SaveChanges();
                        Console.WriteLine("End");
                        Console.ReadLine();


                    }
                    if (remainingLoanLeft == 0)
                    {
                        cam.dictionaryOfcustomers[customer_id].customer_loan_applied = false;
                        using (ManagementContext bankContext = new ManagementContext())
                        {
                            Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                            try
                            {
                                bankContext.Configuration.ValidateOnSaveEnabled = false;



                                bankContext.Customers.Attach(existingCustomer);
                                bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                                bankContext.SaveChanges();
                            }
                            finally
                            {
                                bankContext.Configuration.ValidateOnSaveEnabled = true;
                            }
                            Console.WriteLine("Updated loan fully repaid to db");
                            Console.ReadLine();
                            bankContext.Customers.Add(existingCustomer);
                            bankContext.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.ReadLine();


                        }

                    }
                    FileManager fh1 = new FileManager();
                    fh1.ReadingandWritingcustomer(customer_id, cam, eam, mam);

                }
            }
            else
            {
                decimal amountToRepay = decimal.Parse(repayLoan);
                Console.WriteLine("Amount to repay is: $" + amountToRepay);
                decimal remainingLoanLeft = SubtractLoan(cam.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);

                
                if (amountToRepay > cam.dictionaryOfcustomers[customer_id].loan_amount)
                {
                    Console.WriteLine("Exceed loan repayment, key again");
                }
                else
                {
                    Console.WriteLine("Loan amount left: $" + remainingLoanLeft);
                    cam.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;

                    using (ManagementContext bankContext = new ManagementContext())
                    {
                        Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                        try
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = false;



                            bankContext.Customers.Attach(existingCustomer);
                            bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                            bankContext.SaveChanges();
                        }
                        finally
                        {
                            bankContext.Configuration.ValidateOnSaveEnabled = true;
                        }
                        Console.WriteLine("Updated loan repayment to db");
                        Console.ReadLine();
                        bankContext.Customers.Add(existingCustomer);
                        bankContext.SaveChanges();
                        Console.WriteLine("End");
                        Console.ReadLine();


                    }
                    if (remainingLoanLeft == 0)
                    {
                        cam.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                        using (ManagementContext bankContext = new ManagementContext())
                        {
                            Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                            try
                            {
                                bankContext.Configuration.ValidateOnSaveEnabled = false;



                                bankContext.Customers.Attach(existingCustomer);
                                bankContext.Entry(existingCustomer).State = EntityState.Deleted;
                                bankContext.SaveChanges();
                            }
                            finally
                            {
                                bankContext.Configuration.ValidateOnSaveEnabled = true;
                            }
                            Console.WriteLine("Updated loan fully repaid to db");
                            Console.ReadLine();
                            bankContext.Customers.Add(existingCustomer);
                            bankContext.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.ReadLine();


                        }

                    }
                    FileManager fh1 = new FileManager();
                    fh1.ReadingandWritingcustomer(customer_id, cam, eam, mam);

                }

            }

        }
        public static decimal AddLoan(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractLoan(decimal x, decimal y)
        {
            return x - y;
        }
        public void CustomerAdd(CustomerAccountManagerController cam, CustomerController cust, string id, Customer new_user)
        {
            var checkUserresult = cust.CustomerAddNew(cam, new_user);
            //var json = JsonConvert.SerializeObject(new_user);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            
            
            //var responseTask = _bankClient.PostAsync("api/Customer/Test/Add", stringContent);
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<Dictionary<string, Customer>>();
            //    readTask.Wait();
            //    checkPhoneresult = readTask.Result;
            //}
            //return checkUserresult;
        }
        public Dictionary<string, BankEmployees> EmployeeAdd(EmployeeAccountManagerController eam, BankEmployeeController emp, string id, BankEmployees new_user)
        {
            Dictionary<string, BankEmployees> checkUserresult = emp.EmployeeAddNew(eam, new_user);
            return checkUserresult;
        }
        public Dictionary<string, BankManagers> ManagerAdd(ManagerAccountManagerController mam, string id, BankManagers new_user)
        {
            Dictionary<string, BankManagers> checkUserresult = mam.ManagerAddNew(mam, new_user);
            return checkUserresult;
        }

    }
}
