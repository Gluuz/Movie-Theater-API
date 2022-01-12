using AutoMapper;
using MovieTheaterAPI.Data.Dtos.Adress;
using MovieTheaterAPI.Models;

namespace MovieTheaterAPI.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<AddressDTO, AddressModel>();
        }
    }
}
