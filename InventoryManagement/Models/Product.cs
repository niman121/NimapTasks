using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Models
{
    public class Product
    {
     
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "please write product name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }
}