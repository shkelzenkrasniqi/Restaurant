using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFoodItemRepository
    {
        Task AddAsync(FoodItem foodItem);
        Task<FoodItem> GetByIdAsync(Guid id);
        Task<IEnumerable<FoodItem>> GetAllAsync();
        Task UpdateAsync(FoodItem foodItem);
        Task DeleteAsync(Guid id);
    }
}
