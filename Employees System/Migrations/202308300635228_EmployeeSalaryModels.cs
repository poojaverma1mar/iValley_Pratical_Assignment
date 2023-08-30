namespace Employees_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeSalaryModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalaryDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSalaries", "Id", "dbo.Employees");
            DropIndex("dbo.EmployeeSalaries", new[] { "Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeSalaries");
        }
    }
}
