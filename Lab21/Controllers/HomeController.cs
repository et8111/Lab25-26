using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab21.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

using System.Threading.Tasks;
using System.Net;
using System.Reflection;

namespace Lab21.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<Person> UserManager => HttpContext.GetOwinContext().Get<UserManager<Person>>();

        public ActionResult Index()
        {
            CoffeeShopEntities s = new CoffeeShopEntities();
            ViewBag.Temp = s.UserInfoes.Count();
            return View(ViewBag.Temp);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Person u)
        {
            //var identityResult = await UserManager.CreateAsync(new Person(u.UserName),u.Password);

            if (ModelState.IsValid)
            {
                LoginModel user = new LoginModel();
                user.UserName = u.UserName;
                var userManager = HttpContext.GetOwinContext().Get<UserManager<Person>>();
                var identityResult = await userManager.CreateAsync(new Person(u.UserName), u.Password);

                if (identityResult.Succeeded)
                {
                    UserInfo ui = new UserInfo();
                    ui.Birthday = u.Birthday;
                    ui.Email = u.UserName;
                    ui.FirstName = u.FirstName;
                    ui.LastName = u.LastName;
                    ui.MothersName = u.MotherName;
                    ui.Phone = u.Phone;
                    CoffeeShopEntities shop = new CoffeeShopEntities();
                    shop.UserInfoes.Add(ui);
                    shop.SaveChanges();
                    return RedirectToAction("registerComplete",u);
                }
                ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

                return View();
            }

            return View();
        }

        public ActionResult autoFill()
        {
            string[] s = { "asdf", "asdf", "asdf@asdf.com", "9999999999", "123456", "123456", "MA", "01/01/2018" };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult displayUser()
        {
            return View(new CoffeeShopEntities());
        }
        [Authorize]
        public ActionResult editUser(int id)
        {
            CoffeeShopEntities shop = new CoffeeShopEntities();
            UserInfo u = new UserInfo();
            u = shop.UserInfoes.Find(id);
            return View(u);
        }
        [Authorize]
        public ActionResult UserChanges(UserInfo u)
        {
            CoffeeShopEntities shop = new CoffeeShopEntities();
            UserInfo old = shop.UserInfoes.Find(u.UserID);
            old.FirstName = u.FirstName;
            old.LastName = u.LastName;
            old.Phone = u.Phone;
            old.Email = u.Email;
            old.Password = u.Password;
            old.MothersName = u.MothersName;
            old.Birthday = u.Birthday;

            shop.Entry(old).State = System.Data.Entity.EntityState.Modified;
            shop.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> deleteUser(int id)
        {
            CoffeeShopEntities shop = new CoffeeShopEntities();
            UserInfo dedPerson = shop.UserInfoes.Find(id);
            var userEmail = dedPerson.Email;
            if (userEmail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (userEmail != User.Identity.Name)
            {
                TempData["msg"] = "Not Autherized";
                return RedirectToAction("displayUser", "Home");
            }
            var user = await UserManager.FindByNameAsync(dedPerson.Email);
            if (User.Identity.Name == userEmail)
            {
                var AM = HttpContext.GetOwinContext().Authentication;
                AM.SignOut();
            }
            await UserManager.DeleteAsync(user);

            //////////////////////////////////////////////////////
            
            shop.UserInfoes.Remove(dedPerson);

            shop.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult registerComplete(Person p)
        {
            ViewBag.First = p.FirstName;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}