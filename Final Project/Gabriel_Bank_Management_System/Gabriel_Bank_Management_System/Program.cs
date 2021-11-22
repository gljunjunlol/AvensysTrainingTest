using Gabriel_Bank_Management_System.Interfaces;
using Gabriel_Bank_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gabriel_Bank_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            List<int> loginTries = new List<int>();
            bool exit = false;
            IBankViewModel mv = new BankViewModel();
            do
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("Beginning the Program..");
                Console.WriteLine("ENTER YOUR CHOICE:");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Screen 1 -- customers only" + "\n1. Create User" 
                                + "\n2: Remove User" 
                                + "\nSeek help from bank operator" 
                                + "\n3: Ask user to log in" 
                                + "\n4: Return to home screen");
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
                                                Console.WriteLine("Hello, Welcome.");
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
                                            Console.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
                                            DateTime customer_dob = DateTime.Parse(Console.ReadLine());
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
                                            BankingWebAPI.Models.Customer new_user = mv.SignUp(input11, input12, input13, customer_dob, input16, input15, input17, "A" + input11, 0, Guid.Empty, false, 0);
                                            //Console.WriteLine(new_user);
                                            if (new_user != null)
                                            {

                                                if (cam.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                                                {
                                                    Console.WriteLine("Account already exists");
                                                    
                                                }
                                                else
                                                {
                                                    
                                                    mv.CustomerAdd(cam, cust, new_user.customer_id, new_user);
                                                    //cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
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
                                            
                                            Console.WriteLine("Key in customer id to remove");
                                            string customer_id = Console.ReadLine();
                                            mv.RemoveCustomers(cam, cust, customer_id);
                                            
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
                                                                    bool exit11 = false;
                                                                    while (!exit11)
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("In Savings account, key in operation" + "\n1: withdraw money" + "\n2: deposit money" + "\n3: view the balance" + "\n4: Exit savings operation");
                                                                        var choice2 = Console.ReadLine();

                                                                        switch (choice2)
                                                                        {
                                                                            case "1":
                                                                                {
                                                                                    Console.WriteLine("Key in customer id");
                                                                                    string customerid = Console.ReadLine();
                                                                                    
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customerid) && customerid == customer_id)
                                                                                    {
                                                                                        Console.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal");
                                                                                        Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                                                                                        decimal withdrawAmountKeyedInByCustomer = decimal.Parse(Console.ReadLine());
                                                                                        mv.customerWithdrawl(cam, eam, mam, customer_id, withdrawAmountKeyedInByCustomer, existingCustomer);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Account id not found");
                                                                                    }

                                                                                    break;
                                                                                }
                                                                            case "2":
                                                                                {
                                                                                    Console.WriteLine("Key in customer id");
                                                                                    string customerid = Console.ReadLine();
                                                                                    
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customerid) && customerid == customer_id)
                                                                                    {
                                                                                        Console.WriteLine("Key in amount for deposit - we will use cheque if more than 5k");
                                                                                        Customer existingCustomer = cam.dictionaryOfcustomers.Where(x => x.Key == customer_id).FirstOrDefault().Value;
                                                                                        decimal depositAmountKeyedInByCustomer = decimal.Parse(Console.ReadLine());
                                                                                        mv.customerDeposit(cam, eam, mam, customerid, depositAmountKeyedInByCustomer, existingCustomer);
                                                                                        
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Account id not found");
                                                                                    }
                                                                                    //customerDeposit(cam, eam, mam);
                                                                                    break;
                                                                                }
                                                                            case "3":
                                                                                {
                                                                                    SavingsController sav = new SavingsController();
                                                                                    Console.WriteLine("Key in customer id");
                                                                                    string customer_id4 = Console.ReadLine();
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customer_id4) && customer_id4 == customer_id)
                                                                                    {
                                                                                        mv.ViewBalance(cam, sav, customer_id4);
                                                                                        Console.WriteLine("");
                                                                                        Console.ReadLine();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("No such account");
                                                                                    }
                                                                                    
                                                                                    break;
                                                                                }
                                                                            case "4":
                                                                                {
                                                                                    exit11 = true;
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
                                                            case "2":
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Taking loan here");
                                                                    bool exit12 = false;
                                                                    while (!exit12)
                                                                    {
                                                                        Console.WriteLine("In Loan account, key in required operation" + "\n1: Apply for a new loan" + "\n2: Apply for additional loan" + "\n3: view the loan" + "\n4: Repay loan amount" + "\n5: Exit loans operation");
                                                                        var choice4 = Console.ReadLine();

                                                                        switch (choice4)
                                                                        {
                                                                            case "1":
                                                                                {
                                                                                    Console.WriteLine("Enter customer ID");
                                                                                    string customer_id2 = Console.ReadLine();
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customer_id2))
                                                                                    {
                                                                                        if (cam.dictionaryOfcustomers[customer_id2].customer_loan_applied == false)
                                                                                        {
                                                                                            Console.WriteLine("Enter loan application amount");
                                                                                            decimal loanamount = decimal.Parse(Console.ReadLine());
                                                                                            DateTime datetime = DateTime.Now;
                                                                                            Console.WriteLine("Taking a loan at: " + datetime + "");
                                                                                            Console.WriteLine("Key in amount of months to repay / installment");
                                                                                            decimal monthsIn = decimal.Parse(Console.ReadLine());
                                                                                            Console.WriteLine("Key in % of interest of loan");
                                                                                            decimal interestamount = decimal.Parse(Console.ReadLine());


                                                                                            mv.LoanAccount(cam, eam, mam, customer_id2, loanamount, monthsIn, interestamount);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("Already applied for loan which is unpaid");

                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Account doesn't exist in our database record");

                                                                                    }                                                                                   
                                                                                    break;
                                                                                }
                                                                            case "2":
                                                                                {
                                                                                    Console.WriteLine("Enter customer ID again to ensure of taking loan again");
                                                                                    string customer_id2 = Console.ReadLine();
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customer_id2) && customer_id2 == customer_id)
                                                                                    {
                                                                                        if (cam.dictionaryOfcustomers[customer_id2].customer_loan_applied == false)
                                                                                        {
                                                                                            Console.WriteLine("Enter loan application amount");
                                                                                            decimal loanamount = decimal.Parse(Console.ReadLine());
                                                                                            DateTime datetime = DateTime.Now;
                                                                                            Console.WriteLine("Taking a loan at: " + datetime + "");
                                                                                            Console.WriteLine("Key in amount of months to repay / installment");
                                                                                            decimal monthsIn = decimal.Parse(Console.ReadLine());
                                                                                            Console.WriteLine("Key in % of interest of loan");
                                                                                            decimal interestamount = decimal.Parse(Console.ReadLine());


                                                                                            mv.LoanAccount(cam, eam, mam, customer_id2, loanamount, monthsIn, interestamount);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("Sorry cant take additional loan as previous loan is still outstanding");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Account doesn't exist in our database record");
                                                                                    }
                                                                                    break;
                                                                                }
                                                                            case "3":
                                                                                {
                                                                                    TakingLoanController tk = new TakingLoanController();
                                                                                    Console.WriteLine("Enter customer ID");
                                                                                    string customer_id2 = Console.ReadLine();
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customer_id2) && customer_id2 == customer_id)
                                                                                    {
                                                                                        mv.ViewLoan(cam, tk, customer_id2);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Invalid Account");
                                                                                    }
                                                                                    
                                                                                    break;
                                                                                }
                                                                            case "4":
                                                                                {
                                                                                    Console.WriteLine("Enter customer ID");
                                                                                    string customer_id3 = Console.ReadLine();
                                                                                    if (cam.dictionaryOfcustomers.ContainsKey(customer_id3) && customer_id3 == customer_id)
                                                                                    {
                                                                                        if (cam.dictionaryOfcustomers[customer_id3].customer_loan_applied == true)
                                                                                        {
                                                                                            Console.WriteLine("Current loan is at " + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                                                                                            Console.WriteLine("E.g. key in 100 to repay 100 or / key in  6% to repay 6%");
                                                                                            string repayLoan = Console.ReadLine();
                                                                                            mv.RepayLoan(cam, eam, mam, customer_id3, repayLoan);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("No loan to repay");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Account doesn't exist in our database record");
                                                                                    }
                                                                                    break;
                                                                                }
                                                                            case "5":
                                                                                {
                                                                                    exit12 = true;
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
                                                Console.WriteLine("Savings app");
                                            break;
                                        }
                                    case 4:
                                        {
                                            
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
                                                    Console.WriteLine("Creating by bank moderator..");
                                                    Console.WriteLine("Processing.. please key in 2FA pin password");
                                                    string EmployeeLogin2FARequired = Console.ReadLine();
                                                    Console.WriteLine("successful");
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



                                                //string input21;
                                                Console.WriteLine("Key in employee date of birth in format (MM DDD YYYY)");
                                                DateTime customer_dob = DateTime.Parse(Console.ReadLine());

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
                                                BankingWebAPI.Models.BankEmployees new_user = mv.SignUpEmployee(input18, input19, input20, customer_dob, input22, input23, input24);
                                                //Console.WriteLine(new_user);
                                                if (new_user != null)
                                                {

                                                    if (eam.dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                                                    {
                                                        Console.WriteLine("Account already exists");
                                                        
                                                    }
                                                    else
                                                    {
                                                        mv.EmployeeAdd(eam, emp, new_user.bankemployee_id, new_user);
                                                        //eam.dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
                                                        FileManager fileHandling = new FileManager();
                                                        fileHandling.ReadingandWritingEmployee(new_user.bankemployee_id, cam, eam, mam);
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
                                                BankEmployeeController bemp = new BankEmployeeController();
                                                Console.WriteLine("Key in employee id");
                                                string employee_id = Console.ReadLine();
                                                mv.RemoveEmployees(eam, bemp, employee_id);
                                                break;
                                            }
                                        case 3:
                                            {
                                                BankEmployeeController bemp = new BankEmployeeController();
                                                mv.ListEmployees(eam, bemp);
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
                                                            Console.WriteLine("1: Find customer by ID: ");
                                                            Console.WriteLine("2: Find customer by name");
                                                            Console.WriteLine("3: Logout and go back");
                                                            var choice = Console.ReadLine();
                                                            switch (choice)
                                                            {
                                                                case "1":
                                                                    {
                                                                        Console.WriteLine("1. Search any customer information by customer ID");
                                                                        string customer_id = Console.ReadLine();
                                                                        mv.SearchCustomerByID(cam, customer_id);
                                                                        
                                                                        break;
                                                                    }
                                                                case "2":
                                                                    {

                                                                        Console.WriteLine("2. Search any customer information by customer name");
                                                                        string customer_name = Console.ReadLine();
                                                                        mv.SearchCustomerByName(cam, customer_name);
                                                                        
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
                            
                            Console.WriteLine("Exiting the program");
                            Console.WriteLine("ok cleared"); Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            bool insideMenu12 = false;
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Select Option (Involving Manager access only)");
                                Console.WriteLine("1: Create Bank Manager");
                                Console.WriteLine("2: View Managers");
                                Console.WriteLine("3: Login");
                                Console.WriteLine("4: Return to home screen");
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
                                                    Console.WriteLine("Creating by bank moderator..");
                                                    Console.WriteLine("Processing.. please key in 2FA pin password");
                                                    string EmployeeLogin2FARequired = Console.ReadLine();
                                                    Console.WriteLine("successful");
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



                                                //string input28;
                                                Console.WriteLine("Key in manager date of birth in format (MM DDD YYYY)");
                                                DateTime manager_dob = DateTime.Parse(Console.ReadLine());

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
                                                BankingWebAPI.Models.BankManagers new_user = mv.SignUpManager(input25, input26, input27, manager_dob, input29, input30, input31);
                                                //Console.WriteLine(new_user);
                                                if (new_user != null)
                                                {

                                                    if (mam.dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
                                                    {
                                                        Console.WriteLine("Account already exists");

                                                    }
                                                    else
                                                    {
                                                        mv.ManagerAdd(mam, new_user.bankmanager_id, new_user);
                                                        //mam.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
                                                        FileManager fileHandling = new FileManager();
                                                        fileHandling.ReadingandWritingManager(new_user.bankmanager_id, cam, eam, mam);
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
                                                mv.ViewManagers(mam);
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
                                                                        Console.WriteLine("1. Search any customer information by customer ID");
                                                                        string customer_id = Console.ReadLine();
                                                                        mv.SearchCustomerByID(cam, customer_id);
                                                                        break;
                                                                    }
                                                                case "2":
                                                                    {
                                                                        Console.WriteLine("1. Search any customer information by customer name");
                                                                        string customer_name = Console.ReadLine();
                                                                        mv.SearchCustomerByName(cam, customer_name);
                                                                        break;
                                                                    }
                                                                case "3":
                                                                    {
                                                                        Console.WriteLine("1. List of total customers / 1: View all users (customers)");
                                                                        Console.WriteLine("2: List of Total Loan amount");
                                                                        Console.WriteLine("3: List of Total saving account of customers / budgeting purposes / manage tracking");
                                                                        Console.WriteLine("4: Go back to the previous screen (Screen 1) / Logout and go back");
                                                                        var choice2 = Console.ReadLine();
                                                                        switch (choice2)
                                                                        {
                                                                            case "1":
                                                                                {
                                                                                    
                                                                                    mv.ListCustomers(cam, cust);
                                                                                    break;
                                                                                }
                                                                            case "2":
                                                                                {
                                                                                    TakingLoanController tk = new TakingLoanController();
                                                                                    mv.TotalLoanAmount(cam, tk);
                                                                                    break;
                                                                                }
                                                                            case "3":
                                                                                {
                                                                                    SavingsController sav = new SavingsController();
                                                                                    mv.TotalSavingsAccount(cam, sav);
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
                                    Console.WriteLine("");
                            }
                            while (insideMenu12);                   
                            Console.WriteLine("ok seen manager"); Console.ReadLine();


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
            Console.WriteLine("Exiting the program");
            Console.ReadLine();
        }
        private static void Initialize()
        {
            Console.WriteLine("We have the Requirements and necessary information:");
            Console.WriteLine("3 different type of users in the program: mainly customers, bank employees, bank managers");
            Console.WriteLine("customers with a loan and a savings account");
            Console.WriteLine("Employees to view customer info: ");
            Console.WriteLine("Bank Managers to view all customers + additional function:\n");
            Console.WriteLine("");
            Console.WriteLine("*******************************");
            Console.WriteLine(" << Bank Management System >> \n");
            Console.WriteLine("1: Bank customers (Create new users)\n");
            Console.WriteLine("2: Bank Employee (Find customers by Id/ name)\n ");
            Console.WriteLine("3: Bank Manager(View all)\n");
            Console.WriteLine("4: Exit the room\n");
            Console.WriteLine("*******************************");
        }
    }
}
