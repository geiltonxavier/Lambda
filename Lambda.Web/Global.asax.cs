using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lambda.Web.App_Start;
using Lambda.Web.Infraestrutura.DependecyResolver;
using Lambda.Web.Infraestrutura.FilterProvider;

namespace Lambda.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new FilterProviderCustom());

        }
    }
}
