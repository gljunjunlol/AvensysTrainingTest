using Gabriel_Bank_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Common.Common;
using WebApiLibrary.Controllers;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;


namespace Gabriel_Bank_Management_System
{
    public class Program
    {
        private readonly IConsoleIO ConsoleIO;

        public Program(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public Program()
        {
            ConsoleIO = new ConsoleIO();
        }
        static void Main(string[] args)
        {
            CustomerAccountManagerController cam = new CustomerAccountManagerController(); EmployeeAccountManagerController eam = new EmployeeAccountManagerController(); EmployeeAccountManager emp = new EmployeeAccountManager(); ManagerAccountManagerController mam = new ManagerAccountManagerController(); ManagerAccountManager mgr = new ManagerAccountManager();
            CustomersManager cam1 = new CustomersManager(); BankEmployeesManager eam1 = new BankEmployeesManager();
            BankManagersManager mam1 = new BankManagersManager();


            List<int> loginTries = new List<int>(); Program p = new Program(); ConsoleIO ConsoleIO = new ConsoleIO(); 
            
            
            
            bool exit = false;

            BankViewModel mv = new BankViewModel();


            do
            {
                ConsoleIO.WriteLine("Starting Program..");

                p.Initialize();
                ConsoleIO.WriteLine("ENTER YOUR CHOICE:");
                var action = ConsoleIO.ReadLine();

                switch (action)
                {
                    case "1":
                        {

                            Console.Clear();

                            ConsoleIO.WriteLine("Screen 1 -- customers only" + "\n1. Create User" + "\n2: Remove User" + "\nSeek help from bank operator" + "\n3: Ask user to log in" + "\n4: Return to home screen");

                            string inputStr = Console.ReadLine();

                            mv.ParseInputString(inputStr, out var input);

                            if (input == null)
                                Console.WriteLine("Invalid input." + Environment.NewLine);
                            else
                                switch (input)
                                {
                                    case 1:
                                        {
                                            bool insideMenu = true;
                                            string input11;
                                            do
                                            {
                                                Console.WriteLine("Key in customer id - 4 digits");
                                                input11 = Console.ReadLine();
                                                string output = mv.CheckIdNumber(input11);
                                                if (!string.IsNullOrWhiteSpace(output))
                                                    Console.WriteLine(output);
                                                else
                                                    insideMenu = false;
                                            }
                                            while (insideMenu);
                                            insideMenu = true;
                                            string input12;
                                            do
                                            {
                                                Console.WriteLine("Key in customer name");
                                                input12 = Console.ReadLine();
                                                string output = mv.CheckUserName(input12);
                                                if (!string.IsNullOrWhiteSpace(output))
                                                    Console.WriteLine(output);
                                                else
                                                    insideMenu = false;

                                            }
                                            while (insideMenu);
                                            insideMenu = true;
                                            string input13;


                                            Console.WriteLine("Key in customer address");
                                            input13 = Console.ReadLine();
                                            


                                            string input14;
                                            Console.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
                                            DateTime customer_dob = DateTime.Parse(ConsoleIO.ReadLine());

                                            Console.WriteLine(customer_dob);
                                            
                                            string input15;
                                            do
                                            {
                                                Console.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx");
                                                input15 = Console.ReadLine();

                                                
                                            }
                                            while (mv.validatePhone(input15) == false);
                                            
                                            insideMenu = true;
                                            string input16;
                                            do
                                            {
                                                Console.WriteLine("Key in user email format (e.g. john@mail.com)");
                                                input16 = Console.ReadLine();

                                                insideMenu = false;
                                            }
                                            while (mv.validateEmail(input16) == false);
                                            
                                            insideMenu = true;
                                            string input17;
                                            do
                                            {
                                                Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                                                input17 = Console.ReadLine();

                                                insideMenu = false;
                                            }
                                            while (mv.validatePassword(input17) == false);
                                            while (insideMenu) ;
                                            WebApiLibrary.Models.Customer new_user = mv.SignUp(input11, input12, input13, customer_dob, input15, input16, input17, " ", 0, Guid.Empty, false, 0);
                                            //Console.WriteLine(new_user);
                                            if (new_user != null)
                                            {

                                                if (cam.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                                                {
                                                    Console.WriteLine("Account already exists");
                                                    
                                                }
                                                else
                                                {
                                                    cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                                                    FileManager fileHandling = new FileManager();
                                                    fileHandling.ReadingandWritingcustomer(new_user.customer_id, cam, eam, mam);
                                                    
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("User creation failed try again");
                                                
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            //RemoveCustomers(cam);
                                            break;
                                        }
                                    case 3:
                                        {


                                            bool exited = false;
                                            int numberofTries = 4;
                                            int loginAttempts = 0;
                                            for (int i = 0; i <3; i++)
                                            {
                                                numberofTries--;
                                                Console.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");

                                                string customer_id = Console.ReadLine();
                                                Console.WriteLine("and pw");
                                                string customer_pw = Console.ReadLine();
                                                bool checkLoginOutput = mv.UserLogin(cam, loginTries, customer_id, customer_pw);
                                                
                                                //bool checkLoginOutput = cm.UserLogin(cm, loginTries, customer_id, customer_pw);
                                                //if (checkLoginOutput == false)
                                                //if (cam.UserLogin(cam, loginTries, customer_id, customer_pw) == true)
                                                if (checkLoginOutput == true)
                                                {
                                                    while (!exited)
                                                    {

                                                        Console.WriteLine(DateTime.Now.ToString());
                                                        Console.WriteLine("1 : Savings" + "\n2 : Loan" + "\n3 : Go Back");


                                                        var choice = Console.ReadLine();

                                                        switch (choice)
                                                        {
                                                            case "1":
                                                                {
                                                                    Savings saving = new Savings();
                                                                    saving.performOperation(cam, eam, mam);
                                                                    exited = true;
                                                                    break;
                                                                }
                                                            case "2":
                                                                {


                                                                    TakingLoan tk = new TakingLoan();
                                                                    tk.performOperation(cam, eam, mam);
                                                                    exited = true;
                                                                    break;
                                                                }
                                                            default:
                                                                {
                                                                    exited = true;
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    loginAttempts++;
                                                }


                                                
                                                

                                                
                                                
                                            }
                                            if (loginAttempts > 2)
                                                Console.WriteLine("Incorrect user or pw");
                                            //Console.WriteLine("Too many tries, please wait 5 mins");
                                            else
                                                Console.WriteLine("Login successful");






                                            break;
                                        }
                                    case 4:
                                        {
                                            exit = true;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }

















                            



                            break;
                        }
                    case "2":
                        {


                            Console.Clear();
                            bool insideMenu10 = false;
                            do
                            {
                                Console.WriteLine("Screen 1");
                                Console.WriteLine("Select Option");
                                Console.WriteLine("1. Create Bank Employee a/c");
                                Console.WriteLine("2: Remove Bank Employee");
                                Console.WriteLine("3: View all Employee");
                                Console.WriteLine("4: Ask employee to log in");
                                Console.WriteLine("5: Return to home screen");
                                string inputStr = Console.ReadLine();

                                mv.ParseInputString(inputStr, out var input);

                                if (input == null)
                                    Console.WriteLine("Invalid input." + Environment.NewLine);
                                else

                                    switch (input)
                                    {
                                        case 1:
                                            {
                                                bool insideMenu = true;
                                                string input18;
                                                do
                                                {
                                                    ConsoleIO.WriteLine("Creating by bank moderator..");
                                                    ConsoleIO.WriteLine("Processing.. please key in 2FA pin password");
                                                    string EmployeeLogin2FARequired = ConsoleIO.ReadLine();
                                                    ConsoleIO.WriteLine("successful");
                                                    Console.WriteLine("Key in employee id - 4 digits");
                                                    input18 = Console.ReadLine();
                                                    string output = mv.CheckIdNumber(input18);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;
                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                string input19;
                                                do
                                                {
                                                    Console.WriteLine("Key in employee name");
                                                    input19 = Console.ReadLine();
                                                    string output = mv.CheckUserName(input19);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;

                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                string input20;


                                                Console.WriteLine("Key in employee address");
                                                input20 = Console.ReadLine();



                                                string input21;
                                                Console.WriteLine("Key in employee date of birth in format (MM DDD YYYY)");
                                                DateTime customer_dob = DateTime.Parse(ConsoleIO.ReadLine());

                                                Console.WriteLine(customer_dob);

                                                string input22;
                                                Console.WriteLine("key to employee designation: ");
                                                input22 = Console.ReadLine();

                                                string input23;
                                                Console.WriteLine("Key in employee years of service");
                                                input23 = Console.ReadLine();


                                                string input24;
                                                do
                                                {
                                                    Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                                                    input24 = Console.ReadLine();

                                                    insideMenu = false;
                                                }
                                                while (mv.validatePassword(input24) == false);
                                                while (insideMenu) ;
                                                WebApiLibrary.Models.BankEmployees new_user = mv.SignUpEmployee(input18, input19, input20, customer_dob, input22, input23, input24);
                                                //Console.WriteLine(new_user);
                                                if (new_user != null)
                                                {

                                                    if (eam.dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                                                    {
                                                        ConsoleIO.WriteLine("Account already exists");
                                                        
                                                    }
                                                    else
                                                    {
                                                        eam.dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
                                                        
                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleIO.WriteLine("User creation failed try again");
                                                }







                                                //AddBankEmployees(cam, eam, mam);
                                                break;
                                            }
                                        case 2:
                                            {
                                                BankEmployeesManager bemgr = new BankEmployeesManager();
                                                bemgr.RemoveEmployees(eam);
                                                break;
                                            }
                                        case 3:
                                            {
                                                BankEmployeesManager bemgr = new BankEmployeesManager();
                                                bemgr.ListEmployees(eam);
                                                break;
                                            }
                                        case 4:
                                            {
                                                bool exited1 = false;
                                                int numberofTries = 4;
                                                int loginAttempts = 0;
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    numberofTries--;
                                                    Console.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");

                                                    string bankemployee_id = Console.ReadLine();
                                                    Console.WriteLine("and pw");
                                                    string bankemployee_pw = Console.ReadLine();
                                                    bool checkLoginOutput = mv.UserLogin(eam, loginTries, bankemployee_id, bankemployee_pw);

                                                    
                                                    if (checkLoginOutput == true)
                                                    {
                                                        
                                                        while (!exited1)
                                                        {
                                                            ConsoleIO.WriteLine("1: Find customer by ID: ");
                                                            ConsoleIO.WriteLine("2: Find customer by name");
                                                            ConsoleIO.WriteLine("3: Logout and go back");
                                                            var choice = ConsoleIO.ReadLine();
                                                            switch (choice)
                                                            {
                                                                case "1":
                                                                    {
                                                                        BankEmployeesManager bemgr = new BankEmployeesManager();
                                                                        bemgr.SearchCustomerByID(cam);
                                                                        
                                                                        break;
                                                                    }
                                                                case "2":
                                                                    {
                                                                        BankEmployeesManager bemgr = new BankEmployeesManager();
                                                                        bemgr.SearchCustomerByName(cam);
                                                                        
                                                                        break;
                                                                    }
                                                                case "3":
                                                                    {
                                                                        exited1 = true;
                                                                        break;
                                                                    }
                                                                default:
                                                                    {
                                                                        
                                                                        break;
                                                                    }
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        loginAttempts++;
                                                    }







                                                }
                                                if (loginAttempts > 2)
                                                    Console.WriteLine("Incorrect user or pw");
                                                //Console.WriteLine("Too many tries, please wait 5 mins");
                                                else
                                                    Console.WriteLine("Go back");


                                                break;
                                            }
                                        case 5:
                                            {
                                                exit = true;
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }
                            }
                            while (insideMenu10);
                            
                            ConsoleIO.WriteLine("Exiting the program");







                            ConsoleIO.WriteLine("ok cleared"); ConsoleIO.ReadLine();


                            break;
                        }
                    case "3":
                        {
                            bool insideMenu12 = false;
                            Console.Clear();
                            //mam1.performOperationAdvanced(cam, cam1, eam, eam1, mam, mam1);
                            do
                            {
                                ConsoleIO.WriteLine("Select Option (Involving Manager access only)");
                                ConsoleIO.WriteLine("1: Create Bank Manager");
                                ConsoleIO.WriteLine("2: View Managers");
                                ConsoleIO.WriteLine("3: Login");
                                ConsoleIO.WriteLine("4: Return to home screen");
                                string inputStr = Console.ReadLine();

                                mv.ParseInputString(inputStr, out var input);

                                if (input == null)
                                    Console.WriteLine("Invalid input." + Environment.NewLine);
                                else
                                    switch (input)
                                    {
                                        case 1:
                                            {
                                                bool insideMenu = true;
                                                string input25;
                                                do
                                                {
                                                    ConsoleIO.WriteLine("Creating by bank moderator..");
                                                    ConsoleIO.WriteLine("Processing.. please key in 2FA pin password");
                                                    string EmployeeLogin2FARequired = ConsoleIO.ReadLine();
                                                    ConsoleIO.WriteLine("successful");
                                                    Console.WriteLine("Key in manager id - 4 digits");
                                                    input25 = Console.ReadLine();
                                                    string output = mv.CheckIdNumber(input25);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;
                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                string input26;
                                                do
                                                {
                                                    Console.WriteLine("Key in manager name");
                                                    input26 = Console.ReadLine();
                                                    string output = mv.CheckUserName(input26);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;

                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                string input27;


                                                Console.WriteLine("Key in manager address");
                                                input27 = Console.ReadLine();



                                                string input28;
                                                Console.WriteLine("Key in manager date of birth in format (MM DDD YYYY)");
                                                DateTime manager_dob = DateTime.Parse(ConsoleIO.ReadLine());

                                                Console.WriteLine(manager_dob);

                                                string input29;
                                                Console.WriteLine("key to manager designation: ");
                                                input29 = Console.ReadLine();

                                                string input30;
                                                Console.WriteLine("Key in manager years of service");
                                                input30 = Console.ReadLine();


                                                string input31;
                                                do
                                                {
                                                    Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                                                    input31 = Console.ReadLine();

                                                    insideMenu = false;
                                                }
                                                while (mv.validatePassword(input31) == false);
                                                while (insideMenu) ;
                                                WebApiLibrary.Models.BankManagers new_user = mv.SignUpManager(input25, input26, input27, manager_dob, input29, input30, input31);
                                                //Console.WriteLine(new_user);
                                                if (new_user != null)
                                                {

                                                    if (mam.dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
                                                    {
                                                        ConsoleIO.WriteLine("Account already exists");

                                                    }
                                                    else
                                                    {
                                                        mam.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);

                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleIO.WriteLine("User creation failed try again");
                                                }
                                                //AddBankManagers(cam, eam, mam);
                                                break;
                                            }
                                        case 2:
                                            {
                                                //ViewManagers(mam);
                                                break;
                                            }
                                        case 3:
                                            {
                                                bool exited1 = false;
                                                int numberofTries = 4;
                                                int loginAttempts = 0;
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    numberofTries--;
                                                    Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");

                                                    string bankmanager_id = Console.ReadLine();
                                                    Console.WriteLine("and pw");
                                                    string bankmanager_pw = Console.ReadLine();
                                                    bool checkLoginOutput = mv.UserLogin(mam, loginTries, bankmanager_id, bankmanager_pw);


                                                    if (checkLoginOutput == true)
                                                    {

                                                        while (!exited1)
                                                        {
                                                            Console.WriteLine("1: Find customer by ID: ");
                                                            Console.WriteLine("2: Find customer by name");
                                                            Console.WriteLine("3: Advanced access");
                                                            Console.WriteLine("4: Logout and go back");
                                                            var choice = Console.ReadLine();
                                                            switch (choice)
                                                            {
                                                                case "1":
                                                                    {
                                                                        eam1.SearchCustomerByID(cam);
                                                                        break;
                                                                    }
                                                                case "2":
                                                                    {
                                                                        eam1.SearchCustomerByName(cam);
                                                                        break;
                                                                    }
                                                                case "3":
                                                                    {
                                                                        Console.WriteLine("1. List of total customers / 1: View all users (customers)");
                                                                        Console.WriteLine("2: List of Total Loan amount");
                                                                        Console.WriteLine("3: List of Total saving account of customers / budgeting purposes / manage tracking");
                                                                        Console.WriteLine("4: Go back to the previous screen (Screen 1) / Logout and go back");
                                                                        var choice2 = ConsoleIO.ReadLine();
                                                                        switch (choice2)
                                                                        {
                                                                            case "1":
                                                                                {
                                                                                    cam1.ListCustomers(cam);
                                                                                    break;
                                                                                }
                                                                            case "2":
                                                                                {
                                                                                    BankManagersManager bmgt = new BankManagersManager();
                                                                                    bmgt.TotalLoanAmount(cam);
                                                                                    break;
                                                                                }
                                                                            case "3":
                                                                                {
                                                                                    BankManagersManager bmgt = new BankManagersManager();
                                                                                    bmgt.TotalSavingsAccount(cam);
                                                                                    break;
                                                                                }
                                                                            case "4":
                                                                                {
                                                                                    exit = true;
                                                                                    break;
                                                                                }
                                                                            default:
                                                                                {
                                                                                    break;
                                                                                }
                                                                        }


                                                                        //mam1.performOperationAdvancedInternal1(cam, cam1, eam, eam1, mam, mam1);
                                                                        break;
                                                                    }
                                                                case "4":
                                                                    {
                                                                        exited1 = true;
                                                                        break;
                                                                    }
                                                                default:
                                                                    {
                                                                        break;
                                                                    }
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        loginAttempts++;
                                                    }







                                                }
                                                if (loginAttempts > 2)
                                                    Console.WriteLine("Incorrect user or pw");
                                                //Console.WriteLine("Too many tries, please wait 5 mins");
                                                else
                                                    Console.WriteLine("Go back");
                                                //ManagerAccountManager mgr = new ManagerAccountManager();
                                                //mgr.UserLogin(mam);
                                                //performOperationAdvancedInternal(cam, cam1, eam, eam1, mam, mam1);
                                                break;
                                            }
                                        case 4:
                                            {
                                                exit = true;

                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }
                                    ConsoleIO.WriteLine("");
                            }
                            while (insideMenu12);
                            
                            
                            
                            
                            
                            
                            ConsoleIO.WriteLine("ok seen manager"); ConsoleIO.ReadLine();


                            break;
                        }
                    case "4":
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                
            }
            while (!exit);
            ConsoleIO.WriteLine("Exiting the program");
            ConsoleIO.ReadLine();







            while (!exit)
            {
                try
                {
                    //p.performOperation(cam, cam1, eam, eam1, mam, mam1, loginTries, p);
                }
                catch (Exception)
                {
                    Console.Write("Incorrect format. Please try again");
                    ConsoleIO.ReadLine();
                }
            }
            
            
            

        }
        public void performOperation(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1, List<int> loginTries, Program p)
        {
            
        }
        public void Initialize()
        {
            ConsoleIO.WriteLine("We have the Requirements and necessary information:");
            ConsoleIO.WriteLine("3 different type of users in the program: mainly customers, bank employees, bank managers");
            ConsoleIO.WriteLine("customers with a loan and a savings account");
            ConsoleIO.WriteLine("Employees to view customer info: ");
            ConsoleIO.WriteLine("Bank Managers to view all customers + additional function: \n");
            ConsoleIO.WriteLine("________________________________");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|________________________________");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("");
            ConsoleIO.WriteLine("*******************************");
            ConsoleIO.WriteLine(" << Bank Management System >> \n");
            ConsoleIO.WriteLine("1: Bank customers (Create new users)\n");
            ConsoleIO.WriteLine("2: Bank Employee (Find customers / Employee Information\n ");
            ConsoleIO.WriteLine("3: Bank Manager\n");
            ConsoleIO.WriteLine("4: Exit the room\n");
            ConsoleIO.WriteLine("*******************************");
            

        }
    }
}
