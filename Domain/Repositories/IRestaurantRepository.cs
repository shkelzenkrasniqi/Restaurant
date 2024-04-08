using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant);
        Task<Restaurant> GetByIdAsync(Guid id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task UpdateAsync(Restaurant restaurant);
        Task DeleteAsync(Guid id);
    }
}
