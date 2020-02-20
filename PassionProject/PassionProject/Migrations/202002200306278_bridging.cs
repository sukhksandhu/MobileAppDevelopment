namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bridging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripxTravelers",
                c => new
                    {
                        TripxTravelerId = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        TravelerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripxTravelerId)
                .ForeignKey("dbo.Travelers", t => t.TravelerId, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.TravelerId);
            
            CreateTable(
                "dbo.Travelers",
                c => new
                    {
                        TravelerId = c.Int(nullable: false, identity: true),
                        TravelerfName = c.String(),
                        TravelerlName = c.String(),
                        TravelerContact = c.String(),
                        Guests = c.Int(nullable: false),
                        TravelerEmail = c.String(),
                    })
                .PrimaryKey(t => t.TravelerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripxTravelers", "TripId", "dbo.Trips");
            DropForeignKey("dbo.TripxTravelers", "TravelerId", "dbo.Travelers");
            DropIndex("dbo.TripxTravelers", new[] { "TravelerId" });
            DropIndex("dbo.TripxTravelers", new[] { "TripId" });
            DropTable("dbo.Travelers");
            DropTable("dbo.TripxTravelers");
        }
    }
}
