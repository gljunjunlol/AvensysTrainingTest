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

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/TakingLoan")]
    public class TakingLoanController : ApiController
    {
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

        public TakingLoanController()
        {
            //_customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
            dictionaryOfcustomers.Add("1", new Customer() { customer_id = "1111", customer_name = "HulkSmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "hulk@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Hulk12345678$", account_number = "1111" });
            dictionaryOfcustomers.Add("2", new Customer() { customer_id = "2222", customer_name = "MarySmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "mary@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Mary12345678$", account_number = "2222" });
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
                Console.WriteLine("");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("");
            }
            return 0;
            
        }
        [HttpGet]
        [Route("")]                            // https://localhost:44360/api/TakingLoan
        public decimal TotalLoanAmount()
        {
            decimal totalloanamount = dictionaryOfcustomers.Sum(x => x.Value.loan_amount);
            return totalloanamount;
        }
        [HttpPatch]
        [Route("Customer/Patch")]
        public Dictionary<string, Customer> Patch(string id, bool loan_applied, decimal loanamount)
        {
            //Customer existingcustomer = dictionaryOfcustomers.Where(x => x.Key == id).FirstOrDefault().Value;
            //if (existingcustomer == null)
            //    return null;
            //dictionaryOfcustomers.Remove(id);
            //existingcustomer.customer_name = updatedName;
            //dictionaryOfcustomers.Add(id, existingcustomer);
            //return dictionaryOfcustomers;

            Customer existingCustomer = dictionaryOfcustomers[id];
            if (existingCustomer != null)
                dictionaryOfcustomers.Remove(id);
            else
            {
                existingCustomer.loan_amount = loanamount;
                existingCustomer.customer_loan_applied = true;
                dictionaryOfcustomers.Add(id, existingCustomer);
            }
            return dictionaryOfcustomers;
        }
    }
}
