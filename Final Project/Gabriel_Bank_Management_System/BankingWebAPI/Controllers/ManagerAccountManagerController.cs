using System;
using BankingWebAPI.EntityFramework;
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
        public BankManagers CurrentUser { get; private set; }
        IDataContext dataContext;
        private readonly IConsoleIO ConsoleIO;
        //private IManagerAccountManager _user;
        public ManagerAccountManagerController(IDataContext datacontext)
        {
            dataContext = datacontext;
        }
        public ManagerAccountManagerController(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        private IList<BankManagers> _managersList;
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }



        public ManagerAccountManagerController()
        {
            dataContext = new ManagementContext();
            ConsoleIO = new ConsoleIO();
            using (ManagementContext bankContext = new ManagementContext())
            {
                dictionaryOfManagers = new Dictionary<string, BankManagers>();
                BankManagers bmgr1 = new BankManagers() { bankmanager_id = "1111", bankmanager_name = "Peterson Jr", bankmanager_address = "23 hillview", bankmanager_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankmanager_designation = "Relationship Manager", bankmanager_yearsOfService = "13", bankmanager_pw = "Peterson12345678$" };
                dictionaryOfManagers.Add("1111", bmgr1);
                //bankContext.Managers.Add(bmgr1);
                //bankContext.SaveChanges();
            }
            //Console.WriteLine("End");     // these writeline readline is essential
            //Console.ReadLine();
            _managersList = new List<BankManagers>();
            
            
        }

        //[HttpGet]
        //[Route("managerlogin")]                         // https://localhost:44360/api/ManagerAuthentication/managerlogin?bankmanager_id="hello"&bankmanager_pw="hello"
        //public bool UserLogin(string bankmanager_id, string bankmanager_pw)
        //{
        //    try
        //    {
        //        if (dictionaryOfManagers.ContainsKey(bankmanager_id) && dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
        //        {
        //            Console.WriteLine($"Congratulations, {dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfManagers[bankmanager_id].bankmanager_id} { dictionaryOfManagers[bankmanager_id].bankmanager_name} { dictionaryOfManagers[bankmanager_id].bankmanager_designation} { dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
        //            return true;

        //        }
        //    }
        //    catch(ArgumentNullException)
        //    {
        //        Console.WriteLine("cannot be null");
        //    }
        //    return false;
            

        //}
        [HttpPost]
        [Route("Test/Add")]                                 // https://localhost:44360/api/ManagerAuthentication/Test/Add
        public Dictionary<string, BankManagers> ManagerAdd(BankManagers new_user)
        {
            dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
            return dictionaryOfManagers;

        }
        [HttpPost]
        [Route("Test/AddNew")]
        public Dictionary<string, BankManagers> ManagerAddNew(ManagerAccountManagerController mam, BankManagers new_user)
        {
            Console.WriteLine("Saving as at..");

            try
            {
                using (ManagementContext bankContext = new ManagementContext())
                {
                    mam.dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
                    bankContext.Managers.Add(new_user);
                    bankContext.SaveChanges();
                }
                Console.WriteLine(DateTime.Now + " Done");
                Console.ReadLine();

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("cannot be null");
            }
            return dictionaryOfManagers;

        }
        [HttpGet]
        [Route("signup")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="idNumber"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw)
        {
            BankManagers manager = new BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
            using (ManagementContext bankContext = new ManagementContext())
            {
                bankContext.Managers.Add(manager);
                bankContext.SaveChanges();
                return true;
            }

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
            CurrentUser = dataContext.Managers.Where(x => Equals(x.bankmanager_id, username) && Equals(x.bankmanager_pw, password)).FirstOrDefault();

            if (CurrentUser != null)
            {
                loginSuccess = true;
            }

            return (loginSuccess, isOwner);
        }
        [HttpGet]
        [Route("viewallmanagers")]
        public IHttpActionResult ViewAllManagers()
        {
            IEnumerable<BankManagers> manager = dataContext.Managers.ToList();
            if (manager.Count() > 0)
            {
                return Ok(manager);
            }
            else
            {
                return BadRequest("Invalid Manager ID");
            }
        }
    }
    
}
