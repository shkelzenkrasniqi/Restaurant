using AutoMapper;
using Domain.Entities;
using Domain.Parameters;
using Domain.Repositories;
using Service.Abstractions;
using Shared.DTOs;

namespace Services
{
    public class RestaurantService(IRestaurantRepository _restaurantRepository, IMapper _mapper) : IRestaurantService
    {

        public async Task AddAsync(RestaurantDTO restaurantDTO)
        {
            var restaurantEntity = _mapper.Map<Restaurant>(restaurantDTO);
            await _restaurantRepository.AddAsync(restaurantEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var restaurantEntity = await _restaurantRepository.GetAsync(id);
            await _restaurantRepository.DeleteAsync(restaurantEntity);
        }

        public async Task<List<RestaurantDTO>> GetAllAsync(RestaurantParametersDTO restaurantParametersDTO)
        {
            var restaurantParameters = _mapper.Map<RestaurantParameters>(restaurantParametersDTO);
            var restaurantEntities = await _restaurantRepository.GetAllAsync(restaurantParameters);
            return _mapper.Map<List<RestaurantDTO>>(restaurantEntities);
        }

        public async Task<RestaurantDTO> GetAsync(Guid id)
        {
            var restaurantEntity = await _restaurantRepository.GetAsync(id);
            return _mapper.Map<RestaurantDTO>(restaurantEntity);
        }

        public async Task UpdateAsync(RestaurantDTO restaurantDTO)
        {
            var restaurantEntity = _mapper.Map<Restaurant>(restaurantDTO);
            await _restaurantRepository.UpdateAsync(restaurantEntity);
        }
    }
}
