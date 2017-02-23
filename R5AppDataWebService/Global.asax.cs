using System.Web.Http;

namespace R5AppDataWebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var autofacWebApiResolver = IoCConfig.RegisterDependencies(Server);
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = autofacWebApiResolver;

        }
    }
}
