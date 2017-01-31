using FailTracker.Web.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FailTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // DI with StructureMap
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
            StructureMapObjectFactory.Container.Configure(cfg => {
                cfg.Scan(scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
        }
    }
}
