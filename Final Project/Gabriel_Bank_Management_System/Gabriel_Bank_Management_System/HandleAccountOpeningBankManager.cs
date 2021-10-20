using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    class HandleAccountOpeningBankManager : HandleAccountOpeningEmployee
    {
        public new static void DeleteUserAccount()
        {
            foreach (var item in BankManagersManagement.dictionaryOfManagers)
            {
                Console.WriteLine("Key in manager id");
                string id = Console.ReadLine();
                if (BankManagersManagement.dictionaryOfManagers.ContainsKey(id))
                {
                    BankManagersManagement.dictionaryOfManagers.Remove(item.Key);
                }
            }
        }

        public new static BankManagers CreateUserAccount()
        {
            Console.WriteLine("Creating by bank moderator..");
            Console.WriteLine("Processing.. please key in 2FA pin password");
            string ManagerLogin2FARequired = Console.ReadLine();
            Console.WriteLine("successful");
            Console.WriteLine("Key in manager id");
            string bankmanager_id = Console.ReadLine();

            Console.WriteLine("Key in manager name");
            string bankmanager_name = Console.ReadLine();

            Console.WriteLine("Key in manager address");
            string bankmanager_address = Console.ReadLine();

            Console.WriteLine("Key in manager date of birth in format (MM DDD YYYY)");
            DateTime bankmanager_dob = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("key to manager designation: ");
            string bankmanager_designation = Console.ReadLine();

            Console.WriteLine("Key in manager years of service");
            string bankmanager_yos = Console.ReadLine();


            Console.WriteLine("Key in manager pw");
            Console.WriteLine("Password requirements: 1 lower, 1 upper, 1 digit, 6 - 24 chars:");
            string bankmanager_pw = Console.ReadLine();




            int validConditions = 0;

            foreach (char c in bankmanager_pw)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in bankmanager_pw)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            int count = 0;
            foreach (char c in bankmanager_pw)
            {
                count++;
                if (count >= 6 && count <= 24)
                {
                    validConditions++;
                    break;
                }
            }

            foreach (char c in bankmanager_pw)
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
                var new_user = new BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);

                return new_user;
            }


            return null;






            // form -> data validation
            //create customer
            // return new customer
        }

        public new static void UserLogin()
        {
            bool exit = false;
            int numberofTries = 4;
            int input = 0;
            while (!exit)
            {
                input++;
                numberofTries--;
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string bankmanager_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string bankmanager_pw = Console.ReadLine();
                if (BankManagersManagement.dictionaryOfManagers.ContainsKey(bankmanager_id) && BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
                {
                    Console.WriteLine($"Congratulations, {BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!");
                    Console.WriteLine("ok user found");
                    Console.WriteLine($"Hello your info: { BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_id} { BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_name} { BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_designation} { BankManagersManagement.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
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
