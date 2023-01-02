using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using Microsoft.Ajax.Utilities;

namespace InventoryManagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly InventoryDbContext _context = new InventoryDbContext();
        private readonly AdoInventoryDbContext _Adocontext = new AdoInventoryDbContext();
        [HttpGet]
        public async Task<ActionResult> CategoryList(int? pageNumber)
        {
            var newmodel = new List<Category>();
            int pageSize = 4;
            int totalPages = 0;

            if (pageNumber != null)
            {
                var numbertoskip = pageSize * (pageNumber-1);
                newmodel = await _context.Categories.AsQueryable().OrderBy(q => q.Id).Skip((int)numbertoskip).Take(pageSize).ToListAsync();//ef way
            }
            else
            {
                newmodel = await _context.Categories.AsQueryable().OrderBy(q => q.Id).Skip(0).Take(pageSize).ToListAsync();//ef way
            }
            //var model = await _Adocontext.RetrieveAllCategoriesAsync(); //ado.net way
            int totalCategories = _context.Categories.Count();
            totalPages = totalCategories%pageSize == 0 ? totalCategories/pageSize : totalCategories/pageSize +1;
            ViewBag.TotalNumberOfPages = totalPages;
            return View(newmodel);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            var model = new Category();
            return View(model);
        }

        [HttpPost]
        [ActionName("CreateCategory")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategoryAsync(Category model)
        {
            if (ModelState.IsValid)
            {
               // _context.Categories.Add(model); //ef way
               //await _context.SaveChangesAsync(); //ef way

               await _Adocontext.AddCategoryAsync(model); //ado.net way
               return RedirectToAction("CategoryList");
            }
            return View(model);
        }

        [HttpGet]
        [ActionName("EditCategory")]
        public async Task<ActionResult> EditCategoryAsync(int id)
        {
            //var getCategoryFromDb = await _context.Categories.Where(q=> q.Id == id).SingleAsync();//used ef way
            var getCategoryFromDb = await _Adocontext.GetCategoryByIdAsync(id) ; //used ado.net way

            if (getCategoryFromDb != null)
            {
                return View(getCategoryFromDb);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditCategory")]
        public async Task<ActionResult> EditCategoryAsync(Category category)
        {
            if (ModelState.IsValid)
            {
                //var getCategoryFromDb = await _context.Categories.FindAsync(category.Id); //ef way
                //if (getCategoryFromDb != null)
                //{
                //    getCategoryFromDb.Name = category.Name;
                //    getCategoryFromDb.IsActive = category.IsActive;
                //}
                //await _context.SaveChangesAsync(); //ef way
                await _Adocontext.EditCategoryAsync(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }


        [HttpGet]
        [ActionName("CategoryDetail")]
        public async Task<ActionResult> CategoryDetailAsync(int id)
        {
            //var getCategoryFromDb = await _context.Categories.Where(q => q.Id == id).SingleAsync(); //ef way
            var getCategoryFromDb = await _Adocontext.GetCategoryByIdAsync(id); //ado.net way
            if (getCategoryFromDb != null)
            {
                return View(getCategoryFromDb);
            }
            return View("Error");
        }


        [HttpGet]
        [ActionName("DeleteCategory")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            //var getCategoryFromDb = await _context.Categories.FindAsync(id);//ef way
            var getCategoryFromDb = await _Adocontext.GetCategoryByIdAsync(id); //ado.net way
            if (getCategoryFromDb != null)
            {
                return View(getCategoryFromDb);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCategory")]
        public async Task<ActionResult> DeleteCategoryAsync(Category category)
        {
            if (category != null)
            {
                //var categoryFromDb = await _context.Categories.FindAsync(category.Id); //ef way
                //_context.Categories.Remove(categoryFromDb); //ef way
                //await _context.SaveChangesAsync();// ef way
                await _Adocontext.DeleteCategoryFromDbAsync(category.Id);
                return RedirectToAction("CategoryList");
            }
            return View("Error");
        }


        [HttpGet]
        public async Task<ActionResult> DeActivateCategory(int id)
        {
            //var getCategoryFromDb = await _context.Categories.Include(q => q.Products).SingleOrDefaultAsync(q => q.Id == id); //ef way
            //if (getCategoryFromDb != null)
            //{
            //    getCategoryFromDb.IsActive = false;
            //    foreach (var product in getCategoryFromDb.Products)
            //    {
            //        product.IsCategoryActive = false;
            //    }
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("CategoryList");
            //}
            //return View("Error");

            await _Adocontext.DeActivateCategoryAsync(id);
            return RedirectToAction("CategoryList");

        }
        public async Task<ActionResult> ActivateCategory(int id)
        {
           // var getCategoryFromDb = await _context.Categories.FindAsync(id);// ef way
           //if (getCategoryFromDb != null)
           // {
           //     getCategoryFromDb.IsActive = true;
           //     foreach (var product in getCategoryFromDb.Products)
           //     {
           //         product.IsCategoryActive = true;

           //     }
           //     await _context.SaveChangesAsync();
           //     return RedirectToAction("CategoryList");
           // }
           
            await _Adocontext.ActivateCategoryAsync(id); //ado.net way
            return RedirectToAction("CategoryList");
        }


        public async Task<ActionResult> ProductListToAddInCategory(int id)
        {
            var category = await _Adocontext.GetCategoryByIdAsync(id);//ado.net way
            var newProducts = await _Adocontext.ProductsListNotInCategoryAsync(id);//ado.net way
            ViewBag.CategoryId = category.Id;
            ViewBag.CategoryName = category.Name;
            return View(newProducts);
        }

        public async Task<ActionResult> AddProductToCategory(int id, int productId)
        {
            //var getCategoryFromDb = await _context.Categories.Where(q => q.Id == id).FirstOrDefaultAsync(); //ef way
            //var getProductFromDb = await _context.Products.Where(q => q.Id == productId).FirstOrDefaultAsync(); ef way
            //if (getCategoryFromDb != null && getProductFromDb != null)
            //{
            //    //getCategoryFromDb.Products.Add(getProductFromDb);
            //    return RedirectToAction("CategoryList");
            //}

            await _Adocontext.AddProductToCategoryAsync(productId, id);
            return RedirectToAction("ProductListToAddInCategory",new{id = id});
        }

        public async Task<ActionResult> ProductListInCategory(int id)
        {
            var products = await _Adocontext.GetAllProductInCategoryAsync(id);
            var category = await _Adocontext.GetCategoryByIdAsync(id);
            ViewBag.CategoryId = category.Id;
            ViewBag.CategoryName = category.Name;
            return View(products);
        }

        public async Task<ActionResult> RemoveProductFromCategory(int id, int productId)
        {
            //var getCategoryFromDb = await _context.Categories.Include(q => q.ProductCategories).Where(q => q.Id == id).FirstOrDefaultAsync(); //ef way
            //var product = getCategoryFromDb?.ProductCategories.FirstOrDefault(q => q.ProductId == productId); //ef way

            //if (product == null) return View("Error");

            //getCategoryFromDb.ProductCategories.Remove(product);
            //await _context.SaveChangesAsync();
            await _Adocontext.RemoveProductFromCategory(productId, id); // ado.net way
            return RedirectToAction("ProductListInCategory",new{id = id});
        }

    }
}