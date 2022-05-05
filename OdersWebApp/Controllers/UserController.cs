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
            if (!string.IsNullOrEmpty(Username))
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
            else
            {
                TempData["loginErrMsg"] = "You must enter a username and then click login inorder to store usrname in session state and " +
                    "continue to app, otherwise click skip. Full login is not implemented yet";
                return RedirectToAction("Index", "Home");
            }
        }

        //public IActionResult Login(TempUser user)
        //{
        //    // I am keeping the code that uses temp user to add username to session data
        //    TempData["Message"] = user.Username + " check out all of our products and don't forget to sign up once it is implemented";
        //    TempUser activeUsr = new TempUser();

        //    // determine if username exits in db
        //    User usr = context.Users.FirstOrDefault(u=> u.Username == user.Username);

        //    if (usr != null)
        //    {
        //        // compare encrypt password then comapre against encrypted stored pwd
        //        string pwd = usr.Password;
        //        if (pwd != null)
        //        {
        //            // Protector.Compare takes the stored encrypted password and the entered plaintext password then
        //            // encrypts the entered passwords then compares the values

        //            bool matchingPwd = Protector.Compare(pwd, user.pwd);
        //            // use compare method to check two the hash vlues of the entered and stored pwds
        //            if (matchingPwd)
        //            {
        //                // now add new usr to db
        //                context.TempUsers.Add(activeUsr);
        //                // now add the user to the session
        //                var session = new TempUserSession(HttpContext.Session);

        //                session.SetUserName(activeUsr.Username);
        //                // redirect to the landing page
        //                return RedirectToAction("Landing", "Home");
        //            }
        //            else
        //            {
        //                TempData["loginFailMsg"] = "Invalid Password";
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            TempData["loginFailMsg"] = "Invalid Username";
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    else
        //    {
        //        TempData["loginFailMsg"] = "You must enter a Username";
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Type = "User";
            return View("Edit", new User());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "User";
            var usr = context.Users
                .FirstOrDefault(u => u.UserID == id);

            return View(usr);
        }
        [HttpPost]
        public IActionResult Edit(User usr)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = "User";
            string action = (usr.UserID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    // encrypt the entered pwd
                    string hashedPwd = Protector.Encryptor(usr.Password);
                    usr.Password = hashedPwd;
                    context.Users.Add(usr);
                }
                else
                {
                    // encrypt the entered pwd
                    string hashedPwd = Protector.Encryptor(usr.Password);
                    usr.Password = hashedPwd;
                    context.Users.Update(usr);
                }
                context.SaveChanges();

                return RedirectToAction("Landing", "Home");
            }
            else
            {
                ViewBag.Action = action;
                return View(usr);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var usr = context.Users.FirstOrDefault(u => u.UserID == id);
            ViewBag.Action = "Delete";
            ViewBag.Type = "User";
            return View(usr);
        }
        [HttpPost]
        public IActionResult Delete(User usr)
        {
            ViewBag.ActionType = "Delete";
            ViewBag.Type = "User";
            context.Users.Remove(usr);
            context.SaveChanges();
            return RedirectToAction("Landing", "Home");
        }
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Delete";
            ViewBag.Type = "User";
            var customer = context.Users.FirstOrDefault(c => c.UserID == id);

            return View(customer);
        }
    }
}
