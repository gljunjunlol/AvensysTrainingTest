using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/ManagerAuthentication")]
    public class ManagerAccountManagerController : ApiController, IManagerAccountManager
    {
        private IList<BankManagers> _managersList;
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }



        public ManagerAccountManagerController()
        {
            _managersList = new List<BankManagers>();
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
            dictionaryOfManagers.Add("1111", new BankManagers() { bankmanager_id = "1111", bankmanager_name = "Peterson Jr", bankmanager_address = "23 hillview", bankmanager_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankmanager_designation = "Relationship Manager", bankmanager_yearsOfService = "13", bankmanager_pw = "Peterson12345678$" });
        }

        [HttpGet]
        [Route("managerlogin")]                         // https://localhost:44360/api/ManagerAuthentication/managerlogin?bankmanager_id="hello"&bankmanager_pw="hello"
        public bool UserLogin(string bankmanager_id, string bankmanager_pw)
        {
            try
            {
                if (dictionaryOfManagers.ContainsKey(bankmanager_id) && dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
                {
                    Console.WriteLine($"Congratulations, {dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfManagers[bankmanager_id].bankmanager_id} { dictionaryOfManagers[bankmanager_id].bankmanager_name} { dictionaryOfManagers[bankmanager_id].bankmanager_designation} { dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
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
