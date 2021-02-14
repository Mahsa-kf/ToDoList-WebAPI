namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210211C : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tasks", new[] { "categoryID" });
            AddColumn("dbo.Tasks", "EstimatedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tasks", "SpendedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tasks", "RemainingHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tasks", "PlanedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Tasks", "CategoryID");
            DropColumn("dbo.Tasks", "timeEstimate");
            DropColumn("dbo.Tasks", "timeSpended");
            DropColumn("dbo.Tasks", "timeRemaining");
            DropColumn("dbo.Tasks", "taskStart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "taskStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "timeRemaining", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tasks", "timeSpended", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tasks", "timeEstimate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropIndex("dbo.Tasks", new[] { "CategoryID" });
            DropColumn("dbo.Tasks", "PlanedDate");
            DropColumn("dbo.Tasks", "RemainingHours");
            DropColumn("dbo.Tasks", "SpendedHours");
            DropColumn("dbo.Tasks", "EstimatedHours");
            CreateIndex("dbo.Tasks", "categoryID");
        }
    }
}
