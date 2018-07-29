using CopaFilmes.Application.Core.MovieCup;
using CopaFilmes.Application.Recorder;
using CopaFilmes.Application.Service;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace CopaFilmes.Test
{
    public class StartupBasic
    {
        protected readonly IConfiguration _configuration;
        protected readonly IMoveCup _moveCup;

        public StartupBasic()
        {
            var container = new Container();
            Register.Configuration(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            this._configuration = container.GetInstance<IConfiguration>();
            this._moveCup = container.GetInstance<IMoveCup>();
        }
    }
}
