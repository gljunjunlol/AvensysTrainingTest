using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    class BankManagersManagement : BankEmployeesManagement, IBankManagersManagement
    {

        public static Dictionary<string, BankManagers> dictionaryOfManagers = new Dictionary<string, BankManagers>();
        public static void ListCustomers()
        {

            foreach (var customer in CustomersManagement.dictionaryOfcustomers)
            {
                Console.WriteLine("{0} > {1}", customer.Key, customer.Value);
                Console.WriteLine("Listing all current customers in database: ");
                
                
            }

        }
        public static void TotalLoanAmount()
        {
            List<string> selectedList = new List<string>();
            var sum1 = CustomersManagement.dictionaryOfcustomers.Sum(x => x.Value.loan_amount);

            Console.WriteLine(sum1.ToString("F"));
                
        }
        public static void TotalSavingsAccount()
        {
            var totalsavingsofCustomers = CustomersManagement.dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            Console.WriteLine(totalsavingsofCustomers.ToString("F"));
        }
        public void performOperationAdvanced()
        {
            bool user_exited = false;
            while (!user_exited)
            {
                try
                {
                    Console.WriteLine("Select Option (Involving Manager access only)");
                    Console.WriteLine("1: Create Bank Manager");
                    
                    Console.WriteLine("2: View Managers");
                    Console.WriteLine("3: Login");
                    Console.WriteLine("4: Return to home screen");
                    int user_option = Int32.Parse(Console.ReadLine());

                    switch (user_option)
                    {
                        case 1:
                            {
                                HandleAccountOpeningBankManager newacc = new HandleAccountOpeningBankManager();
                                var new_user = HandleAccountOpeningBankManager.CreateUserAccount();
                                if (new_user != null)
                                {
                                    if (dictionaryOfManagers.ContainsKey(new_user.bankmanager_id))
                                    {
                                        Console.WriteLine("Account already exists");
                                    }
                                    else
                                    {
                                        dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
                                        try
                                        {
                                            // first time writing customer details to file
                                            string text = "ID " + new_user.bankmanager_id + " " + new_user.bankmanager_name + ".txt";
                                            FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                            StreamWriter streamWriter = new StreamWriter(fs);
                                            string managerName = char.ToUpper(new_user.bankmanager_name[0]) + new_user.bankmanager_name.Substring(1);
                                            Console.WriteLine($"Dear " + managerName + $" , your details for your checking, please check the detailed report: { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_id} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_name} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_address} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_dateOfBirth} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_designation} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_yearsOfService}");



                                            streamWriter.WriteLine($"Dear " + managerName + $" , your details for your checking, please check the detailed report: { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_id} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_name} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_address} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_dateOfBirth} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_designation} { BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_yearsOfService}");
                                            streamWriter.Flush();
                                            streamWriter.Close();
                                            fs.Close();

                                            // first time reading customer details on file
                                            FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                                            StreamReader sr1 = new StreamReader(fs2);
                                            Console.WriteLine("Printing content of text file after written detailed report");
                                            sr1.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                                            string str1 = sr1.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                                            Console.WriteLine(str1);
                                            //while (str != null)
                                            //{
                                            //    Console.WriteLine(str);
                                            //    str = sr.ReadLine();
                                            //}
                                            sr1.Close();
                                            fs2.Close();

                                            // Json format - first time writing
                                            BankManagers mgr = new BankManagers()  // object creation
                                            {
                                                bankmanager_id = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_id,
                                                bankmanager_name = Convert.ToString(BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_name),
                                                bankmanager_address = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_address,
                                                bankmanager_dateOfBirth = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_dateOfBirth,
                                                bankmanager_designation = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_designation,
                                                bankmanager_yearsOfService = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_yearsOfService,

                                            };
                                            string jsontext = "ID " + new_user.bankmanager_id + " " + new_user.bankmanager_name + ".json";
                                            List<BankManagers> managerList = new List<BankManagers>();
                                            managerList.Add(mgr);
                                            Console.WriteLine("uploading user details to json file");
                                            string managerListJson = JsonConvert.SerializeObject(managerList, Formatting.Indented);
                                            //File.Create("Manager.Json");
                                            File.WriteAllText(jsontext, managerListJson);

                                            //Console.ReadLine();
                                            List<BankManagers> mgrTemp = JsonConvert.DeserializeObject<List<BankManagers>>(File.ReadAllText(jsontext));
                                            Console.ReadLine();

                                            // json write - list of all managers (append)
                                            BankManagers Allmgr = new BankManagers()  // object creation
                                            {
                                                bankmanager_id = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_id,
                                                bankmanager_name = Convert.ToString(BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_name),
                                                bankmanager_address = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_address,
                                                bankmanager_dateOfBirth = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_dateOfBirth,
                                                bankmanager_designation = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_designation,
                                                bankmanager_yearsOfService = BankManagersManagement.dictionaryOfManagers[new_user.bankmanager_id].bankmanager_yearsOfService,

                                            };
                                            string Alljsontext = "List of all banking managers.json";
                                            var jsonData = System.IO.File.ReadAllText(Alljsontext);
                                            List<BankManagers> AllmanagersList = JsonConvert.DeserializeObject<List<BankManagers>>(jsonData) ?? new List<BankManagers>();

                                            AllmanagersList.Add(Allmgr);
                                            Console.WriteLine("uploading user details to json file");
                                            jsonData = JsonConvert.SerializeObject(AllmanagersList, Formatting.Indented);
                                            //File.Create("Manager.Json");
                                            File.WriteAllText(Alljsontext, jsonData);

                                            //Console.ReadLine();

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
                                foreach (var item in dictionaryOfManagers)
                                {
                                    Console.WriteLine("{0} > {1}", item.Key, item.Value);
                                }
                                Console.WriteLine(" Viewing all manager here");
                                var bankmanager_id = Console.ReadLine();
                                var user = dictionaryOfManagers[bankmanager_id];

                                dictionaryOfManagers[bankmanager_id] = user;
                                break;
                            }
                        case 3:
                            {
                                HandleAccountOpeningBankManager.UserLogin();
                                bool user_exited1 = false;
                                while (!user_exited1)
                                {
                                    Console.WriteLine("1: Find customer by ID: ");
                                    Console.WriteLine("2: Find customer by name");
                                    Console.WriteLine("3: Advanced access");
                                    Console.WriteLine("4: Logout and go back");
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
                                                Console.WriteLine("1. List of total customers / 1: View all users (customers)");
                                                Console.WriteLine("2: List of Total Loan amount");
                                                Console.WriteLine("3: List of Total saving account of customers / budgeting purposes / manage tracking");
                                                Console.WriteLine("4: Go back to the previous screen (Screen 1) / Logout and go back");
                                                int ManagerChoice = Int32.Parse(Console.ReadLine());
                                                switch (ManagerChoice)
                                                {

                                                    case 1:
                                                        {
                                                            ListCustomers();
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            TotalLoanAmount();
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            TotalSavingsAccount();
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            user_exited1 = true;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        case 4:
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
                        case 4:
                            {
                                user_exited = true;
                                break;
                            }
                        default:
                            {
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
        void IBankManagersManagement.ListCustomers()
        {
            BankManagersManagement.ListCustomers();
        }
        void IBankManagersManagement.TotalLoanAmount()
        {
            BankManagersManagement.TotalLoanAmount();
        }
        void IBankManagersManagement.TotalSavingsAccount()
        {
            BankManagersManagement.TotalSavingsAccount();
        }
    }
}
