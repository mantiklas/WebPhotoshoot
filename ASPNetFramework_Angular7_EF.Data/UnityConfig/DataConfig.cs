using ASPNetFramework_Angular7_EF.Data.Core;
using ASPNetFramework_Angular7_EF.Data.EF6;
using ASPNetFramework_Angular7_EF.Data.EF6.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace ASPNetFramework_Angular7_EF.Data.UnityConfig
{
    public static class DataConfig
    {
        public static UnityContainer CurrentContainer { get; set; }

        public static void RegisterDataComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemRepository, ItemRepository>();
        }
    }
}
