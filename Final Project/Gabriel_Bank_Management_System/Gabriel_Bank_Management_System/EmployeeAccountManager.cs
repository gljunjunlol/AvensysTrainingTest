using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class EmployeeAccountManager : IEmployeeAccountManager
    {
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }
        private readonly IConsoleIO ConsoleIO;
        
        public void References()
        {
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
        }
        public EmployeeAccountManager()
        {
            ConsoleIO = new ConsoleIO();
        }
        public EmployeeAccountManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public BankEmployees CreateUserAccount()
        {
            ConsoleIO.WriteLine("Creating by bank moderator..");
            ConsoleIO.WriteLine("Processing.. please key in 2FA pin password");
            string EmployeeLogin2FARequired = ConsoleIO.ReadLine();
            ConsoleIO.WriteLine("successful");
            ConsoleIO.WriteLine("Key in employee id");
            string bankemployee_id = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in employee name");
            string bankemployee_name = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in employee address");
            string bankemployee_address = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in employee date of birth in format (MM DDD YYYY)");
            DateTime bankemployee_dob = DateTime.Parse(ConsoleIO.ReadLine());

            ConsoleIO.WriteLine("key to employee designation: ");
            string bankemployee_designation = ConsoleIO.ReadLine();

            ConsoleIO.WriteLine("Key in employee years of service");
            string bankemployee_yos = ConsoleIO.ReadLine();


            
            
            
            CustomerAccountManager validatepw = new CustomerAccountManager(); string bankemployee_pw;

            do
            {
                ConsoleIO.WriteLine("Key in employee pw"); ConsoleIO.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");

                bankemployee_pw = ConsoleIO.ReadLine();
            }
            while (validatepw.validatePassword(bankemployee_pw) == false);
            if (validatepw.validatePassword(bankemployee_pw) == true)
            {
                ConsoleIO.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

                var new_user = new BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);
                return new_user;
            }
            return null;
            // form -> data validation
            //create customer
            // return new customer
        }
        List<int> loginTries = new List<int>();
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
                ConsoleIO.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string bankemployee_id = ConsoleIO.ReadLine();
                ConsoleIO.WriteLine("and pw");
                string bankemployee_pw = ConsoleIO.ReadLine();
                if (eam.dictionaryOfEmployees.ContainsKey(bankemployee_id) && eam.dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
                {
                    ConsoleIO.WriteLine($"Congratulations, {eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_id} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");

                    exit = true;
                }
                else
                {
                    ConsoleIO.WriteLine("Incorrect user or pw");
                }
                if (loginTries.Count > 3)
                {
                    ConsoleIO.WriteLine("Too many tries, please wait 5 mins");
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
