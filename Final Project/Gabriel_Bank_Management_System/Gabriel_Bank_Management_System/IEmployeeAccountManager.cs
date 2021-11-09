using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IEmployeeAccountManager
    {
        BankEmployees CreateUserAccount();
        void UserLogin(EmployeeAccountManager eam);

    }
}
