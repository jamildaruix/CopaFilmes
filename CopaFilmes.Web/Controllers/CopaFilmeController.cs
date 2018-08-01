using AutoMapper;
using CopaFilmes.Application.Core.MovieCup;
using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Application.Service;
using CopaFilmes.Web.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopaFilmes.Web.Controllers
{
    public class CopaFilmeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMovieCup _movieCup;

        public CopaFilmeController(IConfiguration configuration, IMovieCup movieCup)
        {
            this._configuration = configuration;
            this._movieCup = movieCup;
        }

        [HttpGet]
        public ActionResult Index()
        {
            string apiUrl = _configuration.AppSettingsConfiguration("ApiCopaFilmes");
            var listMovie = this._movieCup.MovieAll(apiUrl);
            var listMovieView = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieView>>(listMovie);
            return View(listMovieView);
        }

        [HttpGet]
        public ActionResult ResultadoFinal()
        {
            return View();
        }
    }
}