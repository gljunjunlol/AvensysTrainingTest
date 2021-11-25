﻿using Gabriel_Bank_Management_System.Interfaces;
using Gabriel_Bank_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Gabriel_Bank_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            bool exit = false;
            IBankViewModel mv = new BankViewModel(new HttpClient());
            do
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("Beginning the Program..");
                Initialize();
                Console.WriteLine("ENTER YOUR CHOICE:");
                string action = Console.ReadLine();
                mv.ParseInputString(action, out var action1);
                if (action1 == null)
                    Console.WriteLine("Invalid input." + Environment.NewLine);
                else

                    switch (action1)
                    {
                        case 1:
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
                                                do
                                                {
                                                    Console.WriteLine("Key in customer address");
                                                    input13 = Console.ReadLine();
                                                    if (input13 == string.Empty)
                                                    {
                                                        Console.WriteLine("Invalid input");
                                                    }

                                                    else
                                                    {
                                                        insideMenu = false;
                                                    }
                                                        
                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                string inputStr33;
                                                do
                                                {
                                                    Console.WriteLine("Key in customer date of birth in format (MM DDD YYYY)");
                                                    inputStr33 = Console.ReadLine();
                                                    mv.ParseInputDate(inputStr33, out var customer_dob);
                                                    if (customer_dob == null)
                                                        Console.WriteLine("Wrong date format." + Environment.NewLine);
                                                    else
                                                        insideMenu = false; 
                                                    
                                                }
                                                while (insideMenu);
                                                insideMenu = true;
                                                DateTime customer_dob1 = DateTime.Parse(inputStr33);
                                                string input15;
                                                do
                                                {
                                                    Console.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx");
                                                    input15 = Console.ReadLine();
                                                    string output = mv.validatePhone(input15);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;


                                                }
                                                while (insideMenu);

                                                insideMenu = true;
                                                string input16;
                                                do
                                                {
                                                    Console.WriteLine("Key in user email format (e.g. john@mail.com)");
                                                    input16 = Console.ReadLine();
                                                    string output = mv.validateEmail(input16);
                                                    if (!string.IsNullOrWhiteSpace(output))
                                                        Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;
                                                }
                                                while (insideMenu);

                                                insideMenu = true;
                                                string input17;
                                                do
                                                {
                                                    Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
                                                    input17 = Console.ReadLine();
                                                    IList<string> outputList = mv.validatePassword(input17);
                                                    if (outputList.Count != 0)
                                                        foreach (string output in outputList)
                                                            Console.WriteLine(output);
                                                    else
                                                        insideMenu = false;
                                                    //insideMenu = false;
                                                }
                                                //while (mv.validatePassword(input17) == false);
                                                while (insideMenu) ;
                                                string signUpOutput = mv.SignUp(input11, input12, input13, customer_dob1, input16, input15, input17, "A" + input11, 0, Guid.Empty, false, 0);
                                                Console.WriteLine(signUpOutput);
                                                Console.ReadLine();
                                                break;
                                            }
                                        case 2:
                                            {
                                            
                                                Console.WriteLine("Key in customer id to remove");
                                                string customer_id = Console.ReadLine();
                                                string remove = mv.RemoveCustomers(customer_id);
                                                Console.WriteLine(remove);
                                                Console.ReadLine();
                                            
                                                break;
                                            }
                                        case 3:
                                            {
                                                bool exited = false;
                                                int numberofTries = 4;
                                                int loginAttempts = 0;
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    numberofTries--;
                                                    Console.WriteLine("Key in your login information" + "\nEnter login id " + " (" + "number of tries left " + numberofTries + " )");

                                                    string customer_id = Console.ReadLine();
                                                    Console.WriteLine("and pw");
                                                    string customer_pw = Console.ReadLine();
                                                    (string, bool?) checkLoginOutput = mv.CheckLogin(customer_id, customer_pw);
                                                    if (!string.IsNullOrWhiteSpace(checkLoginOutput.Item1))
                                                    {
                                                        while (!exited)
                                                        {
                                                            Console.WriteLine(checkLoginOutput.Item1);
                                                            if (checkLoginOutput.Item2 == null)
                                                            {
                                                                Console.WriteLine("Login error has occured.");
                                                            }
                                                            if (checkLoginOutput.Item2 == true)
                                                            {
                                                                inputStr = Console.ReadLine();
                                                                mv.ParseInputStringInt(inputStr, out var input33);
                                                                if (input == null)
                                                                    Console.WriteLine("Invalid input." + Environment.NewLine);
                                                                else
                                                                {

                                                                    switch (input33)
                                                                    {
                                                                        case 1:
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
                                                                                                Console.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal");
                                                                                                string inputStr2 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr2, out var withdrawAmountKeyedInByCustomer);

                                                                                                if (withdrawAmountKeyedInByCustomer == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                }
                                                                                                    
                                                                                                else
                                                                                                {
                                                                                                    mv.customerWithdrawl(customer_id, withdrawAmountKeyedInByCustomer.Value);
                                                                                                }
                                                                                                

                                                                                                break;
                                                                                            }
                                                                                        case "2":
                                                                                            {
                                                                                                Console.WriteLine("Key in amount for deposit - we will use cheque if more than 5k");
                                                                                                string inputStr3 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr3, out var depositAmountKeyedInByCustomer);

                                                                                                if (depositAmountKeyedInByCustomer == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    mv.customerDeposit(customer_id, depositAmountKeyedInByCustomer.Value);
                                                                                                }
                                                                                                
                                                                                                break;
                                                                                            }
                                                                                        case "3":
                                                                                            {
                                                                                                mv.ViewBalance(customer_id);

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
                                                                        case 2:
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
                                                                                                Console.WriteLine("Enter loan application amount");
                                                                                                string inputStr2 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr2, out var loanamount);

                                                                                                if (loanamount == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                DateTime datetime = DateTime.Now;
                                                                                                Console.WriteLine("Taking a loan at: " + datetime + "");
                                                                                                Console.WriteLine("Key in amount of months to repay / installment");
                                                                                                string inputStr3 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr3, out var monthsIn);

                                                                                                if (monthsIn == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                Console.WriteLine("Key in % of interest of loan");
                                                                                                string inputStr4 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr4, out var interestamount);

                                                                                                if (interestamount == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    mv.LoanAccount(customer_id, loanamount.Value, monthsIn.Value, interestamount.Value);
                                                                                                }


                                                                                                
                                                                                                break;
                                                                                            }
                                                                                        case "2":
                                                                                            {
                                                                                                Console.WriteLine("Enter customer ID again to ensure of taking loan again");
                                                                                                string customer_id2 = Console.ReadLine();
                                                                                                Console.WriteLine("Enter loan application amount");
                                                                                                string inputStr2 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr2, out var loanamount);

                                                                                                if (loanamount == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                DateTime datetime = DateTime.Now;
                                                                                                Console.WriteLine("Taking a loan at: " + datetime + "");
                                                                                                Console.WriteLine("Key in amount of months to repay / installment");
                                                                                                string inputStr3 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr3, out var monthsIn);

                                                                                                if (monthsIn == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                Console.WriteLine("Key in % of interest of loan");
                                                                                                string inputStr4 = Console.ReadLine();
                                                                                                mv.ParseInputDecimal(inputStr4, out var interestamount);

                                                                                                if (interestamount == null)
                                                                                                {
                                                                                                    Console.WriteLine("Key in valid input" + Environment.NewLine);
                                                                                                    Console.ReadLine();
                                                                                                    break;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    mv.LoanAccount(customer_id, loanamount.Value, monthsIn.Value, interestamount.Value);
                                                                                                }
                                                                                                break;
                                                                                            }
                                                                                        case "3":
                                                                                            {
                                                                                                mv.ViewLoan(customer_id);

                                                                                                break;
                                                                                            }
                                                                                        case "4":
                                                                                            {
                                                                                                Console.WriteLine("Enter customer ID");
                                                                                                string customer_id3 = Console.ReadLine();
                                                                                                Console.WriteLine("E.g. key in 100 to repay 100 or / key in  6% to repay 6%");
                                                                                                string repayLoan = Console.ReadLine();
                                                                                                mv.RepayLoan(customer_id3, repayLoan);
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
                                                        else
                                                            Console.WriteLine("Savings app");
                                                        break;
                                                    }
                                                }
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
                        case 2:
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
                                                    do
                                                    {
                                                        Console.WriteLine("Key in employee address");
                                                        input20 = Console.ReadLine();
                                                        if (input20 == string.Empty)
                                                        {
                                                            Console.WriteLine("Invalid input");
                                                        }

                                                        else
                                                        {
                                                            insideMenu = false;
                                                        }

                                                    }
                                                    while (insideMenu);
                                                    insideMenu = true;
                                                    string inputStr34;
                                                    do
                                                    {
                                                        Console.WriteLine("Key in employee date of birth in format (MM DDD YYYY)");
                                                        inputStr34 = Console.ReadLine();
                                                        mv.ParseInputDate(inputStr34, out var bankemployee_dob);
                                                        if (bankemployee_dob == null)
                                                            Console.WriteLine("Wrong date format." + Environment.NewLine);
                                                        else
                                                            insideMenu = false;

                                                    }
                                                    while (insideMenu);
                                                    insideMenu = true;
                                                    DateTime bankemployee_dob1 = DateTime.Parse(inputStr34);

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
                                                        IList<string> outputList = mv.validatePassword(input24);
                                                        if (outputList.Count != 0)
                                                            foreach (string output in outputList)
                                                                Console.WriteLine(output);
                                                        else
                                                            insideMenu = false;
                                                        
                                                    }
                                                    //while (mv.validatePassword(input24) == false);
                                                    while (insideMenu) ;
                                                    string new_user = mv.SignUpEmployee(input18, input19, input20, bankemployee_dob1, input22, input23, input24);
                                                    Console.WriteLine(new_user);
                                                    Console.ReadLine();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("Key in employee id");
                                                    string employee_id = Console.ReadLine();
                                                    mv.RemoveEmployees(employee_id);
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    mv.ListEmployees();
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
                                                        (string, bool?) checkLoginOutput = mv.CheckEmployeeLogin(bankemployee_id, bankemployee_pw);
                                                        if (!string.IsNullOrWhiteSpace(checkLoginOutput.Item1))
                                                        {
                                                            while (!exited1)
                                                            {
                                                                Console.WriteLine(checkLoginOutput.Item1);
                                                                if (checkLoginOutput.Item2 == null)
                                                                {
                                                                    Console.WriteLine("Login error has occured.");
                                                                }
                                                                if (checkLoginOutput.Item2 == true)
                                                                {
                                                                    inputStr = Console.ReadLine();
                                                                    mv.ParseInputStringInt(inputStr, out var input34);
                                                                    if (input == null)
                                                                        Console.WriteLine("Invalid input." + Environment.NewLine);
                                                                    else
                                                                    {
                                                                        

                                                                        switch (input34)
                                                                        {
                                                                            case 1:
                                                                                {
                                                                                    Console.WriteLine("1. Search any customer information by customer ID");
                                                                                    string customer_id = Console.ReadLine();
                                                                                    mv.SearchCustomerByID(customer_id);

                                                                                    break;
                                                                                }
                                                                            case 2:
                                                                                {

                                                                                    Console.WriteLine("2. Search any customer information by customer name");
                                                                                    string customer_name = Console.ReadLine();
                                                                                    mv.SearchCustomerByName(customer_name);

                                                                                    break;
                                                                                }
                                                                            case 3:
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
                                                                }
                                                                else
                                                                {
                                                                    loginAttempts++;
                                                                }
                                                            }
                                                            if (loginAttempts > 2)
                                                                Console.WriteLine("Incorrect user or pw");
                                                            else
                                                                Console.WriteLine("Go back");


                                                            break;
                                                        }
                                                    }
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
                        case 3:
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
                                    Console.WriteLine("5: Cancel Manager");
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
                                                    do
                                                    {
                                                        Console.WriteLine("Key in manager address");
                                                        input27 = Console.ReadLine();
                                                        if (input27 == string.Empty)
                                                        {
                                                            Console.WriteLine("Invalid input");
                                                        }

                                                        else
                                                        {
                                                            insideMenu = false;
                                                        }

                                                    }
                                                    while (insideMenu);
                                                    insideMenu = true;
                                                    string inputStr35;
                                                    do
                                                    {
                                                        Console.WriteLine("Key in manager date of birth in format (MM DDD YYYY)");
                                                        inputStr35 = Console.ReadLine();
                                                        mv.ParseInputDate(inputStr35, out var bankmanager_dob);
                                                        if (bankmanager_dob == null)
                                                            Console.WriteLine("Wrong date format." + Environment.NewLine);
                                                        else
                                                            insideMenu = false;

                                                    }
                                                    while (insideMenu);
                                                    insideMenu = true;
                                                    DateTime manager_dob1 = DateTime.Parse(inputStr35);

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
                                                        IList<string> outputList = mv.validatePassword(input31);
                                                        if (outputList.Count != 0)
                                                            foreach (string output in outputList)
                                                                Console.WriteLine(output);
                                                        else
                                                            insideMenu = false;
                                                    }
                                                    //while (mv.validatePassword(input31) == false);
                                                    while (insideMenu) ;
                                                    string new_user = mv.SignUpManager(input25, input26, input27, manager_dob1, input29, input30, input31);
                                                    Console.WriteLine(new_user);
                                                    Console.ReadLine();
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    mv.ViewManagers();
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
                                                        (string, bool?) checkLoginOutput = mv.CheckManagerLogin(bankmanager_id, bankmanager_pw);
                                                        if (!string.IsNullOrWhiteSpace(checkLoginOutput.Item1))
                                                        {
                                                            while (!exited1)
                                                            {
                                                                Console.WriteLine(checkLoginOutput.Item1);
                                                                if (checkLoginOutput.Item2 == null)
                                                                {
                                                                    Console.WriteLine("Login error has occured.");
                                                                }
                                                                if (checkLoginOutput.Item2 == true)
                                                                {
                                                                    inputStr = Console.ReadLine();
                                                                    mv.ParseInputStringInt(inputStr, out var input35);
                                                                    if (input == null)
                                                                    {
                                                                        Console.WriteLine("Invalid input." + Environment.NewLine);
                                                                    }
                                                                    else
                                                                    {
                                                                        switch (input35)
                                                                        {
                                                                            case 1:
                                                                                {
                                                                                    Console.WriteLine("1. Search any customer information by customer ID");
                                                                                    string customer_id = Console.ReadLine();
                                                                                    mv.SearchCustomerByID(customer_id);
                                                                                    break;
                                                                                }
                                                                            case 2:
                                                                                {
                                                                                    Console.WriteLine("1. Search any customer information by customer name");
                                                                                    string customer_name = Console.ReadLine();
                                                                                    mv.SearchCustomerByName(customer_name);
                                                                                    break;
                                                                                }
                                                                            case 3:
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

                                                                                                mv.ListCustomers();
                                                                                                break;
                                                                                            }
                                                                                        case "2":
                                                                                            {
                                                                                                mv.TotalLoanAmount();
                                                                                                break;
                                                                                            }
                                                                                        case "3":
                                                                                            {
                                                                                                mv.TotalSavingsAccount();
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
                                                                            case 4:
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


                                                                }
                                                                else
                                                                {
                                                                    loginAttempts++;
                                                                }
                                                                }
                                                                if (loginAttempts > 2)
                                                                    Console.WriteLine("Incorrect user or pw");
                                                                else
                                                                    Console.WriteLine("Go back");
                                                                break;
                                                            }


                                                        }
                                                        
                                                    
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    exit = true;

                                                    break;
                                                }
                                            case 5:
                                                {
                                                    Console.WriteLine("Key in manager id");
                                                    string manager_id = Console.ReadLine();
                                                    mv.DeleteManager(manager_id);
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
