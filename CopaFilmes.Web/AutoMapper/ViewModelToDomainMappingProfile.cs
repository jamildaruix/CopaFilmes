using AutoMapper;
using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Web.Models.Movie;
using System;

namespace CopaFilmes.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MovieView, Movie>();
        }
    }
}