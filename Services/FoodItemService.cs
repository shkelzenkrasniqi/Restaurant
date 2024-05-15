using AutoMapper;
using Domain.Entities;
using Domain.Parameters;
using Domain.Repositories;
using Service.Abstractions;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FoodItemService(IFoodItemRepository _foodItemRepository, IMapper _mapper) : IFoodItemService
    {

        public async Task AddAsync(FoodItemDTO foodItemDTO)
        {
            var foodItemEntity = _mapper.Map<FoodItem>(foodItemDTO);
            await _foodItemRepository.AddAsync(foodItemEntity);
        }

        public async Task DeleteAsync(Guid restaurantId ,Guid id)
        {
            var foodItemEntity = await _foodItemRepository.GetAsync(restaurantId,id);
            await _foodItemRepository.DeleteAsync(foodItemEntity);
        }
        public async Task<List<FoodItemDTO>> GetAllAsync(Guid restaurantId, FoodItemParametersDTO foodItemParametersDTO)
        {
            var foodItemParameters = _mapper.Map<FoodItemParameters>(foodItemParametersDTO);
            var foodItemEntities = await _foodItemRepository.GetAllAsync(restaurantId, foodItemParameters);
            return _mapper.Map<List<FoodItemDTO>>(foodItemEntities);
        }

        public async Task<FoodItemDTO> GetAsync(Guid restaurantId, Guid id)
        {
            var foodItemEntity = await _foodItemRepository.GetAsync(restaurantId, id);
            return _mapper.Map<FoodItemDTO>(foodItemEntity);
        }

        public async Task UpdateAsync(FoodItemDTO foodItemDTO)
        {
            var foodItemEntity = _mapper.Map<FoodItem>(foodItemDTO);
            await _foodItemRepository.UpdateAsync(foodItemEntity);
        }

        public async Task<bool> RestaurantExists(Guid restaurantId)
        {
            return await _foodItemRepository.RestaurantExists(restaurantId);
        }
    }
}
