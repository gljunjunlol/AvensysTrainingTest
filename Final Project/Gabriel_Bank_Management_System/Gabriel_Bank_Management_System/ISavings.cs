using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ISavings
    {
        void performOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        bool customerDeposit(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void customerWithdrawl(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void ViewBalance(CustomersManagement cmgt);
        decimal DepositLimit();
        decimal TakeDepositInput();
    }
}
