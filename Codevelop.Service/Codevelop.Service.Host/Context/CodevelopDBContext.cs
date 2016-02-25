using Codevelop.Service.Entities;
using Microsoft.Azure.SqlDatabase.ElasticScale.ShardManagement;
using System.Data.Common;
using System.Data.Entity;

//using System.Data.Entity;
using System.Data.SqlClient;

namespace Codevelop.Service.Host.Context
{


    public class CodevelopDBContext<T> : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        // Regular constructor calls should not happen.
        // 1.) Use the protected c'tor with the connection string parameter
        // to intialize a new shard. 
        // 2.) Use the public c'tor with the shard map parameter in
        // the regular application calls with a tenant id.
        private CodevelopDBContext()
        {
        }

        // C'tor to deploy schema and migrations to a new shard
        protected internal CodevelopDBContext(string connectionString)
            : base(SetInitializerForConnection(connectionString))
        {
        }

        // Only static methods are allowed in calls into base class c'tors
        private static string SetInitializerForConnection(string connnectionString)
        {
            // We want existence checks so that the schema can get deployed
            Database.SetInitializer<CodevelopDBContext<T>>(new CreateDatabaseIfNotExists<CodevelopDBContext<T>>());
            return connnectionString;
        }

        // C'tor for data dependent routing. This call will open a validated connection 
        // routed to the proper shard by the shard map manager. 
        // Note that the base class c'tor call will fail for an open connection
        // if migrations need to be done and SQL credentials are used. This is the reason for the 
        // separation of c'tors into the data-dependent routing case (this c'tor) and the internal c'tor for new shards.
        public CodevelopDBContext(ShardMap shardMap, T shardingKey, string connectionStr)
            : base(CreateDDRConnection(shardMap, shardingKey, connectionStr),
            true /* contextOwnsConnection */)
        {
        }

        // Only static methods are allowed in calls into base class c'tors.
        private static DbConnection CreateDDRConnection(ShardMap shardMap,T shardingKey,string connectionStr)
        {
            // No initialization
            Database.SetInitializer<CodevelopDBContext<T>>(null);

            // Ask shard map to broker a validated connection for the given key
            SqlConnection conn = shardMap.OpenConnectionForKey<T>(shardingKey, connectionStr, ConnectionOptions.Validate);
            return conn;
        }
    }
}