using Shared.DTOs;

namespace Service.Abstractions
{
    public interface IFoodItemService
    {
        Task AddAsync(FoodItemDTO foodItemDTO);
        Task DeleteAsync(Guid restaurantId,Guid id);
        Task UpdateAsync(FoodItemDTO foodItemDTO);
        Task<List<FoodItemDTO>> GetAllAsync(Guid restaurantId, FoodItemParametersDTO foodItemParametersDTO);
        Task<FoodItemDTO> GetAsync(Guid restaurantId, Guid id);
        Task<bool> RestaurantExists(Guid restaurantId);
    }
}
