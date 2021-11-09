using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ISavings
    {
        void performOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        bool customerDeposit(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void customerWithdrawl(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void ViewBalance(CustomerAccountManager cam);
        decimal DepositLimit();
        decimal TakeDepositInput();
    }
}
