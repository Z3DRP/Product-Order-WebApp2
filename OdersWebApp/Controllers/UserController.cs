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

        public IActionResult Login(string usrname)
        {
            TempUser activeUsr = new TempUser();
            // search for user name
            var usr = context.TempUsers.FromSqlRaw("Select * from dbo.TempUsers").Where(x => x.Username == usrname);
            // if user name not in db then add it to db
            if (usr == null)
            {
                // get the number of entries in the db to get the id
                var count = context.TempUsers.FromSqlRaw("Select count(distinct ID) from dbo.TempUsers");

                // add one to the count to get the next id number
                activeUsr.ID = Convert.ToInt32(count) + 1;
                activeUsr.Username = usrname;
                // now add new usr to db
                context.TempUsers.Add(activeUsr);
            }
            else
                activeUsr = context.TempUsers.FirstOrDefault(x => x.Username == usrname);
            // now add the user to the session
            var session = new TempUserSession(HttpContext.Session);

            session.SetUserName(activeUsr.Username);
            // redirect to the landing page
            return RedirectToAction("Landing", "Home");
        }
    }
}
