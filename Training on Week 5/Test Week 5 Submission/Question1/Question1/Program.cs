using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Question1
{
    class Program
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();  // cheque number

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("1 : Sign up a customer");
                    Console.WriteLine("2 :  List approved customers");
                    Console.WriteLine("3 :  deposit");
                    Console.WriteLine("4 :  Withdrawal");
                    Console.WriteLine("5: : Loan applies");
                    Console.WriteLine("6 :  Exit");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                Console.WriteLine("Add a new customer");
                                CustomerManagement cmgt = new CustomerManagement();
                                Console.WriteLine("Enter new customer id: ");
                                int customerID = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new customer name");
                                string customerName = Console.ReadLine();
                                Console.WriteLine("Enter customer salary");
                                double customerSalary = double.Parse(Console.ReadLine());
                                Thread t2 = new Thread(() => { cmgt.AddCustomer(new Customer(customerID, customerName, customerSalary, 0)); });
                                t2.Start();


                                string file = @"D:\textfile.txt";
                                if (!File.Exists(file))
                                {
                                    File.Create(file);
                                }

                                Console.WriteLine("Reading File using File.ReadAllText()");
                                if (File.Exists(file))
                                {
                                    try
                                    {
                                        using (StreamWriter writetext = new StreamWriter(file, true))
                                        {

                                            writetext.WriteLine("Customer ID is " + customerID);
                                            writetext.WriteLine("Customer Name is " + customerName);
                                            writetext.WriteLine("Customer Salary is " + customerSalary);
                                            writetext.WriteLine("");
                                            //writetext.Write("test");
                                            writetext.Flush();

                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("some error, try again");
                                    }

                                    Console.WriteLine("ok done");
                                    Console.ReadKey();

                                }
                                if (File.Exists(file))
                                {
                                    try
                                    {
                                        // Read file using StreamReader. Reads file line by line  
                                        using (StreamReader writetext = new StreamReader(file, true))
                                        {
                                            int counter = 0;
                                            string ln;

                                            while ((ln = writetext.ReadLine()) != null)
                                            {
                                                Console.WriteLine(ln);
                                                counter++;
                                            }
                                            writetext.Close();
                                            Console.WriteLine($"File has {counter} lines.");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("some error reading, try again");
                                    }

                                }
                                break;
                            }
                        case 2:
                            {
                                CustomerManagement cmgt = new CustomerManagement();
                                Thread t4 = new Thread(() => { cmgt.ListCustomers(); });
                                t4.Start();
                                break;
                            }
                        case 3:
                            {
                                CustomerManagement cmgt = new CustomerManagement();
                                Console.WriteLine("Key in customer ID");
                                int customerid = Int32.Parse(Console.ReadLine());
                                Customer cust1 = new Customer(customerid, "", 0, 0);
                                Console.WriteLine("Key in amount for deposit");
                                decimal input5 = Int32.Parse(Console.ReadLine());
                                if (input5 > 5000)
                                {
                                    Console.WriteLine("sorry 5000 limit, please use cheque");
                                    var guid1 = Guid.NewGuid();
                                    Console.WriteLine($"New cheque issued number: " + guid1);

                                    cheque.Add(customerid, guid1);
                                    foreach (var customer in cheque)
                                    {
                                        Console.WriteLine("Listing all cheques issued: ");
                                        Console.WriteLine("{0} > {1}", customer.Key, customer.Value);

                                    }

                                    cust1.deposit(input5);
                                    Console.WriteLine();
                                }

                                break;
                            }
                        case 4:
                            {
                                CustomerManagement cgmt = new CustomerManagement();

                                Console.WriteLine("Key in customer ID");
                                int customerid = Int32.Parse(Console.ReadLine());
                                Customer cust1 = new Customer(customerid, "", 0, 0);
                                Console.WriteLine("Key in amount for withdrawal");
                                decimal input6 = Int32.Parse(Console.ReadLine());
                                if (CustomerManagement.customers.ContainsKey(customerid))
                                {
                                    if (input6 > 5000)
                                    {
                                        Console.WriteLine("sorry 5000 limit, please use cheque");
                                        var guid1 = Guid.NewGuid();
                                        Console.WriteLine($"New cheque issued number: " + guid1);

                                        cheque.Add(customerid, guid1);
                                        foreach (var customer in cheque)
                                        {
                                            Console.WriteLine("Listing all cheques issued: ");
                                            Console.WriteLine("{0} > {1}", customer.Key, customer.Value);

                                        }
                                    }
                                    Console.WriteLine("Total Balance amount in the account....");
                                    Thread.Sleep(5000);

                                    CustomerManagement.customers[customerid] = new Tuple<string, double, decimal>("", 0, input6);
                                    cust1.withdraw(input6);
                                    if (cust1.customerBalance < 0)
                                    {
                                        Console.WriteLine("Bank overdraft of " + Math.Abs(cust1.customerBalance));
                                    }
                                    else
                                    {
                                        Console.WriteLine(cust1.customerBalance);
                                    }
                                }




                                break;
                            }
                        case 5:
                            {
                                LoanApplies loan1 = new LoanApplies();
                                loan1.ApplyLoan();
                                break;
                            }
                        case 6:
                            {
                                loop = false;
                                break;
                            }
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Incorrectformat");
                }
                finally
                {

                }
            }
            Console.WriteLine("Exiting program");
            Console.ReadLine();
        }


        static void FileHandling()
        {

            
        }
    }
}



