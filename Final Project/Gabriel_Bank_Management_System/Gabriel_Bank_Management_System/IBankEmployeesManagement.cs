using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    interface IBankEmployeesManagement
    {
        
        void ListEmployees();
        void RemoveCustomers();
        void AddBankEmployees(BankEmployees bankemployee);
        void SearchCustomerByID();
        void SearchCustomerByName();
        void PerformOperation();
        
        

    }
}
