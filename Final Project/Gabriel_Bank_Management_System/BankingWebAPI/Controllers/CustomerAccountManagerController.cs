using System;
using BankingWebAPI.EntityFramework;
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
        public Customer CurrentUser { get; private set; }
        IDataContext dataContext;
        public CustomerAccountManagerController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }
        private IList<Customer> _customerList;
        public virtual Dictionary<string, Customer> dictionaryOfcustomers { get; set; }

        public CustomerAccountManagerController()
        {
            dataContext = new ManagementContext();
            using (ManagementContext bankContext = new ManagementContext())
            {
                dictionaryOfcustomers = new Dictionary<string, Customer>();
                Customer cust1 = new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" };
                Customer cust2 = new Customer() { customer_id = "1233", customer_name = "petersmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "peter@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c152f04e-975a-4cfd-bdcf-88d136b1f23e"), account_number = "A1233" };
                dictionaryOfcustomers.Add("1232", cust1);
                dictionaryOfcustomers.Add("1233", cust2);
                //bankContext.Customers.Remove(cust1);
                //bankContext.Customers.Remove(cust2);
                //bankContext.Customers.Add(cust1);
                //bankContext.Customers.Add(cust2);
                //bankContext.SaveChanges();
            }
            //Console.WriteLine("End");
            //Console.ReadLine();
            _customerList = new List<Customer>();
            
            
        }
        [HttpGet]
        [Route("login")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public (bool, bool?) Login(string username, string password)
        {
            bool loginSuccess = false;
            bool? isOwner = false;
            CurrentUser = dataContext.Customers.Where(x => Equals(x.customer_id, username) && Equals(x.customer_pw, password)).FirstOrDefault();

            if (CurrentUser != null)
            {
                loginSuccess = true;
                isOwner = true;
            }

            return (loginSuccess, isOwner);
        }
        //}
        [HttpGet]
        [Route("checkpassword")]                                 // https://localhost:44360/api/Authentication/checkpassword?customer_pw=John12345678$
        public ForPasswordResultType validatePassword(string customer_pw)
        {

            ForPasswordResultType type = ForPasswordResultType.None;
            if (customer_pw == null || customer_pw.Length < 6 || customer_pw.Length > 24)
            {
                type = ForPasswordResultType.IncorrectPasswordLength;
                //Console.WriteLine("Password not met - 6 - 24 chars");
                //return false;
                return type;
            }

            if (customer_pw.Any(char.IsLower) == false)
            {
                type = ForPasswordResultType.PasswordNoLowerCaseLetter;
                //Console.WriteLine("Password not met - need lower case");
                //return false;
                return type;
            }
            if (customer_pw.Any(char.IsUpper) == false)
            {
                type = ForPasswordResultType.PasswordNoUpperCaseLetter;
                //Console.WriteLine("Password not met - need upper case");
                //return false;
                return type;
            }

            if (customer_pw.Any(char.IsDigit) == false)
            {
                type = ForPasswordResultType.PasswordNoDigits;
                //Console.WriteLine("Password not met - need to include digits");
                //return false;
                return type;
            }
            Regex rgx = new Regex("[^A-Za-z0-9]");
            bool hasSpecialChars = rgx.IsMatch(customer_pw);
            if (hasSpecialChars == false)
            {
                type = ForPasswordResultType.PasswordNoSpecialCharacter;
                //Console.WriteLine("Password not met - need to include special characters");
                //return false;
                return type;
            }
            //return true;
            return type;

        }
        [HttpGet]
        [Route("checkphonenumber")]                // https://mybankapi.me/api/Authentication/checkphonenumber?phone=(222)333-4444
        public PhoneNumberResultType validatePhone(string phone)
        {
            PhoneNumberResultType type = PhoneNumberResultType.None;
            while (true)
            {
                try
                {
                    if (phone == null)
                    {
                        type = PhoneNumberResultType.PhoneNumberNullError;
                    }
                    Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
                    if (regex.IsMatch(phone))
                    {
                        //Console.WriteLine("Phone id entered is valid");

                    }
                    else
                    {
                        //Console.WriteLine("phone number is not valid, please try again");
                        type = PhoneNumberResultType.PhoneNumberIncorrect;
                        //throw new PhoneIncorrectException(phone);
                    }
                }
                catch
                {

                }
                return type;

            }

        }
        [HttpGet]
        [Route("checkemail")]                                        // https://mybankapi.me/api/Authentication/checkemail?email=john@mail.com
        public EmailAddressResultType validateEmail(string email)
        {
            EmailAddressResultType type = EmailAddressResultType.None;
            while (true)
            {
                try
                {
                    if (email == null)
                    {
                        type = EmailAddressResultType.EmailAddressNullError;
                    }
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (regex.IsMatch(email))
                    {
                        //Console.WriteLine("Email id entered is valid");
                        // validate the email Id
                    }
                    else
                    {
                        type = EmailAddressResultType.EmailAddressIncorrect;
                        //Console.WriteLine("Email is not valid, please try again");

                        //throw new EmailIncorrectException(email);
                    }
                }
                catch
                {

                }
                return type;

            }

        }
        [HttpGet]
        [Route("checkusername")]                         // http://mybankapi.me/api/Authentication/checkusername?username=johnsmith
        public UserNameResultType CheckUserName(string username)
        {
            UserNameResultType type = UserNameResultType.None;
            if (username == null || username.Length < 6 || username.Length > 24)
            {
                type = UserNameResultType.UserNameLengthIncorrect;
            }
            if (username != null)
            {
                foreach (char character in username)
                {
                    if (char.IsWhiteSpace(character))
                    {
                        type = UserNameResultType.UserNameContainsSpace;
                        break;
                    }
                }
            }
            return type;
        }
        [HttpGet]
        [Route("checkid")]                      // http://mybankapi.me/api/Authentication/checkid?idNumber=1111
        public IdResultType CheckId(string idNumber)
        {
            IdResultType type = IdResultType.None;
            if (idNumber == null)
            {
                type = IdResultType.IdNullError;
            }
            if (idNumber == null || idNumber.Length != 4)
            {
                type = IdResultType.IdIncorrect;
            }
            return type;
        }
        
    }
}
