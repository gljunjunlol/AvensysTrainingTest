using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ICustomersManagement
    {
        bool AddCustomer(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
        void RemoveCustomers(CustomersManagement cmgt);
        void PerformOperation(CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt, List<int> loginTries);
        void ListCustomers(CustomersManagement cmgt);

    }
}
