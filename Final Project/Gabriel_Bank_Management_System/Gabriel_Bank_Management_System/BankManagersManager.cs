using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class BankManagersManager : BankEmployeesManager, IBankManagersManager
    {
        private readonly IConsoleIO ConsoleIO;
        public BankManagersManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        

        public BankManagersManager()
        {
            ConsoleIO = new ConsoleIO();
        }

        public void AddBankManagers(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            //BankManagers mgr = new BankManagers("12345", "karen", "23 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$");
            //mam.dictionaryOfManagers.Add("12345", mgr);
            ManagerAccountManager newacc = new ManagerAccountManager();
            var new_user = newacc.CreateUserAccount();
            if (new_user != null)
            {

                if (mam.dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                }
                else
                {
                    mam.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
                    // first time writing customer details to file
                    FileHandling fileHandling = new FileHandling();
                    fileHandling.ReadingandWritingcustomer(new_user.bankmanager_id, cam, eam, mam);
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
            }

        }
        public decimal TotalLoanAmount(CustomerAccountManager cam)
        {

            var totalloanamount = cam.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            ConsoleIO.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F"));
            return totalloanamount;

        }
        public decimal TotalSavingsAccount(CustomerAccountManager cam)
        {

            var totalsavingsofCustomers = cam.dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            ConsoleIO.WriteLine("Total savings of the bank " + totalsavingsofCustomers.ToString("F"));
            return totalsavingsofCustomers;
        }
        public void ViewManagers(ManagerAccountManager mam)
        {
            foreach (KeyValuePair<string, BankManagers> kvp in mam.dictionaryOfManagers)
            {
                ConsoleIO.WriteLine($"{kvp.Value.bankmanager_id} {kvp.Value.bankmanager_name} " + "\n Viewing all managers here");

            }
            var bankmanager_id = ConsoleIO.ReadLine();
            var user = mam.dictionaryOfManagers[bankmanager_id];

            mam.dictionaryOfManagers[bankmanager_id] = user;
        }
        public void performOperationAdvanced(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("Select Option (Involving Manager access only)");
                ConsoleIO.WriteLine("1: Create Bank Manager");
                ConsoleIO.WriteLine("2: View Managers");
                ConsoleIO.WriteLine("3: Login");
                ConsoleIO.WriteLine("4: Return to home screen");
                var input = ConsoleIO.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            AddBankManagers(cam, eam, mam);
                            break;
                        }
                    case "2":
                        {
                            ViewManagers(mam);
                            break;
                        }
                    case "3":
                        {
                            ManagerAccountManager mgr = new ManagerAccountManager();
                            mgr.UserLogin(mam);
                            performOperationAdvancedInternal(cam, cam1, eam, eam1, mam, mam1);
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
                ConsoleIO.WriteLine("");

            }
                 

        }
        public void performOperationAdvancedInternal(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("1: Find customer by ID: ");
                ConsoleIO.WriteLine("2: Find customer by name");
                ConsoleIO.WriteLine("3: Advanced access");
                ConsoleIO.WriteLine("4: Logout and go back");
                var input = ConsoleIO.ReadLine();
                switch (input)
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
                            mam1.performOperationAdvancedInternal1(cam, cam1, eam, eam1, mam, mam1);
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
        }
        public void performOperationAdvancedInternal1(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("1. List of total customers / 1: View all users (customers)");
                ConsoleIO.WriteLine("2: List of Total Loan amount");
                ConsoleIO.WriteLine("3: List of Total saving account of customers / budgeting purposes / manage tracking");
                ConsoleIO.WriteLine("4: Go back to the previous screen (Screen 1) / Logout and go back");
                var input = ConsoleIO.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            cam1.ListCustomers(cam);
                            break;
                        }
                    case "2":
                        {
                            TotalLoanAmount(cam);
                            break;
                        }
                    case "3":
                        {
                            TotalSavingsAccount(cam);
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
        }
    }
}
