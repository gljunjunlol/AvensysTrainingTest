namespace BankingWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankingWebAPI.EntityFramework.BankManagementContexts>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;  // if auto is true
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BankingWebAPI.EntityFramework.BankManagementContexts context) // seed is initial create
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
