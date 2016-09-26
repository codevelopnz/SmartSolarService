using Codevelop.Service.Entities;
using Microsoft.Azure.SqlDatabase.ElasticScale.ShardManagement;
using System.Data.Common;
using System.Data.Entity;

//using System.Data.Entity;
using System.Data.SqlClient;

namespace Codevelop.Service.Host.Context
{


    public class CodevelopDBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

       
       

        // C'tor to deploy schema and migrations to a new shard
        protected internal CodevelopDBContext(): base("DefaultConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContainer, DbConfiguration>());
            //Database.SetInitializer(new CodevelopDBInitialiser());


        }

    }
}