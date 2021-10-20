using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    class BankEmployeesManagement : IBankEmployeesManagement
    {
        public static Dictionary<string, BankEmployees> dictionaryOfEmployees = new Dictionary<string, BankEmployees>();

        public BankEmployeesManagement()
        {
            if (!File.Exists("BankEmployeeInformation.txt"))
            {
                //Console.WriteLine("!!!!No Previous Data Exist!!!!");
                return;
            }
            FileStream fs = new FileStream("Bank Employee details.txt", FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs);

            string str = sr.ReadLine();
            while (str != null)
            {
                var strarr = str.Split('_');    //get array of customer id ..etc in string
                var user = new BankEmployees(strarr[0], strarr[1], strarr[2], Convert.ToDateTime(strarr[3]), strarr[4], strarr[5], strarr[6]);
                if (dictionaryOfEmployees.ContainsKey(strarr[0]))
                {
                    dictionaryOfEmployees.Add(strarr[0], user);
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void AddBankEmployees(BankEmployees bankemployee)
        {
            try
            {

                HandleAccountOpeningEmployee newacc = new HandleAccountOpeningEmployee();
                var new_user = HandleAccountOpeningEmployee.CreateUserAccount();
                if (new_user != null)
                {
                    if (dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
                    }
                }
                else
                {
                    Console.WriteLine("User creation failed try again");
                }



            }
            catch (ArgumentException)
            {
                Console.WriteLine("Customer already in database, Please try another customer number");
            }
            catch (AggregateException)
            {
                Console.WriteLine("sorry not allowed");
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrect format");
            }

        }
        public void SearchCustomerByID()
        {
            Console.WriteLine("1. Search any customer information by customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("ok found");
                Console.WriteLine("");
                Console.WriteLine("CUSTOMER ID: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_id);
                Console.WriteLine("CUSTOMER NAME: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name);
                Console.WriteLine("CUSTOMER ADDRESS: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_address);
                Console.WriteLine("CUSTOMER DATEOFBIRTH: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth);
                Console.WriteLine("CUSTOMER EMAIL: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_email);
                Console.WriteLine("CUSTOMER PHONE: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone);
                Console.WriteLine("CUSTOMER CHEQUE IF ANY: " + CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);
                Console.WriteLine("CUSTOMER BALANCE: $" + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                Console.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied);
                Console.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
            }
        }
        public void SearchCustomerByName()
        {
            Console.WriteLine("1. Search any customer information by customer name");
            string customer_name2 = Console.ReadLine();
            string customer_name = customer_name2.ToUpper();
            foreach (var customer in CustomersManagement.dictionaryOfcustomers)
            {
                if (customer.Value.customer_name.ToUpper().StartsWith(customer_name))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Search for " + customer_name);
                    Console.WriteLine("CUSTOMER ID: " + customer.Key);
                    Console.WriteLine("CUSTOMER NAME: " + customer.Value.customer_name);
                    Console.WriteLine("CUSTOMER ADDRESS: " + customer.Value.customer_address);
                    Console.WriteLine("CUSTOMER DATEOFBIRTH: " + customer.Value.customer_dateOfBirth);
                    Console.WriteLine("CUSTOMER EMAIL: " + customer.Value.customer_email);
                    Console.WriteLine("CUSTOMER PHONE: " + customer.Value.customer_phone);
                    Console.WriteLine("CUSTOMER CHEQUE IF ANY: " + customer.Value.cheque_book_number);
                    Console.WriteLine("CUSTOMER BALANCE: $" + customer.Value.customerBalance);
                    Console.WriteLine("CUSTOMER LOAN APPLIED IF ANY: " + customer.Value.customer_loan_applied);
                    Console.WriteLine("CUSTOMER LOAN AMOUNT IF ANY: " + customer.Value.loan_amount);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Account doesn't exist");
                }
            }
        }
        

        public void PerformOperation()
        {
            bool user_exited = false;
            while (!user_exited)
            {
                try
                {
                    Console.WriteLine("Screen 1");
                    Console.WriteLine("Select Option");
                    Console.WriteLine("1. Create Bank Employee");
                    Console.WriteLine("2: Remove Bank Employee");
                    Console.WriteLine("3: View all Employee");
                    Console.WriteLine("4: Ask employee to log in");                    
                    Console.WriteLine("5: Return to home screen");
                    int user_option = Int32.Parse(Console.ReadLine());

                    switch (user_option)
                    {
                        case 1:
                            {
                                HandleAccountOpeningEmployee newacc = new HandleAccountOpeningEmployee();
                                var new_user = HandleAccountOpeningEmployee.CreateUserAccount();
                                if (new_user != null)
                                {
                                    if (dictionaryOfEmployees.ContainsKey(new_user.bankemployee_id))
                                    {
                                        Console.WriteLine("Account already exists");
                                    }
                                    else
                                    {
                                        dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);

                                        try
                                        {

                                            // first time writing customer details to file
                                            string text = "ID " + new_user.bankemployee_id + " " + new_user.bankemployee_name + ".txt";
                                            FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                            StreamWriter streamWriter = new StreamWriter(fs);

                                            Console.WriteLine($"Dear Employee, your details for your checking, please check the detailed report: { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_id} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_name} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_address} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_dateOfBirth} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_designation} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_yearsOfService}");



                                            streamWriter.WriteLine($"Dear Employee, your details for your checking, please check the detailed report: { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_id} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_name} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_address} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_dateOfBirth} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_designation} { BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_yearsOfService}");
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
                                            BankEmployees emp = new BankEmployees()  // object creation
                                            {
                                                bankemployee_id = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_id,
                                                bankemployee_name = Convert.ToString(BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_name),
                                                bankemployee_address = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_address,
                                                bankemployee_dateOfBirth = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_dateOfBirth,
                                                bankemployee_designation = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_designation,
                                                bankemployee_yearsOfService = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_yearsOfService,

                                            };
                                            string jsontext = "ID " + new_user.bankemployee_id + " " + new_user.bankemployee_name + ".json";
                                            List<BankEmployees> employeeList = new List<BankEmployees>();
                                            employeeList.Add(emp);
                                            Console.WriteLine("uploading user details to json file");
                                            string employeeListJson = JsonConvert.SerializeObject(employeeList, Formatting.Indented);
                                            //File.Create("Employee.Json");
                                            File.WriteAllText(jsontext, employeeListJson);

                                            //Console.ReadLine();
                                            List<BankEmployees> empTemp = JsonConvert.DeserializeObject<List<BankEmployees>>(File.ReadAllText(jsontext));
                                            Console.ReadLine();

                                            // json write - list of all employees (append)
                                            BankEmployees Allemp = new BankEmployees()  // object creation
                                            {
                                                bankemployee_id = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_id,
                                                bankemployee_name = Convert.ToString(BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_name),
                                                bankemployee_address = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_address,
                                                bankemployee_dateOfBirth = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_dateOfBirth,
                                                bankemployee_designation = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_designation,
                                                bankemployee_yearsOfService = BankEmployeesManagement.dictionaryOfEmployees[new_user.bankemployee_id].bankemployee_yearsOfService,

                                            };
                                            string Alljsontext = "List of all banking employees.json";
                                            var jsonData = System.IO.File.ReadAllText(Alljsontext);
                                            List<BankEmployees> AllemployeeList = JsonConvert.DeserializeObject<List<BankEmployees>>(jsonData) ?? new List<BankEmployees>();

                                            AllemployeeList.Add(Allemp);
                                            Console.WriteLine("uploading user details to json file");
                                            jsonData = JsonConvert.SerializeObject(AllemployeeList, Formatting.Indented);
                                            //File.Create("Employee.Json");
                                            File.WriteAllText(Alljsontext, jsonData);
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
                                else
                                {
                                    Console.WriteLine("User creation failed try again");
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Key in employee id");
                                string new_user = Console.ReadLine();
                                if (dictionaryOfEmployees.ContainsKey(new_user))
                                {
                                    dictionaryOfEmployees.Remove(new_user);
                                    Console.WriteLine("ID employee: " + new_user + " has been removed");
                                }
                                else
                                {
                                    Console.WriteLine("Account doesn't exist");
                                }

                                break;
                            }
                        case 3:
                            {
                                foreach (var item in dictionaryOfEmployees)
                                {
                                    Console.WriteLine("{0} > {1}", item.Key, item.Value);
                                }
                                Console.WriteLine(" Viewing all employees here");
                                var bankemployee_id = Console.ReadLine();
                                var user = dictionaryOfEmployees[bankemployee_id];

                                dictionaryOfEmployees[bankemployee_id] = user;
                                break;
                            }
                        case 4:
                            {
                                HandleAccountOpeningEmployee.UserLogin();
                                bool user_exited1 = false;
                                while (!user_exited1)
                                {
                                    Console.WriteLine("1: Find customer by ID: ");
                                    Console.WriteLine("2: Find customer by name");
                                    Console.WriteLine("3: Logout and go back");
                                    int input = Int32.Parse(Console.ReadLine());

                                    switch (input)
                                    {
                                        case 1:
                                            {
                                                SearchCustomerByID();

                                                break;
                                            }
                                        case 2:
                                            {
                                                SearchCustomerByName();

                                                break;
                                            }
                                        case 3:
                                            {
                                                user_exited1 = true;
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }
                                
                                }
                                break;
                            }
                        case 5:
                            {
                                user_exited = true;
                                break;
                            }
                    }

                }
                catch
                {
                }

            }
            Console.WriteLine("Exiting the program");
        }
        
        public void RemoveCustomers()
        {
            Console.WriteLine("Key in employee id");
            string new_user = Console.ReadLine();
            if (dictionaryOfEmployees.ContainsKey(new_user))
            {
                dictionaryOfEmployees.Remove(new_user);
                Console.WriteLine("ID: " + new_user + " has been removed");
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
            }
        }
        public static void ListEmployees()
        {

            foreach (var employee in dictionaryOfEmployees)
            {
                Console.WriteLine("{0} > {1}", employee.Key, employee.Value);
                Console.WriteLine("Listing all current employees in database: ");

            }

        }
        void IBankEmployeesManagement.AddBankEmployees(BankEmployees bankemployee)
        {
            BankEmployeesManagement.AddBankEmployees(bankemployee);
        }
        void IBankEmployeesManagement.ListEmployees()
        {
            BankEmployeesManagement.ListEmployees();
        }
    }
}
