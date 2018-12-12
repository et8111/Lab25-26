using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab21.Models
{
    public class Person: IdentityUser
    {
        
        public Person()
        {

        }
        public Person(string username)
        {
            UserName = username;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string MotherName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}