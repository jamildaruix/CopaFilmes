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
            CreateMap<Movie, MovieView>()
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));
        }
    }
}