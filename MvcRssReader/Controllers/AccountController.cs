using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRssReader.ViewModels;

namespace MvcRssReader.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(account.Username, account.Password))
                {
                    Session["Username"] = account.Username;
                    return View("Main", account);
                }
                else
                {
                    ModelState.AddModelError("", "Either username or password is incorrect");
                }
            }
            return View("Login", account);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.UsernameExists(account.Username))
                {
                    ModelState.AddModelError("", "Username " + account.Username + " already exists. Please pick another one.");
                }
                else
                {
                    MembershipService.CreateUser(account);
                    return RedirectToAction("Login");
                }         
            }
            
            return View("Registration", account);
        }

        public ActionResult SignOut()
        {
            Session["Username"] = null;
            return RedirectToAction("Login");
        }
    }
}
