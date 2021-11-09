using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class Savings : ISavings
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();
        private readonly IConsoleIO ConsoleIO;
        private ISavings _savings;
        public Savings()
        {
            ConsoleIO = new ConsoleIO();
        }
        
        public Savings(ISavings savings)
        {
            _savings = savings;
        }
        public Savings(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public void performOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            bool exit = false;
            while (!exit)
            {
                
                ConsoleIO.WriteLine("In Savings account, key in operation" + "\n1: withdraw money" + "\n2: deposit money" + "\n3: view the balance" + "\n4: Exit savings operation");
                    var input = ConsoleIO.ReadLine();

                    switch (input)
                    {
                        case "1":
                            {
                                customerWithdrawl(cam, eam, mam);
                                break;
                            }
                        case "2":
                            {
                                customerDeposit(cam, eam, mam);
                                break;
                            }
                        case "3":
                            {
                                ViewBalance(cam);
                                break;
                            }
                        case "4":
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
        public decimal DepositLimit()
        {
            decimal maximumamount = 5000;
            return maximumamount;
        }
        public decimal TakeDepositInput()
        {
            ConsoleIO.WriteLine("Key in amount for deposit - we will use cheque if more than 5k");
            string depositAmountKeyedInByCustomer = ConsoleIO.ReadLine();
            decimal depositAmount = decimal.Parse(depositAmountKeyedInByCustomer);
            return depositAmount;
        }
        public bool customerDeposit(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                

                decimal depositAmount = TakeDepositInput();
                if (depositAmount > DepositLimit())
                {
                    var guid1 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid1; cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;

                    ConsoleIO.WriteLine("Amount is larger than 5000, we will process the cheque\n"); ConsoleIO.WriteLine(cam.dictionaryOfcustomers[customer_id].ToString() + "\n"); ConsoleIO.WriteLine(cam.dictionaryOfcustomers[customer_id].customer_name.ToString()); ConsoleIO.WriteLine(cam.dictionaryOfcustomers[customer_id].cheque_book_number.ToString());
                    ConsoleIO.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                    FileHandling fh = new FileHandling();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
                    return true;

                }
                if (depositAmount <= DepositLimit())
                {
                    Customer cust = new Customer();
                    cust.deposit(depositAmount); cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;


                    ConsoleIO.WriteLine($"Dear Customer, your deposit is: " + depositAmount.ToString("F") + " and current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                    FileHandling fh = new FileHandling();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
                    return true;
                }
            }
            else
            {
                ConsoleIO.WriteLine("Account id not found");
                return false;
            }
            return false;
        }
        public void customerWithdrawl(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal");

                decimal withdrawAmountKeyedInByCustomer = decimal.Parse(ConsoleIO.ReadLine());
                if (withdrawAmountKeyedInByCustomer <= 0)
                {
                    ConsoleIO.WriteLine("withdrawal amount should be more than 0");
                }
                else
                {
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance < withdrawAmountKeyedInByCustomer)
                    {
                        ConsoleIO.WriteLine("Your balance does not meet the requirement, insufficient funds in balance " + $"\nDear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance);
                    }
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer <= DepositLimit())
                    {
                        cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;


                        ConsoleIO.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer.ToString("F"));
                        ConsoleIO.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                        ConsoleIO.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                        FileHandling fh = new FileHandling();
                        fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);


                    }
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer > DepositLimit())
                    {

                        cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        ConsoleIO.WriteLine("Amount is larger than 5000, we will search for the cheque");

                        var guid2 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid2;

                        Console.WriteLine("{0} > {1} > {2}", cam.dictionaryOfcustomers[customer_id], cam.dictionaryOfcustomers[customer_id].customer_name, cam.dictionaryOfcustomers[customer_id].cheque_book_number);

                        ConsoleIO.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                        ConsoleIO.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                        FileHandling fh = new FileHandling();
                        fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);



                        ConsoleIO.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                    }
                }
            }
            else
            {
                ConsoleIO.WriteLine("Account id not found");
            }
        }
        public void ViewBalance(CustomerAccountManager cam)
        {
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("Customer balance is " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
            }
        }
        public static decimal AddSavings(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractSaving(decimal x, decimal y)
        {
            return x - y;
        }
        public static decimal Multiply(decimal x, decimal y, decimal z)
        {
            return x * y * z;
        }
        public static decimal Divide(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }

        }
        public static decimal Modulus(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x % y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }

        }
    }
}
