using CopaFilmes.Application.Service;
using SimpleInjector;
using Microsoft.Practices.ServiceLocation;
using CopaFilmes.Application.Core.MovieCup;
using CopaFilmes.Application.Useful;
using CopaFilmes.Application.Dominio.MovieCup;

namespace CopaFilmes.Application.Recorder
{
    public static class Register
    {
        public static void Configuration(Container container)
        {
            ServicesConfiguration(container);
        }

        private static void ServicesConfiguration(Container container)
        {
            container.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
            container.Register<IMoveCup, MoveCup>(Lifestyle.Singleton);
            container.Register<IApi<Movie>, Api<Movie>>(Lifestyle.Singleton);
            container.Verify();
        }
    }
}
