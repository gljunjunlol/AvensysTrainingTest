using System.Collections.Generic;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface ICustomerAccountManager
    {
        bool UserLogin(string customer_id, string customer_pw);
        bool validatePassword(string customer_pw);
        bool validatePhone(string a);
        bool validateEmail(string a);
    }
}
