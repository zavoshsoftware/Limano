namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryItemGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GalleryItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        GalleryItemGroupId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GalleryItemGroups", t => t.GalleryItemGroupId, cascadeDelete: true)
                .Index(t => t.GalleryItemGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryItems", "GalleryItemGroupId", "dbo.GalleryItemGroups");
            DropIndex("dbo.GalleryItems", new[] { "GalleryItemGroupId" });
            DropTable("dbo.GalleryItems");
            DropTable("dbo.GalleryItemGroups");
        }
    }
}
