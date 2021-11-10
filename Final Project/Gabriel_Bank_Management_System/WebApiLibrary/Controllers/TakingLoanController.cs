using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Utility;

namespace WebApiLibrary.Controllers
{
    class TakingLoan
    {
        public TakingLoan()
        {
            
        }
        public decimal CalculateLoanAmount(decimal amt, decimal interest, int month)
        {
            Console.WriteLine("Enter loan application amount");
            decimal loanamount = decimal.Parse(Console.ReadLine());
            DateTime datetime = DateTime.Now;
            Console.WriteLine("Taking a loan at: " + datetime + "");
            Console.WriteLine("Key in amount of months to repay / installment");
            decimal monthsIn = decimal.Parse(Console.ReadLine()); var months = Divide(monthsIn, 12);
            Console.WriteLine("Key in % of interest of loan"); decimal interestamount = decimal.Parse(Console.ReadLine()); var interests = Divide(interestamount, 100); decimal totalloanamount = AddLoan(loanamount, Multiply(loanamount, interests, months));
            // principal loan amount * interest rate * number of years in term = total interest paid



            Console.WriteLine("Total loan calculated after interest\n" + totalloanamount.ToString("F") + "\nChecking for approval....\nLoan of: $" + totalloanamount.ToString("F") + " will repay in" + monthsIn + " installments or $" + (totalloanamount / monthsIn).ToString("F") + " monthly");
            return totalloanamount;
        }
        public void LoanAccount(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cam.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    decimal totalloanamount = CalculateLoanAmount(0, 0, 0);
                    Console.WriteLine("Loan application : ID : " + cam.dictionaryOfcustomers[customer_id] + " " + cam.dictionaryOfcustomers[customer_id].customer_name);

                    cam.dictionaryOfcustomers[customer_id].customer_loan_applied = true; cam.dictionaryOfcustomers[customer_id].loan_amount = totalloanamount;
                    FileManager fh = new FileManager(); fh.ReadingandWritingcustomer(customer_id, cam, eam, mam);
                }

                else
                {
                    Console.WriteLine("Already applied for loan which is unpaid");

                }
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");

            }
        }

        public void ViewLoan(CustomerAccountManager cam)
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cam.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    Console.WriteLine("Current loan is at $" + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                }
                else
                {
                    Console.WriteLine("Current loan is at $0");
                }

            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }
        }

        public void AddLoan(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            Console.WriteLine("Enter customer ID again to ensure of taking loan again");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cam.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    Console.WriteLine(customer_id);
                    TakingLoan tk = new TakingLoan();
                    tk.LoanAccount(cam, eam, mam);



                }
                else
                {
                    Console.WriteLine("Sorry cant take additional loan as previous loan is still outstanding");
                }
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }

        }
        public void RepayLoan(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (cam.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cam.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    Console.WriteLine("Current loan is at " + cam.dictionaryOfcustomers[customer_id].loan_amount.ToString("F") + "\nE.g. key in 100 to repay 100 or / key in  6% to repay 6%");
                    string repayLoan = Console.ReadLine();
                    if (repayLoan.Contains("%") == true)
                    {
                        var charsToRemove = new string[] { "%" };
                        foreach (var c in charsToRemove)
                        {
                            repayLoan = repayLoan.Replace(c, string.Empty);
                        }
                        decimal repayLoanParse = decimal.Parse(repayLoan);
                        decimal amountToRepay = Multiply(repayLoanParse, Divide(cam.dictionaryOfcustomers[customer_id].loan_amount, 100), 1);
                        Console.WriteLine("Amount to repay is: $" + amountToRepay.ToString("F"));
                        decimal remainingLoanLeft = SubtractLoan(cam.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);
                        if (amountToRepay > cam.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            Console.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {


                            Console.WriteLine("Loan amount left: $" + remainingLoanLeft.ToString("F"));
                            cam.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;
                            if (remainingLoanLeft == 0)
                            {
                                cam.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                            }
                            FileManager fh1 = new FileManager();
                            fh1.ReadingandWritingcustomer(customer_id, cam, eam, mam);

                        }
                    }
                    else
                    {
                        decimal amountToRepay = decimal.Parse(repayLoan);
                        Console.WriteLine("Amount to repay is: $" + amountToRepay);
                        decimal remainingLoanLeft = SubtractLoan(cam.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);
                        if (amountToRepay > cam.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            Console.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {
                            Console.WriteLine("Loan amount left: $" + remainingLoanLeft);
                            cam.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;
                            if (remainingLoanLeft == 0)
                            {
                                cam.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                            }
                            FileManager fh1 = new FileManager();
                            fh1.ReadingandWritingcustomer(customer_id, cam, eam, mam);

                        }

                    }
                }
                else
                {
                    Console.WriteLine("No loan to repay");
                }
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }

        }
        public void performOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            Console.WriteLine("Taking loan here");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("In Loan account, key in required operation" + "\n1: Apply for a new loan" + "\n2: Apply for additional loan" + "\n3: view the loan" + "\n4: Repay loan amount" + "\n5: Exit loans operation");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            LoanAccount(cam, eam, mam);
                            break;
                        }
                    case "2":
                        {
                            AddLoan(cam, eam, mam);
                            break;
                        }
                    case "3":
                        {
                            ViewLoan(cam);
                            break;
                        }
                    case "4":
                        {
                            RepayLoan(cam, eam, mam);
                            break;
                        }
                    case "5":
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












        public static decimal AddLoan(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractLoan(decimal x, decimal y)
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
