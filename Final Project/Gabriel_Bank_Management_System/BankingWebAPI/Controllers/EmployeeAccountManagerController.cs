using System;
using BankingWebAPI.EntityFramework;
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
        public BankEmployees CurrentUser { get; private set; }
        IDataContext dataContext;
        public EmployeeAccountManagerController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }
        private readonly IConsoleIO ConsoleIO;
        //private IEmployeeAccountManager _user;
        public EmployeeAccountManagerController(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        private IList<BankEmployees> _employeeList;
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }


        public EmployeeAccountManagerController()
        {
            dataContext = new ManagementContext();
            ConsoleIO = new ConsoleIO();
            using (ManagementContext bankContext = new ManagementContext())
            {
                dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
                BankEmployees bemp1 = new BankEmployees() { bankemployee_id = "1111", bankemployee_name = "jamesmith", bankemployee_address = "23 hillview", bankemployee_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankemployee_designation = "Relationship Associate", bankemployee_yearsOfService = "3", bankemployee_pw = "pw" };
                BankEmployees bemp2 = new BankEmployees() { bankemployee_id = "1235", bankemployee_name = "alansmith", bankemployee_address = "24 hillview", bankemployee_dateOfBirth = DateTime.Parse("14 Oct 1996"), bankemployee_designation = "Admin Employee", bankemployee_yearsOfService = "10", bankemployee_pw = "pw" };
                BankEmployees bemp3 = new BankEmployees() { bankemployee_id = "1236", bankemployee_name = "samuelsmith", bankemployee_address = "25 hillview", bankemployee_dateOfBirth = DateTime.Parse("15 Oct 1991"), bankemployee_designation = "Customer Savings Associate", bankemployee_yearsOfService = "13", bankemployee_pw = "Samuel12345678$" };
                dictionaryOfEmployees.Add("1111", bemp1);
                dictionaryOfEmployees.Add("1235", bemp2);
                dictionaryOfEmployees.Add("1236", bemp3);
                //bankContext.Employees.Add(bemp1);
                //bankContext.Employees.Add(bemp2);
                //bankContext.Employees.Add(bemp3);
                BankEmployeeBranch emp1 = new BankEmployeeBranch() { bankemployee_id = "1111", bank_branch = "Singapore Branch" };
                BankEmployeeBranch emp2 = new BankEmployeeBranch() { bankemployee_id = "1235", bank_branch = "Hong Kong Branch" };
                BankEmployeeBranch emp3 = new BankEmployeeBranch() { bankemployee_id = "1236", bank_branch = "South Branch" };
                List<BankEmployeeBranch> bankEmployeeBranchList = new List<BankEmployeeBranch>();
                bankEmployeeBranchList.Add(emp1);
                bankEmployeeBranchList.Add(emp2);
                bankEmployeeBranchList.Add(emp3);
                //bankContext.employeeDetails.Add(emp1);
                //bankContext.employeeDetails.Add(emp2);
                //bankContext.employeeDetails.Add(emp3);
                //bankContext.SaveChanges();
            }
            //Console.WriteLine("End");
            //Console.ReadLine();
            _employeeList = new List<BankEmployees>();
            
            
        }
        //[HttpGet]
        //[Route("employeelogin")]                       // https://localhost:44360/api/EmployeeAuthentication/employeelogin?bankemployee_id=hello&bankemployee_pw=hello
        //public bool UserLogin(string bankemployee_id, string bankemployee_pw)
        //{
        //    try
        //    {
        //        if (dictionaryOfEmployees.ContainsKey(bankemployee_id) && dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
        //        {
        //            Console.WriteLine($"Congratulations, {dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfEmployees[bankemployee_id].bankemployee_id} { dictionaryOfEmployees[bankemployee_id].bankemployee_name} { dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
        //            return true;

        //        }
        //    }
        //    catch(ArgumentNullException)
        //    {
        //        Console.WriteLine("cannot be null");
        //    }
            
        //    return false;

        //}
        [HttpGet]
        [Route("login")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public (bool, bool?) Login(string username, string password)
        {
            bool loginSuccess = false;
            bool? isOwner = false;
            CurrentUser = dataContext.Employees.Where(x => Equals(x.bankemployee_id, username) && Equals(x.bankemployee_pw, password)).FirstOrDefault();

            if (CurrentUser != null)
            {
                loginSuccess = true;
            }

            return (loginSuccess, isOwner);
        }
    }
}
