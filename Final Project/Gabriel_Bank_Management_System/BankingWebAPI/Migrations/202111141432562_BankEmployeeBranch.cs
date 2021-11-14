namespace BankingWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankEmployeeBranch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankEmployeeBranches",
                c => new
                    {
                        bankemployee_id = c.String(nullable: false, maxLength: 128),
                        bank_branch = c.String(),
                    })
                .PrimaryKey(t => t.bankemployee_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankEmployeeBranches");
        }
    }
}
