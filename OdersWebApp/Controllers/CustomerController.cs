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
        public IActionResult SignUp()
        {
            return View();
        }
        //public IActionResult History(int id)
        //{
        //    List<CustomerViewModel> cViews = new List<CustomerViewModel>();
        //    CustomerViewModel customer = new CustomerViewModel();
        //    var c = context.Customers.FirstOrDefault(c => c.CustomerID == id);
        //}
    }
}
