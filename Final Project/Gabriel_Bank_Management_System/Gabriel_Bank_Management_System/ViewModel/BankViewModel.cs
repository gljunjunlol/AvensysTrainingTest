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
    public class BankViewModel : IBankViewModel
    {
        private readonly HttpClient _bankClient;
        public BankViewModel(HttpClient httpClient)
        {
            _bankClient = httpClient;
            //_bankClient = new HttpClient();
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

        public IList<string> validatePassword(string password)
        {
            IList<string> outputList = new List<string>();
            ForPasswordResultType checkPasswordResult = ForPasswordResultType.UnhandledPasswordError;
            var responseTask = _bankClient.GetAsync("api/Authentication/checkpassword?customer_pw=" + password);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ForPasswordResultType>();
                readTask.Wait();
                checkPasswordResult = readTask.Result;
            }
            if (Equals (checkPasswordResult & ForPasswordResultType.IncorrectPasswordLength, ForPasswordResultType.IncorrectPasswordLength))
            {
                outputList.Add("Password not met - 6 - 24 chars");
            }
            if (Equals(checkPasswordResult & ForPasswordResultType.PasswordNoLowerCaseLetter, ForPasswordResultType.PasswordNoLowerCaseLetter))
            {
                outputList.Add("Password not met - need lower case");
            }
            if (Equals(checkPasswordResult & ForPasswordResultType.PasswordNoUpperCaseLetter, ForPasswordResultType.PasswordNoUpperCaseLetter))
            {
                outputList.Add("Password not met - need upper case");
            }
            if (Equals(checkPasswordResult & ForPasswordResultType.PasswordNoDigits, ForPasswordResultType.PasswordNoDigits))
            {
                outputList.Add("Password not met - need to include digits");
            }
            if (Equals(checkPasswordResult & ForPasswordResultType.PasswordNoSpecialCharacter, ForPasswordResultType.PasswordNoSpecialCharacter))
            {
                outputList.Add("Password not met - need to include special characters");
            }
            return outputList;
            //return false;
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
            string output = string.Empty;
            //(string, string, string, DateTime, string, string, string, string, decimal, Guid, bool, decimal) output;
            
            var responseTask = _bankClient.GetAsync("api/Customer/signup?customer_id=" + customer_id + 
                "&customer_name=" + customer_name + 
                "&customer_address=" + customer_address + 
                "&customer_dob=" + customer_dob.ToString("O") + 
                "&customer_email=" + customer_email + 
                "&customer_phone=" + customer_phone + 
                "&customer_pw=" + customer_pw + 
                "&account_no=" + account_no + 
                "&account_bal=" + account_bal + 
                "&cheque_bk_number=" + cheque_bk_number + 
                "&loan_app=" + loan_app + 
                "&loan_with_amt=" + loan_with_amt).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Account creation has been completed";

                //if (signUpResult != null)
                //{
                //    output = "deposit has been registered.";
                //}
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankemployee_id,"></param>
        /// <param name="bankemployee_name"></param>
        /// <param name="bankemployee_address"></param>
        /// <param name="bankemployee_dob"></param>
        /// <param name="bankemployee_designation"></param>
        /// <param name="bankemployee_yos"></param>
        /// <param name="bankemployee_pw"></param>
        /// <returns></returns>
        public string SignUpEmployee(string bankemployee_id, string bankemployee_name, string bankemployee_address, DateTime bankemployee_dob, string bankemployee_designation, string bankemployee_yos, string bankemployee_pw)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/signup?bankemployee_id=" + bankemployee_id + 
                "&bankemployee_name=" + bankemployee_name + 
                "&bankemployee_address=" + bankemployee_address + 
                "&bankemployee_dob=" + bankemployee_dob.ToString("O") + "&bankemployee_designation=" + bankemployee_designation + 
                "&bankemployee_yos=" + bankemployee_yos + 
                "&bankemployee_pw=" + bankemployee_pw).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Account creation has been completed";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            return output;
        }
        public string SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/signup?bankmanager_id=" + bankmanager_id +
                "&bankmanager_name=" + bankmanager_name +
                "&bankmanager_address=" + bankmanager_address +
                "&bankmanager_dob=" + bankmanager_dob.ToString("O") +
                "&bankmanager_designation=" + bankmanager_designation +
                "&bankmanager_yos=" + bankmanager_yos +
                "&bankmanager_pw=" + bankmanager_pw).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                //var readTask = result.Content.ReadAsAsync<IHttpActionResult>();
                //readTask.Wait();
                //IHttpActionResult signUpResult = readTask.Result;
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Account creation has been completed";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
                //output = "Error has occured.";
            }
            return output;
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
            var responseTask = _bankClient.GetAsync("api/BankEmployee/delete?bankemployee_id=" + bankemployee_id);
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
        public string DeleteManager(string bankmanager_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/delete?bankmanager_id=" + bankmanager_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<bool>();
                readTask.Wait();
                bool RemoveCustomerResult = readTask.Result;

                if (RemoveCustomerResult)
                {
                    output = bankmanager_id + " has been removed";
                }
            }
            else
            {
                output = "Error has occured";
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
                    output = null;
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
                    output = null;
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
                    output = null;
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
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
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
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
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
        public void ParseInputDecimal(string input, out decimal? value)
        {
            try
            {
                value = Convert.ToDecimal(input);
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
        public void ParseInputDate(string input, out DateTime? value)
        {
            try
            {
                value = Convert.ToDateTime(input);
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
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            return output;

        }

        public string ViewLoan(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/viewloan?customer_id=" + customer_id).Result;
            if (responseTask.IsSuccessStatusCode)
            {

                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";

            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
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
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
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
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
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
            var responseTask = _bankClient.GetAsync("api/Customer/viewallcustomers").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }

            return output;
        }
        
        public string ListEmployees()
        {
            Console.WriteLine("\n Viewing all employees here");
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/viewallemployees").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            
            return output;

        }
        
        public string SearchCustomerByID(string customer_id)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/customerbyid?customer_id=" + customer_id).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine("Incorrect format");
                //Console.ReadLine();
                return "Error";
            }

            return output;
        }
        public string SearchCustomerByName(string customer_name)
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/BankEmployee/customerbyname?customer_name=" + customer_name).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine("Incorrect format");
                //Console.ReadLine();
                return "Error";
            }

            return output;
        }
        public string TotalLoanAmount()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/TakingLoan/viewtotalloan/").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            return output;
        }
        public string TotalSavingsAccount()
        {
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/Savings/viewtotalsavings/").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();

                
                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            return output;
        }
        public string ViewManagers()
        {
            Console.WriteLine("\n Viewing all managers here");
            string output = string.Empty;
            var responseTask = _bankClient.GetAsync("api/ManagerAuthentication/viewallmanagers").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var dataObjects = responseTask.Content.ReadAsAsync<object>().Result; Console.WriteLine(dataObjects); Console.ReadLine();


                return "Successful";
            }
            else
            {
                //var result = $"{(int)responseTask.StatusCode} ({responseTask.ReasonPhrase})";
                //Console.WriteLine(result);
                //Console.ReadLine();
                return "Error";
            }
            return output;
        }
    }
}
