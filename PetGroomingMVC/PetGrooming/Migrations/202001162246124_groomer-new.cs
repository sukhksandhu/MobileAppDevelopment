namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groomernew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groomers",
                c => new
                    {
                        GroomerId = c.Int(nullable: false, identity: true),
                        GroomerFname = c.String(),
                        GroomerLname = c.String(),
                        GroomerDob = c.DateTime(nullable: false),
                        GroomerPhone = c.String(),
                        GroomerRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Groomers");
        }
    }
}
