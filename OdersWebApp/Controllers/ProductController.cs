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
    }
}
