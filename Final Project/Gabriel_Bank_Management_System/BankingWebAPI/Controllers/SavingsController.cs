using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;
using BankingWebAPI.Utility;
using Newtonsoft.Json;

namespace BankingWebAPI.Controllers
{
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
            dictionaryOfcustomers.Add("1", new Customer() { customer_id = "1", customer_name = "John", customerBalance = 4000 });
            dictionaryOfcustomers.Add("2", new Customer() { customer_id = "2", customer_name = "Mary", customerBalance = 5000 });
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
            Customer existingCustomer = dictionaryOfcustomers[id];
            return existingCustomer.customerBalance;
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
