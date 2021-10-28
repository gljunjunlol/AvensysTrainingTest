using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IBankManagersManagement
    {
        void ViewManagers(BankManagersManagement bmgt);
        
        decimal TotalLoanAmount(CustomersManagement cmgt);
        decimal TotalSavingsAccount(CustomersManagement cmgt);
        void performOperationAdvanced(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void performOperationAdvancedInternal(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void performOperationAdvancedInternal1(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);

    }
}
