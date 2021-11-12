using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface IManagerAccountManager
    {
        bool UserLogin(string bankmanager_id, string bankmanager_pw);
    }
}
