[assembly: WebActivator.PostApplicationStartMethod(typeof(EP.CursoMvc.UI.Mvc.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace EP.CursoMvc.UI.Mvc.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using EP.CursoMvc.Infra.CrossCutting.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //aqui é onde iremos registrar nossas dependencias, porem nao registramos aqui senao teremos que jogar as referencias de todas as camadas no mvc
            BootStrapper.RegisterServices(container); //deleguei para outra camada fazer o serviço
        }
    }
}