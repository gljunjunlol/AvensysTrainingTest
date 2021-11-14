namespace BankingWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerName = c.String(unicode: false, storeType: "text"),
                        CustomerAddress = c.String(unicode: false, storeType: "text"),
                        customer_id = c.String(nullable: false, maxLength: 128),
                        customer_dateOfBirth = c.DateTime(nullable: false),
                        customer_email = c.String(),
                        customer_phone = c.String(),
                        customer_pw = c.String(maxLength: 24),
                        cheque_book_number = c.Guid(nullable: false),
                        account_number = c.String(),
                        customerBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        customer_loan_applied = c.Boolean(nullable: false),
                        loan_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.BankEmployees",
                c => new
                    {
                        EmployeeName = c.String(unicode: false, storeType: "text"),
                        EmployeeAddress = c.String(unicode: false, storeType: "text"),
                        bankemployee_id = c.String(nullable: false, maxLength: 128),
                        bankemployee_dateOfBirth = c.DateTime(nullable: false),
                        bankemployee_designation = c.String(),
                        bankemployee_yearsOfService = c.String(),
                        bankemployee_pw = c.String(),
                    })
                .PrimaryKey(t => t.bankemployee_id);
            
            CreateTable(
                "dbo.BankManagers",
                c => new
                    {
                        bankmanager_id = c.String(nullable: false, maxLength: 128),
                        bankmanager_name = c.String(),
                        bankmanager_address = c.String(),
                        bankmanager_dateOfBirth = c.DateTime(nullable: false),
                        bankmanager_designation = c.String(),
                        bankmanager_yearsOfService = c.String(),
                        bankmanager_pw = c.String(),
                    })
                .PrimaryKey(t => t.bankmanager_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankManagers");
            DropTable("dbo.BankEmployees");
            DropTable("dbo.Customers");
        }
    }
}
