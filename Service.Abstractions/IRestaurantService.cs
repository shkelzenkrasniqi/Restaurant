using Shared.DTOs;

namespace Service.Abstractions
{
    public interface IRestaurantService
    {
        Task AddAsync(RestaurantDTO restaurantDTO);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(RestaurantDTO restaurantDTO);
        Task<List<RestaurantDTO>> GetAllAsync(RestaurantParametersDTO restaurantParametersDTO);
        Task<RestaurantDTO> GetAsync(Guid id);
    }
}
