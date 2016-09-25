using Codevelop.Service.Host.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Codevelop.Service.Host.Context
{
    public class CodevelopDBInitialiser: CreateDatabaseIfNotExists<CodevelopDBContext<T>>
    {

        protected override void Seed(CodevelopDBContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var hasher = new PasswordHasher();
            var user = new ApplicationUser
            {
                UserName = "abhimanyu",
                PasswordHash = hasher.HashPassword("abhimanyu"),
                UserProfileInfo = new UserProfileInfo
                {
                    FirstName = "Abhimanyu K",
                    LastName = "Vatsa",
                    EmailID = "abhikumarvatsa@yahoo.co.in"
                }
            };

            manager.Create(user, "abhimanyu");
        }
    }
}