namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TripName = c.String(),
                        TripCost = c.Int(nullable: false),
                        TripDate = c.Int(nullable: false),
                        Dest1 = c.String(),
                        Dest2 = c.String(),
                    })
                .PrimaryKey(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trips");
        }
    }
}
