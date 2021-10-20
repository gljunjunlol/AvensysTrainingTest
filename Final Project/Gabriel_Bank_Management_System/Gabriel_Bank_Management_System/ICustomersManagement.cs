using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ICustomersManagement
    {
        void AddCustomer(Customer customer);
        void RemoveCustomers();
        void PerformOperation();
        void ListCustomers();
        void SavingsAccount();
        void WriteAllTransactionInFile();

    }
}
