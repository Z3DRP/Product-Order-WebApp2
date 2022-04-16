using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OdersWebApp.Models;

namespace OdersWebApp.Controllers
{
    public class ProductController : Controller
    {
        private OrderContext context { get; set; }

        public ProductController(OrderContext pctx)
        {
            context = pctx;
        }
        public IActionResult Display()
        {
            ViewBag.Action = "Display";
            ViewBag.Type = "Product";
            var products = context.Products.OrderBy(p => p.Name);

            return View(products);
        }
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Details";
            ViewBag.Type = "Product";
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }
        public IActionResult AddToCart()
        {
            return View();
        }
        public IActionResult QuickView()
        {
            // Change to usee session data to get the selected products
            ViewData["PageHeader"] = "Shop Our Products";
            // init a list of product views
            List<ProductViewModel> pView = new List<ProductViewModel>();
            
            // get the items from DB
            var products = context.Products.OrderBy(p => p.Name);
            // assign items to productView
            foreach(Product p in products)
            {
                ProductViewModel prod = new ProductViewModel();
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.UnitPrice = p.UnitPrice;
                prod.Image = p.Image;
                pView.Add(prod);
            }
            return View(pView);
        }
    }
}
