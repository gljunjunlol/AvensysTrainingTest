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
        [Route("viewtotalloan")]                            // http://mybankapi.me/api/TakingLoan/viewtotalloan
        public IHttpActionResult TotalLoanAmount()
        {
            IEnumerable<Customer> customer = dataContext.Customers.ToList();
            decimal totalloanamount = dataContext.Customers.Sum(x => x.loan_amount);
            return Ok(totalloanamount.ToString("F"));
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
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            // principal loan amount * interest rate * number of years in term = total interest paid
            var months = Divide(monthsIn, 12);

            var interests = Divide(interestamount, 100);

            decimal totalloanamount = AddLoan(loanamount, Multiply(loanamount, interests, months));
            
            if (customer != null && customer.loan_amount > 0)
            {
                return Ok("Already applied for loan which is unpaid");
            }
            if (customer != null && customer.loan_amount == 0 || customer.loan_amount < 0)
            {

                customer.customer_loan_applied = true;
                customer.loan_amount = totalloanamount;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Updated loan approval to db \n {customer.loan_amount.ToString("F")} Total loan calculated after interest\n" + totalloanamount.ToString("F") + "\nChecking for approval....\nLoan of: $" + totalloanamount.ToString("F") + " will repay in " + monthsIn + " installments or $" + (totalloanamount / monthsIn).ToString("F") +" monthly \n Loan application : ID " + customer_id);
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
                
                if (customer.loan_amount == 0)
                {

                    return Ok("No loan to repay");
                }
                if (repayLoan.Contains("%") == true)
                {
                    var charsToRemove = new string[] { "%" };
                    foreach (var c in charsToRemove)
                    {
                        repayLoan = repayLoan.Replace(c, string.Empty);
                    }
                    decimal repayLoanParse = decimal.Parse(repayLoan);
                    if (decimal.Parse(repayLoan) < 0)
                    {
                        return Ok("below zero error");
                    }
                    decimal amountToRepay = Multiply(repayLoanParse, Divide(customer.loan_amount, 100), 1);
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
                        if (remainingLoanLeft != 0)
                        {
                            return Ok($"Updated loan repayment to db, amount repaid " + amountToRepay.ToString("F") + " amount left " + remainingLoanLeft.ToString("F"));
                        }
                        else
                        {
                            customer.customer_loan_applied = false;
                            dataContext.Entry(customer).State = EntityState.Modified;
                            dataContext.SaveChanges();
                            return Ok(DateTime.Now + "Updated loan fully repaid to db");
                        }

                    }                    
                }
                else
                {
                    try
                    {
                        decimal amountToRepay = decimal.Parse(repayLoan);
                        if (amountToRepay < 0)
                        {
                            return Ok("below zero error");
                        }
                        decimal remainingLoanLeft = SubtractLoan(customer.loan_amount, amountToRepay);


                        if (amountToRepay > customer.loan_amount)
                        {
                            return Ok("Exceed loan repayment, key again");
                        }
                        else
                        {
                            customer.loan_amount = remainingLoanLeft;

                            dataContext.Entry(customer).State = EntityState.Modified;
                            dataContext.SaveChanges();
                            if (remainingLoanLeft != 0)
                            {
                                return Ok($"Updated loan repayment to db, amount repaid " + amountToRepay.ToString("F") + " amount left " + remainingLoanLeft.ToString("F"));
                            }
                            else
                            {
                                customer.customer_loan_applied = false;
                                dataContext.Entry(customer).State = EntityState.Modified;
                                dataContext.SaveChanges();
                                return Ok(DateTime.Now + "Updated loan fully repaid to db");
                            }
                        }
                    }
                    catch
                    {
                        return Ok("Invalid format");
                    }
                    

                }
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
