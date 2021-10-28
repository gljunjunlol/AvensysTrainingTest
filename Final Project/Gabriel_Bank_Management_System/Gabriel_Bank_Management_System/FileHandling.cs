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
                // first time writing customer details to file
                string text = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fs);

                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { cmgt.dictionaryOfcustomers[customer_id].customer_id} { cmgt.dictionaryOfcustomers[customer_id].customer_name} { cmgt.dictionaryOfcustomers[customer_id].customer_address} { cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { cmgt.dictionaryOfcustomers[customer_id].customer_email} { cmgt.dictionaryOfcustomers[customer_id].customer_phone} { cmgt.dictionaryOfcustomers[customer_id].customerBalance} { cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied} { cmgt.dictionaryOfcustomers[customer_id].loan_amount}");
                streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { cmgt.dictionaryOfcustomers[customer_id].customer_id} { cmgt.dictionaryOfcustomers[customer_id].customer_name} { cmgt.dictionaryOfcustomers[customer_id].customer_address} { cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { cmgt.dictionaryOfcustomers[customer_id].customer_email} { cmgt.dictionaryOfcustomers[customer_id].customer_phone} { cmgt.dictionaryOfcustomers[customer_id].customerBalance} { cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied} { cmgt.dictionaryOfcustomers[customer_id].loan_amount}");
                streamWriter.Flush();
                streamWriter.Close();
                fs.Close();

                // first time reading customer details on file
                FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                StreamReader sr1 = new StreamReader(fs2);
                Console.WriteLine("Printing content of text file after written detailed report");
                sr1.BaseStream.Seek(0, SeekOrigin.Begin);
                string str1 = sr1.ReadToEnd();
                Console.WriteLine(str1);
                //while (str != null)
                //{
                //    Console.WriteLine(str);
                //    str = sr.ReadLine();
                //}
                sr1.Close();
                fs2.Close();

                // Json format - first time writing
                Customer cust = new Customer()  // object creation
                {
                    customer_id = cmgt.dictionaryOfcustomers[customer_id].customer_id, customer_name = cmgt.dictionaryOfcustomers[customer_id].customer_name, customer_address = cmgt.dictionaryOfcustomers[customer_id].customer_address, customer_dateOfBirth = cmgt.dictionaryOfcustomers[customer_id].customer_dateOfBirth, customer_email = cmgt.dictionaryOfcustomers[customer_id].customer_email, customer_phone = cmgt.dictionaryOfcustomers[customer_id].customer_phone, customer_loan_applied = cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied, loan_amount = cmgt.dictionaryOfcustomers[customer_id].loan_amount,
 
                };
                string jsontext = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".json";

                List<Customer> customerList = new List<Customer>();
                customerList.Add(cust);
                Console.WriteLine("uploading user details to json file");
                string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                //File.Create("Customer.Json");
                File.WriteAllText(jsontext, customerListJson);

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
    }
}
