namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureStation = c.String(),
                        ArrivalStation = c.String(),
                        DepartureDate = c.DateTime(nullable: false),
                        FlightNumber = c.String(maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transports", t => t.FlightNumber)
                .Index(t => t.FlightNumber);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FlightNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "FlightNumber", "dbo.Transports");
            DropIndex("dbo.Flights", new[] { "FlightNumber" });
            DropTable("dbo.Transports");
            DropTable("dbo.Flights");
        }
    }
}
