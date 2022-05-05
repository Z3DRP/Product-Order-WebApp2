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
        public IActionResult Add(int id, int quantity)
        {
            

            var product = data.Get(id);

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
        public ViewResult Review()
        {
            Cart cart = GetCart();
            var cartModel = new CartViewModel
            {
                ProductList = cart.List,
                Subtotal = cart.Subtotal
            };

            return View(cartModel);
        }

        public ViewResult Checkout() => View("CheckoutTemp");

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartProduct product = cart.GetById(id);
            cart.Remove(product);
            cart.Save();

            TempData["message"] = $"{product.Product.Name} removed from cart";
            return RedirectToAction("Review");
        }
        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart has been cleared";
            return RedirectToAction("Review");
        }
        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartProduct product = cart.GetById(id);

            if (product == null)
            {
                TempData["message"] = "Unable to find cart item";
                return RedirectToAction("Display");
            }
            else
                return View(product);
        }
        [HttpPost]
        public RedirectToActionResult Edit(CartProduct item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Product.Name} has been updated";
            return RedirectToAction("Review");
        }
        
        public IActionResult ProductInfo(int id)
        {
            if (id > 0)
            {
                // get cart item
                Cart cart = GetCart();
                CartProduct sessionProduct = cart.GetById(id);

                // then create a  detail viewmodel for that product
                var product = data.Get(id);

                ProductDetailViewModel pview = new ProductDetailViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.UnitPrice,
                    Image = product.Image,
                    Quantity = sessionProduct.Quantity,
                    ID = product.ProductID
                };
                // return the view

                return View(pview);
            }
            else
                return new EmptyResult();
        }
    }
}
