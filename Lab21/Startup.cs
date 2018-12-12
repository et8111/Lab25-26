using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
//using Lab21.Data;
using Lab21.Models;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Lab21.Startup))]

namespace Lab21
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewNEWMaster;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            app.CreatePerOwinContext(() => new IdentityDbContext<Person>(ConnectionString));

            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<IdentityDbContext<Person>>())));

            app.CreatePerOwinContext<UserStore<Person>>((opt, cont) => new UserStore<Person>(cont.Get<IdentityDbContext<Person>>()));
            app.CreatePerOwinContext<UserManager<Person>>(                (opt, cont) => new UserManager<Person>(cont.Get<UserStore<Person>>()));


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Login"),
            });
        }
    }
}