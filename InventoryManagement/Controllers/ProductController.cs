using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly InventoryDbContext _context = new InventoryDbContext(); //for ef
        private readonly AdoInventoryDbContext _Adocontext = new AdoInventoryDbContext(); //for ado.net 

        //public ProductController(InventoryDbContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public async  Task<ActionResult> ProductList()
        {
            //var products = _context.Products; //ef way
            var products = await _Adocontext.RetrieveAllProductsAsync();//ado.net way
            return View(products);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            var newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateProduct")]
        public async Task<ActionResult> CreateProductAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                //_context.Products.Add(newProduct); //ef way
                //await _context.SaveChangesAsync(); //ef way

                await _Adocontext.AddProductAsync(product);
                return RedirectToAction("ProductList");
            }

            return View(product);
        }

        [HttpGet]
        [ActionName("EditProduct")]
        public async Task<ActionResult> EditProductAsync(int id)
        {
            //var getProductFromDb =await  _context.Products.Where(q => q.Id == id).SingleAsync(); //ef way
            var getProductFromDb = await _Adocontext.GetProductByIdAsync(id); //ado.net way
            if (getProductFromDb != null)
            {
                return View(getProductFromDb);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditProduct")]
        public async Task<ActionResult> EditProductAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                //var getProductFromDb = await _context.Products.FindAsync(product.Id);//ef way
                //getProductFromDb.Name = product.Name; //ef way
                //await _context.SaveChangesAsync(); //ef way
                await _Adocontext.EditProductAsync(product);
                return RedirectToAction("ProductList");
            }
            return View(product);
        }


        [HttpGet]
        [ActionName("ProductDetail")]
        public async Task<ActionResult> ProductDetailAsync(int id)
        {
            //var getProductFromDb = await _context.Products.Where(q => q.Id == id).SingleAsync(); //ef way
            var getProductFromDb = await _Adocontext.GetProductByIdAsync(id); //ado.net way
            if (getProductFromDb != null)
            {
                return View(getProductFromDb);
            }
            return View("Error");
        }


        [HttpGet]
        [ActionName("DeleteProduct")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            //var getProductFromDb = await _context.Products.FindAsync(id); //ef way
            var getProductFromDb = await _Adocontext.GetProductByIdAsync(id); //ado.net way
            if (getProductFromDb != null)
            {
                return View(getProductFromDb);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteProduct")]
        public async Task<ActionResult> DeleteProductAsync(Product product)
        {
            if (product != null)
            {
                //var productFromDb = await _context.Products.FindAsync(product.Id); //ef way
                //_context.Products.Remove(productFromDb); // ef way
                //await _context.SaveChangesAsync(); //ef way
                await _Adocontext.DeleteProductFromDbByIdAsync(product.Id);//ado.net way
                return RedirectToAction("ProductList");
            }
            return View("Error");
        }

    }
}