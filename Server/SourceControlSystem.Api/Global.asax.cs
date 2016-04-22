namespace SourceControlSystem.Api
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
