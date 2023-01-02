using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;

namespace InventoryManagement.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext() : base("InventoryDbContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<ProductCategories> ProductCategories { get; set; }
    }
}