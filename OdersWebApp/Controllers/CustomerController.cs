using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdersWebApp.Models;
using OdersWebApp.Encryption;

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
            // get the first name and the last name so id can be found and saved to session to be used in username creation
            
            if (ModelState.IsValid)
            {
                if (action == "Add")
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();

                // after customer added to db retieve the id
                var cust = context.Customers.FirstOrDefault(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName);
                // add to tempdata
                TempData["fname"] = customer.FirstName;
                TempData["lname"] = customer.LastName;
                TempData["cid"] = cust.CustomerID;
                // then save id to session state
                var sesh = new TempUserSession(HttpContext.Session);
                sesh.SetFname(customer.FirstName);
                sesh.SetLname(customer.LastName);
                sesh.SetCid(cust.CustomerID.ToString());

                // add a flag to test on username creation view
                TempData["customerStatus"] = "added";

                return RedirectToAction("Landing", "Home");
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
            return RedirectToAction("Landing", "Home");
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
