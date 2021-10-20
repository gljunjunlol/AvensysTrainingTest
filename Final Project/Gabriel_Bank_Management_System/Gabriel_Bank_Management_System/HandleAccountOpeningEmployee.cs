using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    class HandleAccountOpeningEmployee
    {
        public static void DeleteUserAccount()
        {

            foreach (var item in BankEmployeesManagement.dictionaryOfEmployees)
            {
                Console.WriteLine("Key in employee id");
                string id = Console.ReadLine();
                if (BankEmployeesManagement.dictionaryOfEmployees.ContainsKey(id))
                {
                    BankEmployeesManagement.dictionaryOfEmployees.Remove(item.Key);
                }
            }
        }

        public static BankEmployees CreateUserAccount()
        {
            Console.WriteLine("Creating by bank moderator..");
            Console.WriteLine("Processing.. please key in 2FA pin password");
            string EmployeeLogin2FARequired = Console.ReadLine();
            Console.WriteLine("successful");
            Console.WriteLine("Key in employee id");
            string bankemployee_id = Console.ReadLine();

            Console.WriteLine("Key in employee name");
            string bankemployee_name = Console.ReadLine();

            Console.WriteLine("Key in employee address");
            string bankemployee_address = Console.ReadLine();

            Console.WriteLine("Key in employee date of birth in format (MM DDD YYYY)");
            DateTime bankemployee_dob = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("key to employee designation: ");
            string bankemployee_designation = Console.ReadLine();

            Console.WriteLine("Key in employee years of service");
            string bankemployee_yos = Console.ReadLine();


            Console.WriteLine("Key in employee pw");
            Console.WriteLine("Password requirements: 1 lower, 1 upper, 1 digit, 6 - 24 chars:");
            string bankemployee_pw = Console.ReadLine();




            int validConditions = 0;

            foreach (char c in bankemployee_pw)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in bankemployee_pw)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            int count = 0;
            foreach (char c in bankemployee_pw)
            {
                count++;
                if (count >= 6 && count <= 24)
                {
                    validConditions++;
                    break;
                }
            }

            foreach (char c in bankemployee_pw)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0 || validConditions == 1 || validConditions == 2 || validConditions == 3)
            {
                Console.WriteLine("password not met");
            }
            else
            {
                Console.WriteLine("password is ok");
                Console.WriteLine("Writing to file..");
                Console.WriteLine("Congratulations, Account creation has been completed.....");
                var new_user = new BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);

                return new_user;
            }


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
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string bankemployee_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string bankemployee_pw = Console.ReadLine();
                if (BankEmployeesManagement.dictionaryOfEmployees.ContainsKey(bankemployee_id) && BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
                {
                    Console.WriteLine($"Congratulations, {BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!");
                    Console.WriteLine("ok user found");
                    Console.WriteLine($"Hello your info: { BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_id} { BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_name} { BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { BankEmployeesManagement.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
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
    }
}
