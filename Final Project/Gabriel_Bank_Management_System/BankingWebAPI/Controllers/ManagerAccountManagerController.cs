using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;

namespace BankingWebAPI.Controllers
{
    [RoutePrefix("api/ManagerAuthentication")]
    public class ManagerAccountManagerController : ApiController, IManagerAccountManager
    {
        private IList<BankManagers> _managersList;
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }



        public ManagerAccountManagerController()
        {
            _managersList = new List<BankManagers>();
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
        }

        [HttpGet]
        [Route("managerlogin")]
        public bool UserLogin(string bankmanager_id, string bankmanager_pw)
        {
            if (dictionaryOfManagers.ContainsKey(bankmanager_id) && dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
            {
                Console.WriteLine($"Congratulations, {dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfManagers[bankmanager_id].bankmanager_id} { dictionaryOfManagers[bankmanager_id].bankmanager_name} { dictionaryOfManagers[bankmanager_id].bankmanager_designation} { dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
                return true;
                
            }
            else
            {
                return false;
            }

        }
    }
}
