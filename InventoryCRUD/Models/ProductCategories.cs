using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class ProductCategories
    {
        [Key, Column(Order = 0), ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Product")]
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public bool IsActive { get; set; }

    }
}