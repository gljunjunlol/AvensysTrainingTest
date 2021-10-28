using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class BankManagersManagement : BankEmployeesManagement, IBankManagersManagement
    {
        private readonly IConsoleIO ConsoleIO;
        public new void References()
        {
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
        }
        public BankManagersManagement(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        private IBankManagersManagement _bankingmanager;

        public BankManagersManagement()
        {
            ConsoleIO = new ConsoleIO();
        }

        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }

        public void AddBankManagers(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            //BankManagers mgr = new BankManagers("12345", "karen", "23 hillview", DateTime.Now, "loan manager", "3", "Karen12345678$");
            //bmgt.dictionaryOfManagers.Add("12345", mgr);
            HandleAccountOpeningBankManager newacc = new HandleAccountOpeningBankManager();
            var new_user = newacc.CreateUserAccount();
            if (new_user != null)
            {

                if (bmgt.dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                }
                else
                {
                    bmgt.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
                    // first time writing customer details to file
                    FileHandling fileHandling = new FileHandling();
                    fileHandling.ReadingandWritingcustomer(new_user.bankmanager_id, cmgt, bemgt, bmgt);
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
            }

        }
        public decimal TotalLoanAmount(CustomersManagement cmgt)
        {

            var totalloanamount = cmgt.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            ConsoleIO.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F"));
            return totalloanamount;

        }
        public decimal TotalSavingsAccount(CustomersManagement cmgt)
        {

            var totalsavingsofCustomers = cmgt.dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            ConsoleIO.WriteLine("Total savings of the bank " + totalsavingsofCustomers.ToString("F"));
            return totalsavingsofCustomers;
        }
        public void ViewManagers(BankManagersManagement bmgt)
        {
            foreach (KeyValuePair<string, BankManagers> kvp in bmgt.dictionaryOfManagers)
            {
                ConsoleIO.WriteLine($"{kvp.Value.bankmanager_id} {kvp.Value.bankmanager_name} " + "\n Viewing all managers here");

            }
            var bankmanager_id = ConsoleIO.ReadLine();
            var user = dictionaryOfManagers[bankmanager_id];

            dictionaryOfManagers[bankmanager_id] = user;
        }
        public void performOperationAdvanced(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
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
                            bmgt.AddBankManagers(cmgt, bemgt, bmgt);
                            break;
                        }
                    case "2":
                        {
                            ViewManagers(bmgt);
                            break;
                        }
                    case "3":
                        {
                            HandleAccountOpeningBankManager mgr = new HandleAccountOpeningBankManager();
                            mgr.UserLogin(bmgt);
                            performOperationAdvancedInternal(cmgt, bemgt, bmgt);
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
        public void performOperationAdvancedInternal(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
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
                            bemgt.SearchCustomerByID(cmgt);
                            break;
                        }
                    case "2":
                        {
                            bemgt.SearchCustomerByName(cmgt);
                            break;
                        }
                    case "3":
                        {
                            bmgt.performOperationAdvancedInternal1(cmgt, bemgt, bmgt);
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
        public void performOperationAdvancedInternal1(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
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
                            cmgt.ListCustomers(cmgt);
                            break;
                        }
                    case "2":
                        {
                            TotalLoanAmount(cmgt);
                            break;
                        }
                    case "3":
                        {
                            TotalSavingsAccount(cmgt);
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
