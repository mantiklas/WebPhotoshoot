using ASPNetFramework_Angular7_EF.Business.Businesses;
using ASPNetFramework_Angular7_EF.Business.Core;
using ASPNetFramework_Angular7_EF.Data.Core;
using ASPNetFramework_Angular7_EF.Data.EF6;
using ASPNetFramework_Angular7_EF.Data.EF6.Repositories;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using Context = ASPNetFramework_Angular7_EF.Data.EF6.Context;

namespace ASPNetFramework_Angular7_EF
{
    public static class UnityConfig
    {
        public static UnityContainer CurrentContainer { get; set; }
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IItemBusiness, ItemBusiness>();
            container.RegisterType<IContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemRepository, ItemRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            CurrentContainer = container;
        }
    }
}