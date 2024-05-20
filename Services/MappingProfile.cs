using AutoMapper;
using Domain.Entities;
using Domain.Parameters;
using Shared.DTOs;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
            CreateMap<FoodItem, FoodItemDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<RestaurantParameters, RestaurantParametersDTO>().ReverseMap();
            CreateMap<FoodItemParameters, FoodItemParametersDTO>().ReverseMap();
            CreateMap<AppUser, UserDTO>().ReverseMap();
        }
    }
}
