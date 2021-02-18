namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210217A : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryID" });
            AlterColumn("dbo.Tasks", "EstimatedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "SpendedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "RemainingHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "PlanedDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "CategoryID", c => c.Int());
            CreateIndex("dbo.Tasks", "CategoryID");
            AddForeignKey("dbo.Tasks", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryID" });
            AlterColumn("dbo.Tasks", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "PlanedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "RemainingHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "SpendedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "EstimatedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Tasks", "CategoryID");
            AddForeignKey("dbo.Tasks", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
