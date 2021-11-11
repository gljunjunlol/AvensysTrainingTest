using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;

namespace Gabriel_Bank_Management_System
{
    public interface IBankEmployeesManager
    {
        
        void ListEmployees(EmployeeAccountManagerController eam);
        void RemoveEmployees(EmployeeAccountManagerController eam);
        bool AddBankEmployees(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void SearchCustomerByID(CustomerAccountManagerController customersmanagement);
        void SearchCustomerByName(CustomerAccountManagerController customersmanagement);
        void PerformOperation(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void performOperationinternal(CustomerAccountManagerController cam, EmployeeAccountManager eam);




    }
}
