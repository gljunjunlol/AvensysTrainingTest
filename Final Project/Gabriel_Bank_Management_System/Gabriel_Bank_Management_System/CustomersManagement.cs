using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    class CustomersManagement : ICustomersManagement
    {
        public static Dictionary<string, Customer> dictionaryOfcustomers = new Dictionary<string, Customer>();

        public CustomersManagement()
        {
            if (!File.Exists("BankCustomerInformation.txt"))
            {
                //Console.WriteLine("!!!!No Previous Data Exist!!!!");
                return;
            }
            FileStream fs = new FileStream("Customer details.txt", FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs);

            string str = sr.ReadLine();
            while (str != null)
            {
                var strarr = str.Split('_');    //get array of customer id ..etc in string
                var user = new Customer(strarr[0], strarr[1], strarr[2], Convert.ToDateTime(strarr[3]), strarr[4], strarr[5], strarr[6], strarr[7], Convert.ToDecimal(strarr[8]), Guid.Parse(strarr[9]), Convert.ToBoolean(strarr[10]), Convert.ToDecimal(strarr[11]));
                if (dictionaryOfcustomers.ContainsKey(strarr[0]))
                {
                    dictionaryOfcustomers.Add(strarr[0], user);
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void AddCustomer(Customer customer)
        {
            try
            {

                HandleAccountOpening newacc = new HandleAccountOpening();
                var new_user = HandleAccountOpening.CreateUserAccount();
                if (new_user != null)
                {
                    if (dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        dictionaryOfcustomers.Add(new_user.customer_id, new_user);
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
        void ICustomersManagement.AddCustomer(Customer customer)
        {
            CustomersManagement.AddCustomer(customer);
        }

        void ICustomersManagement.ListCustomers()
        {
            CustomersManagement.ListCustomers();
        }

        public void RemoveCustomers()
        {
            Console.WriteLine("Key in customer id");
            string new_user = Console.ReadLine();
            if (dictionaryOfcustomers.ContainsKey(new_user))
            {
                dictionaryOfcustomers.Remove(new_user);
                Console.WriteLine("ID: " + new_user + " has been removed");
            }
            else
            {
                Console.WriteLine("Account doesn't exist");
            }
        }

        public void PerformOperation()
        {
            bool user_exited = false;
            while (!user_exited)
            {
                try
                {
                    Console.WriteLine("Screen 1 -- customers only");
                    Console.WriteLine("1. Create User");
                    Console.WriteLine("2: Remove User");
                    Console.WriteLine("Seek help from bank operator");
                    Console.WriteLine("3: Ask user to log in");
                    Console.WriteLine("4: Return to home screen");
                    int user_option = Int32.Parse(Console.ReadLine());

                    switch (user_option)
                    {
                        case 1:
                            {
                                HandleAccountOpening newacc = new HandleAccountOpening();
                                var new_user = HandleAccountOpening.CreateUserAccount();
                                if (new_user != null)
                                {
                                    if (dictionaryOfcustomers.ContainsKey(new_user.customer_id))
                                    {
                                        Console.WriteLine("Account already exists");
                                    }
                                    else
                                    {
                                        dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                                        try
                                        {
                                            // first time writing customer details to file
                                            string text = "ID " + new_user.customer_id + " " + new_user.customer_name + ".txt";
                                            FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                            StreamWriter streamWriter = new StreamWriter(fs);

                                            Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].loan_amount}");



                                            streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[new_user.customer_id].loan_amount}");
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
                                            sr1.Close();
                                            fs2.Close();

                                            // Json format - first time writing
                                            Customer cust = new Customer()  // object creation
                                            {
                                                customer_id = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_id,
                                                customer_name = Convert.ToString(CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_name),
                                                customer_address = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_address,
                                                customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_dateOfBirth,
                                                customer_email = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_email,
                                                customer_phone = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_phone,

                                            };
                                            string jsontext = "ID " + new_user.customer_id + " " + new_user.customer_name + ".json";
                                            List<Customer> customerList = new List<Customer>();
                                            customerList.Add(cust);
                                            Console.WriteLine("uploading user details to json file");
                                            string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                                            //File.Create("Customer.Json");
                                            File.WriteAllText(jsontext, customerListJson);

                                            //Console.ReadLine();
                                            List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                                            Console.ReadLine();

                                            // json write - list of all customers (append)
                                            Customer Allcust = new Customer()  // object creation
                                            {
                                                customer_id = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_id,
                                                customer_name = Convert.ToString(CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_name),
                                                customer_address = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_address,
                                                customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_dateOfBirth,
                                                customer_email = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_email,
                                                customer_phone = CustomersManagement.dictionaryOfcustomers[new_user.customer_id].customer_phone,

                                            };
                                            string Alljsontext = "List of all banking customers.json";
                                            var jsonData = System.IO.File.ReadAllText(Alljsontext);
                                            List<Customer> AllcustomerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData) ?? new List<Customer>();
                                            //List<Customer> AllcustomerList = new List<Customer>();
                                            AllcustomerList.Add(Allcust);
                                            Console.WriteLine("uploading user details to json file");
                                            jsonData = JsonConvert.SerializeObject(AllcustomerList, Formatting.Indented);
                                            //File.Create("Customer.Json");
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
                                        catch(Exception)
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
                                Console.WriteLine("Key in user id");
                                string new_user = Console.ReadLine();
                                if (dictionaryOfcustomers.ContainsKey(new_user))
                                {
                                    dictionaryOfcustomers.Remove(new_user);
                                    Console.WriteLine("ID: " + new_user + " has been removed");
                                }
                                else
                                {
                                    Console.WriteLine("Account doesn't exist");
                                }

                                break;
                            }
                        case 3:
                            {
                                HandleAccountOpening.UserLogin();
                                break;
                            }
                        case 4:
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
        public static void ListCustomers()
        {

            foreach (var customer in dictionaryOfcustomers)
            {
                Console.WriteLine("{0} > {1}", customer.Key, customer.Value);
                Console.WriteLine("Listing all current customers in database: ");
                //Console.WriteLine("{0} > {1}", customer.Key, customer.Value.Item1, customer.Value.Item2, customer.Value.customer_id);

            }

        }

        public void SavingsAccount()
        {

        }

        public void WriteAllTransactionInFile()
        {
            throw new NotImplementedException();
            // override existing file
            // write content of dict in file
        }
    }
}
