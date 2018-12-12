using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab21.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab21.Models
{
    public class AppUserManager : UserManager<Person>
    {
        public AppUserManager(IUserStore<Person> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<Person>(context.Get<IdentityDbContext<Person>>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}