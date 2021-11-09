using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers
{
    public class CustomerAccountManager : ICustomerAccountManager
    {
        private IList<Customer> _customerList;
        
        public CustomerAccountManager()
        {
            _customerList = new List<Customer>();
        }
        public Customer CreateUserAccount()
        {

            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();

            Console.WriteLine("Key in customer name");
            string customer_name = Console.ReadLine();

            Console.WriteLine("Key in customer address");
            string customer_address = Console.ReadLine();

            Console.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
            DateTime customer_dob = DateTime.Parse(Console.ReadLine());




            string customer_pw; string customer_phone; string customer_email;
            do
            {
                Console.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx"); customer_phone = Console.ReadLine();



            }
            while (validatePhone(customer_phone) == false);
            do
            {
                Console.WriteLine("Key in user email format (e.g. john@mail.com)"); customer_email = Console.ReadLine();


            }
            while (validateEmail(customer_email) == false);
            do
            {
                Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:"); customer_pw = Console.ReadLine();

            }
            while (validatePassword(customer_pw) == false);


            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, " ", 0, Guid.Empty, false, 0);
            return new_user;
        }
        public virtual Dictionary<string, Customer> dictionaryOfcustomers { get; set; }
        public void UserLogin(CustomerAccountManager cam, List<int> loginTries)
        {
            bool exit = false;
            int numberofTries = 4;
            //int input = 0;
            while (!exit)
            {
                loginTries.Add(1);
                //input++;
                numberofTries--;
                Console.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");

                string customer_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string customer_pw = Console.ReadLine();

                //dictionary.References();

                if (dictionaryOfcustomers.ContainsKey(customer_id) && dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
                {
                    Console.WriteLine($"Congratulations, {dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfcustomers[customer_id].customer_id} { dictionaryOfcustomers[customer_id].customer_name} { dictionaryOfcustomers[customer_id].customer_email} { dictionaryOfcustomers[customer_id].account_number}");
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (loginTries.Count > 3)
                {
                    Console.WriteLine("Too many tries, please wait 5 mins");

                    Console.ReadLine();
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
                        //throw new PhoneIncorrectException(phone);
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
                        //throw new EmailIncorrectException(email);
                    }
                }
                catch
                {
                    return false;
                }

            }

        }
    }
}
