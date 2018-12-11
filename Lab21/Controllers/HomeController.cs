using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab21.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin;
using System.Threading.Tasks;

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
            var identityResult = await UserManager.CreateAsync(new Person(u.UserName),u.Password);

            if (ModelState.IsValid)
            {
                if (identityResult.Succeeded)

                {
                    UserInfo ui = new UserInfo();
                    ui.Birthday = u.Birthday;
                    ui.Email = u.UserName;
                    ui.FirstName = u.FirstName;
                    ui.LastName = u.LastName;
                    ui.MothersName = u.MotherName;
                    ui.Password = u.Password;
                    ui.Phone = u.Phone;
                    CoffeeShopEntities shop = new CoffeeShopEntities();
                    shop.UserInfoes.Add(ui);
                    shop.SaveChanges();

                    ViewBag.fn = ui.FirstName;
                    return RedirectToAction("registerComplete");
                }
                ModelState.AddModelError("FAIL", identityResult.Errors.FirstOrDefault());

                return View();
            }

            return View();
        }

        public ActionResult autoFill()
        {
            string[] s = { "asdf", "asdf", "asdf@asdf.com", "9999999999", "asdf", "asdf", "MA", "2018-01-01" };
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public ActionResult displayUser()
        {
            return View(new CoffeeShopEntities());
        }

        public ActionResult editUser(int id)
        {
            CoffeeShopEntities shop = new CoffeeShopEntities();
            UserInfo u = shop.UserInfoes.First(a => a.UserID == id);
            return View(u);
        }

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

        public ActionResult deleteUser(int id)
        {
            CoffeeShopEntities shop = new CoffeeShopEntities();
            UserInfo dedPerson = shop.UserInfoes.Find(id);
            shop.UserInfoes.Remove(dedPerson);

            shop.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult registerComplete(Person p)
        {
            ViewBag.fn = p.FirstName;
            return View();
        }
    }
}