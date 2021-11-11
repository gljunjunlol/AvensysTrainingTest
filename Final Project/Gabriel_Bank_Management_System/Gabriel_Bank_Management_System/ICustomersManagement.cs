using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;

namespace Gabriel_Bank_Management_System
{
    public interface ICustomersManagement
    {
        bool AddCustomer(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
        void RemoveCustomers(CustomerAccountManagerController cam);
        void PerformOperation(CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam, List<int> loginTries);
        void ListCustomers(CustomerAccountManagerController cam);

    }
}
