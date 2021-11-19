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
                

                
                Customer cust = new Customer()
                {
                    customer_id = cam.dictionaryOfcustomers[customer_id].customer_id,
                    customer_name = cam.dictionaryOfcustomers[customer_id].customer_name,
                    customer_address = cam.dictionaryOfcustomers[customer_id].customer_address,
                    customer_dateOfBirth = cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                    customer_email = cam.dictionaryOfcustomers[customer_id].customer_email,
                    customer_phone = cam.dictionaryOfcustomers[customer_id].customer_phone,
                    customer_pw = cam.dictionaryOfcustomers[customer_id].customer_pw,
                    account_number = "A" + cam.dictionaryOfcustomers[customer_id].customer_id,
                    cheque_book_number = cam.dictionaryOfcustomers[customer_id].cheque_book_number,
                    customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance,
                    customer_loan_applied = cam.dictionaryOfcustomers[customer_id].customer_loan_applied,
                    loan_amount = cam.dictionaryOfcustomers[customer_id].loan_amount,

                };
                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { cam.dictionaryOfcustomers[customer_id].customer_id} { cam.dictionaryOfcustomers[customer_id].customer_name} { cam.dictionaryOfcustomers[customer_id].customer_address} { cam.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { cam.dictionaryOfcustomers[customer_id].customer_email} { cam.dictionaryOfcustomers[customer_id].customer_phone} { cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F")} { cam.dictionaryOfcustomers[customer_id].customer_loan_applied} { cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F")}");
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
        public void ReadingandWritingEmployee(string bankemployee_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam)
        {
            try
            {
                


                BankEmployees bemp = new BankEmployees()
                {
                    bankemployee_id = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_id,
                    bankemployee_name = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name,
                    bankemployee_address = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_address,
                    bankemployee_dateOfBirth = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_dateOfBirth,
                    bankemployee_designation = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_designation,
                    bankemployee_yearsOfService = eam.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService,
                    bankemployee_pw = "",
                    

                };
                Console.WriteLine($"Dear Employee, your details for your checking, please check the detailed report: { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_id} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_address} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_dateOfBirth} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
                string jsontext = "Employee ID " + bankemployee_id + " " + eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name + ".json";

                List<BankEmployees> employeeList = new List<BankEmployees>(); employeeList.Add(bemp);
                Console.WriteLine("uploading user details to json file");
                string employeeListJson = JsonConvert.SerializeObject(employeeList, Formatting.Indented, new FormatDecimalConverter()); File.WriteAllText(jsontext, employeeListJson);
                List<BankEmployees> empTemp1 = JsonConvert.DeserializeObject<List<BankEmployees>>(File.ReadAllText(jsontext));
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
        public void ReadingandWritingManager(string bankmanager_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam)
        {
            try
            {
                


                BankManagers bmgr = new BankManagers()
                {
                    bankmanager_id = mam.dictionaryOfManagers[bankmanager_id].bankmanager_id,
                    bankmanager_name = mam.dictionaryOfManagers[bankmanager_id].bankmanager_name,
                    bankmanager_address = mam.dictionaryOfManagers[bankmanager_id].bankmanager_address,
                    bankmanager_dateOfBirth = mam.dictionaryOfManagers[bankmanager_id].bankmanager_dateOfBirth,
                    bankmanager_designation = mam.dictionaryOfManagers[bankmanager_id].bankmanager_designation,
                    bankmanager_yearsOfService = mam.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService,
                    bankmanager_pw = "",


                };
                Console.WriteLine($"Dear Sir / Mam, your details for your checking, please check the detailed report: { mam.dictionaryOfManagers[bankmanager_id].bankmanager_id} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_name} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_address} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_dateOfBirth} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_designation} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
                string jsontext = "Manager ID " + bankmanager_id + " " + mam.dictionaryOfManagers[bankmanager_id].bankmanager_name + ".json";

                List<BankManagers> managerList = new List<BankManagers>(); managerList.Add(bmgr);
                Console.WriteLine("uploading user details to json file");
                string managerListJson = JsonConvert.SerializeObject(managerList, Formatting.Indented, new FormatDecimalConverter()); File.WriteAllText(jsontext, managerListJson);
                List<BankManagers> mgrTemp = JsonConvert.DeserializeObject<List<BankManagers>>(File.ReadAllText(jsontext));
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
