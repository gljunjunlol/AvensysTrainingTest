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
using BankingWebAPI.BankManagementContext;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/BankEmployee")]
    public class BankEmployeeController : ApiController
    {
        //DataContext data = new DataContext();
        public Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }

        public BankEmployeeController()
        {
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            dictionaryOfEmployees.Add("1111", new BankEmployees() { bankemployee_id = "1111", bankemployee_name = "jamesmith", bankemployee_address = "23 hillview", bankemployee_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankemployee_designation = "Relationship Associate", bankemployee_yearsOfService = "3", bankemployee_pw = "pw" });
            dictionaryOfEmployees.Add("1235", new BankEmployees() { bankemployee_id = "1235", bankemployee_name = "alansmith", bankemployee_address = "24 hillview", bankemployee_dateOfBirth = DateTime.Parse("14 Oct 1996"), bankemployee_designation = "Admin Employee", bankemployee_yearsOfService = "10", bankemployee_pw = "pw" });
            dictionaryOfEmployees.Add("1236", new BankEmployees() { bankemployee_id = "1236", bankemployee_name = "samuelsmith", bankemployee_address = "25 hillview", bankemployee_dateOfBirth = DateTime.Parse("15 Oct 1991"), bankemployee_designation = "Customer Savings Associate", bankemployee_yearsOfService = "13", bankemployee_pw = "pw" });
        }
        //[HttpGet]
        //[Route("customerbyid")]
        //public IHttpActionResult CustomerByID(int id)
        //{
        //    Customer cust = data.Customers.Where(x => x.ID == id).FirstOrDefault();
        //    if (customer != null)
        //    {
        //        return Ok(customer);
        //    }
        //    else
        //    {
        //        return BadRequest("Account invalid");
        //    }
        //}

        //[HttpGet]
        //[Route("customerbyname")]
        //public IHttpActionResult CustomerByName(string name)
        //{
        //    Customer cust = data.Customers.Where(x => x.Name == name).FirstOrDefault();
        //    if (customer != null)
        //    {
        //        return Ok(customer);
        //    }
        //    else
        //    {
        //        return BadRequest("Account name not exist");
        //    }
        //}
        [HttpGet]
        [Route("")]                               // https://localhost:44360/api/BankEmployee     OR http://mybankapi.me/api/BankEmployee
        public Dictionary<string, BankEmployees> GetAll()
        {
            return dictionaryOfEmployees;
        }
        [HttpGet]
        [Route("Employee/{id}")]                   // https://localhost:44360/api/BankEmployee/Employee/1   OR http://mybankapi.me/api/BankEmployee/Employee/1
        public BankEmployees GET(string id)
        {
            return dictionaryOfEmployees.Where(x => x.Key.Contains(id)).FirstOrDefault().Value;
        }
        [HttpPatch]
        [Route("Patch")]
        public Dictionary<string, BankEmployees> Patch(string bankemployee_id, string updatedName)
        {
            BankEmployees existingEmployee = dictionaryOfEmployees[bankemployee_id];
            if (existingEmployee != null)
                dictionaryOfEmployees.Remove(bankemployee_id);
            else
            {
                existingEmployee.bankemployee_name = updatedName;
                dictionaryOfEmployees.Add(bankemployee_id, existingEmployee);
            }
            return dictionaryOfEmployees;
        }
        [HttpPost]
        [Route("Test/Add")]                                 // https://localhost:44360/api/BankEmployee/Test/Add
        public Dictionary<string, BankEmployees> EmployeeAddTo(BankEmployees new_user)
        {
            dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
            return dictionaryOfEmployees;

        }
        [HttpPost]
        [Route("Test/Add1")]                                 // https://localhost:44360/api/BankEmployee/Test/Add
        public Dictionary<string, BankEmployees> EmployeeAdd(BankEmployees new_user)
        {
            BankEmployees existingEmployee = dictionaryOfEmployees.Where(x => x.Key == new_user.bankemployee_id).FirstOrDefault().Value;
            if (existingEmployee != null)
                return dictionaryOfEmployees;
            dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
            return dictionaryOfEmployees;

        }
        [HttpPut]
        [Route("Test/Put")]                                  // https://localhost:44360/api/BankEmployee/Test/Put
        public Dictionary<string, BankEmployees> PUT(BankEmployees new_user)
        {
            BankEmployees existingEmployee = dictionaryOfEmployees.Where(x => x.Key == new_user.bankemployee_id).FirstOrDefault().Value;
            if (existingEmployee != null)
                dictionaryOfEmployees.Remove(new_user.bankemployee_id);
            dictionaryOfEmployees.Add(new_user.bankemployee_id, new_user);
            return dictionaryOfEmployees;

        }
        [HttpDelete]
        [Route("Delete")]
        public Dictionary<string, BankEmployees> Delete(string id, BankEmployees employee)
        {
            BankEmployees existingEmployee = dictionaryOfEmployees.Where(x => x.Key == employee.bankemployee_id).FirstOrDefault().Value;
            if (existingEmployee != null)
                dictionaryOfEmployees.Remove(id);
            return dictionaryOfEmployees;
        }
        [HttpDelete]
        [Route("DeleteById/{id}")]               // https://localhost:44360/api/BankEmployee/DeleteById/2
        public Dictionary<string, BankEmployees> DeleteById(string id)
        {
            BankEmployees existingEmployee = dictionaryOfEmployees.Where(x => x.Key == id).FirstOrDefault().Value;
            if (existingEmployee != null)
                dictionaryOfEmployees.Remove(id);
            return dictionaryOfEmployees;
        }

    }
}
