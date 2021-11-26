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
        //private IEmployeeAccountManager _user;
        private IList<BankEmployees> _employeeList;
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }


        public EmployeeAccountManagerController()
        {
            dataContext = new ManagementContext();
            using (ManagementContext bankContext = new ManagementContext())
            {
            }
            _employeeList = new List<BankEmployees>();
            
            
        }
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
                isOwner = true;
            }

            return (loginSuccess, isOwner);
        }
    }
}
