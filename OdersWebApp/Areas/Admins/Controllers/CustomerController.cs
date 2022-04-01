using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class CustomerController : Controller
    {
        public IActionResult AddUpdate()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
