namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trip : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trips", "TripName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trips", "TripName", c => c.String());
        }
    }
}
