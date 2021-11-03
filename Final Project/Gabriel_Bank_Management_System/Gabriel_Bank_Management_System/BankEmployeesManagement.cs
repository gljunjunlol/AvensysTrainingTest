using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class BankEmployeesManagement : IBankEmployeesManagement
    {
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }
        private IHandleAccountOpeningEmployee _user;
        private readonly IConsoleIO ConsoleIO;
        public void References()
        {
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
        }
        public BankEmployeesManagement(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public BankEmployeesManagement()
        {
            ConsoleIO = new ConsoleIO();
        }
        public BankEmployeesManagement(IHandleAccountOpeningEmployee user) // constructor dependency injection
        {
            _user = user;
        }
        public bool AddBankEmployees(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            //BankEmployees emp = new BankEmployees("12345", "george", "23 hillview", DateTime.Now, "loan employee", "3", "George12345678$");
            //bemgt.dictionaryOfEmployees.Add("12345", emp);

            HandleAccountOpeningEmployee _user = new HandleAccountOpeningEmployee();
            var new_user = _user.CreateUserAccount();
            if (new_user != null)
            {

                if (bemgt.dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                {
                    ConsoleIO.WriteLine("Account already exists");
                    return false;
                }
                else
                {
                    bemgt.dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
                    // first time writing customer details to file
                    FileHandling fileHandling = new FileHandling();
                    fileHandling.ReadingandWritingcustomer(new_user.bankemployee_id, cmgt, bemgt, bmgt);
                    return true;
                }
            }
            else
            {
                ConsoleIO.WriteLine("User creation failed try again");
                return false;
            }
            return false;

        }
        public void SearchCustomerByID(CustomersManagement cmgt)
        {
            ConsoleIO.WriteLine("1. Search any customer information by customer ID");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("\n" + "ok found" + "\n");
                ConsoleIO.WriteLine("CUSTOMER ID: " + cmgt.dictionaryOfcustomers[customer_id].customer_id);
                ConsoleIO.WriteLine("CUSTOMER NAME: " + cmgt.dictionaryOfcustomers[customer_id].customer_name);
                ConsoleIO.WriteLine("CUSTOMER ADDRESS: " + cmgt.dictionaryOfcustomers[customer_id].customer_address);
                ConsoleIO.WriteLine("CUSTOMER DATEOFBIRTH: " + cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth);
                ConsoleIO.WriteLine("CUSTOMER EMAIL: " + cmgt.dictionaryOfcustomers[customer_id].customer_email);
                ConsoleIO.WriteLine("CUSTOMER PHONE: " + cmgt.dictionaryOfcustomers[customer_id].customer_phone);
                ConsoleIO.WriteLine("CUSTOMER CHEQUE IF ANY: " + cmgt.dictionaryOfcustomers[customer_id].cheque_book_number);
                ConsoleIO.WriteLine("CUSTOMER BALANCE: $" + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                ConsoleIO.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied);
                ConsoleIO.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + cmgt.dictionaryOfcustomers[customer_id].loan_amount);
                ConsoleIO.WriteLine("");
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }
        }
        public void SearchCustomerByName(CustomersManagement cmgt)
        {
            ConsoleIO.WriteLine("1. Search any customer information by customer name");
            string customer_name = ConsoleIO.ReadLine();
            
            foreach (KeyValuePair<string, Customer> kvp in cmgt.dictionaryOfcustomers)
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
                    ConsoleIO.WriteLine($"CUSTOMER BALANCE: ${kvp.Value.customerBalance}");
                    ConsoleIO.WriteLine($"CUSTOMER LOAN APPLIED IF ANY: {kvp.Value.customer_loan_applied}");
                    ConsoleIO.WriteLine($"CUSTOMER LOAN AMOUNT IF ANY: {kvp.Value.loan_amount}\n");
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


        public void PerformOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
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
                            bemgt.AddBankEmployees(cmgt, bemgt, bmgt);
                            break;
                        }
                    case "2":
                        {
                            bemgt.RemoveEmployees(bemgt);
                            break;
                        }
                    case "3":
                        {
                            bemgt.ListEmployees(bemgt);
                            break;
                        }
                    case "4":
                        {
                            HandleAccountOpeningEmployee emp = new HandleAccountOpeningEmployee();
                            emp.UserLogin(bemgt); bemgt.performOperationinternal(cmgt, bemgt);



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
        public void performOperationinternal(CustomersManagement cmgt, BankEmployeesManagement bemgt)
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
                            SearchCustomerByID(cmgt);
                            break;
                        }
                    case "2":
                        {
                            SearchCustomerByName(cmgt);
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

        public void RemoveEmployees(BankEmployeesManagement bemgt)
        {
            ConsoleIO.WriteLine("Key in employee id");
            string employee_id = ConsoleIO.ReadLine();

            if (bemgt.dictionaryOfEmployees.ContainsKey(employee_id))
            {

                ConsoleIO.WriteLine(employee_id + " has been removed");
                dictionaryOfEmployees.Remove(employee_id);
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist");
            }                      
        }
        public void ListEmployees(BankEmployeesManagement bemgt)
        {
            foreach (KeyValuePair<string, BankEmployees> kvp in bemgt.dictionaryOfEmployees)
            {
                ConsoleIO.WriteLine($"{kvp.Value.bankemployee_id} {kvp.Value.bankemployee_name} "+ "\n Viewing all employees here");

            }

            var bankemployee_id = Console.ReadLine();
            var user = dictionaryOfEmployees[bankemployee_id];

            dictionaryOfEmployees[bankemployee_id] = user;

        }
    }
}
