using ASPNetFramework_Angular7_EF.Data.Core;
using ASPNetFramework_Angular7_EF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetFramework_Angular7_EF.Data.EF6
{
   public class Context : DbContext , IContext
    {
        public Context() : base("name=DevConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            var ensureDLLIsCopied =
               System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            return;
        }
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
        public new void Dispose()
        {
            base.Dispose();
        }
    }
  
}
