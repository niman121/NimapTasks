namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
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
            
            CreateIndex("dbo.ProductCategories", "Category_Id");
            CreateIndex("dbo.ProductCategories", "Product_Id");
            AddForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
