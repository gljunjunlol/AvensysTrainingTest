using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface IEmployeeAccountManager
    {
        BankEmployees CreateUserAccount();
        void UserLogin(EmployeeAccountManager eam);
        void References();
    }
}
