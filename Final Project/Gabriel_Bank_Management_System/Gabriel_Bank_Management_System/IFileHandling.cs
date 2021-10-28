using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface IFileHandling
    {
        void ReadingandWritingcustomer(string customer_id, CustomersManagement cmgt, BankEmployeesManagement bemgt, BankManagersManagement bmgt);
    }
}
