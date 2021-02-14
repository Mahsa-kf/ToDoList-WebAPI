namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        taskID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        timeEstimate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        timeSpended = c.Decimal(nullable: false, precision: 18, scale: 2),
                        timeRemaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dueDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        taskStart = c.Decimal(nullable: false, precision: 18, scale: 2),
                        note = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.taskID)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryID = c.Int(nullable: false, identity: true),
                        categorytitle = c.String(),
                        color = c.String(),
                    })
                .PrimaryKey(t => t.categoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "categoryID", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "categoryID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Tasks");
        }
    }
}
