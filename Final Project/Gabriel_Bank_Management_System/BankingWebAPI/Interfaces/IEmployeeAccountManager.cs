using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface IEmployeeAccountManager
    {
        (bool, bool?) Login(string username, string password);
        //bool UserLogin(string bankemployee_id, string bankemployee_pw);
    }
}
