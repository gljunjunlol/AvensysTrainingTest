using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;

namespace Gabriel_Bank_Management_System
{
    public interface IBankManagersManager
    {
        void ViewManagers(ManagerAccountManager mam);
        
        decimal TotalLoanAmount(CustomerAccountManagerController cam);
        decimal TotalSavingsAccount(CustomerAccountManagerController cam);
        void performOperationAdvanced(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);
        void performOperationAdvancedInternal(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);
        void performOperationAdvancedInternal1(CustomerAccountManagerController cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1);

    }
}
