using System;
using BankingWebAPI.EntityFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Filters;
using BankingWebAPI.Models;
using BankingWebAPI.Utility;
using Newtonsoft.Json;
using BankingWebAPI.Interfaces;
using System.Data.Entity;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/TakingLoan")]
    public class TakingLoanController : ApiController
    {
        IDataContext dataContext;
        private string customerRecords;
        public void Read()
        {
            customerRecords = File.ReadAllText("List of customers.json");
            dictionaryOfcustomers = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(customerRecords);

        }
        public void Write()
        {
            string write = JsonConvert.SerializeObject(dictionaryOfcustomers);
            File.WriteAllText("List of customers.json", write);
        }
        public Dictionary<string, Customer> dictionaryOfcustomers { get; set; }
        public TakingLoanController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }

        public TakingLoanController()
        {
            dataContext = new ManagementContext();
        }
        [HttpGet]
        [Route("customer/{id}")]                       // https://localhost:44360/api/TakingLoan/customer/2
        public decimal ViewLoan(string id)
        {
            try
            {
                Customer existingCustomer = dictionaryOfcustomers[id];
                return existingCustomer.loan_amount;
            }
            catch(KeyNotFoundException)
            {
                return 0;
            }
            catch(ArgumentNullException)
            {
                return 0;
            }
            return 0;
            
        }
        [HttpGet]
        [Route("viewtotalloan")]                            // https://localhost:44360/api/TakingLoan/viewtotalloan
        public decimal TotalLoanAmount()
        {
            decimal totalloanamount = dictionaryOfcustomers.Sum(x => x.Value.loan_amount);
            return totalloanamount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="loanamount"></param>
        /// <param name="monthsIn"></param>
        /// <param name="interestamount"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("loan")]
        public IHttpActionResult LoanAccount(string customer_id, decimal loanamount, decimal monthsIn, decimal interestamount)
        {
            // principal loan amount * interest rate * number of years in term = total interest paid
            var months = Divide(monthsIn, 12);

            var interests = Divide(interestamount, 100);

            decimal totalloanamount = AddLoan(loanamount, Multiply(loanamount, interests, months));
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (loanamount > 0)
            {
                return Ok("Already applied for loan which is unpaid");
            }
            if (customer != null && loanamount > 0)
            {
                
                customer.customer_loan_applied = true;
                customer.loan_amount = totalloanamount;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Updated loan approval to db \n {customer.loan_amount.ToString("F")} Total loan calculated after interest\n" + totalloanamount.ToString("F") + "\nChecking for approval....\nLoan of: $" + totalloanamount.ToString("F") + " will repay in" + monthsIn + " installments or $" + (totalloanamount / monthsIn).ToString("F") + " monthly \n Loan application : ID " + customer_id);
            }
            else
            {
                return BadRequest("Account doesn't exist in our database record");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="repayLoan"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("repayloan")]
        public IHttpActionResult RepayLoan(string customer_id, string repayLoan)
        {
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (customer != null)
            {
                if (repayLoan.Contains("%") == true)
                {
                    var charsToRemove = new string[] { "%" };
                    foreach (var c in charsToRemove)
                    {
                        repayLoan = repayLoan.Replace(c, string.Empty);
                    }
                    decimal repayLoanParse = decimal.Parse(repayLoan);
                    decimal amountToRepay = Multiply(repayLoanParse, Divide(customer.loan_amount, 100), 1);
                    //Console.WriteLine("Amount to repay is: $" + amountToRepay.ToString("F"));
                    decimal remainingLoanLeft = SubtractLoan(customer.loan_amount, amountToRepay);


                    if (amountToRepay > customer.loan_amount)
                    {
                        return Ok("Exceed loan repayment, key again");
                    }
                    else
                    {
                        Ok("Loan amount left: $" + remainingLoanLeft.ToString("F"));
                        customer.loan_amount = remainingLoanLeft;

                        dataContext.Entry(customer).State = EntityState.Modified;
                        dataContext.SaveChanges();
                        return Ok($"Updated loan repayment to db, amount repaid " + amountToRepay.ToString("F") + " amount left " + remainingLoanLeft.ToString("F"));
                        if (remainingLoanLeft == 0)
                        {
                            customer.customer_loan_applied = false;
                            dataContext.Entry(customer).State = EntityState.Modified;
                            dataContext.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.ReadLine();
                            return Ok("Updated loan fully repaid to db");


                        }

                    }
                    

                }

                else
                {
                    decimal amountToRepay = decimal.Parse(repayLoan);
                    //Console.WriteLine("Amount to repay is: $" + amountToRepay);
                    decimal remainingLoanLeft = SubtractLoan(customer.loan_amount, amountToRepay);


                    if (amountToRepay > customer.loan_amount)
                    {
                        return Ok("Exceed loan repayment, key again");
                    }
                    else
                    {
                        Console.WriteLine("Loan amount left: $" + remainingLoanLeft);
                        customer.loan_amount = remainingLoanLeft;

                        dataContext.Entry(customer).State = EntityState.Modified;
                        dataContext.SaveChanges();
                        return Ok($"Updated loan repayment to db, amount repaid " + amountToRepay.ToString("F") + " amount left " + remainingLoanLeft.ToString("F"));
                        
                    }
                    if (remainingLoanLeft == 0)
                    {
                        customer.customer_loan_applied = false;
                        dataContext.Entry(customer).State = EntityState.Modified;
                        dataContext.SaveChanges();
                        Console.WriteLine(DateTime.Now);
                        Console.ReadLine();
                        return Ok("Updated loan fully repaid to db");

                    }

                }
                return Ok("No loan to repay");
                



            }
            return BadRequest("Account doesn't exist in our database record");
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
        public static decimal AddLoan(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractLoan(decimal x, decimal y)
        {
            return x - y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("viewloan")]
        public IHttpActionResult viewLoan(string customer_id)
        {
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (customer != null)
            {
                return Ok($"Dear Customer, Current loan is at: ${customer.loan_amount.ToString("F")}");
            }
            else
            {
                return BadRequest("Account id not found");
            }

        }
    }
}
