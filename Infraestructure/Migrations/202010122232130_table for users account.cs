namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableforusersaccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RolId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Names = c.String(),
                        PassWord = c.String(),
                        Document = c.String(),
                        Status = c.Boolean(nullable: false),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRols", "RolId", "dbo.Rols");
            DropIndex("dbo.UserRols", new[] { "UserId" });
            DropIndex("dbo.UserRols", new[] { "RolId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRols");
            DropTable("dbo.Rols");
        }
    }
}
