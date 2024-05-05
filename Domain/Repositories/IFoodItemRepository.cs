using Domain.Entities;
using Domain.Parameters;

namespace Domain.Repositories
{
    public interface IFoodItemRepository : IGenericRepository<FoodItem>
    {
        Task<List<FoodItem>> GetAllAsync(Guid restaurantId, FoodItemParameters foodItemParameters);
        Task<FoodItem> GetAsync(Guid restaurantId, Guid id);
        Task<bool> RestaurantExists(Guid restaurantId);
    }
}
