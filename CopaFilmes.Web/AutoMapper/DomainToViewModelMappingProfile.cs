using AutoMapper;
using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Web.Models.Movie;
using System;

namespace CopaFilmes.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Movie, MovieView>();
        }
    }
}