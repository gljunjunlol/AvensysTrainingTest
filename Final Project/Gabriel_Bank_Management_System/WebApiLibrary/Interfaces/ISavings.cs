using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface ISavings
    {
        void performOperation(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam);
        bool customerDeposit(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam);
        void customerWithdrawl(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam);
        void ViewBalance(CustomerAccountManagerController cam);
        decimal DepositLimit();
        decimal TakeDepositInput();
    }
}
