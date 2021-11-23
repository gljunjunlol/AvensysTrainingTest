using System;
using BankingWebAPI.EntityFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Filters;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;
using BankingWebAPI.Utility;
using Newtonsoft.Json;
using System.Data.Entity;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/Savings")]
    public class SavingsController : ApiController
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
        public SavingsController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }

        public SavingsController()
        {
            dataContext = new ManagementContext();
        }
        //[HttpPatch]
        //[Route("deposit")]
        //public Dictionary<string, Customer> customerDepositPatch(string id, decimal depositAmountKeyedInByCustomer)
        //{

        //    Customer existingCustomer = dictionaryOfcustomers[id];
        //    if (existingCustomer != null)
        //        dictionaryOfcustomers.Remove(id);
        //    else
        //    {
        //        existingCustomer.customerBalance = existingCustomer.customerBalance + depositAmountKeyedInByCustomer;
        //        dictionaryOfcustomers.Add(id, existingCustomer);
        //    }
        //    return dictionaryOfcustomers;
        //}
        //[HttpPatch]
        //[Route("withdrawal")]
        //public Dictionary<string, Customer> customerWithdrawl(string id, decimal withdrawAmountKeyedInByCustomer)
        //{
        //    Customer existingCustomer = dictionaryOfcustomers[id];
        //    if (existingCustomer != null)
        //        dictionaryOfcustomers.Remove(id);
        //    else
        //    {
        //        existingCustomer.customerBalance = existingCustomer.customerBalance - withdrawAmountKeyedInByCustomer;
        //        dictionaryOfcustomers.Add(id, existingCustomer);
        //    }
        //    return dictionaryOfcustomers;
        //}
        [HttpGet]
        [Route("customer/{id}")]                       // https://localhost:44360/api/Savings/customer/2
        public decimal ViewBalance(string id)
        {
            try
            {
                Customer existingCustomer = dictionaryOfcustomers[id];
                return existingCustomer.customerBalance;
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("");
            }
            return 0;
            
        }
        [HttpGet]
        [Route("viewtotalsavings")]                                // https://localhost:44360/api/Savings/viewtotalsavings
        public decimal TotalSavingsAmount()
        {
            decimal totalSavingsamount = dictionaryOfcustomers.Sum(x => x.Value.customerBalance);
            return totalSavingsamount;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="withdrawAmountKeyedInByCustomer"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("withdrawal")]
        public IHttpActionResult customerWithdrawal(string customer_id, decimal withdrawAmountKeyedInByCustomer)
        {
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (withdrawAmountKeyedInByCustomer < 0)
            {
                return Ok("withdrawal amount should be more than 0");
            }
            if (customer.customerBalance > withdrawAmountKeyedInByCustomer && customer != null && customer.customerBalance > 0 && withdrawAmountKeyedInByCustomer > 5000)
            {
                var guid1 = Guid.NewGuid();
                customer.cheque_book_number = guid1;
                customer.customerBalance = customer.customerBalance - withdrawAmountKeyedInByCustomer;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Amount is larger than 5000, we will process the cheque \n Updated cheque withdrawal to db \n Successfully withdrawed Product ID: {customer_id}. Quantity: {withdrawAmountKeyedInByCustomer.ToString("F")} Dear Customer, your current balance is: {customer.customerBalance.ToString("F")}");
            }
            
            if (customer.customerBalance > withdrawAmountKeyedInByCustomer && customer != null && customer.customerBalance > 0)
            {
                customer.customerBalance = customer.customerBalance - withdrawAmountKeyedInByCustomer;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Updated withdrawal to db \n Successfully withdrawed Product ID: {customer_id}. Quantity: {withdrawAmountKeyedInByCustomer.ToString("F")} Dear Customer, your current balance is: {customer.customerBalance.ToString("F")}");
            }
            
            if (customer != null && customer.customerBalance < 0 || customer.customerBalance < withdrawAmountKeyedInByCustomer)
            {
                
                return Ok($"Your balance does not meet the requirement, insufficient funds in balance. your current balance is: {customer.customerBalance.ToString("F")}");
            }
            else
            {
                return BadRequest("Invalid Customer ID");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <param name="depositAmountKeyedInByCustomer"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deposit")]
        public IHttpActionResult customerDeposit(string customer_id, decimal depositAmountKeyedInByCustomer)
        {
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (customer != null && depositAmountKeyedInByCustomer < 0)
            {
                return Ok("deposit amount should be more than 0");
                
            }
            if (customer != null && depositAmountKeyedInByCustomer > 5000)
            {
                var guid1 = Guid.NewGuid();
                customer.cheque_book_number = guid1;
                customer.customerBalance = customer.customerBalance + depositAmountKeyedInByCustomer;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Amount is larger than 5000, we will process the cheque \n Updated cheque deposit to db \n Successfully deposit Product ID: {customer_id}. Quantity: {depositAmountKeyedInByCustomer.ToString("F")} Dear Customer, your current balance is: {customer.customerBalance}");
            }

            if (customer != null && depositAmountKeyedInByCustomer < 5001)
            {
                customer.customerBalance = customer.customerBalance + depositAmountKeyedInByCustomer;
                dataContext.Entry(customer).State = EntityState.Modified;
                dataContext.SaveChanges();
                return Ok($"Updated deposit to db \n Successfully deposit Product ID: {customer_id}. Quantity: {depositAmountKeyedInByCustomer.ToString("F")} Dear Customer, your current balance is: {customer.customerBalance}");
            }
            else
            {
                return BadRequest("Invalid Customer ID");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("viewbalance")]
        public IHttpActionResult viewBalance(string customer_id)
        {
            Customer customer = dataContext.Customers.Where(x => x.customer_id == customer_id).FirstOrDefault();
            if (customer != null)
            {
                return Ok($"Dear Customer, your current balance is: {customer.customerBalance.ToString("F")}");
            }
            else
            {
                return BadRequest("Account id not found");
            }
            
        }
    }
}
