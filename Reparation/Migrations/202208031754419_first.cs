namespace Reparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Anummer = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        confirmPassword = c.String(nullable: false),
                        ButikId = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        Createdby = c.String(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkOrderId = c.String(),
                        GoldSmithName = c.String(),
                        CustomerName = c.String(nullable: false),
                        CustomerMobileNumber = c.String(nullable: false),
                        CustomerEmail = c.String(),
                        JewelleryDescription1 = c.String(),
                        JewelleryDescription2 = c.String(),
                        JewelleryDescription3 = c.String(),
                        WorkToBeDone = c.String(),
                        WorkToBeDone2 = c.String(),
                        WorkToBeDone3 = c.String(),
                        AgentName = c.String(),
                        ProductGivenOn = c.DateTime(nullable: false),
                        DateAcceptedOrRejected = c.DateTime(),
                        sAcceptedRejectedStatus = c.Int(nullable: false),
                        AmountToBeCollected = c.Int(),
                        sStatus = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkOrders");
            DropTable("dbo.UserAccounts");
        }
    }
}
