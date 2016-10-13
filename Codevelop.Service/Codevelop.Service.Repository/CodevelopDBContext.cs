using Codevelop.Service.Entities;
using Codevelop.Shared.Entity;
using System.Data.Common;
using System.Data.Entity;

//using System.Data.Entity;
using System.Data.SqlClient;

namespace Codevelop.Service.Repository
{


    public class CodevelopDBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

       public DbSet<DeviceFeed> DeviceFeed { get; set; }
       

        // C'tor to deploy schema and migrations to a new shard
        public CodevelopDBContext(): base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodevelopDBContext, CodevelopDBContextInitialiser>());
        }



    }
}