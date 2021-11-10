using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers
{
    public class ManagerAccountManager : IManagerAccountManager
    {
        private IList<BankManagers> _managersList;

        
        
        public ManagerAccountManager()
        {
            _managersList = new List<BankManagers>();
        }

        public BankManagers CreateUserAccount()
        {
            Console.WriteLine("Creating by bank moderator..");
            Console.WriteLine("Processing.. please key in 2FA pin password");
            string EmployeeLogin2FARequired = Console.ReadLine();
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





            CustomerAccountManager validatepw = new CustomerAccountManager();
            string bankmanager_pw;
            do
            {
                Console.WriteLine("Key in manager pw");
                Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                bankmanager_pw = Console.ReadLine();
            }
            while (validatepw.validatePassword(bankmanager_pw) == false);
            if (validatepw.validatePassword(bankmanager_pw) == true)
            {
                Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

                var new_user = new BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
                return new_user;
            }
            return null;
            // form -> data validation
            //create customer
            // return new customer
        }
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }
        public void References()
        {
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
        }
        public void UserLogin(ManagerAccountManager mam)
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
                if (mam.dictionaryOfManagers.ContainsKey(bankmanager_id) && mam.dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
                {
                    Console.WriteLine($"Congratulations, {mam.dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { mam.dictionaryOfManagers[bankmanager_id].bankmanager_id} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_name} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_designation} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");

                    exit = true;
                }
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (input > 3)
                {
                    Console.WriteLine("Too many tries, please wait 5 mins");

                    Console.ReadLine(); Environment.Exit(0);

                }
                if (numberofTries == 0)
                {
                    numberofTries = 4;
                }
            }

        }
    }
}
