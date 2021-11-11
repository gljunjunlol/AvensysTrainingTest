using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiLibrary.Controllers;
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
        public bool AddBankEmployees(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {

            //EmployeeAccountManager _user = new EmployeeAccountManager();
            //var new_user = _user.CreateUserAccount();
            //if (new_user != null)
            //{

            //    if (eam.dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
            //    {
            //        ConsoleIO.WriteLine("Account already exists");
            //        return false;
            //    }
            //    else
            //    {
            //        eam.dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
            //        return true;
            //    }
            //}
            //else
            //{
            //    ConsoleIO.WriteLine("User creation failed try again");
            //    return false;
            //}
            return false;

        }
        public void SearchCustomerByID(CustomerAccountManagerController cam)
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
        public void SearchCustomerByName(CustomerAccountManagerController cam)
        {
            ConsoleIO.WriteLine("1. Search any customer information by customer name");
            string customer_name = ConsoleIO.ReadLine();
            
            foreach (KeyValuePair<string, WebApiLibrary.Models.Customer > kvp in cam.dictionaryOfcustomers)
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


        public void PerformOperation(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            



        }
        public void performOperationinternal(CustomerAccountManagerController cam, EmployeeAccountManager eam)
        {
            
            
        }
        public void ListEmployees(EmployeeAccountManagerController eam)
        {
            foreach (KeyValuePair<string, WebApiLibrary.Models.BankEmployees > kvp in eam.dictionaryOfEmployees)
            {
                ConsoleIO.WriteLine($"{kvp.Value.bankemployee_id} {kvp.Value.bankemployee_name} " + "\n Viewing all employees here");

            }

        }
        public void RemoveEmployees(EmployeeAccountManagerController eam)
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
