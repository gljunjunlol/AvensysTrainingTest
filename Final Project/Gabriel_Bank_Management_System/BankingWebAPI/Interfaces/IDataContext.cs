using BankingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI.Interfaces
{
    public interface IDataContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<BankEmployees> Employees { get; set; }
        DbSet<BankManagers> Managers { get; set; }
        DbSet<Models.BankEmployeeBranch> employeeDetails { get; set; }
    }
}
