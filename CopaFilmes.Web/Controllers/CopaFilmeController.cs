using CopaFilmes.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopaFilmes.Web.Controllers
{
    public class CopaFilmeController : Controller
    {
        protected readonly IConfiguration _configuration;

        public CopaFilmeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teste = _configuration.AppSettingsConfiguration("ApiCopaFilmes");
            return View();
        }

        [HttpGet]
        public ActionResult ResultadoFinal()
        {
            return View();
        }
    }
}