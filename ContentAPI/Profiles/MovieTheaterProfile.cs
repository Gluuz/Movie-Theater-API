using AutoMapper;
using MovieTheaterAPI.Data.Dtos.MovieTheater;
using MovieTheaterAPI.Models;

namespace MovieTheaterAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<MovieTheaterDTO, MovieTheaterModel>();
        }

    }
}
