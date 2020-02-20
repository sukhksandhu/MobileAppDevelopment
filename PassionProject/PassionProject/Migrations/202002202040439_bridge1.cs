namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bridge1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TripxTravelers", "TravelerId", "dbo.Travelers");
            DropForeignKey("dbo.TripxTravelers", "TripId", "dbo.Trips");
            DropIndex("dbo.TripxTravelers", new[] { "TripId" });
            DropIndex("dbo.TripxTravelers", new[] { "TravelerId" });
            CreateTable(
                "dbo.TravelerTrips",
                c => new
                    {
                        Traveler_TravelerId = c.Int(nullable: false),
                        Trip_TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Traveler_TravelerId, t.Trip_TripId })
                .ForeignKey("dbo.Travelers", t => t.Traveler_TravelerId, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.Trip_TripId, cascadeDelete: true)
                .Index(t => t.Traveler_TravelerId)
                .Index(t => t.Trip_TripId);
            
            DropTable("dbo.TripxTravelers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TripxTravelers",
                c => new
                    {
                        TripxTravelerId = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        TravelerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripxTravelerId);
            
            DropForeignKey("dbo.TravelerTrips", "Trip_TripId", "dbo.Trips");
            DropForeignKey("dbo.TravelerTrips", "Traveler_TravelerId", "dbo.Travelers");
            DropIndex("dbo.TravelerTrips", new[] { "Trip_TripId" });
            DropIndex("dbo.TravelerTrips", new[] { "Traveler_TravelerId" });
            DropTable("dbo.TravelerTrips");
            CreateIndex("dbo.TripxTravelers", "TravelerId");
            CreateIndex("dbo.TripxTravelers", "TripId");
            AddForeignKey("dbo.TripxTravelers", "TripId", "dbo.Trips", "TripId", cascadeDelete: true);
            AddForeignKey("dbo.TripxTravelers", "TravelerId", "dbo.Travelers", "TravelerId", cascadeDelete: true);
        }
    }
}
