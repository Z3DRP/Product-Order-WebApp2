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
        public IActionResult Skip() => RedirectToAction("Landing", "Home");

        // for now make Login not have a Http request
        // last one used
        public IActionResult Login(string Username)
        {
            TempData["Message"] = Username + " check out all of our products and don't forget to sign up once it is implemented";
            TempUser activeUsr = new TempUser();
            // search for user name
            var usr = context.TempUsers.FromSqlRaw("Select * from dbo.TempUsers").Where(x => x.Username == Username);
            // if user name not in db then add it to db
            // get the number of entries in the db to get the id

            activeUsr.Username = Username;
            // now add new usr to db
            context.TempUsers.Add(activeUsr);
            // now add the user to the session
            var session = new TempUserSession(HttpContext.Session);

            session.SetUserName(activeUsr.Username);
            // redirect to the landing page
            return RedirectToAction("Landing", "Home");
        }

    }
}
