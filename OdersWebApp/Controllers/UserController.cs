using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdersWebApp.Models;

namespace OdersWebApp.Controllers
{
    public class UserController : Controller
    {
        private OrderContext context { get; set; }

        public UserController(OrderContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
