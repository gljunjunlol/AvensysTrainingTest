using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiLibrary.Interfaces;

namespace Gabriel_Bank_Management_System
{
    public class BankEmployeesManager : IBankEmployeesManager
    {
        
        private IEmployeeAccountManager _user;
        private readonly IConsoleIO ConsoleIO;
        public BankEmployeesManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public BankEmployeesManager()
        {
            ConsoleIO = new ConsoleIO();
        }
        public BankEmployeesManager(IEmployeeAccountManager user) // constructor dependency injection
        {
            _user = user;
        }
        public bool AddBankEmployees(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            
            EmployeeAccountManager _user = new EmployeeAccountManager();
            var new_user = _user.CreateUserAccount();
            if (new_user != null)
            {

                if (eam.dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                    return false;
                }
                else
                {
                    eam.dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
                    return true;
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
                return false;
            }

        }
        public void SearchCustomerByID(CustomerAccountManager cam)
        {
            ConsoleIO.WriteLine("1. Search any customer information by customer ID");
            string customer_id = ConsoleIO.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("\n" + "ok found" + "\n");
                ConsoleIO.WriteLine("CUSTOMER ID: " + cam.dictionaryOfcustomers[customer_id].customer_id);
                ConsoleIO.WriteLine("CUSTOMER NAME: " + cam.dictionaryOfcustomers[customer_id].customer_name);
                ConsoleIO.WriteLine("CUSTOMER ADDRESS: " + cam.dictionaryOfcustomers[customer_id].customer_address);
                ConsoleIO.WriteLine("CUSTOMER DATEOFBIRTH: " + cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth);
                ConsoleIO.WriteLine("CUSTOMER EMAIL: " + cam.dictionaryOfcustomers[customer_id].customer_email);
                ConsoleIO.WriteLine("CUSTOMER PHONE: " + cam.dictionaryOfcustomers[customer_id].customer_phone);
                ConsoleIO.WriteLine("CUSTOMER CHEQUE IF ANY: " + cam.dictionaryOfcustomers[customer_id].cheque_book_number);
                ConsoleIO.WriteLine("CUSTOMER BALANCE: $" + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                ConsoleIO.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + cam.dictionaryOfcustomers[customer_id].customer_loan_applied);
                ConsoleIO.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                ConsoleIO.WriteLine("");
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }
        }
        public void SearchCustomerByName(CustomerAccountManager cam)
        {
            ConsoleIO.WriteLine("1. Search any customer information by customer name");
            string customer_name = ConsoleIO.ReadLine();
            
            foreach (KeyValuePair<string, Customer> kvp in cam.dictionaryOfcustomers)
            {
                if (kvp.Value.customer_name == customer_name)
                {
                    ConsoleIO.WriteLine("\n" + "Search for " + customer_name + "\n");
                    ConsoleIO.WriteLine($"CUSTOMER ID: {kvp.Value.customer_id}");
                    ConsoleIO.WriteLine($"CUSTOMER NAME: {kvp.Value.customer_name}");
                    ConsoleIO.WriteLine($"CUSTOMER ADDRESS: {kvp.Value.customer_address}");
                    ConsoleIO.WriteLine($"CUSTOMER DATEOFBIRTH: {kvp.Value.customer_dateOfBirth}");
                    ConsoleIO.WriteLine($"CUSTOMER EMAIL: {kvp.Value.customer_email}");
                    ConsoleIO.WriteLine($"CUSTOMER PHONE: {kvp.Value.customer_phone}");
                    ConsoleIO.WriteLine($"CUSTOMER CHEQUE IF ANY: {kvp.Value.cheque_book_number}");
                    ConsoleIO.WriteLine($"CUSTOMER BALANCE: ${kvp.Value.customerBalance.ToString("F")}");
                    ConsoleIO.WriteLine($"CUSTOMER LOAN APPLIED IF ANY: {kvp.Value.customer_loan_applied}");
                    ConsoleIO.WriteLine($"CUSTOMER LOAN AMOUNT IF ANY: {kvp.Value.loan_amount.ToString("F")}\n");
                    ConsoleIO.WriteLine("");
                    ConsoleIO.WriteLine("");
                    ConsoleIO.WriteLine("");
                    ConsoleIO.WriteLine("");
                    ConsoleIO.WriteLine("");
                    ConsoleIO.WriteLine("");
                    return;
                }
                else
                {
                    ConsoleIO.WriteLine("Account doesn't exist");

                }
            }
        }


        public void PerformOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("Screen 1");
                ConsoleIO.WriteLine("Select Option");
                ConsoleIO.WriteLine("1. Create Bank Employee a/c");
                ConsoleIO.WriteLine("2: Remove Bank Employee");
                ConsoleIO.WriteLine("3: View all Employee");
                ConsoleIO.WriteLine("4: Ask employee to log in");
                ConsoleIO.WriteLine("5: Return to home screen");
                var user_option = ConsoleIO.ReadLine();

                switch (user_option)
                {
                    case "1":
                        {
                            AddBankEmployees(cam, eam, mam);
                            break;
                        }
                    case "2":
                        {
                            RemoveEmployees(eam);
                            break;
                        }
                    case "3":
                        {
                            ListEmployees(eam);
                            break;
                        }
                    case "4":
                        {
                            EmployeeAccountManager emp = new EmployeeAccountManager();
                            emp.UserLogin(eam); performOperationinternal(cam, eam);



                            break;
                        }
                    case "5":
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
            ConsoleIO.WriteLine("Exiting the program");



        }
        public void performOperationinternal(CustomerAccountManager cam, EmployeeAccountManager eam)
        {
            
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("1: Find customer by ID: ");
                ConsoleIO.WriteLine("2: Find customer by name");
                ConsoleIO.WriteLine("3: Logout and go back");
                var input = ConsoleIO.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            SearchCustomerByID(cam);
                            break;
                        }
                    case "2":
                        {
                            SearchCustomerByName(cam);
                            break;
                        }
                    case "3":
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
        }
        public void ListEmployees(EmployeeAccountManager eam)
        {
            foreach (KeyValuePair<string, BankEmployees> kvp in eam.dictionaryOfEmployees)
            {
                ConsoleIO.WriteLine($"{kvp.Value.bankemployee_id} {kvp.Value.bankemployee_name} " + "\n Viewing all employees here");

            }

            var bankemployee_id = Console.ReadLine();
            var user = eam.dictionaryOfEmployees[bankemployee_id];

            eam.dictionaryOfEmployees[bankemployee_id] = user;

        }
        public void RemoveEmployees(EmployeeAccountManager eam)
        {
            ConsoleIO.WriteLine("Key in employee id");
            string employee_id = ConsoleIO.ReadLine();

            if (eam.dictionaryOfEmployees.ContainsKey(employee_id))
            {

                ConsoleIO.WriteLine(employee_id + " has been removed");
                eam.dictionaryOfEmployees.Remove(employee_id);
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }                      
        }
        
    }
}
