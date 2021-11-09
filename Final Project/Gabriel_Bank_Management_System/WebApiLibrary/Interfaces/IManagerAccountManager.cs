using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    interface IManagerAccountManager
    {
        BankManagers CreateUserAccount();
        void UserLogin(ManagerAccountManager mam);
    }
}
