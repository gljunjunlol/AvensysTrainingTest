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
        }
        [HttpGet]
        [Route("employeelogin")]                       // https://localhost:44360/api/EmployeeAuthentication/employeelogin?bankemployee_id=hello&bankemployee_pw=hello
        public bool UserLogin(string bankemployee_id, string bankemployee_pw)
        {
            if (dictionaryOfEmployees.ContainsKey(bankemployee_id) && dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
            {
                Console.WriteLine($"Congratulations, {dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfEmployees[bankemployee_id].bankemployee_id} { dictionaryOfEmployees[bankemployee_id].bankemployee_name} { dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
                return true;

            }
            return false;

        }
    }
}
