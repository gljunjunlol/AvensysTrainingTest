using System;
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

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/Savings")]
    public class SavingsController : ApiController
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();
        
        private string customerRecords;
        private void Read()
        {
            customerRecords = File.ReadAllText("List of customers.json");
            dictionaryOfcustomers = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(customerRecords);

        }
        private void Write()
        {
            string write = JsonConvert.SerializeObject(dictionaryOfcustomers);
            File.WriteAllText("List of customers.json", write);
        }
        public Dictionary<string, Customer> dictionaryOfcustomers { get; set; }

        public SavingsController()
        {
            //_customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
            dictionaryOfcustomers.Add("1111", new Customer() { customer_id = "1111", customer_name = "HulkSmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "hulk@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Hulk12345678$", account_number = "1111" });
            dictionaryOfcustomers.Add("2222", new Customer() { customer_id = "2222", customer_name = "MarySmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "mary@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Mary12345678$", account_number = "2222" });
        }
        [HttpPatch]
        [Route("deposit")]
        public Dictionary<string, Customer> customerDepositPatch(string id, decimal depositAmountKeyedInByCustomer)
        {

            Customer existingCustomer = dictionaryOfcustomers[id];
            if (existingCustomer != null)
                dictionaryOfcustomers.Remove(id);
            else
            {
                existingCustomer.customerBalance = existingCustomer.customerBalance + depositAmountKeyedInByCustomer;
                dictionaryOfcustomers.Add(id, existingCustomer);
            }
            return dictionaryOfcustomers;
        }
        [HttpPatch]
        [Route("withdrawal")]
        public Dictionary<string, Customer> customerWithdrawl(string id, decimal withdrawAmountKeyedInByCustomer)
        {
            Customer existingCustomer = dictionaryOfcustomers[id];
            if (existingCustomer != null)
                dictionaryOfcustomers.Remove(id);
            else
            {
                existingCustomer.customerBalance = existingCustomer.customerBalance - withdrawAmountKeyedInByCustomer;
                dictionaryOfcustomers.Add(id, existingCustomer);
            }
            return dictionaryOfcustomers;
        }
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
        [Route("")]                                // https://localhost:44360/api/Savings
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

        public decimal DepositLimit()
        {
            return 0;
        }
    }
}
