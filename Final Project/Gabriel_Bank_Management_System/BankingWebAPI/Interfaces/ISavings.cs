using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface ISavings
    {
        void customerDeposit(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal depositAmountKeyedInByCustomer);
        void customerWithdrawl(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal withdrawAmountKeyedInByCustomer);
        void ViewBalance(CustomerAccountManagerController cam);
        decimal DepositLimit();
    }
}
