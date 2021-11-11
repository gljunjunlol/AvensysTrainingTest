using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiLibrary.Controllers;

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

        public bool AddBankManagers(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            //ManagerAccountManager newacc = new ManagerAccountManager();
            //var new_user = newacc.CreateUserAccount();
            //if (new_user != null)
            //{

            //    if (mam.dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
            //    {
            //        ConsoleIO.WriteLine("Account already exists");
            //    }
            //    else
            //    {
            //        mam.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
            //    }
            //}
            //else
            //{
            //    ConsoleIO.WriteLine("User creation failed try again");
            //}
            return false;

        }
        public decimal TotalLoanAmount(CustomerAccountManagerController cam)
        {

            var totalloanamount = cam.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            ConsoleIO.WriteLine("Total outstanding loan taken:  " + totalloanamount.ToString("F"));
            return totalloanamount;

        }
        public decimal TotalSavingsAccount(CustomerAccountManagerController cam)
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
        public void performOperationAdvanced(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                

            }
                 

        }
        public void performOperationAdvancedInternal(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                

            }
        }
        public void performOperationAdvancedInternal1(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1)
        {
            bool exit = false;
            while (!exit)
            {
                
            }
        }
    }
}
