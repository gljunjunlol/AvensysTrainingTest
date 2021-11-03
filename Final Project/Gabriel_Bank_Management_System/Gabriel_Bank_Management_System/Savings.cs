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
        public void performOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
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
                                customerWithdrawl(cmgt, bemgt, bmgt);
                                break;
                            }
                        case "2":
                            {
                                customerDeposit(cmgt, bemgt, bmgt);
                                break;
                            }
                        case "3":
                            {
                                ViewBalance(cmgt);
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
        public bool customerDeposit(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                

                decimal depositAmount = TakeDepositInput();
                if (depositAmount > DepositLimit())
                {
                    var guid1 = Guid.NewGuid(); cmgt.dictionaryOfcustomers[customer_id].cheque_book_number = guid1; cmgt.dictionaryOfcustomers[customer_id].customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;


                    ConsoleIO.WriteLine("Amount is larger than 5000, we will process the cheque\n"); ConsoleIO.WriteLine(cmgt.dictionaryOfcustomers[customer_id].ToString() + "\n"); ConsoleIO.WriteLine(cmgt.dictionaryOfcustomers[customer_id].customer_name.ToString()); ConsoleIO.WriteLine(cmgt.dictionaryOfcustomers[customer_id].cheque_book_number.ToString());



                    //// writing customer details to file (cheque deposit)
                    //string text1 = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                    //FileStream fs1 = new FileStream(text1, FileMode.Append, FileAccess.Write); StreamWriter streamWriter1 = new StreamWriter(fs1);


                    //streamWriter1.WriteLine($"Dear Customer, your cheque deposit is: " + depositAmount + $"\nDear Customer, cheque number issued is: " + customer_id + "," + cmgt.dictionaryOfcustomers[customer_id].customer_name + ", have issued cheque " + guid1 + $"\nDear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", cmgt.dictionaryOfcustomers[customer_id], cmgt.dictionaryOfcustomers[customer_id].customer_name, cmgt.dictionaryOfcustomers[customer_id].cheque_book_number + $"\nDear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                    //streamWriter1.Flush(); streamWriter1.Close(); fs1.Close();


                    ConsoleIO.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);


                    FileHandling fh = new FileHandling();
                    fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
                    return true;



                    


                }
                if (depositAmount <= DepositLimit())
                {
                    Customer cust = new Customer();
                    cust.deposit(depositAmount); cmgt.dictionaryOfcustomers[customer_id].customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;


                    //// writing customer details to file (deposit)
                    //string text = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                    //FileStream fs = new FileStream(text, FileMode.Append, FileAccess.Write);
                    //StreamWriter streamWriter = new StreamWriter(fs);

                    //streamWriter.WriteLine($"Dear Customer, your deposit is: " + depositAmount + $"\nDear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                    //streamWriter.Flush(); streamWriter.Close(); fs.Close();


                    ConsoleIO.WriteLine($"Dear Customer, your deposit is: " + depositAmount + " and current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                    FileHandling fh = new FileHandling();
                    fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
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
        public void customerWithdrawl(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal");

                decimal withdrawAmountKeyedInByCustomer = Int32.Parse(ConsoleIO.ReadLine());
                if (withdrawAmountKeyedInByCustomer <= 0)
                {
                    ConsoleIO.WriteLine("withdrawal amount should be more than 0");
                }
                else
                {
                    if (cmgt.dictionaryOfcustomers[customer_id].customerBalance < withdrawAmountKeyedInByCustomer)
                    {
                        ConsoleIO.WriteLine("Your balance does not meet the requirement, insufficient funds in balance " + $"\nDear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                        //Console.WriteLine("Bank overdraft of " + Math.Abs(Customer.customerBalance));
                    }
                    if (cmgt.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer <= DepositLimit())
                    {
                        cmgt.dictionaryOfcustomers[customer_id].customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        //Console.WriteLine(cmgt.dictionaryOfcustomers[customer_id].customerBalance);

                        //// writing customer details to file (withdrawal)
                        //string text = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                        //FileStream fs = new FileStream(text, FileMode.Append, FileAccess.Write); StreamWriter streamWriter = new StreamWriter(fs);


                        ConsoleIO.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer);

                        //streamWriter.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer);
                        ConsoleIO.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                        ConsoleIO.WriteLine(cmgt.dictionaryOfcustomers[customer_id].customerBalance.ToString());
                        //streamWriter.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);


                        //streamWriter.Flush(); streamWriter.Close(); fs.Close(); ConsoleIO.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                        FileHandling fh = new FileHandling();
                        fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);


                    }
                    if (cmgt.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer > DepositLimit())
                    {

                        cmgt.dictionaryOfcustomers[customer_id].customerBalance = cmgt.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        ConsoleIO.WriteLine("Amount is larger than 5000, we will search for the cheque");

                        var guid2 = Guid.NewGuid(); cmgt.dictionaryOfcustomers[customer_id].cheque_book_number = guid2;

                        Console.WriteLine("{0} > {1} > {2}", cmgt.dictionaryOfcustomers[customer_id], cmgt.dictionaryOfcustomers[customer_id].customer_name, cmgt.dictionaryOfcustomers[customer_id].cheque_book_number);

                        // writing customer details to file (cheque withdrawal)
                        //string text1 = "ID " + customer_id + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                        //FileStream fs1 = new FileStream(text1, FileMode.Append, FileAccess.Write);
                        //StreamWriter streamWriter1 = new StreamWriter(fs1);

                        //streamWriter1.WriteLine($"Dear Customer, your cheque withdraw amount is: " + withdrawAmountKeyedInByCustomer + $"\nDear Customer, cheque number used is: " + customer_id + "," + cmgt.dictionaryOfcustomers[customer_id].customer_name + ", have used cheque " + guid2 + $"\nDear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", cmgt.dictionaryOfcustomers[customer_id], cmgt.dictionaryOfcustomers[customer_id].customer_name, cmgt.dictionaryOfcustomers[customer_id].cheque_book_number);

                        ConsoleIO.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);

                        ConsoleIO.WriteLine(cmgt.dictionaryOfcustomers[customer_id].customerBalance.ToString());
                        //streamWriter1.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                        //streamWriter1.Flush(); streamWriter1.Close(); fs1.Close();
                        FileHandling fh = new FileHandling();
                        fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);



                        ConsoleIO.WriteLine($"Dear Customer, your current balance is: " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
                    }
                }
            }
            else
            {
                ConsoleIO.WriteLine("Account id not found");
            }
        }
        public void ViewBalance(CustomersManagement cmgt)
        {
            ConsoleIO.WriteLine("Key in customer id");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                ConsoleIO.WriteLine("Customer balance is " + cmgt.dictionaryOfcustomers[customer_id].customerBalance);
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
