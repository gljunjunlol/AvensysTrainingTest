using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class User : IUser
    {
        private readonly IConsoleIO ConsoleIO;
        private IUser _user;
        public User(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        
        public User()
        {
            ConsoleIO = new ConsoleIO();
        }
        public User(IUser user)
        {
            _user = user;
        }
        public void DeleteUserAccount()
        {
            


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

            ConsoleIO.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx");
            string customer_phone = ConsoleIO.ReadLine();
            validatePhone(customer_phone);

            ConsoleIO.WriteLine("Key in user email format (e.g. john@mail.com)");
            string customer_email = ConsoleIO.ReadLine();
            validateEmail(customer_email);

            User validatepw = new User();
            string customer_pw;
            do
            {
                ConsoleIO.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                customer_pw = ConsoleIO.ReadLine();
            }
            while (validatepw.validatePassword(customer_pw) == false);
            if (validatepw.validatePassword(customer_pw) == true)
            {
                ConsoleIO.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");
                
                var new_user = new Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, " ", 0, Guid.Empty, false, 0);
                return new_user;
            }
            return null;
        }
        
        public void UserLogin(CustomersManagement cmgt, List<int> loginTries)
        {
            bool exit = false;
            int numberofTries = 4;
            //int input = 0;
            while (!exit)
            {
                loginTries.Add(1);
                //input++;
                numberofTries--;
                ConsoleIO.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");
                
                string customer_id = ConsoleIO.ReadLine();
                ConsoleIO.WriteLine("and pw");
                string customer_pw = ConsoleIO.ReadLine();
                
                //dictionary.References();
                
                if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id) && cmgt.dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
                {
                    ConsoleIO.WriteLine($"Congratulations, {cmgt.dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { cmgt.dictionaryOfcustomers[customer_id].customer_id} { cmgt.dictionaryOfcustomers[customer_id].customer_name} { cmgt.dictionaryOfcustomers[customer_id].customer_email} { cmgt.dictionaryOfcustomers[customer_id].account_number}");
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
            Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
            if (regex.IsMatch(phone))
            {
                Console.WriteLine("Phone id entered is valid");
                return true;
            }
            else
            {
                Console.WriteLine("phone number is not valid, please try again");
                throw new PhoneIncorrectException(phone);
            }
        }
        public bool validateEmail(string email)
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
                throw new EmailIncorrectException(email);
            }
        }
        public static void AddUser(CustomersManagement cmgt)
        {
            Customer cust = new Customer("1", "apple", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0, Guid.Empty, false, 100);
            Customer cust2 = new Customer("2", "band", "23 hillview", DateTime.Now, "something@mail.com", "(222)333-4444", "John12345678", "", 0);
            cmgt.dictionaryOfcustomers.Add("12345", cust);
            cmgt.dictionaryOfcustomers.Add("12346", cust2);
        }
    }
}
