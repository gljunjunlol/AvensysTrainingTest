using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;


namespace Gabriel_Bank_Management_System
{
    public class CustomerAccountManager : ICustomerAccountManager
    {
        public virtual Dictionary<string, Customer> dictionaryOfcustomers { get; set; }
        private readonly IConsoleIO ConsoleIO;
        private ICustomerAccountManager _user;
        public void References()
        {
            dictionaryOfcustomers = new Dictionary<string, Customer>();
        }
        public CustomerAccountManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        
        public CustomerAccountManager()
        {
            ConsoleIO = new ConsoleIO();
        }
        public CustomerAccountManager(ICustomerAccountManager user)
        {
            _user = user;
        }
        public Customer CreateUserAccount()
        {
            
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in customer name");
            string customer_name = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in customer address");
            string customer_address = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
            DateTime customer_dob = DateTime.Parse(ConsoleIO.ReadLine());

            

            
            string customer_pw; string customer_phone; string customer_email;
            do
            {
                ConsoleIO.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx"); customer_phone = ConsoleIO.ReadLine();
                

                
            }
            while (validatePhone(customer_phone) == false);
            do
            {
                ConsoleIO.WriteLine("Key in user email format (e.g. john@mail.com)"); customer_email = ConsoleIO.ReadLine();


            }
            while (validateEmail(customer_email) == false);
            do
            {
                ConsoleIO.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:"); customer_pw = ConsoleIO.ReadLine();

            }
            while (validatePassword(customer_pw) == false);


            ConsoleIO.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, " ", 0, Guid.Empty, false, 0);
            return new_user;
        }
        
        public void UserLogin(CustomerAccountManager cam, List<int> loginTries)
        {
            bool exit = false;
            int numberofTries = 4;
            
            while (!exit)
            {
                loginTries.Add(1);
                
                numberofTries--;
                ConsoleIO.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");
                
                string customer_id = ConsoleIO.ReadLine();
                ConsoleIO.WriteLine("and pw");
                string customer_pw = ConsoleIO.ReadLine();
                                
                
                if (cam.dictionaryOfcustomers.ContainsKey(customer_id) && cam.dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
                {
                    ConsoleIO.WriteLine($"Congratulations, {cam.dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { cam.dictionaryOfcustomers[customer_id].customer_id} { cam.dictionaryOfcustomers[customer_id].customer_name} { cam.dictionaryOfcustomers[customer_id].customer_email} { cam.dictionaryOfcustomers[customer_id].account_number}");
                    exit = true;
                }
                else
                {
                    ConsoleIO.WriteLine("Incorrect user or pw");
                }
                if (loginTries.Count > 3)
                {
                    ConsoleIO.WriteLine("Too many tries, please wait 5 mins");

                    ConsoleIO.ReadLine();
                    Environment.Exit(0);
                }
                if (numberofTries == 0)
                {
                    numberofTries = 4;
                }
            }

        }
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
                        //return false;
                        throw new PhoneIncorrectException(phone);
                    }
                }
                catch
                {
                    return false;
                }
                
            }
            
        }
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
                        //return false;
                        throw new EmailIncorrectException(email);
                    }
                }
                catch
                {
                    return false;
                }
                
            }
            
        }
        public static void AddUser(CustomerAccountManager cam)
        {
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0, Guid.Empty, false, 100);
            Customer cust2 = new Customer("2", "band", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0);
            cam.dictionaryOfcustomers.Add("12345", cust);
            cam.dictionaryOfcustomers.Add("12346", cust2);
        }

        public void UserLogin(WebApiLibrary.Controllers.CustomerAccountManager cam, List<int> loginTries)
        {
            throw new NotImplementedException();
        }

        WebApiLibrary.Models.Customer ICustomerAccountManager.CreateUserAccount()
        {
            throw new NotImplementedException();
        }
    }
}
