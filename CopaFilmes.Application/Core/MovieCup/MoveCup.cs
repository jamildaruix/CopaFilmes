using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Application.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Core.MovieCup
{
    internal class MoveCup : IMoveCup
    {
        private readonly IApi<Movie> _api;

        public MoveCup(IApi<Movie> api)
        {
            this._api = api;
        }

        public void GroupStage(string urlApi)
        {
            var selectedLine = _api.GetList(urlApi);
        }
    }
}
