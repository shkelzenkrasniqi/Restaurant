using AutoMapper;
using Domain.Entities;
using Domain.Parameters;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
