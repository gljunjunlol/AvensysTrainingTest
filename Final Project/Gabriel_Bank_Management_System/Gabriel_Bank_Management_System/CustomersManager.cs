using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            CustomerAccountManager _user = new CustomerAccountManager();
            var new_user = _user.CreateUserAccount();
            if (new_user != null)
            {
                
                if (cam.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                    return false;
                }
                else
                {
                    cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                    // first time writing customer details to file
                    FileHandling fileHandling = new FileHandling();
                    fileHandling.ReadingandWritingcustomer(new_user.customer_id, cam, eam, mam);
                    return true;
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
                return false;
            }
        }

        public void RemoveCustomers(CustomerAccountManager cam)
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
                ConsoleIO.WriteLine("Screen 1 -- customers only" + "\n1. Create User" + "\n2: Remove User" + "\nSeek help from bank operator" + "\n3: Ask user to log in" + "\n4: Return to home screen");

                var user_option = ConsoleIO.ReadLine();

                switch (user_option)
                {
                    case "1":
                        {
                            AddCustomer(cam, eam, mam);
                            break;
                        }
                    case "2":
                        {
                            RemoveCustomers(cam);
                            break;
                        }
                    case "3":
                        {
                            CustomerAccountManager newacc = new CustomerAccountManager();
                            newacc.UserLogin(cam, loginTries);
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
            ConsoleIO.WriteLine(DateTime.Now.ToString());
        }
        public void ListCustomers(CustomerAccountManager cam)
        {
            foreach (KeyValuePair<string, Customer> kvp in cam.dictionaryOfcustomers)
            {
                ConsoleIO.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} {kvp.Value.customer_address} {kvp.Value.customer_dateOfBirth} " + "\n Listing all current customers in database: ");

            }
        }
    }
}
