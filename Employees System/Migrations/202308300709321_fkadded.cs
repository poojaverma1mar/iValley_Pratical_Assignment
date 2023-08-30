namespace Employees_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeSalaries", "Id", "dbo.Employees");
            DropIndex("dbo.EmployeeSalaries", new[] { "Id" });
            AddColumn("dbo.EmployeeSalaries", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeSalaries", "EmployeeID");
            AddForeignKey("dbo.EmployeeSalaries", "EmployeeID", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSalaries", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeSalaries", new[] { "EmployeeID" });
            DropColumn("dbo.EmployeeSalaries", "EmployeeID");
            CreateIndex("dbo.EmployeeSalaries", "Id");
            AddForeignKey("dbo.EmployeeSalaries", "Id", "dbo.Employees", "Id");
        }
    }
}
