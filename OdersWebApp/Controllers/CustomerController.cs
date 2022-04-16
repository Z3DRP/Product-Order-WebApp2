using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdersWebApp.Models;

namespace OdersWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private OrderContext context { get; set; }

        public CustomerController(OrderContext pctx)
        {
            context = pctx;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Action = "Add";
            ViewBag.Type = "Customer";
            return View("SignUp", new Customer());
        }
        [HttpGet]
        public IActionResult SignUp(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Customer";
            var customer = context.Customers
                .FirstOrDefault(c => c.CustomerID == id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult SignUp(Customer customer)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Customer";
            string action = (customer.CustomerID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(customer);
            }
        }
        //public IActionResult History(int id)
        //{
        //    List<CustomerViewModel> cViews = new List<CustomerViewModel>();
        //    CustomerViewModel customer = new CustomerViewModel();
        //    var c = context.Customers.FirstOrDefault(c => c.CustomerID == id);
        //}
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Type = "Customer";
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Customer";
            var customer = context.Customers
                .FirstOrDefault(c => c.CustomerID == id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "Customer";
            string action = (customer.CustomerID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.FirstOrDefault(c => c.CustomerID == id);
            ViewBag.Action = "Delete";
            ViewBag.Type = "Customer";
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            ViewBag.ActionType = "Delete";
            ViewBag.Type = "Customer";
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Delete";
            ViewBag.Type = "Customer";
            var customer = context.Customers.FirstOrDefault(c => c.CustomerID == id);

            return View(customer);
        }
        public IActionResult DisplayAll()
        {
            ViewBag.Action = "Display";
            ViewBag.Type = "Customer";
            var customer = context.Customers.OrderBy(c => c.LastName);

            return View(customer);
        }
    }
}
