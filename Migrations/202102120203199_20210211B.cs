namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210211B : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "dueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "taskStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "note", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "note", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "taskStart", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tasks", "dueDate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
