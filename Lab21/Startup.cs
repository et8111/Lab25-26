using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using Lab21.Models;

[assembly: OwinStartup(typeof(Lab21.Startup))]

namespace Lab21
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            app.CreatePerOwinContext(() => new IdentityDbContext(ConnectionString));


            app.CreatePerOwinContext<UserStore<Person>>((opt, cont) => new UserStore<Person>(cont.Get<IdentityDbContext>()));            app.CreatePerOwinContext<UserManager<Person>>(                (opt, cont) => new UserManager<Person>(cont.Get<UserStore<Person>>()));

        }
    }
}