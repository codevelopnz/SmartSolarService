using Codevelop.Service.Host.Context;
using Codevelop.Service.Host.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Codevelop.Service.Host.Context
{
    public class ApplicationDbContextInitialiser: DbMigrationsConfiguration<ApplicationDbContext>
    {

        public ApplicationDbContextInitialiser()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var hasher = new PasswordHasher();
            var user = new ApplicationUser
            {
                UserName = "testUser",
                PasswordHash = hasher.HashPassword("Password!")
                
            };

            manager.Create(user, "Password!");
        }
    }
}