namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameIsActiveProduct : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Products","IsCategoryActive","IsActive");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Products", "IsActive", "IsCategoryActive");
        }
    }
}
