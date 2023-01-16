namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJunctionBetweenProductCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Categories", "IsActive");
            DropTable("dbo.ProductCategories");
        }
    }
}
