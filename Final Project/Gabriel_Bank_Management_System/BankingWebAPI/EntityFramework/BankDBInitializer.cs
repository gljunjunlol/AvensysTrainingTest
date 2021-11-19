using BankingWebAPI.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingWebAPI.EntityFramework
{
    public class BankDBInitializer : DropCreateDatabaseAlways<ManagementContext>
    {
        protected override void Seed(ManagementContext context) // seed get called only once (initial data you want) - usually value of first row loaded into the table
        {
            Customer defaultUser = new Customer("1232", "bobbysmith", "23 hillview road", DateTime.Parse("12 Oct 1996"), "hulk@gmail.com", "(222)333-4444", "Test12345678$", "A1232", 1000, Guid.Parse("c44301de-2926-4875-8bf7-d7fce72fe2a7"), true, 2000);
            Customer defaultUser2 = new Customer("1233", "petersmith", "150 hillview road", DateTime.Parse("12 Oct 1996"), "peter@gmail.com", "(555)666-7777", "Test12345678$", "A1233", 1000, Guid.Parse("c152f04e-975a-4cfd-bdcf-88d136b1f23e"), true, 1500);
            context.Customers.Add(defaultUser);
            context.Customers.Add(defaultUser2);
            context.SaveChanges();

            BankEmployees defaultEmployee = new BankEmployees("1111", "jamesmith", "23 hillview", DateTime.Parse("13 Oct 1986"), "loan employee", "3", "pw");
            context.Employees.Add(defaultEmployee);
            context.SaveChanges();

            base.Seed(context);
        }
        //public override void InitializeDatabase(BankManagementContexts context)
        //{
        //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
        //        , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

        //    base.InitializeDatabase(context);
        //}
    }
}