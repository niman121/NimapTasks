namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryProductIsActive : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            AddColumn("dbo.Products", "IsCategoryActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Products", "IsActive");
            DropTable("dbo.ProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id });
            
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Products", "IsCategoryActive");
            CreateIndex("dbo.ProductCategories", "Category_Id");
            CreateIndex("dbo.ProductCategories", "Product_Id");
            AddForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
