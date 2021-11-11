using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Interfaces;

namespace Gabriel_Bank_Management_System
{
    public class ManagerAccountManager : EmployeeAccountManager, IManagerAccountManager
    {

        public Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }

        
        private readonly IConsoleIO ConsoleIO;
        public ManagerAccountManager()
        {
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
            ConsoleIO = new ConsoleIO();
        }
        public ManagerAccountManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }

        public new BankManagers CreateUserAccount()
        {
            ConsoleIO.WriteLine("Creating by bank moderator..");
            ConsoleIO.WriteLine("Processing.. please key in 2FA pin password");
            string EmployeeLogin2FARequired = ConsoleIO.ReadLine();
            ConsoleIO.WriteLine("successful");
            ConsoleIO.WriteLine("Key in manager id");
            string bankmanager_id = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in manager name");
            string bankmanager_name = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in manager address");
            string bankmanager_address = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in manager date of birth in format (MM DDD YYYY)");
            DateTime bankmanager_dob = DateTime.Parse(ConsoleIO.ReadLine());

            ConsoleIO.WriteLine("key to manager designation: ");
            string bankmanager_designation = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in manager years of service");
            string bankmanager_yos = ConsoleIO.ReadLine();





            CustomerAccountManagerController validatepw = new CustomerAccountManagerController();
            string bankmanager_pw;
            do
            {
                ConsoleIO.WriteLine("Key in manager pw");
                ConsoleIO.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                bankmanager_pw = ConsoleIO.ReadLine();
            }
            while (validatepw.validatePassword(bankmanager_pw) == false);
            if (validatepw.validatePassword(bankmanager_pw) == true)
            {
                ConsoleIO.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

                var new_user = new BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
                return new_user;
            }
            return null;
            // form -> data validation
            //create customer
            // return new customer
        }

        public void UserLogin(ManagerAccountManager mam)
        {
            //bool exit = false;
            //int numberofTries = 4;
            //int input = 0;
            //while (!exit)
            //{
            //    input++;
            //    numberofTries--;
            //    ConsoleIO.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
            //    string bankmanager_id = ConsoleIO.ReadLine();
            //    ConsoleIO.WriteLine("and pw");
            //    string bankmanager_pw = ConsoleIO.ReadLine();
            //    if (mam.dictionaryOfManagers.ContainsKey(bankmanager_id) && mam.dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
            //    {
            //        ConsoleIO.WriteLine($"Congratulations, {mam.dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { mam.dictionaryOfManagers[bankmanager_id].bankmanager_id} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_name} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_designation} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
                    
            //        exit = true;
            //    }
            //    else
            //    {
            //        ConsoleIO.WriteLine("Incorrect user or pw");
            //    }
            //    if (input > 3)
            //    {
            //        ConsoleIO.WriteLine("Too many tries, please wait 5 mins");

            //        ConsoleIO.ReadLine(); Environment.Exit(0);

            //    }
            //    if (numberofTries == 0)
            //    {
            //        numberofTries = 4;
            //    }
            //}

        }

        public bool UserLogin(WebApiLibrary.Controllers.ManagerAccountManagerController mam, List<int> loginTries, string bankmanager_id, string bankmanager_pw)
        {
            throw new NotImplementedException();
        }
    }
}
