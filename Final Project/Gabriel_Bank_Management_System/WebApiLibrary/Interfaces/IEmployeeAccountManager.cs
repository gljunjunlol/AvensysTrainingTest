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
        bool UserLogin(EmployeeAccountManagerController eam, List<int> loginTries, string bankemployee_id, string bankemployee_pw);
    }
}
