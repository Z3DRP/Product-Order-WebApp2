using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdersWebApp.Models;

namespace OdersWebApp.Controllers
{
    public class CartController : Controller
    {
        private OrderContext context { get; set; }

        public CartController(OrderContext ctx)
        {
            context = ctx;
        }
        public IActionResult Add(ProductViewModel model)
        {
            model.OrderedProduct = (OrderedProduct)context.Products
                .Where(p => p.ProductID == model.OrderedProduct.ProductID)
                .FirstOrDefault();
            var sesh = new TempUserSession(HttpContext.Session);
            var products = sesh.GetMyProducts();
            products.Add((OrderedProduct)model.Product);

            var cookie = new TempUserCookies(HttpContext.Response.Cookies);
            cookie.SetMyProductIds(products);
            TempData["message"] = $"{model.Product.Name} has been added to your cart";

            return RedirectToAction("QuickView", "Product");
        }
    }
}
