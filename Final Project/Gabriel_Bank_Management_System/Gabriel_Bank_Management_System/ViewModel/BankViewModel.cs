using Bank.Common.Common;
using Gabriel_Bank_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gabriel_Bank_Management_System.ViewModel
{
    internal class BankViewModel : IBankViewModel
    {
        private readonly HttpClient _bankClient;
        internal BankViewModel()
        {
            _bankClient = new HttpClient();
#if DEBUG
            _bankClient.BaseAddress = new Uri("https://localhost:44360/");
#else
            _bankClient.BaseAddress = new Uri("http://mybankapi.me");
#endif
            var responseTask = _bankClient.GetAsync("api");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

            }
        }
        public string CheckIdNumber(string idNumber)
        {
            string output = string.Empty;
            IdResultType checkIdResult = IdResultType.UnhandledIdError;
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
            UserNameResultType checkUserNameResult = UserNameResultType.UnhandledUserError;
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

        public string validateEmail(string email)
        {
            string output = string.Empty;
            EmailAddressResultType checkEmailresult = EmailAddressResultType.UnhandledEmailAddressError;
            var responseTask = _bankClient.GetAsync("api/Authentication/checkemail?email=" + email);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmailAddressResultType>();
                readTask.Wait();
                checkEmailresult = readTask.Result;
            }
            switch (checkEmailresult)
            {
                case EmailAddressResultType.None:
                    {
                        break;
                    }
                case EmailAddressResultType.DuplicateEmailAddress:
                    {
                        output = "Duplicate EmailAddress.";
                        break;
                    }
                case EmailAddressResultType.EmailAddressIncorrect:
                    {
                        output = "Invalid Email";
                        break;
                    }
                case EmailAddressResultType.EmailAddressNullError:
                    {
                        output = "Input cannot be Null.";
                        break;
                    }
                case EmailAddressResultType.UnhandledEmailAddressError:
                    {
                        output = "Unexpected Error.";
                        break;
                    }
            }
            return output;
        }

        public string validatePhone(string phone)
        {
            string output = string.Empty;
            PhoneNumberResultType checkPhoneNumberResult = PhoneNumberResultType.UnhandledPhoneNumberError;
            var responseTask = _bankClient.GetAsync("api/Authentication/checkphonenumber?phone=" + phone);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<PhoneNumberResultType>();
                readTask.Wait();
                checkPhoneNumberResult = readTask.Result;
            }
            switch (checkPhoneNumberResult)
            {
                case PhoneNumberResultType.None:
                    {
                        break;
                    }
                case PhoneNumberResultType.DuplicatePhoneNumber:
                    {
                        output = "Duplicate Phone Number.";
                        break;
                    }
                case PhoneNumberResultType.PhoneNumberIncorrect:
                    {
                        output = "Invalid Phone Number";
                        break;
                    }
                case PhoneNumberResultType.PhoneNumberNullError:
                    {
                        output = "Input cannot be Null.";
                        break;
                    }
                case PhoneNumberResultType.UnhandledPhoneNumberError:
                    {
                        output = "Unexpected Error.";
                        break;
                    }
            }
            return output;
        }

        public bool validatePassword(string password)
        {
            var responseTask = _bankClient.GetAsync("api/Authentication/checkpassword?customer_pw=" + password);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                return readTask.Result;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="customer_name"></param>
        /// <param name="customer_address"></param>
        /// <param name="customer_dob"></param>
        /// <param name="customer_email"></param>
        /// <param name="customer_phone"></param>
        /// <param name="customer_pw"></param>
        /// <param name="account_no"></param>
        /// <param name="account_bal"></param>
        /// <param name="cheque_bk_number"></param>
        /// <param name="loan_app"></param>
        /// <param name="loan_with_amt"></param>
        /// <returns></returns>
        public string SignUp(string customer_id, string customer_name, string customer_address, DateTime customer_dob, string customer_email, string customer_phone, string customer_pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            //Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations");
            string output2 = string.Empty;
            //(string, string, string, DateTime, string, string, string, string, decimal, Guid, bool, decimal) output;
            
            var responseTask = _bankClient.GetAsync("api/Customer/signup?customer_id=" + customer_id + 
                "&customer_name=" + customer_name + 
                "&customer_address=" + customer_address + 
                "&customer_dob=" + customer_dob + 
                "&customer_email=" + customer_email + 
                "&customer_phone=" + customer_phone + 
                "&customer_pw=" + customer_pw + 
                "&account_no=" + account_no + 
                "&account_bal=" + account_bal + 
                "&cheque_bk_number=" + cheque_bk_number + 
                "&loan_app=" + loan_app + 
                "&loan_with_amt=" + loan_with_amt);
            responseTask.Wait();
            //output.Item1 = customer_id;
            //output.Item2 = customer_name;
            //output.Item3 = customer_address;
            //output.Item4 = customer_dob;
            //output.Item5 = customer_email;
            //output.Item6 = customer_phone;
            //output.Item7 = customer_pw;
            //output.Item8 = account_no;
            //output.Item9 = account_bal;
            //output.Item10 = cheque_bk_number;
            //output.Item11 = loan_app;
            //output.Item12 = loan_with_amt;
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool signUpResult = readTask.Result;

                if (signUpResult)
                {
                    output2 = "New account has been registered.";
                }
            }
            else
            {
                output2 = "Error has occured.";
            }
            return output2;





            //var new_user = new BankingWebAPI.Models.Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, account_no, 0, Guid.Empty, false, 0);
            //return new_user;
        }
        public string SignUpEmployee(string bankemployee_id, string bankemployee_name, string bankemployee_address, DateTime bankemployee_dob, string bankemployee_designation, string bankemployee_yos, string bankemployee_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/signup?username=" + bankemployee_name +
                "&idNumber=" + bankemployee_id +
                "&address=" + bankemployee_address +
                "$dateofbirth=" + bankemployee_dob +
                "$designation=" + bankemployee_designation +
                "$yearsofservice=" + bankemployee_yos +
                "&password=" + bankemployee_pw);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool signUpResult = readTask.Result;

                if (signUpResult)
                {
                    output = "New account has been registered.";
                }
            }
            else
            {
                output = "Error has occured.";
            }
            return output;
            //var new_user = new BankingWebAPI.Models.BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);
            //return new_user;
        }
        public string SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");


            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankManager/signup?username=" + bankmanager_name +
                "&idNumber=" + bankmanager_id +
                "&address=" + bankmanager_address +
                "$dateofbirth=" + bankmanager_dob +
                "$designation=" + bankmanager_designation +
                "$yearsofservice=" + bankmanager_yos +
                "&password=" + bankmanager_pw);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool signUpResult = readTask.Result;

                if (signUpResult)
                {
                    output = "New account has been registered.";
                }
            }
            else
            {
                output = "Error has occured.";
            }
            return output;
            //var new_user = new BankingWebAPI.Models.BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
            //return new_user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="customer_name"></param>
        /// <param name="customer_address"></param>
        /// <param name="customer_dob"></param>
        /// <param name="customer_email"></param>
        /// <param name="customer_phone"></param>
        /// <param name="customer_pw"></param>
        /// <param name="account_no"></param>
        /// <param name="account_bal"></param>
        /// <param name="cheque_bk_number"></param>
        /// <param name="loan_app"></param>
        /// <param name="loan_with_amt"></param>
        /// <returns></returns>
        public string RemoveCustomers(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Customer/delete?customer_id=" + customer_id);  // getaync instead of deleteasync
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool RemoveCustomerResult = readTask.Result;

                if (RemoveCustomerResult)
                {
                    output = "Removed customer";
                }
            }
            else
            {
                output = "Error has occured";
            }

            return output;
        }
        public string RemoveEmployees(string bankemployee_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.DeleteAsync("api/BankEmployee/delete/" + bankemployee_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool RemoveEmployeeResult = readTask.Result;

                if (RemoveEmployeeResult)
                {
                    output = bankemployee_id + " has been removed";
                }
            }
            else
            {
                output = "Account doesn't exist";
            }
            return output;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public (string, bool?) CheckLogin(string userName, string passWord)
        {
            string output = string.Empty;
            (bool, bool?) isLoginSuccess = (false, null);
            var responseTask = _bankClient.GetAsync("api/Authentication/login?username=" + userName + "&password=" + passWord);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<(bool, bool?)>();
                readTask.Wait();
                isLoginSuccess = readTask.Result;
            }
            if (isLoginSuccess.Item1 == true)
            {
                if (isLoginSuccess.Item2 == true)
                {
                    output = "\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1.) Savings" +
                        "\n2.) Loan" +
                        "\n3.) Go Back.";

                    Console.WriteLine(DateTime.Now.ToString());
                }
                else if (isLoginSuccess.Item2 == false)
                {
                    //output = $"Welcome {userName}." +
                    //    "\nWould you like to" +
                    //    "\n1.) Play Slots?" +
                    //    "\n2.) Logout?";
                }
            }
            return (output, isLoginSuccess.Item2);
        }
        public (string, bool?) CheckEmployeeLogin(string userName, string passWord)
        {
            string output = string.Empty;
            (bool, bool?) isLoginSuccess = (false, null);
            var responseTask = _bankClient.GetAsync("api/EmployeeAuthentication/login?username=" + userName + "&password=" + passWord);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<(bool, bool?)>();
                readTask.Wait();
                isLoginSuccess = readTask.Result;
            }
            if (isLoginSuccess.Item1 == true)
            {
                if (isLoginSuccess.Item2 == true)
                {
                    output = "\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1: Find customer by ID: " +
                        "\n2: Find customer by name" +
                        "\n3: Logout and go back";

                    Console.WriteLine(DateTime.Now.ToString());
                }
                else if (isLoginSuccess.Item2 == false)
                {
                    //output = $"Welcome {userName}." +
                    //    "\nWould you like to" +
                    //    "\n1.) Play Slots?" +
                    //    "\n2.) Logout?";
                }
            }
            return (output, isLoginSuccess.Item2);
        }
        public (string, bool?) CheckManagerLogin(string userName, string passWord)
        {
            string output = string.Empty;
            (bool, bool?) isLoginSuccess = (false, null);
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/login?username=" + userName + "&password=" + passWord);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<(bool, bool?)>();
                readTask.Wait();
                isLoginSuccess = readTask.Result;
            }
            if (isLoginSuccess.Item1 == true)
            {
                if (isLoginSuccess.Item2 == true)
                {
                    output = "\nWelcome Owner." +
                        "\nWould you like to" +
                        "\n1: Find customer by ID: " +
                        "\n2: Find customer by name" +
                        "\n3: Advanced access" +
                        "\n4: Logout and go back";

                    Console.WriteLine(DateTime.Now.ToString());
                }
                else if (isLoginSuccess.Item2 == false)
                {
                    //output = $"Welcome {userName}." +
                    //    "\nWould you like to" +
                    //    "\n1.) Play Slots?" +
                    //    "\n2.) Logout?";
                }
            }
            return (output, isLoginSuccess.Item2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="withdrawAmountKeyedInByCustomer"></param>
        /// <returns></returns>
        public string customerWithdrawl(string customer_id, decimal withdrawAmountKeyedInByCustomer)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Savings/withdrawal?customer_id=" + customer_id + "&withdrawAmountKeyedInByCustomer=" + withdrawAmountKeyedInByCustomer).Result;
            //responseTask.Wait();
            //var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = responseTask.Content.ReadAsAsync<bool>();
                //readTask.Wait();
                //bool signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";
                //if (signUpResult)
                //{
                //    output = "withdrawal has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="depositAmountKeyedInByCustomer"></param>
        /// <returns></returns>
        public string customerDeposit(string customer_id, decimal depositAmountKeyedInByCustomer)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Savings/deposit?customer_id=" + customer_id + "&depositAmountKeyedInByCustomer=" + depositAmountKeyedInByCustomer).Result;
            //responseTask.Wait();
            //var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        public void ParseInputStringInt(string input, out int? value)
        {
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                value = null;
            }
            catch (OverflowException)
            {
                value = null;
            }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="loanamount"></param>
        /// <param name="monthsIn"></param>
        /// <param name="interestamount"></param>
        /// <returns></returns>
        public string LoanAccount(string customer_id, decimal loanamount, decimal monthsIn, decimal interestamount)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/loan?customer_id=" + customer_id +
                "&loanamount=" + loanamount +
                "&monthsIn=" + monthsIn +
                "&interestamount=" + interestamount).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;

        }

        public string ViewLoan(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/viewloan?customer_id=" + customer_id).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="repayLoan"></param>
        /// <returns></returns>
        public string RepayLoan(string customer_id, string repayLoan)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/repayLoan?customer_id=" + customer_id +
                "&repayLoan=" + repayLoan).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;



        }
        

        public decimal DepositLimit()
        {
            decimal maximumamount = 5000;
            return maximumamount;
        }

        
        
        public string ViewBalance(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Savings/viewbalance?customer_id=" + customer_id).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result;
                Console.WriteLine(dataObjects);
                Console.ReadLine();
                return "Successful";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                Console.WriteLine(result);
                Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;
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
        public string ListCustomers()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Customers/viewallcustomers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
            }
            Console.WriteLine("\n Viewing all customers here");
            return output;
            //Console.WriteLine("\n Listing all current customers in database: ");
            //foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            //{
            //    Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} {kvp.Value.customer_address} {kvp.Value.customerBalance.ToString("F")} {kvp.Value.loan_amount.ToString("F")} {kvp.Value.customer_dateOfBirth}");

            //}
        }
        
        public string ListEmployees()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/viewallemployees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool viewAllEmployeeResult = readTask.Result;
            }
            Console.WriteLine("\n Viewing all employees here");
            return output;

        }
        
        public string SearchCustomerByID(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Customer/getcustomerbyid/" + customer_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
            }
            return output;
            //if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            //{
            //    Console.WriteLine("\n" + "ok found" + "\n");
            //    Console.WriteLine("CUSTOMER ID: " + cam.dictionaryOfcustomers[customer_id].customer_id);
            //    Console.WriteLine("CUSTOMER NAME: " + cam.dictionaryOfcustomers[customer_id].customer_name);
            //    Console.WriteLine("CUSTOMER ADDRESS: " + cam.dictionaryOfcustomers[customer_id].customer_address);
            //    Console.WriteLine("CUSTOMER DATEOFBIRTH: " + cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth);
            //    Console.WriteLine("CUSTOMER EMAIL: " + cam.dictionaryOfcustomers[customer_id].customer_email);
            //    Console.WriteLine("CUSTOMER PHONE: " + cam.dictionaryOfcustomers[customer_id].customer_phone);
            //    Console.WriteLine("CUSTOMER CHEQUE IF ANY: " + cam.dictionaryOfcustomers[customer_id].cheque_book_number);
            //    Console.WriteLine("CUSTOMER BALANCE: $" + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
            //    Console.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + cam.dictionaryOfcustomers[customer_id].customer_loan_applied);
            //    Console.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
            //    Console.WriteLine("");
            //}
            //else
            //{
            //    Console.WriteLine("Account doesn't exist");
            //}
        }
        public string SearchCustomerByName(string customer_name)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Customer/getcustomerbyname/" + customer_name);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
            }
            return output;
            //int permissionError = 0;
            //foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            //{
            //    if (kvp.Value.customer_name == customer_name)
            //    {
            //        Console.WriteLine("\n" + "Search for " + customer_name + "\n");
            //        Console.WriteLine($"CUSTOMER ID: {kvp.Value.customer_id}");
            //        Console.WriteLine($"CUSTOMER NAME: {kvp.Value.customer_name}");
            //        Console.WriteLine($"CUSTOMER ADDRESS: {kvp.Value.customer_address}");
            //        Console.WriteLine($"CUSTOMER DATEOFBIRTH: {kvp.Value.customer_dateOfBirth}");
            //        Console.WriteLine($"CUSTOMER EMAIL: {kvp.Value.customer_email}");
            //        Console.WriteLine($"CUSTOMER PHONE: {kvp.Value.customer_phone}");
            //        Console.WriteLine($"CUSTOMER CHEQUE IF ANY: {kvp.Value.cheque_book_number}");
            //        Console.WriteLine($"CUSTOMER BALANCE: ${kvp.Value.customerBalance.ToString("F")}");
            //        Console.WriteLine($"CUSTOMER LOAN APPLIED IF ANY: {kvp.Value.customer_loan_applied}");
            //        Console.WriteLine($"CUSTOMER LOAN AMOUNT IF ANY: {kvp.Value.loan_amount.ToString("F")}\n");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //        Console.WriteLine("");
            //        return;
            //    }
            //    else
            //    {
            //        permissionError = 1;

            //    }
            //}
            //if (permissionError == 1)
            //{
            //    Console.WriteLine("Account doesn't exist");
            //}
        }
        public string TotalLoanAmount()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/viewtotalloan/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
            }
            return output;
            //foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            //{
            //    Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} Loan amt: {kvp.Value.loan_amount.ToString("F")}");

            //}
            //var totalloanamount = cam.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            //Console.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F"));
            //return totalloanamount;

        }
        public string TotalSavingsAccount()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/viewtotalsavings/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<decimal>();
                readTask.Wait();
            }
            return output;
            //foreach (KeyValuePair<string, BankingWebAPI.Models.Customer> kvp in cam.dictionaryOfcustomers)
            //{
            //    Console.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} Customer balance: {kvp.Value.customerBalance.ToString("F")}");

            //}
            //var totalsavingsofCustomers = cam.dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            //Console.WriteLine("Total savings of the bank " + totalsavingsofCustomers.ToString("F"));
            //return totalsavingsofCustomers;
        }
        public string ViewManagers()
        {
            Console.WriteLine("\n Viewing all managers here");
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/viewallmanagers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool viewAllEmployeeResult = readTask.Result;
            }
            
            return output;
            //foreach (KeyValuePair<string, BankingWebAPI.Models.BankManagers> kvp in mam.dictionaryOfManagers)
            //{
            //    Console.WriteLine($"{kvp.Value.bankmanager_id} {kvp.Value.bankmanager_name}");

            //}
        }
        
        //public void CustomerAdd(CustomerAccountManagerController cam, CustomerController cust, string id, Customer new_user)
        //{
        //    var checkUserresult = cust.CustomerAddNew(cam, new_user);
        //    //var json = JsonConvert.SerializeObject(new_user);
        //    //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            
            
        //    //var responseTask = _bankClient.PostAsync("api/Customer/Test/Add", stringContent);
        //    //responseTask.Wait();
        //    //var result = responseTask.Result;
        //    //if (result.IsSuccessStatusCode)
        //    //{
        //    //    var readTask = result.Content.ReadAsAsync<Dictionary<string, Customer>>();
        //    //    readTask.Wait();
        //    //    checkPhoneresult = readTask.Result;
        //    //}
        //    //return checkUserresult;
        //}
        //public Dictionary<string, BankEmployees> EmployeeAdd(EmployeeAccountManagerController eam, BankEmployeeController emp, string id, BankEmployees new_user)
        //{
        //    Dictionary<string, BankEmployees> checkUserresult = emp.EmployeeAddNew(eam, new_user);
        //    return checkUserresult;
        //}
        //public Dictionary<string, BankManagers> ManagerAdd(ManagerAccountManagerController mam, string id, BankManagers new_user)
        //{
        //    Dictionary<string, BankManagers> checkUserresult = mam.ManagerAddNew(mam, new_user);
        //    return checkUserresult;
        //}

    }
}
