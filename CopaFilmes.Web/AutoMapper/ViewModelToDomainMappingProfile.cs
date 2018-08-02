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
            CreateMap<MovieView, Movie>()
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));
        }
    }
}