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
        private Repo<Product> data { get; set; }
        public CartController(OrderContext ctx) => data = new Repo<Product>(ctx);
        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Fill(data);
            return cart;
        }
        public IActionResult Add(int id)
        {
            // get the selected product from the db
            var product = data.Get(new QueryOptions<Product>
            {
                Where = p => p.ProductID == id
            }); ; // if item was not found 
            if (product == null)
                TempData["message"] = "An error occured while adding item to cart";
            else
            {
                // create product item with default quantity of 1
                var pto = new ProductDTO();
                pto.Load(product);
                CartProduct item = new CartProduct
                {
                    Product = pto,
                    Quantity = 1
                };
                // add item to cart and save session
                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{product.Name} added to cart";
            }
            // eventually add code to redirect to where user left off
            return RedirectToAction("Display", "Product");
        }
    }
}
