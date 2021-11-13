using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Filters;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/EmployeeAuthentication")]
    public class EmployeeAccountManagerController : ApiController, IEmployeeAccountManager
    {
        private IList<BankEmployees> _employeeList;
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }


        public EmployeeAccountManagerController()
        {
            _employeeList = new List<BankEmployees>();
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
            dictionaryOfEmployees.Add("1111", new BankEmployees() { bankemployee_id = "1111", bankemployee_name = "jamesmith", bankemployee_address = "23 hillview", bankemployee_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankemployee_designation = "Relationship Associate", bankemployee_yearsOfService = "3", bankemployee_pw = "pw" });
            dictionaryOfEmployees.Add("1235", new BankEmployees() { bankemployee_id = "1235", bankemployee_name = "alansmith", bankemployee_address = "24 hillview", bankemployee_dateOfBirth = DateTime.Parse("14 Oct 1996"), bankemployee_designation = "Admin Employee", bankemployee_yearsOfService = "10", bankemployee_pw = "pw" });
            dictionaryOfEmployees.Add("1236", new BankEmployees() { bankemployee_id = "1236", bankemployee_name = "samuelsmith", bankemployee_address = "25 hillview", bankemployee_dateOfBirth = DateTime.Parse("15 Oct 1991"), bankemployee_designation = "Customer Savings Associate", bankemployee_yearsOfService = "13", bankemployee_pw = "Samuel12345678$" });
        }
        [HttpGet]
        [Route("employeelogin")]                       // https://localhost:44360/api/EmployeeAuthentication/employeelogin?bankemployee_id=hello&bankemployee_pw=hello
        public bool UserLogin(string bankemployee_id, string bankemployee_pw)
        {
            try
            {
                if (dictionaryOfEmployees.ContainsKey(bankemployee_id) && dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
                {
                    Console.WriteLine($"Congratulations, {dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfEmployees[bankemployee_id].bankemployee_id} { dictionaryOfEmployees[bankemployee_id].bankemployee_name} { dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
                    return true;

                }
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("cannot be null");
            }
            
            return false;

        }
    }
}
