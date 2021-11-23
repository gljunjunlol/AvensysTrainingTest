using System.Collections.Generic;
using Bank.Common.Common;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface ICustomerAccountManager
    {
        (bool, bool?) Login(string username, string password);
        //bool UserLogin(string customer_id, string customer_pw);
        bool validatePassword(string customer_pw);
        PhoneNumberResultType validatePhone(string a);
        EmailAddressResultType validateEmail(string a);
    }
}
