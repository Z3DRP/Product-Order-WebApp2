using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdersWebApp.Models;

namespace OdersWebApp.Controllers
{
    public class OrderController : Controller
    {
        private OrderContext context { get; set; }

        public OrderController(OrderContext pctx)
        {
            context = pctx;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
