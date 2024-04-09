using Shared.DTOs;

namespace Service.Abstractions
{
    public interface IFoodItemService
    {
        Task AddFoodItemAsync(FoodItemDTO foodItemDTO);
        Task<FoodItemDTO> GetFoodItemByIdAsync(Guid id);
        Task<IEnumerable<FoodItemDTO>> GetAllFoodItemsAsync();
        Task UpdateFoodItemAsync(FoodItemDTO foodItemDTO);
        Task DeleteFoodItemAsync(Guid id);
    }
}
