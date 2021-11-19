using System.Data.Entity;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Migrations;
using BankingWebAPI.Models;


namespace BankingWebAPI.EntityFramework
{
    public class ManagementContext : DbContext, IDataContext
    {
        public ManagementContext() : base("Name=BankDBConnectionString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<BankManagementContexts>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BankManagementContexts>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<BankManagementContexts>());
            Database.SetInitializer(new BankDBInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion< BankManagementContexts, Configuration>()); // re-run if change in database schema
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // delegate that gets called when model is created
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("My");
            //modelBuilder.Entity<Customer>().ToTable("MyTable", "MyCustomerTableSchema");
            //modelBuilder.Configurations.Add(new BankManagementConfiguration());
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BankEmployees> Employees { get; set; }
        public virtual DbSet<BankManagers> Managers { get; set; }
        public virtual DbSet<Models.BankEmployeeBranch> employeeDetails { get; set; }
    }

}