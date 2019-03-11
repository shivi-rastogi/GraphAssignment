using GraphApi.Data;
using GraphApi.Logger;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;
using Unity.WebApi;

namespace GraphApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IGraphContext, GraphContext>();
            container.RegisterType<IGraphRepository, GraphRepository>();
            container.RegisterType<IExceptionManager, ExceptionManager>();
            container.RegisterType<IExceptionLogger, ExceptionManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}