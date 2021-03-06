﻿using CopaFilmes.Application.Dominio.MovieCup;
using System.Collections.Generic;

namespace CopaFilmes.Application.Core.MovieCup
{
    public interface IMovieCup
    {
        IEnumerable<Movie> MovieAll(string urlApi, int timeoutPolicySeconds);
        LeagueInfo Championship(IList<Movie> selectedList);
    }
}
