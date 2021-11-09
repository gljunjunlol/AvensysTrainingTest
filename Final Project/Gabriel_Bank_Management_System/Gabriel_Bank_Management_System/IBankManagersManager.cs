using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IBankManagersManager
    {
        void ViewManagers(ManagerAccountManager mam);
        
        decimal TotalLoanAmount(CustomerAccountManager cam);
        decimal TotalSavingsAccount(CustomerAccountManager cam);
        void performOperationAdvanced(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);
        void performOperationAdvancedInternal(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);
        void performOperationAdvancedInternal1(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);

    }
}
