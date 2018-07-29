using CopaFilmes.Application.Registrator;
using CopaFilmes.Application.Service;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CopaFilmes.Test
{
    public class StartupBasic
    {
        protected readonly IConfiguration _configuration;

        public StartupBasic()
        {
            var container = new Container();
            Register.Configuration(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            _configuration = container.GetInstance<IConfiguration>();
        }

    }
}
