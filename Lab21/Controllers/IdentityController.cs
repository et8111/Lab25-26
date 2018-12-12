using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab21.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Lab21.Controllers
{
    public class IdentityController : Controller
    {
        public UserManager<Person> UserManager => HttpContext.GetOwinContext().Get<UserManager<Person>>();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {   //Check this line below
                //var userManager = HttpContext.GetOwinContext().GetUserManager<Person>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                Person user = UserManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Idiot");
            return View(login);
        }
    }
}