namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingFlighNumberForeignKeyFromFlightModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "FlightNumber", "dbo.Transports");
            DropIndex("dbo.Flights", new[] { "FlightNumber" });
            AlterColumn("dbo.Flights", "FlightNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "FlightNumber", c => c.String(maxLength: 128));
            CreateIndex("dbo.Flights", "FlightNumber");
            AddForeignKey("dbo.Flights", "FlightNumber", "dbo.Transports", "FlightNumber");
        }
    }
}
