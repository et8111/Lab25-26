using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {   //Check this line below
                //var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                var user = UserManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("displayUser", "Home");
                }
            }
            ModelState.AddModelError("", "Idiot");
            return View(login);
        }

        //public ActionResult Registration()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<ActionResult> Registration(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Person user = new Person();
                user.UserName = login.UserName;
                var userManager = HttpContext.GetOwinContext().Get<UserManager<Person>>();
                var x = await userManager.CreateAsync(user, login.Password);
                if (x.Succeeded)
                {
                    return RedirectToAction("Login", login);
                }
            }
            return RedirectToAction("Registration");
        }
    }
}