using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankOperatorManagement bomgt = new BankOperatorManagement();
            bomgt.AddOperator();
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("1 : Sign up a bank loan");
                    Console.WriteLine("2 :  List approved customers");
                    Console.WriteLine("3 : Document verification -- already have account");
                    Console.WriteLine("4 :  Negotiating the loan details");
                    Console.WriteLine("5 :  Final approval and deposit");
                    Console.WriteLine("6 :  Withdrawal");
                    Console.WriteLine("7 : Exit");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                Console.WriteLine("Sign up new bank loan: Y / N");
                                string input1 = Console.ReadLine();
                                if (input1 == "Y" || input1 == "y")
                                {
                                    Loan loan = new Loan();
                                    CustomerManagement cmgt = new CustomerManagement();
                                    Console.WriteLine("Enter new customer id: ");
                                    int customerID = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter new customer name");
                                    string customerName = Console.ReadLine();
                                    Console.WriteLine("Enter customer salary");
                                    double customerSalary = double.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter vaccinnation status, true or false");
                                    bool vaccination = bool.Parse(Console.ReadLine());
                                    if (vaccination == true)
                                    {
                                        Thread t2 = new Thread(() => { cmgt.AddCustomer(new Customer(customerID, customerName, customerSalary, 0)); });
                                        t2.Start();
                                    }
                                    else
                                    {
                                        Thread t2 = new Thread(() => { cmgt.AddCustomer(new Customer(customerID, customerName, customerSalary, 0)); });
                                        Console.WriteLine("We will still assist you");
                                    }
                                    Console.WriteLine("Minimum salary to borrow: 1500");
                                    if (customerSalary > 1500)
                                    {
                                        Loan loan1 = new Loan();
                                        loan1.ApplyLoan();
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
                                Console.WriteLine("Enter your customer ID");
                                int customerid = Int32.Parse(Console.ReadLine());
                                if (CustomerManagement.customers.ContainsKey(customerid))
                                {
                                    Console.WriteLine("ID found, please key in your country ID for KYC application");
                                    int input3 = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine(input3 + " is being processed.....");
                                    //CustomerManagement.customers[customerid] = new Tuple<string, double, int>("", 20000.00, 500);
                                }
                                else
                                {
                                    Console.WriteLine(" Not signed up yet");
                                }


                                    break;
                            }

                        case 4:
                            {
                                Console.WriteLine("Enter your customer ID");
                                int customerid = Int32.Parse(Console.ReadLine());
                                if (CustomerManagement.customers.ContainsKey(customerid))
                                {
                                    Console.WriteLine("ID found, please check to calculate interest rate is ok...wait");
                                    Thread.Sleep(5000);
                                    Console.WriteLine("Key in loan period in months..");
                                    int input3 = Int32.Parse(Console.ReadLine());
                                    double input4 = input3 / 2.5;
                                    Console.WriteLine("Interest rate is at " + (input4) + " per annum" );
                                    
                                    Console.WriteLine(" loan is being processed.....");
                                    Loan.loanamount.Add(input4);
                                }
                                else
                                {
                                    Console.WriteLine(" Not signed up yet");
                                }
                                //Admin result = new Admin();
                                //result.ListStudentsResults();
                                break;
                            }
                        case 5:
                            {
                                foreach (int i in Loan.loanamount)
                                {
                                    Console.WriteLine(i + " all are approved");
                                }
                                Console.WriteLine("Key in amount for deposit");
                                decimal input5 = Int32.Parse(Console.ReadLine());
                                Customer.deposit(input5);
                                Console.WriteLine();
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Key in amount for withdrawal");
                                decimal input6 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Total Balance amount in the account....");
                                Thread.Sleep(5000);
                                Customer.withdraw(input6);
                                if (Customer.customerBalance < 0)
                                {
                                    Console.WriteLine("Bank overdraft of " + Math.Abs(Customer.customerBalance));
                                }
                                else
                                {
                                    Console.WriteLine(Customer.customerBalance);
                                }
                                
                                break;
                            }
                        case 7:
                            {
                                loop = false;
                                break;
                            }
                    }
                }
                catch (FormatException)
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
    }
}
