namespace Reparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rep1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "Createdby", c => c.String());
            AddColumn("dbo.UserAccounts", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "CreatedOn");
            DropColumn("dbo.UserAccounts", "Createdby");
        }
    }
}
