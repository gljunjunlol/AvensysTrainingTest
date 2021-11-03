using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IBankEmployeesManagement
    {
        
        void ListEmployees(BankEmployeesManagement bemgt);
        void RemoveEmployees(BankEmployeesManagement bemgt);
        bool AddBankEmployees(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void SearchCustomerByID(CustomersManagement customersmanagement);
        void SearchCustomerByName(CustomersManagement customersmanagement);
        void PerformOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void performOperationinternal(CustomersManagement cmgt, BankEmployeesManagement bemgt);




    }
}
