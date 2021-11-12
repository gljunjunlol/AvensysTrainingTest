using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using BankingWebAPI.Controllers;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;

namespace BankingWebAPI.Utility
{
    public class FileManager : IFileManager
    {
        
        public void ReadingandWritingcustomer(string customer_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam)
        {
            try
            {
                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { cam.dictionaryOfcustomers[customer_id].customer_id} { cam.dictionaryOfcustomers[customer_id].customer_name} { cam.dictionaryOfcustomers[customer_id].customer_address} { cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { cam.dictionaryOfcustomers[customer_id].customer_email} { cam.dictionaryOfcustomers[customer_id].customer_phone} { cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F")} { cam.dictionaryOfcustomers[customer_id].customer_loan_applied} { cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F")}");

                
                Customer cust = new Customer()
                {
                    customer_id = cam.dictionaryOfcustomers[customer_id].customer_id,
                    customer_name = cam.dictionaryOfcustomers[customer_id].customer_name,
                    customer_address = cam.dictionaryOfcustomers[customer_id].customer_address,
                    customer_dateOfBirth = cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                    customer_email = cam.dictionaryOfcustomers[customer_id].customer_email,
                    customer_phone = cam.dictionaryOfcustomers[customer_id].customer_phone,
                    cheque_book_number = cam.dictionaryOfcustomers[customer_id].cheque_book_number,
                    customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance,
                    customer_loan_applied = cam.dictionaryOfcustomers[customer_id].customer_loan_applied,
                    loan_amount = cam.dictionaryOfcustomers[customer_id].loan_amount,

                };
                string jsontext = "ID " + customer_id + " " + cam.dictionaryOfcustomers[customer_id].customer_name + ".json";

                List<Customer> customerList = new List<Customer>(); customerList.Add(cust);
                Console.WriteLine("uploading user details to json file");
                string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented, new FormatDecimalConverter()); File.WriteAllText(jsontext, customerListJson);
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
        public void JsonListofAllCustomers(string customer_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam)
        {
            Customer cust = new Customer()
            {
                customer_id = cam.dictionaryOfcustomers[customer_id].customer_id,
                customer_name = cam.dictionaryOfcustomers[customer_id].customer_name,
                customer_address = cam.dictionaryOfcustomers[customer_id].customer_address,
                customer_dateOfBirth = cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                customer_email = cam.dictionaryOfcustomers[customer_id].customer_email,
                customer_phone = cam.dictionaryOfcustomers[customer_id].customer_phone,
                cheque_book_number = cam.dictionaryOfcustomers[customer_id].cheque_book_number,
                customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance,
                customer_loan_applied = cam.dictionaryOfcustomers[customer_id].customer_loan_applied,
                loan_amount = cam.dictionaryOfcustomers[customer_id].loan_amount,
            };
            string Alljsontext = "List of all banking customers.json";
            var jsonData = System.IO.File.ReadAllText(Alljsontext);
            List<Customer> customerBalances = JsonConvert.DeserializeObject<List<Customer>>(jsonData) ?? new List<Customer>();
            customerBalances.Add(cust);
            Console.WriteLine("uploading user details to json file");
            jsonData = JsonConvert.SerializeObject(customerBalances, Formatting.Indented);
            File.WriteAllText(Alljsontext, jsonData);
            Console.ReadLine();
        }
    }
}
