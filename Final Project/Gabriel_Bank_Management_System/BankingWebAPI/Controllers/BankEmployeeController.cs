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

    }
}
