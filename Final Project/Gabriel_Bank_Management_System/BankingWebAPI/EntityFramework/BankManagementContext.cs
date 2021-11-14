using System.Data.Entity;
using BankingWebAPI.Models;


namespace BankingWebAPI.EntityFramework
{
    public class BankManagementContexts : DbContext
    {
        public BankManagementContexts() : base("Name=BankDBConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BankManagementContexts>());
            Database.SetInitializer(new DropCreateDatabaseAlways<BankManagementContexts>());
            //Database.SetInitializer(new BankDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // delegate that gets called when model is created
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankEmployees> Employees { get; set; }
        public DbSet<BankManagers> Managers { get; set; }
    }

}