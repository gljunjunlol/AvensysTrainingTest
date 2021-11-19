namespace BankingWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedbankCu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "CustomerName", newName: "customer_name");
            RenameColumn(table: "dbo.Customers", name: "CustomerAddress", newName: "customer_address");
            AlterColumn("dbo.Customers", "customer_name", c => c.String());
            AlterColumn("dbo.Customers", "customer_address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "customer_address", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Customers", "customer_name", c => c.String(unicode: false, storeType: "text"));
            RenameColumn(table: "dbo.Customers", name: "customer_address", newName: "CustomerAddress");
            RenameColumn(table: "dbo.Customers", name: "customer_name", newName: "CustomerName");
        }
    }
}
