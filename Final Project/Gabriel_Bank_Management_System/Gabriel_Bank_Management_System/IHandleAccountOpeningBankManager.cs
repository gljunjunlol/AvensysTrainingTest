using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IHandleAccountOpeningBankManager
    {
        void DeleteUserAccount();
        BankManagers CreateUserAccount();
        void UserLogin(BankManagersManagement bmgt);

    }
}
