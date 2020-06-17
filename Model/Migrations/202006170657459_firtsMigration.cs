namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firtsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStockAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.ProviderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        Status = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.ProductId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Address = c.String(),
                        ReceiptMark = c.Boolean(nullable: false),
                        DateReception = c.DateTime(),
                        Prioritet = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        CompanyName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UserId", "dbo.Users");
            DropForeignKey("dbo.RequestProducts", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.RequestProducts", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.RequestProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.ProviderProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropIndex("dbo.RequestProducts", new[] { "ProviderId" });
            DropIndex("dbo.RequestProducts", new[] { "ProductId" });
            DropIndex("dbo.RequestProducts", new[] { "RequestId" });
            DropIndex("dbo.ProviderProducts", new[] { "ProductId" });
            DropIndex("dbo.ProviderProducts", new[] { "ProviderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
            DropTable("dbo.RequestProducts");
            DropTable("dbo.Providers");
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.Products");
        }
    }
}
