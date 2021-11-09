using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    interface ICustomerAccountManager
    {
        void UserLogin(CustomerAccountManager cam, List<int> loginTries);
        bool validatePassword(string customer_pw);
        bool validatePhone(string a);
        bool validateEmail(string a);
        Customer CreateUserAccount();
    }
}
