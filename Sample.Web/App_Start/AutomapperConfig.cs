using AutoMapper;
using Sample.DataAccess.Entities;
using Sample.Web.ViewModels.Movie;
using Sample.Web.ViewModels.MovieRate;

namespace Sample.Web{
    public static class AutomapperConfig{
        public static void RegisterMappings(){
            Mapper.CreateMap<Movie, ListMovieModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Title, src => src.MapFrom(m => m.Title))
                .ForMember(dest => dest.Date, src => src.MapFrom(m => m.Date))
                .ForMember(dest => dest.MovieRates, src => src.MapFrom(m => m.MovieRates));

            Mapper.CreateMap<MovieRate, ListMovieRateModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Date, src => src.MapFrom(m => m.Date))
                .ForMember(dest => dest.Rate, src => src.MapFrom(m => m.Rate))
                .ForMember(dest => dest.Comments, src => src.MapFrom(m => m.Comments))
                .ForMember(dest => dest.User, src => src.MapFrom(m => m.User.Firstname))
                .ForMember(dest => dest.Title, src => src.MapFrom(m => m.Movie.Title));

            Mapper.CreateMap<Movie, EditMovieModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Title, src => src.MapFrom(m => m.Title));

            Mapper.AssertConfigurationIsValid();
        }
    }
}