using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class FileHandling : IFileHandling
    {
        private readonly IConsoleIO ConsoleIO;
        public FileHandling()
        {
            ConsoleIO = new ConsoleIO();
        }
        public FileHandling(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public void ReadingandWritingcustomer(string customer_id, CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            try
            {
                

                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { cmgt.dictionaryOfcustomers[customer_id].customer_id} { cmgt.dictionaryOfcustomers[customer_id].customer_name} { cmgt.dictionaryOfcustomers[customer_id].customer_address} { cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { cmgt.dictionaryOfcustomers[customer_id].customer_email} { cmgt.dictionaryOfcustomers[customer_id].customer_phone} { cmgt.dictionaryOfcustomers[customer_id].customerBalance} { cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied} { cmgt.dictionaryOfcustomers[customer_id].loan_amount}");
                


                // Json format - first time writing
                Customer cust = new Customer()  // object creation
                {
                    customer_id = cmgt.dictionaryOfcustomers[customer_id].customer_id, customer_name = cmgt.dictionaryOfcustomers[customer_id].customer_name, customer_address = cmgt.dictionaryOfcustomers[customer_id].customer_address, customer_dateOfBirth = cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth, customer_email = cmgt.dictionaryOfcustomers[customer_id].customer_email, customer_phone = cmgt.dictionaryOfcustomers[customer_id].customer_phone, cheque_book_number = cmgt.dictionaryOfcustomers[customer_id].cheque_book_number, customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance, customer_loan_applied = cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied, loan_amount = cmgt.dictionaryOfcustomers[customer_id].loan_amount,
 
                };
                string jsontext = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".json";

                List<Customer> customerList = new List<Customer>(); customerList.Add(cust);

                Console.WriteLine("uploading user details to json file");
                string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented); File.WriteAllText(jsontext, customerListJson);
                //File.Create("Customer.Json");


                //Console.ReadLine();
                List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                Console.ReadLine();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file or directory is not supported");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException)
            {
                Console.WriteLine($"The file already exist ");
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }
        public void JsonListofAllCustomers(string customer_id, CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            Customer cust = new Customer()
            {
                customer_id = cmgt.dictionaryOfcustomers[customer_id].customer_id, customer_name = cmgt.dictionaryOfcustomers[customer_id].customer_name, customer_address = cmgt.dictionaryOfcustomers[customer_id].customer_address, customer_dateOfBirth = cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth, customer_email = cmgt.dictionaryOfcustomers[customer_id].customer_email, customer_phone = cmgt.dictionaryOfcustomers[customer_id].customer_phone, cheque_book_number = cmgt.dictionaryOfcustomers[customer_id].cheque_book_number, customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance, customer_loan_applied = cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied, loan_amount = cmgt.dictionaryOfcustomers[customer_id].loan_amount,
            };
            string Alljsontext = "List of all banking customers.json";
            var jsonData = System.IO.File.ReadAllText(Alljsontext);
            List<Customer> customerBalances = JsonConvert.DeserializeObject<List<Customer>>(jsonData) ?? new List<Customer>();

            customerBalances.Add(cust);
            Console.WriteLine("uploading user details to json file");
            jsonData = JsonConvert.SerializeObject(customerBalances, Formatting.Indented);
            //File.Create("Manager.Json");
            File.WriteAllText(Alljsontext, jsonData);

            //Console.ReadLine();

            Console.ReadLine();
        }
    }
}
