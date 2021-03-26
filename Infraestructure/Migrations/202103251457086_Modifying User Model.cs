namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRols", "RolId", "dbo.Rols");
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropIndex("dbo.UserRols", new[] { "RolId" });
            DropIndex("dbo.UserRols", new[] { "UserId" });
            AddColumn("dbo.Users", "Phone", c => c.String());
            DropColumn("dbo.Users", "PassWord");
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "Login");
            DropTable("dbo.Rols");
            DropTable("dbo.UserRols");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PassWord", c => c.String());
            DropColumn("dbo.Users", "Phone");
            CreateIndex("dbo.UserRols", "UserId");
            CreateIndex("dbo.UserRols", "RolId");
            AddForeignKey("dbo.UserRols", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRols", "RolId", "dbo.Rols", "Id", cascadeDelete: true);
        }
    }
}
