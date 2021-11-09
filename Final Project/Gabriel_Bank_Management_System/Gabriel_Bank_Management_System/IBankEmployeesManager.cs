using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IBankEmployeesManager
    {
        
        void ListEmployees(EmployeeAccountManager eam);
        void RemoveEmployees(EmployeeAccountManager eam);
        bool AddBankEmployees(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void SearchCustomerByID(CustomerAccountManager customersmanagement);
        void SearchCustomerByName(CustomerAccountManager customersmanagement);
        void PerformOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void performOperationinternal(CustomerAccountManager cam, EmployeeAccountManager eam);




    }
}
