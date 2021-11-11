using System.Collections.Generic;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface ICustomerAccountManager
    {
        bool UserLogin(CustomerAccountManagerController cam, List<int> loginTries, string customer_id, string customer_pw);
        bool validatePassword(string customer_pw);
        bool validatePhone(string a);
        bool validateEmail(string a);
    }
}
