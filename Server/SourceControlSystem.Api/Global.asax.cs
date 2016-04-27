namespace SourceControlSystem.Api
{
    using Common.Constants;
    using System.Reflection;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
