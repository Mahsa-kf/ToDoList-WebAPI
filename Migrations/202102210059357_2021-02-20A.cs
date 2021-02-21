namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210220A : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "PriorityID", c => c.Int());
            AddColumn("dbo.Tasks", "StateID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "StateID");
            DropColumn("dbo.Tasks", "PriorityID");
        }
    }
}
