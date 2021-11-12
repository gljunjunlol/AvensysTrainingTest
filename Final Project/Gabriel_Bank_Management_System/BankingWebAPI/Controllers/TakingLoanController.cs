using System;
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
            dictionaryOfcustomers.Add("1", new Customer() { customer_id = "1", customer_name = "John" });
            dictionaryOfcustomers.Add("2", new Customer() { customer_id = "2", customer_name = "Mary" });
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
