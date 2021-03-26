namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingrelationbetweenFlightandUserModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Flights", "UserId");
            AddForeignKey("dbo.Flights", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "UserId", "dbo.Users");
            DropIndex("dbo.Flights", new[] { "UserId" });
            DropColumn("dbo.Flights", "UserId");
        }
    }
}
