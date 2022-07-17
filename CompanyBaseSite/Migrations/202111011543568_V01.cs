namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        Message = c.String(nullable: false),
                        Response = c.String(),
                        Website = c.String(),
                        BlogId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Summery = c.String(nullable: false),
                        ImageUrl = c.String(),
                        UrlParam = c.String(),
                        Visit = c.Int(nullable: false),
                        Body = c.String(nullable: false, storeType: "ntext"),
                        BlogGroupId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogGroups", t => t.BlogGroupId, cascadeDelete: true)
                .Index(t => t.BlogGroupId);
            
            CreateTable(
                "dbo.BlogGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Summery = c.String(nullable: false),
                        UrlParam = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactUsForms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false, maxLength: 300),
                        Message = c.String(nullable: false, storeType: "ntext"),
                        Ip = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        HasSeoEffect = c.Boolean(nullable: false),
                        UrlParam = c.String(),
                        ImageUrl = c.String(),
                        Body = c.String(storeType: "ntext"),
                        PageTitle = c.String(),
                        MetaDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        PageTitle = c.String(maxLength: 500),
                        PageDescription = c.String(maxLength: 1000),
                        ImageUrl = c.String(maxLength: 500),
                        Summary = c.String(),
                        Body = c.String(storeType: "ntext"),
                        ProductGroupId = c.Guid(nullable: false),
                        Visit = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Password = c.String(maxLength: 150),
                        CellNum = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 250),
                        RoleId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        ImageUrl = c.String(maxLength: 500),
                        Title = c.String(),
                        Summery = c.String(),
                        LinkTitle = c.String(),
                        LandingPage = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        Summery = c.String(),
                        Body = c.String(storeType: "ntext"),
                        LinkUrl = c.String(),
                        LinkTitle = c.String(),
                        TextItemTypeId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TextItemTypes", t => t.TextItemTypeId)
                .Index(t => t.TextItemTypeId);
            
            CreateTable(
                "dbo.TextItemTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        TypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextItems", "TextItemTypeId", "dbo.TextItemTypes");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.Blogs", "BlogGroupId", "dbo.BlogGroups");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.TextItems", new[] { "TextItemTypeId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.Blogs", new[] { "BlogGroupId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropTable("dbo.TextItemTypes");
            DropTable("dbo.TextItems");
            DropTable("dbo.Sliders");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Products");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.ContactUsForms");
            DropTable("dbo.BlogGroups");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogComments");
        }
    }
}
