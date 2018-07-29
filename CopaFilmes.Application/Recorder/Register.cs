using CopaFilmes.Application.Service;
using SimpleInjector;
using Microsoft.Practices.ServiceLocation;

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
            container.Verify();
        }
    }
}
