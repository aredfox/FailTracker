using FailTracker.Web.Infrastructure;
using StructureMap;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FailTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Container Per Request Pattern
        public IContainer Container
        {
            get { return (IContainer)HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // DI with StructureMap
            DependencyResolver.SetResolver(
                new StructureMapDependencyResolver(
                    () => Container ?? StructureMapObjectFactory.Container
                )
            );
            StructureMapObjectFactory.Container.Configure(cfg => {
                cfg.Scan(scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    // Brand new controller per request - as this is needed in MVC when using the "container-per-request-pattern"
                    // as controllers cannot be reused per request.
                    scan.With(new StructureMapControllerConvention());
                });
            });
        }

        public void Application_BeginRequest()
        {
            Container = StructureMapObjectFactory.Container.GetNestedContainer();
        }
        public void Application_EndRequest()
        {
            Container.Dispose();
            Container = null;
        }
    }
}
