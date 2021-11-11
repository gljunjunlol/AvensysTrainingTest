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
    public class CustomersManager : ICustomersManagement
    {
        
        private ICustomerAccountManager _user;
        private readonly IConsoleIO ConsoleIO;
        

        public CustomersManager()
        {
            ConsoleIO = new ConsoleIO();
        }
        public CustomersManager(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public CustomersManager(ICustomerAccountManager user)  // constructor dependency injection
        {
            _user = user;
        }
        public bool AddCustomer(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            //CustomerAccountManager _user = new CustomerAccountManager();
            //var new_user = _user.CreateUserAccount();
            //if (new_user != null)
            //{
                
            //    if (cam.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
            //    {
            //        ConsoleIO.WriteLine("Account already exists");
            //        return false;
            //    }
            //    else
            //    {
            //        cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
            //        FileManager fileHandling = new FileManager();
            //        fileHandling.ReadingandWritingcustomer(new_user.customer_id, cam, eam, mam);
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

        public void RemoveCustomers(CustomerAccountManagerController cam)
        {
            ConsoleIO.WriteLine("Key in customer id to remove");
            string customer_id = ConsoleIO.ReadLine();
            
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                
                ConsoleIO.WriteLine(customer_id + " has been removed");
                cam.dictionaryOfcustomers.Remove(customer_id);
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }
        }

        public void PerformOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam, List<int> loginTries)
        {
            bool exit = false;
            while (!exit)
            {
                

            }
            
        }
        public void ListCustomers(CustomerAccountManagerController cam)
        {
            foreach (KeyValuePair<string, WebApiLibrary.Models.Customer > kvp in cam.dictionaryOfcustomers)
            {
                ConsoleIO.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} {kvp.Value.customer_address} {kvp.Value.customer_dateOfBirth} " + "\n Listing all current customers in database: ");

            }
        }
    }
}
