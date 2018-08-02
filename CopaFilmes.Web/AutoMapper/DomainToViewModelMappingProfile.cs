using AutoMapper;
using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Web.Models.Movie;
using System.Linq;

namespace CopaFilmes.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Movie, MovieView>()
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));

            CreateMap<LeagueInfo, LeagueInfoView>()
                .ForMember(dest => dest.First, opt => opt.MapFrom(src => src.Champions.Where(w => w.Key == 1).Select(s => s.Value).SingleOrDefault()))
                .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Champions.Where(w => w.Key == 2).Select(s => s.Value).SingleOrDefault()))
                .ForMember(dest => dest.Third, opt => opt.MapFrom(src => src.Champions.Where(w => w.Key == 3).Select(s => s.Value).SingleOrDefault()))
                .ForMember(dest => dest.JsonLeague, opt => opt.MapFrom(src => src.JsonLeague));
        }
    }
}