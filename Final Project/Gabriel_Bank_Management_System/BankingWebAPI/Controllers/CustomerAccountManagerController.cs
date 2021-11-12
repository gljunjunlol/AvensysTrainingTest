using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;
using System.IO;
using Newtonsoft.Json;
using Bank.Common.Common;
using BankingWebAPI.Utility;
using System.Web.Http;
using BankingWebAPI.Filters;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/Authentication")]
    public class CustomerAccountManagerController : ApiController, ICustomerAccountManager
    {
        private IList<Customer> _customerList;
        public Dictionary<string, Customer> dictionaryOfcustomers { get; set; }

        public CustomerAccountManagerController()
        {
            _customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
        }
        [HttpGet]
        [Route("login")]                                     // https://localhost:44360/api/Authentication/login?customer_id=hello&customer_pw=hello
        public bool UserLogin(string customer_id, string customer_pw)
        {
            if (dictionaryOfcustomers.ContainsKey(customer_id) && dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
            {
                Console.WriteLine($"Congratulations, {dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfcustomers[customer_id].customer_id} { dictionaryOfcustomers[customer_id].customer_name} { dictionaryOfcustomers[customer_id].customer_email} { dictionaryOfcustomers[customer_id].account_number}");
                return true;

            }
            return false;

        }
        [HttpGet]
        [Route("checkpassword")]                                 // https://localhost:44360/api/Authentication/checkpassword?customer_pw=John12345678$
        public bool validatePassword(string customer_pw)
        {
            if (customer_pw.Length < 6 || customer_pw.Length > 24)
            {
                Console.WriteLine("Password not met - 6 - 24 chars");
                return false;
            }

            if (customer_pw.Any(char.IsLower) == false)
            {

                Console.WriteLine("Password not met - need lower case");
                return false;

            }
            if (customer_pw.Any(char.IsUpper) == false)
            {

                Console.WriteLine("Password not met - need upper case");
                return false;

            }

            if (customer_pw.Any(char.IsDigit) == false)
            {

                Console.WriteLine("Password not met - need to include digits");
                return false;
            }
            Regex rgx = new Regex("[^A-Za-z0-9]");
            bool hasSpecialChars = rgx.IsMatch(customer_pw);
            if (hasSpecialChars == false)
            {
                Console.WriteLine("Password not met - need to include special characters");
                return false;
            }
            return true;
        }
        [HttpGet]
        [Route("checkphonenumber")]                // https://localhost:44360/api/Authentication/checkphonenumber?phone=(222)333-4444
        public bool validatePhone(string phone)
        {
            while (true)
            {
                try
                {
                    Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
                    if (regex.IsMatch(phone))
                    {
                        Console.WriteLine("Phone id entered is valid");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("phone number is not valid, please try again");
                        return false;
                        //throw new PhoneIncorrectException(phone);
                    }
                }
                catch
                {
                    return false;
                }

            }

        }
        [HttpGet]
        [Route("checkemail")]                                        // https://localhost:44360/api/Authentication/checkemail?email=john@mail.com
        public bool validateEmail(string email)
        {
            while (true)
            {
                try
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (regex.IsMatch(email))
                    {
                        Console.WriteLine("Email id entered is valid");
                        // validate the email Id
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Email is not valid, please try again");
                        return false;
                        //throw new EmailIncorrectException(email);
                    }
                }
                catch
                {
                    return false;
                }

            }

        }
        [HttpGet]
        [Route("checkusername")]                         // https://localhost:44360/api/Authentication/checkusername?username=johnsmith
        public UserNameResultType CheckUserName(string username)
        {
            UserNameResultType type = UserNameResultType.None;
            try
            {
                if (username.Length < 6 || username.Length > 24)
                {
                    type = UserNameResultType.UserNameLengthIncorrect;
                }
                foreach (char character in username)
                {
                    if (char.IsWhiteSpace(character))
                    {
                        type = UserNameResultType.UserNameContainsSpace;
                        break;
                    }
                }

                //List<Customer> userList = JsonConvert.DeserializeObject<List<Customer>>(_fileHandling.ReadAllText("User.json"));
                //if (userList != null)
                //{
                //    foreach (Customer customer in userList)
                //    {
                //        if (Equals(customer.customer_name, username))
                //        {
                //            type = UserNameResultType.DuplicateUser;
                //            break;
                //        }
                //    }
                //}
            }
            catch (IOException)
            {
                type = UserNameResultType.UserNameDataAccessError;
            }
            catch (Exception)
            {
                type = UserNameResultType.UnhandledUserError;
            }
            return type;
        }
        [HttpGet]
        [Route("checkid")]                      // https://localhost:44360/api/Authentication/checkid?idNumber=1234
        public IdResultType CheckId(string idNumber)
        {
            IdResultType type = IdResultType.None;
            try
            {
                if (idNumber.Length != 4)
                {
                    type = IdResultType.IdIncorrect;
                }
                
                //List<Customer> userList = JsonConvert.DeserializeObject<List<Customer>>(_fileHandling.ReadingandWritingcustomer(string customer_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam));
                //if (userList != null)
                //{
                //    foreach (Customer customer in userList)
                //    {
                //        if (Equals(customer.customer_id, idNumber))
                //        {
                //            type = IdResultType.DuplicateId;
                //            break;
                //        }
                //    }
                //}
            }
            catch (IOException)
            {
                type = IdResultType.IdDataAccessError;
            }
            catch (Exception)
            {
                type = IdResultType.UnhandledIdError;
            }
            return type;
        }
    }
}
