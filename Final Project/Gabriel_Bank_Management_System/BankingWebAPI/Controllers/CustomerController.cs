using System;
using BankingWebAPI.EntityFramework;
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

        IDataContext dataContext;
        public CustomerController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }
        public Dictionary<string, Customer> dictionaryOfcustomers { get; set; }

        public CustomerController()
        {
            dataContext = new ManagementContext();
            //_customerList = new List<Customer>();
            dictionaryOfcustomers = new Dictionary<string, Customer>();
            dictionaryOfcustomers.Add("1232", new Customer() { customer_id = "1232", customer_name = "bobbysmith", customer_address = "23 hillview", customer_dateOfBirth = DateTime.Parse("01 Feb 1985"), customer_email = "bobby@mail.com", customer_phone = "(333)-444-9555", customerBalance = 1000, customer_loan_applied = true, loan_amount = 2000, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), account_number = "A1232" });
            dictionaryOfcustomers.Add("1233", new Customer() { customer_id = "1233", customer_name = "petersmith", customer_address = "15 church street", customer_dateOfBirth = DateTime.Parse("01 Apr 1985"), customer_email = "peter@gmail.com", customer_phone = "(338)-445-1126", customerBalance = 1000, customer_loan_applied = true, loan_amount = 1500, customer_pw = "Test12345678$", cheque_book_number = Guid.Parse("c152f04e-975a-4cfd-bdcf-88d136b1f23e"), account_number = "A1233" });

        }
        [HttpGet]
        [Route("")]                               // https://localhost:44360/api/Customer              OR      http://mybankapi.me/api/Customer
        public Dictionary<string, Customer> GetAll()
        {
            CustomerAccountManagerController cust = new CustomerAccountManagerController();
            return cust.dictionaryOfcustomers;
        }
        [HttpGet]
        [Route("Customer/{id}")]                   // https://localhost:44360/api/Customer/Customer/1      OR http://mybankapi.me/api/Customer/Customer/1
        public Customer GET(string id)
        {
            return dictionaryOfcustomers.Where(x => x.Key.Contains(id)).FirstOrDefault().Value;
        }
        [HttpPatch]
        [Route("Test/Patch")]                             // https://localhost:44360/api/Customer/Test/Patch
        public Dictionary<string, Customer> updateName(Customer new_user)
        {
            string updatedName = "hello";
            //Customer existingCustomer = dictionaryOfcustomers[customer_id];
            Customer existingCustomer = dictionaryOfcustomers.Where(x => x.Key == new_user.customer_id).FirstOrDefault().Value;
            if (existingCustomer != null)
            {
                dictionaryOfcustomers.Remove(new_user.customer_id);
                existingCustomer.customer_name = updatedName;
                dictionaryOfcustomers.Add(new_user.customer_id, existingCustomer);
            }
            else
            {
                dictionaryOfcustomers.Add(new_user.customer_id, new_user);
            }
            return dictionaryOfcustomers;
        }
        //[HttpPost]
        //[Route("Customer/Add")]
        //public Dictionary<string, Customer> CustomerAdd(string id, string name, string address, DateTime dob, string email, string phone, string pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        //{
        //    dictionaryOfcustomers.Add(id, new Customer (id, name, address, dob, email, phone, pw, account_no, account_bal, cheque_bk_number, loan_app, loan_with_amt));
        //    return dictionaryOfcustomers;

        //}
        [HttpPost]
        [Route("Test/Add")]                                 // https://localhost:44360/api/Customer/Test/Add
        public Dictionary<string, Customer> CustomerAdd(Customer new_user)
        {
            Console.WriteLine("Saving..");
            
            try
            {
                dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                    
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("cannot be null");
            }
            
            return dictionaryOfcustomers;

        }
        [HttpGet]
        [Route("viewallcustomers")]
        public IHttpActionResult ViewAllCustomers()
        {
            IEnumerable<Customer> customer = dataContext.Customers.ToList();
            if (customer.Count() >0)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest("Invalid Bank Customer ID");
            }
        }
        [HttpPost]
        [Route("Test/AddNew")]
        public IHttpActionResult CustomerAddNew(CustomerAccountManagerController cam, Customer new_user)
        {
            //Customer existingcustomer = dictionaryOfcustomers.Where(x => x.Key == new_user.customer_id).FirstOrDefault().Value;
            //if (existingcustomer != null)
            //    return dictionaryOfcustomers;
            Console.WriteLine("Saving as at..");

            try
            {
                using (ManagementContext bankContext = new ManagementContext())
                {
                    cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
                    bankContext.Customers.Add(new_user);
                    bankContext.SaveChanges();
                }
                Console.WriteLine(DateTime.Now + " Done");
                Console.ReadLine();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("cannot be null");
            }

            //return dictionaryOfcustomers;
            return null;

        }
        [HttpPut]
        [Route("Test/Put")]                                  // https://localhost:44360/api/Customer/Test/Put
        public Dictionary<string, Customer> PUT (Customer customer)
        {
            Customer existingcustomer = dictionaryOfcustomers.Where(x => x.Key == customer.customer_id).FirstOrDefault().Value;
            if (existingcustomer != null)
                dictionaryOfcustomers.Remove(customer.customer_id);
            dictionaryOfcustomers.Add(customer.customer_id, customer);
            return dictionaryOfcustomers;

        }
        [HttpDelete]
        [Route("Customer/Delete")]                          // https://localhost:44360/api/Customer/Customer/Delete
        public Dictionary<string, Customer> Delete(Customer customer)
        {
            Customer existingstudent = dictionaryOfcustomers.Where(x => x.Key == customer.customer_id).FirstOrDefault().Value;
            if (existingstudent != null)
                dictionaryOfcustomers.Remove(customer.customer_id);
            return dictionaryOfcustomers;
        }
        [HttpDelete]
        [Route("Customer/DeleteById/{id}")]               // https://localhost:44360/api/Customer/Customer/DeleteById/2222
        public Dictionary<string, Customer> DeleteById(string id)
        {
            Customer existingstudent = dictionaryOfcustomers.Where(x => x.Key == id).FirstOrDefault().Value;
            if (existingstudent != null)
                dictionaryOfcustomers.Remove(id);
            return dictionaryOfcustomers;
        }

    }
}

