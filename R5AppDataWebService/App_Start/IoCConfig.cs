using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using R5AppData.ResourceAccess;
using R5AppData.ServiceImplementation;

namespace R5AppDataWebService
{
    public sealed class IoCConfig
	{
		private IoCConfig() { }

		public static AutofacWebApiDependencyResolver RegisterDependencies(HttpServerUtility httpserver)
		{
			// Create the builder
			var builder = new ContainerBuilder();

            // Setup a common pattern - placed here before RegisterControllers as last one wins

            builder.RegisterAssemblyTypes(typeof(R5AppContext).Assembly)
                .Where(t => t.Name.EndsWith("Context"))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(R5AppContext).Assembly)
                 .Where(t => t.Name.EndsWith("Work"))
                 .AsImplementedInterfaces()
                 .AsSelf()
                 .InstancePerRequest();

            builder.RegisterAssemblyTypes(
                typeof(R5AppDataService).Assembly
                )
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .AsSelf()
                   .InstancePerRequest();

            //Register API controllers for the assembly

            // Register your Web API controllers.
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly)
                   .InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);




            //			//Register modules

            //			builder.RegisterAssemblyModules(typeof(WebApiApplication).Assembly);
            //			builder.RegisterAssemblyModules(typeof(ServiceImplementation.ActiveDirectorySync).Assembly);
            //			builder.RegisterAssemblyModules(typeof(ServiceContracts.IActiveDirectorySync).Assembly);

            #region Model binder providers - excluded - not sure if need
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();
            #endregion


            // Set the API dependency resolver to use Autofac
            var container = builder.Build();

			return new AutofacWebApiDependencyResolver(container);
		}
	}
}
