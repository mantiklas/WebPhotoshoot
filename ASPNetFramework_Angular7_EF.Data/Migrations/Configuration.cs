using ASPNetFramework_Angular7_EF.Data.EF6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Data.Migrations
{
   internal sealed  class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            AutomaticMigrationsEnabled = false;
        }
    }
}
