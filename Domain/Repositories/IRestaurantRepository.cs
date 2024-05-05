using Domain.Entities;
using Domain.Parameters;

namespace Domain.Repositories
{
    public interface IRestaurantRepository: IGenericRepository<Restaurant>
    {
        Task<List<Restaurant>> GetAllAsync(RestaurantParameters restaurantParameters);
        Task<Restaurant> GetAsync(Guid id);
    }
}
