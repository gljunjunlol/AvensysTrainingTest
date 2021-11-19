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
        private readonly IConsoleIO ConsoleIO;
        public CustomerAccountManagerController(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        private IList<Customer> _customerList;
        public virtual Dictionary<string, Customer> dictionaryOfcustomers { get; set; }

        public CustomerAccountManagerController()
        {
            ConsoleIO = new ConsoleIO();
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
        [Route("login")]                                     // https://localhost:44360/api/Authentication/login?customer_id=hello&customer_pw=hello
        public bool UserLogin(string customer_id, string customer_pw)
        {
            try
            {
                if (dictionaryOfcustomers.ContainsKey(customer_id) && dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
                {
                    ConsoleIO.WriteLine($"Congratulations, {dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfcustomers[customer_id].customer_id} { dictionaryOfcustomers[customer_id].customer_name}");
                    return true;

                }
                return false;
            }
            catch(ArgumentNullException)
            {
                ConsoleIO.WriteLine("cannot be null");
            }
            return false;
            

        }
        [HttpGet]
        [Route("checkpassword")]                                 // https://localhost:44360/api/Authentication/checkpassword?customer_pw=John12345678$
        public bool validatePassword(string customer_pw)
        {
            while (true)
            {
                try
                {
                    if (customer_pw ==null || customer_pw.Length < 6 || customer_pw.Length > 24)
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
                catch
                {
                    return false;
                }
            }
            
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
                if (username ==null || username.Length < 6 || username.Length > 24)
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
                if (idNumber ==null || idNumber.Length != 4)
                {
                    type = IdResultType.IdIncorrect;
                }
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
