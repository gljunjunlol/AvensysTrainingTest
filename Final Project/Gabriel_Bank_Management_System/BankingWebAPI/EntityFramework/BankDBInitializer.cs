using BankingWebAPI.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingWebAPI.EntityFramework
{
    public class BankDBInitializer : DropCreateDatabaseAlways<BankManagementContexts>
    {
        protected override void Seed(BankManagementContexts context) // seed get called only once (initial data you want) - usually value of first row loaded into the table
        {
            Customer defaultUser = new Customer("1111", "HulkSmith", "23 hillview road", DateTime.Parse("12 Oct 1996"), "hulk@gmail.com", "(222)333-4444", "pw", "1111", 1000);
            context.Customers.Add(defaultUser);
            context.SaveChanges();

            BankEmployees defaultEmployee = new BankEmployees("1111", "jamesmith", "23 hillview", DateTime.Parse("13 Oct 1986"), "loan employee", "3", "pw");
            context.Employees.Add(defaultEmployee);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}