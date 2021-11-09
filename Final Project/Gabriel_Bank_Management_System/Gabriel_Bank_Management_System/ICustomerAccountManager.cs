using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ICustomerAccountManager
    {
        void UserLogin(CustomerAccountManager cam, List<int> loginTries);
        bool validatePassword(string customer_pw);
        bool validatePhone(string a);
        bool validateEmail(string a);
        Customer CreateUserAccount();
    }
}
