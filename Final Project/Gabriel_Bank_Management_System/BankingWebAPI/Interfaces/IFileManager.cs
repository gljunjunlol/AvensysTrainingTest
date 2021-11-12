using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI.Controllers;
using BankingWebAPI.Models;

namespace BankingWebAPI.Interfaces
{
    public interface IFileManager
    {
        void ReadingandWritingcustomer(string customer_id, CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam);
    }
}
