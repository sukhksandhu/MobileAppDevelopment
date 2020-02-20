namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destination : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        DestinationName = c.String(),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            AddColumn("dbo.Trips", "Destination_DestinationId", c => c.Int());
            CreateIndex("dbo.Trips", "Destination_DestinationId");
            AddForeignKey("dbo.Trips", "Destination_DestinationId", "dbo.Destinations", "DestinationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "Destination_DestinationId", "dbo.Destinations");
            DropIndex("dbo.Trips", new[] { "Destination_DestinationId" });
            DropColumn("dbo.Trips", "Destination_DestinationId");
            DropTable("dbo.Destinations");
        }
    }
}
