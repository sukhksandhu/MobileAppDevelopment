namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trips", "Destination_DestinationId", "dbo.Destinations");
            DropIndex("dbo.Trips", new[] { "Destination_DestinationId" });
            RenameColumn(table: "dbo.Trips", name: "Destination_DestinationId", newName: "DestinationId");
            AlterColumn("dbo.Trips", "DestinationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trips", "DestinationId");
            AddForeignKey("dbo.Trips", "DestinationId", "dbo.Destinations", "DestinationId", cascadeDelete: true);
            DropColumn("dbo.Trips", "Dest1");
            DropColumn("dbo.Trips", "Dest2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trips", "Dest2", c => c.String());
            AddColumn("dbo.Trips", "Dest1", c => c.String());
            DropForeignKey("dbo.Trips", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Trips", new[] { "DestinationId" });
            AlterColumn("dbo.Trips", "DestinationId", c => c.Int());
            RenameColumn(table: "dbo.Trips", name: "DestinationId", newName: "Destination_DestinationId");
            CreateIndex("dbo.Trips", "Destination_DestinationId");
            AddForeignKey("dbo.Trips", "Destination_DestinationId", "dbo.Destinations", "DestinationId");
        }
    }
}
