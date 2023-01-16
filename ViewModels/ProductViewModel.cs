using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.ViewModels
{
    public class ProductWithCategoryListViewModel
    {
        public int productId { get; set; }
        public List<int> categoryId { get; set; }
        public string productName { get; set; }

        public List<string> categoryName { get; set; }

    }
}