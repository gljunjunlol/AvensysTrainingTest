using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class CustomersManagement : ICustomersManagement
    {
        public virtual Dictionary<string, Customer> dictionaryOfcustomers { get; set; }
        private readonly IConsoleIO ConsoleIO;
        public void References()
        {
            dictionaryOfcustomers = new Dictionary<string, Customer>();
        }

        public CustomersManagement()
        {
            ConsoleIO = new ConsoleIO();
        }
        public CustomersManagement(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public void AddCustomer(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            User newacc = new User();
            var new_user = newacc.CreateUserAccount();
            if (new_user != null)
            {
                
                if (cmgt.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                }
                else
                {
                    cmgt.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                    // first time writing customer details to file
                    FileHandling fileHandling = new FileHandling();
                    fileHandling.ReadingandWritingcustomer(new_user.customer_id, cmgt, bemgt, bmgt);
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
            }
        }

        public void RemoveCustomers(CustomersManagement cmgt)
        {
            ConsoleIO.WriteLine("Key in customer id to remove");
            string customer_id = ConsoleIO.ReadLine();
            
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                
                ConsoleIO.WriteLine(customer_id + " has been removed");
                dictionaryOfcustomers.Remove(customer_id);
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }
        }

        public void PerformOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt, List<int> loginTries)
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
                            cmgt.AddCustomer(cmgt, bemgt, bmgt);
                            break;
                        }
                    case "2":
                        {
                            cmgt.RemoveCustomers(cmgt);
                            break;
                        }
                    case "3":
                        {
                            User newacc = new User();
                            newacc.UserLogin(cmgt, loginTries);
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
            ConsoleIO.WriteLine("Exiting the program");
        }
        public void ListCustomers(CustomersManagement cmgt)
        {
            foreach (KeyValuePair<string, Customer> kvp in cmgt.dictionaryOfcustomers)
            {
                ConsoleIO.WriteLine($"{kvp.Value.customer_id} {kvp.Value.customer_name} {kvp.Value.customer_address} {kvp.Value.customer_dateOfBirth} " + "\n Listing all current customers in database: ");

            }
        }
    }
}
