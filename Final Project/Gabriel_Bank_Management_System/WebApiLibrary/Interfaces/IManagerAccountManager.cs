using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface IManagerAccountManager
    {
        bool UserLogin(ManagerAccountManagerController mam, List<int> loginTries, string bankmanager_id, string bankmanager_pw);
    }
}
