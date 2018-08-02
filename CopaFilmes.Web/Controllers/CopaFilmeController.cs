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
            string apiUrl = _configuration.AppSettingsConfiguration("ApiCup");
            int timeoutPolicySeconds = Convert.ToInt32(_configuration.AppSettingsConfiguration("TimeoutPolicySeconds"));
            var listMovie = this._movieCup.MovieAll(apiUrl, timeoutPolicySeconds);
            var listMovieView = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieView>>(listMovie);
            return View(listMovieView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResultadoFinal(IEnumerable<MovieView> model)
        {
            var result = model.Where(w => w.Checked);
            var listMovie = Mapper.Map<IEnumerable<MovieView>, IEnumerable<Movie>>(result);
            var leagueInfo  = this._movieCup.Championship(listMovie.ToList());
            var leagueInfoView = Mapper.Map<LeagueInfo, LeagueInfoView>(leagueInfo);
            return View(leagueInfoView);
        }
    }
}