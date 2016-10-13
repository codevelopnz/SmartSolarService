using System.Data.Entity.Migrations;

namespace Codevelop.Service.Repository
{
    public class CodevelopDBContextInitialiser : DbMigrationsConfiguration<CodevelopDBContext>
    {

        public CodevelopDBContextInitialiser()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(CodevelopDBContext context)
        //{
            
        //}
    }
}