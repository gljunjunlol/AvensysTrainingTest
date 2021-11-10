using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers
{
    public class EmployeeAccountManager : IEmployeeAccountManager
    {
        private IList<BankEmployees> _employeeList;
        
        
        public EmployeeAccountManager()
        {
            _employeeList = new List<BankEmployees>();
        }
        public BankEmployees CreateUserAccount()
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





            CustomerAccountManager validatepw = new CustomerAccountManager(); string bankemployee_pw;

            do
            {
                Console.WriteLine("Key in employee pw"); Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");

                bankemployee_pw = Console.ReadLine();
            }
            while (validatepw.validatePassword(bankemployee_pw) == false);
            if (validatepw.validatePassword(bankemployee_pw) == true)
            {
                Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

                var new_user = new BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);
                return new_user;
            }
            return null;
            // form -> data validation
            //create customer
            // return new customer
        }
        List<int> loginTries = new List<int>();
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }
        public void References()
        {
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
        }
        public void UserLogin(EmployeeAccountManager eam)
        {
            bool exit = false;
            int numberofTries = 4;

            //int input = 0;
            while (!exit)
            {
                loginTries.Add(1);
                //input++;
                numberofTries--;
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string bankemployee_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string bankemployee_pw = Console.ReadLine();
                if (eam.dictionaryOfEmployees.ContainsKey(bankemployee_id) && eam.dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
                {
                    Console.WriteLine($"Congratulations, {eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_id} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");

                    exit = true;
                }
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (loginTries.Count > 3)
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
