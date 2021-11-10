using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiLibrary.Models;
using WebApiLibrary.Utility;

namespace WebApiLibrary.Controllers
{
    class Savings
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();
        
        public Savings()
        {
            
        }
        public void performOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            bool exit = false;
            while (!exit)
            {

                Console.WriteLine("In Savings account, key in operation" + "\n1: withdraw money" + "\n2: deposit money" + "\n3: view the balance" + "\n4: Exit savings operation");
                var input = Console.ReadLine();

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

        public decimal TakeDepositInput()
        {
            Console.WriteLine("Key in amount for deposit - we will use cheque if more than 5k");
            string depositAmountKeyedInByCustomer = Console.ReadLine();
            decimal depositAmount = decimal.Parse(depositAmountKeyedInByCustomer);
            return depositAmount;
        }
        public decimal DepositLimit()
        {
            decimal maximumamount = 5000;
            return maximumamount;
        }
        public bool customerDeposit(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {

            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {


                decimal depositAmount = TakeDepositInput();
                if (depositAmount > DepositLimit())
                {
                    var guid1 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid1; cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;

                    Console.WriteLine("Amount is larger than 5000, we will process the cheque\n"); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].ToString() + "\n"); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customer_name.ToString()); Console.WriteLine(cam.dictionaryOfcustomers[customer_id].cheque_book_number.ToString());
                    Console.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                    FileManager fh = new FileManager();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
                    return true;

                }
                if (depositAmount <= DepositLimit())
                {
                    Customer cust = new Customer();
                    cust.deposit(depositAmount); cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance + depositAmount;


                    Console.WriteLine($"Dear Customer, your deposit is: " + depositAmount.ToString("F") + " and current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                    FileManager fh = new FileManager();
                    fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Account id not found");
                return false;
            }
            return false;
        }
        public void customerWithdrawl(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("we will use cheque if more than 5k" + "\nKey in amount for withdrawal");

                decimal withdrawAmountKeyedInByCustomer = decimal.Parse(Console.ReadLine());
                if (withdrawAmountKeyedInByCustomer <= 0)
                {
                    Console.WriteLine("withdrawal amount should be more than 0");
                }
                else
                {
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance < withdrawAmountKeyedInByCustomer)
                    {
                        Console.WriteLine("Your balance does not meet the requirement, insufficient funds in balance " + $"\nDear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance);
                    }
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer <= DepositLimit())
                    {
                        cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;


                        Console.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer.ToString("F"));
                        Console.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                        Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                        FileManager fh = new FileManager();
                        fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);


                    }
                    if (cam.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer > DepositLimit())
                    {

                        cam.dictionaryOfcustomers[customer_id].customerBalance = cam.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        Console.WriteLine("Amount is larger than 5000, we will search for the cheque");

                        var guid2 = Guid.NewGuid(); cam.dictionaryOfcustomers[customer_id].cheque_book_number = guid2;

                        Console.WriteLine("{0} > {1} > {2}", cam.dictionaryOfcustomers[customer_id], cam.dictionaryOfcustomers[customer_id].customer_name, cam.dictionaryOfcustomers[customer_id].cheque_book_number);

                        Console.WriteLine("Total Balance amount in the account...."); Thread.Sleep(5000);
                        Console.WriteLine(cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));

                        FileManager fh = new FileManager();
                        fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);



                        Console.WriteLine($"Dear Customer, your current balance is: " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
                    }
                }
            }
            else
            {
                Console.WriteLine("Account id not found");
            }
        }
        public void ViewBalance(CustomerAccountManager cam)
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("Customer balance is " + cam.dictionaryOfcustomers[customer_id].customerBalance.ToString("F"));
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
