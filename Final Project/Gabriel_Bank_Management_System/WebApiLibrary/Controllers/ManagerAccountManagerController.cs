using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;

namespace WebApiLibrary.Controllers
{
    public class ManagerAccountManagerController : IManagerAccountManager
    {
        private IList<BankManagers> _managersList;
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }



        public ManagerAccountManagerController()
        {
            _managersList = new List<BankManagers>();
            dictionaryOfManagers = new Dictionary<string, BankManagers>();
        }
        
        
        public bool UserLogin(ManagerAccountManagerController mam, List<int> loginTries, string bankmanager_id, string bankmanager_pw)
        {
            if (mam.dictionaryOfManagers.ContainsKey(bankmanager_id) && mam.dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
            {
                Console.WriteLine($"Congratulations, {mam.dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { mam.dictionaryOfManagers[bankmanager_id].bankmanager_id} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_name} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_designation} { mam.dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
                return true;
                
            }
            else
            {
                return false;
            }

        }
    }
}
