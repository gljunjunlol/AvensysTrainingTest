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
        void performOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        bool customerDeposit(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void customerWithdrawl(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void ViewBalance(CustomerAccountManager cam);
        decimal DepositLimit();
        decimal TakeDepositInput();
    }
}
