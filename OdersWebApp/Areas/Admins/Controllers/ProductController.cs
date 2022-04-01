using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OdersWebApp.Models;

namespace OdersWebApp.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ProductController : Controller
    {
        private OrderContext context { get; set; }

        public ProductController(OrderContext pctx)
        {
            context = pctx;
        }
        public IActionResult Manage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Type = "Product";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Product";
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Product";
            string action = (product.ProductID == 0) ? "Add" : "Edit";

            string testImg = product.Image;

            if (ModelState.IsValid)
            {
                if (action == "Add")
                    context.Products.Add(product);
                else
                    context.Products.Update(product);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;

                return View(product);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            ViewBag.Type = "Product";
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            ViewBag.Action = "Delete";
            ViewBag.Type = "Product";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Details";
            ViewBag.Type = "Product";
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }
        public IActionResult DisplayAll()
        {
            ViewBag.Action = "Display";
            ViewBag.Type = "Product";
            var products = context.Products.OrderBy(p => p.Name);

            return View(products);
        }
        public IActionResult SortByPrice()
        {
            ViewBag.Action = "Sort";
            ViewBag.Type = "Product";
            var products = context.Products.OrderByDescending(p => p.UnitPrice);
            return View(products);
        }

    }

}
