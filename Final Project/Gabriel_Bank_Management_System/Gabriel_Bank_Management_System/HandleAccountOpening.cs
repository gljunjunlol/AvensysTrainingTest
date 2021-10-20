using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class HandleAccountOpening
    {
        private IValidatePw _validatePw;

        public HandleAccountOpening()
        {

        }
        public HandleAccountOpening(IValidatePw validatePw)
        {
            _validatePw = validatePw;
        }
        public static void DeleteUserAccount()
        {
            
            foreach(var item in CustomersManagement.dictionaryOfcustomers)
            {
                Console.WriteLine("Key in user id");
                string id = Console.ReadLine();
                if (CustomersManagement.dictionaryOfcustomers.ContainsKey(id))
                {
                    CustomersManagement.dictionaryOfcustomers.Remove(item.Key);
                }
                
            }
            

        }
        public static Customer CreateUserAccount()
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();

            Console.WriteLine("Key in customer name");
            string customer_name = Console.ReadLine();

            Console.WriteLine("Key in customer address");
            string customer_address = Console.ReadLine();

            Console.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
            DateTime customer_dob = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx");
            string customer_phone = Console.ReadLine();
            validatePhone(customer_phone);

            Console.WriteLine("Key in user email format (e.g. john@mail.com)");
            string customer_email = Console.ReadLine();
            validateEmail(customer_email);

            //Console.WriteLine("Key in user pw");
            //Console.WriteLine("Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
            //string customer_pw = Console.ReadLine();

            ValidatePw tk = new ValidatePw();
            HandleAccountOpening validatepw = new HandleAccountOpening(tk);
            bool result = validatepw.validatePassword();
            string result2 = tk.ValidatePwMethod();
            if (result)
            {
                Console.WriteLine("password is ok");
                Console.WriteLine("Writing to file..");
                Console.WriteLine("Congratulations, Account creation has been completed.....");
                var new_user = new Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, result2, " ", 0, Guid.Empty, false, 0);

                return new_user;
            }
            //do
            //{
            //    validatepw.validatePassword();
            //    customer_pw = Console.ReadLine();
            //}
            //while (validatepw.validatePassword() == false);

            
            //if (result)
            //{

                
            //    var new_user = new Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, " ", 0, Guid.Empty, false, 0);

            //    return new_user;
            //}
            
            
            return null;

            

            




            // form -> data validation
            //create customer
            // return new customer
        }

        public static void UserLogin()
        {
            bool exit = false;
            int numberofTries = 4;
            int input = 0;
            while (!exit)
            {
                input++;
                numberofTries--;
                Console.WriteLine("Key in your login information");
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string customer_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string customer_pw = Console.ReadLine();
                if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id) && CustomersManagement.dictionaryOfcustomers[customer_id].customer_pw == customer_pw)
                {
                    Console.WriteLine($"Congratulations, {CustomersManagement.dictionaryOfcustomers[customer_id].customer_name}, you are now logged in!");
                    Console.WriteLine("ok user found");
                    Console.WriteLine($"Hello your info: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].account_number}");
                    Console.ReadLine();
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (input > 3)
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
        public bool validatePassword()
        {
            string customer_pw = _validatePw.ValidatePwMethod();
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
        public static void validatePhone(string a)
        {
            Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
            if (regex.IsMatch(a))
            {
                Console.WriteLine("Phone id entered is valid");
            }
            else
            {
                Console.WriteLine("phone number is not valid, please try again");
                throw new PhoneIncorrectException(a);
                //throw new NullReferenceException();
                //throw new ArgumentNullException();
            }
        }
        public static void validateEmail(string a)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(a))
            {
                Console.WriteLine("Email id entered is valid");
                // validate the email Id
            }
            else
            {
                Console.WriteLine("Email is not valid, please try again");
                throw new EmailIncorrectException(a);
                //throw new NullReferenceException();
                //throw new ArgumentNullException();
            }
        }
    }
}
