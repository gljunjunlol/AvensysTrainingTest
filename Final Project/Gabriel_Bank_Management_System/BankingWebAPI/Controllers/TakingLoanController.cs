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

        public TakingLoanController()
        {
            //_customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
            dictionaryOfcustomers.Add("1", new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" });
            dictionaryOfcustomers.Add("2", new Customer() { customer_id = "1233", customer_name = "petersmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "peter@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c152f04e-975a-4cfd-bdcf-88d136b1f23e"), account_number = "A1233" });
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
        //[HttpPatch]
        //[Route("Customer/Patch")]
        //public Dictionary<string, Customer> Patch(string id, bool loan_applied, decimal loanamount)
        //{

        //    Customer existingCustomer = dictionaryOfcustomers[id];
        //    if (existingCustomer != null)
        //        dictionaryOfcustomers.Remove(id);
        //    else
        //    {
        //        existingCustomer.loan_amount = loanamount;
        //        existingCustomer.customer_loan_applied = true;
        //        dictionaryOfcustomers.Add(id, existingCustomer);
        //    }
        //    return dictionaryOfcustomers;
        //}
    }
}
