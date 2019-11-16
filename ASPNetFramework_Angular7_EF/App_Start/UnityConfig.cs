using ASPNetFramework_Angular7_EF.Business.Businesses;
using ASPNetFramework_Angular7_EF.Business.Core;
using ASPNetFramework_Angular7_EF.Business.Email;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace ASPNetFramework_Angular7_EF
{
    public static class UnityConfig
    {
        public static UnityContainer CurrentContainer { get; set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IItemBusiness, ItemBusiness>();
            container.RegisterType<IEmailSender, EmailSender>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            CurrentContainer = container;
        }
    }
}
