using Shared.DTOs;

namespace Service.Abstractions
{
    public interface IRestaurantService
    {
        Task AddRestaurantAsync(RestaurantDTO restaurantDTO);
        Task<RestaurantDTO> GetRestaurantByIdAsync(Guid id);
        Task<IEnumerable<RestaurantDTO>> GetAllRestaurantsAsync();
        Task UpdateRestaurantAsync(RestaurantDTO restaurantDTO);
        Task DeleteRestaurantAsync(Guid id);
    }
}
