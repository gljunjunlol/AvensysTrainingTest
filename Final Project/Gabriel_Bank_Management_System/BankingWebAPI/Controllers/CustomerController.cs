using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;
using System.IO;
using Newtonsoft.Json;
using Bank.Common.Common;
using BankingWebAPI.Utility;
using System.Web.Http;
using BankingWebAPI.Filters;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        //private IList<Customer> _customerList;
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

        public CustomerController()
        {
            //_customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
            dictionaryOfcustomers.Add("1111", new Customer() { customer_id = "1111", customer_name = "HulkSmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "hulk@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Hulk12345678$", account_number = "1111" });
            dictionaryOfcustomers.Add("2222", new Customer() { customer_id = "2222", customer_name = "MarySmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "mary@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Mary12345678$", account_number = "2222" });
        }
        [HttpGet]
        [Route("")]                               // https://localhost:44360/api/Customer              OR      http://mybankapi.me/api/Customer
        public Dictionary<string, Customer> GetAll()
        {
            return dictionaryOfcustomers;
        }
        [HttpGet]
        [Route("Customer/{id}")]                   // https://localhost:44360/api/Customer/Customer/1      OR http://mybankapi.me/api/Customer/Customer/1
        public Customer GET(string id)
        {
            return dictionaryOfcustomers.Where(x => x.Key.Contains(id)).FirstOrDefault().Value;
        }
        [HttpPatch]
        [Route("Customer/Patch")]
        public Dictionary<string, Customer> Patch(string customer_id, string updatedName)
        {
            //Customer existingcustomer = dictionaryOfcustomers.Where(x => x.Key == id).FirstOrDefault().Value;
            //if (existingcustomer == null)
            //    return null;
            //dictionaryOfcustomers.Remove(id);
            //existingcustomer.customer_name = updatedName;
            //dictionaryOfcustomers.Add(id, existingcustomer);
            //return dictionaryOfcustomers;

            Customer existingCustomer = dictionaryOfcustomers[customer_id];
            if (existingCustomer != null)
                dictionaryOfcustomers.Remove(customer_id);
            else
            {
                existingCustomer.customer_name = updatedName;
                dictionaryOfcustomers.Add(customer_id, existingCustomer);
            }
            return dictionaryOfcustomers;
        }
        [HttpPost]
        [Route("Customer/Add")]
        public Dictionary<string, Customer> CustomerAdd(string id, string name, string address, DateTime dob, string email, string phone, string pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            dictionaryOfcustomers.Add(id, new Customer (id, name, address, dob, email, phone, pw, account_no, account_bal, cheque_bk_number, loan_app, loan_with_amt));
            return dictionaryOfcustomers;

        }
        [HttpPut]
        [Route("Customer/Put")]
        public Dictionary<string, Customer> PUT (string id, Customer customer)
        {
            Customer existingcustomer = dictionaryOfcustomers.Where(x => x.Key == customer.customer_id).FirstOrDefault().Value;
            if (existingcustomer == null)
                dictionaryOfcustomers.Remove(id);
            dictionaryOfcustomers.Add(id, customer);
            return dictionaryOfcustomers;

        }
        [HttpDelete]
        [Route("Customer/Delete")]
        public Dictionary<string, Customer> Delete(string id, Customer customer)
        {
            Customer existingstudent = dictionaryOfcustomers.Where(x => x.Key == customer.customer_id).FirstOrDefault().Value;
            if (existingstudent != null)
                dictionaryOfcustomers.Remove(id);
            return dictionaryOfcustomers;
        }
        [HttpDelete]
        [Route("Customer/DeleteById/{id}")]               // https://localhost:44360/api/Customer/Customer/DeleteById/2
        public Dictionary<string, Customer> DeleteById(string id)
        {
            Customer existingstudent = dictionaryOfcustomers.Where(x => x.Key == id).FirstOrDefault().Value;
            if (existingstudent != null)
                dictionaryOfcustomers.Remove(id);
            return dictionaryOfcustomers;
        }

    }
}

