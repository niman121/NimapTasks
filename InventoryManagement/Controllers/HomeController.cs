using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.Services;
using InventoryManagement.ViewModels;
using Microsoft.Ajax.Utilities;

namespace InventoryManagement.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly InventoryDbContext _context = new InventoryDbContext();
        private readonly AdoInventoryDbContext _Adocontext = new AdoInventoryDbContext();

        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost/InventoryManagement/Account/Login");
            ;
            
            return View();
        }

        [CustomFilter]
        public async Task<ActionResult> ProductCategoryList(int? pageNumber)
        {
            int pageSize = 4;
            var model = new List<ProductWithCategoryListViewModel>();
            var modelDb = await _context.Products.Include(q => q.ProductCategories).ToListAsync();
            
            foreach (var product in modelDb)
            {
                var names = new List<string>();
                var newProduct = new ProductWithCategoryListViewModel();
                newProduct.productId = product.Id;
                newProduct.productName = product.Name;
                newProduct.categoryId = product.ProductCategories.Select(q => q.CategoryId).ToList();
                foreach (int categoryId in newProduct.categoryId)
                {
                    var cat = await _context.Categories.SingleAsync(q => q.Id == categoryId);
                    names.Add(cat.Name);
                }
                newProduct.categoryName = names;
                model.Add(newProduct);
            }
            return View(model);
        }

    }
}