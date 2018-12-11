using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab21.Models
{
    public class Person: IdentityUser
    {
        public Person(string userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string MotherName { get; set; }
        public DateTime Birthday { get; set; }
    }
}