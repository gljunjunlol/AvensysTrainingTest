using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers
{
    public class EmployeeAccountManagerController : IEmployeeAccountManager
    {
        //private IList<BankEmployees> _employeeList;
        public virtual Dictionary<string, BankEmployees> dictionaryOfEmployees { get; set; }


        public EmployeeAccountManagerController()
        {
            //_employeeList = new List<BankEmployees>();
            dictionaryOfEmployees = new Dictionary<string, BankEmployees>();
        }

        public bool UserLogin(EmployeeAccountManagerController eam, List<int> loginTries, string bankemployee_id, string bankemployee_pw)
        {
            if (eam.dictionaryOfEmployees.ContainsKey(bankemployee_id) && eam.dictionaryOfEmployees[bankemployee_id].bankemployee_pw == bankemployee_pw)
            {
                Console.WriteLine($"Congratulations, {eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_id} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_name} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_designation} { eam.dictionaryOfEmployees[bankemployee_id].bankemployee_yearsOfService}");
                return true;

            }
            return false;

        }
    }
}
