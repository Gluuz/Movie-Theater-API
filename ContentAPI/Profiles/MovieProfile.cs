using AutoMapper;
using ContentAPI.Data.Dtos;
using ContentAPI.Models;

namespace ContentAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDTO, MovieModel>();
        }
    }
}
