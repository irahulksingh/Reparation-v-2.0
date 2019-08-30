namespace Reparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rep2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "CreatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
