using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    public class TakingLoan
    {
        private readonly IConsoleIO ConsoleIO;
        public TakingLoan()
        {
            ConsoleIO = new ConsoleIO();
        }
        public TakingLoan(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public decimal CalculateLoanAmount(decimal amt, decimal interest, int month)
        {
            ConsoleIO.WriteLine("Enter loan application amount");
            decimal loanamount = decimal.Parse(ConsoleIO.ReadLine());
            DateTime datetime = DateTime.Now;
            ConsoleIO.WriteLine("Taking a loan at: " + datetime + "");
            ConsoleIO.WriteLine("Key in amount of months to repay / installment");
            decimal monthsIn = decimal.Parse(ConsoleIO.ReadLine()); var months = Divide(monthsIn, 12);
            ConsoleIO.WriteLine("Key in % of interest of loan"); decimal interestamount = decimal.Parse(ConsoleIO.ReadLine()); var interests = Divide(interestamount, 100); decimal totalloanamount = AddLoan(loanamount, Multiply(loanamount, interests, months));
            // principal loan amount * interest rate * number of years in term = total interest paid



            ConsoleIO.WriteLine("Total loan calculated after interest\n" + totalloanamount.ToString("F\n") + "\nChecking for approval....\nLoan of: $" + totalloanamount.ToString("F") + " will repay in" + monthsIn + " installments or $" + (totalloanamount / monthsIn).ToString("F") + " monthly");
            return totalloanamount;
        }
        public void LoanAccount(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            ConsoleIO.WriteLine("Enter customer ID");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    decimal totalloanamount = CalculateLoanAmount(0, 0, 0);
                    ConsoleIO.WriteLine("Loan application : ID : " + cmgt.dictionaryOfcustomers[customer_id] + " " + cmgt.dictionaryOfcustomers[customer_id].customer_name);

                    cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied = true; cmgt.dictionaryOfcustomers[customer_id].loan_amount = totalloanamount; 
                    FileHandling fh = new FileHandling(); fh.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);
                }

                else
                {
                    ConsoleIO.WriteLine("Already applied for loan which is unpaid");

                }
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist in our database record");

            }



        }


        public void ViewLoan(CustomersManagement cmgt)
        {
            ConsoleIO.WriteLine("Enter customer ID");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    ConsoleIO.WriteLine("Current loan is at $" + cmgt.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                }
                else
                {
                    ConsoleIO.WriteLine("Current loan is at $0");
                }

            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist in our database record");
            }
        }

        public void AddLoan(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            ConsoleIO.WriteLine("Enter customer ID again to ensure of taking loan again");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    ConsoleIO.WriteLine(customer_id);
                    TakingLoan tk = new TakingLoan();
                    tk.LoanAccount(cmgt, bemgt, bmgt);
                    


                }
                else
                {
                    ConsoleIO.WriteLine("Sorry cant take additional loan as previous loan is still outstanding");
                }
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist in our database record");
            }

        }
        public void RepayLoan(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            ConsoleIO.WriteLine("Enter customer ID");
            string customer_id = ConsoleIO.ReadLine();
            if (cmgt.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    ConsoleIO.WriteLine("Current loan is at " + cmgt.dictionaryOfcustomers[customer_id].loan_amount.ToString("F") + "\nE.g. key in 100 to repay 100 or / key in  6% to repay 6%");
                    string repayLoan = ConsoleIO.ReadLine();
                    if (repayLoan.Contains("%") == true)
                    {
                        var charsToRemove = new string[] { "%" };
                        foreach (var c in charsToRemove)
                        {
                            repayLoan = repayLoan.Replace(c, string.Empty);
                        }
                        decimal repayLoanParse = decimal.Parse(repayLoan);
                        decimal amountToRepay = Multiply(repayLoanParse, Divide(cmgt.dictionaryOfcustomers[customer_id].loan_amount, 100), 1);
                        ConsoleIO.WriteLine("Amount to repay is: $" + amountToRepay.ToString("F"));
                        decimal remainingLoanLeft = SubtractLoan(cmgt.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);
                        if (amountToRepay > cmgt.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            ConsoleIO.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {


                            ConsoleIO.WriteLine("Loan amount left: $" + remainingLoanLeft.ToString("F"));
                            cmgt.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;
                            if (remainingLoanLeft == 0)
                            {
                                cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                            }
                            FileHandling fh1 = new FileHandling();
                            fh1.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);

                        }
                    }
                    else
                    {
                        decimal amountToRepay = decimal.Parse(repayLoan);
                        ConsoleIO.WriteLine("Amount to repay is: $" + amountToRepay);
                        decimal remainingLoanLeft = SubtractLoan(cmgt.dictionaryOfcustomers[customer_id].loan_amount, amountToRepay);
                        if (amountToRepay > cmgt.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            ConsoleIO.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {
                            ConsoleIO.WriteLine("Loan amount left: $" + remainingLoanLeft);
                            cmgt.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;
                            if (remainingLoanLeft == 0)
                            {
                                cmgt.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                            }
                            FileHandling fh1 = new FileHandling();
                            fh1.ReadingandWritingcustomer(customer_id, cmgt, bemgt, bmgt);

                        }

                    }
                }
                else
                {
                    ConsoleIO.WriteLine("No loan to repay");
                }
            }
            else
            {
                ConsoleIO.WriteLine("Account doesn't exist in our database record");
            }

        }
        public void performOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt)
        {
            ConsoleIO.WriteLine("Taking loan here");
            bool exit = false;
            while (!exit)
            {
                ConsoleIO.WriteLine("In Loan account, key in required operation" + "\n1: Apply for a new loan" + "\n2: Apply for additional loan" + "\n3: view the loan" + "\n4: Repay loan amount" + "\n5: Exit loans operation");
                var input = ConsoleIO.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            LoanAccount(cmgt, bemgt, bmgt);
                            break;
                        }
                    case "2":
                        {
                            AddLoan(cmgt, bemgt, bmgt);
                            break;
                        }
                    case "3":
                        {
                            ViewLoan(cmgt);
                            break;
                        }
                    case "4":
                        {
                            RepayLoan(cmgt, bemgt, bmgt);
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
