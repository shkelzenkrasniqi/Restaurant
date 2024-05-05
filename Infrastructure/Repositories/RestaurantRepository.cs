using Domain.Entities;
using Domain.Parameters;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    internal sealed class RestaurantRepository(ApplicationDbContext _context) : GenericRepository<Restaurant>(_context), IRestaurantRepository
    {
        public async Task<List<Restaurant>> GetAllAsync(RestaurantParameters restaurantParameters)
        {
            if (restaurantParameters == null)
                throw new ArgumentNullException(nameof(restaurantParameters));

            var collection = _context.Restaurants.Include(r => r.Address) as IQueryable<Restaurant>;

            if (!string.IsNullOrWhiteSpace(restaurantParameters.Name))
                collection = collection.Where(r => r.Name == restaurantParameters.Name);

            if (!string.IsNullOrWhiteSpace(restaurantParameters.City))
                collection = collection.Where(r => r.Address.City == restaurantParameters.City);

            if (!string.IsNullOrWhiteSpace(restaurantParameters.Category))
                collection = collection.Where(r => r.Category == restaurantParameters.Category);

            if (restaurantParameters.HasDelivery != null)
                collection = collection.Where(r => r.HasDelivery == restaurantParameters.HasDelivery);

            if (!string.IsNullOrWhiteSpace(restaurantParameters.SearchQuery))
            {
                var searchQuery = restaurantParameters.SearchQuery.Trim();

                collection = collection.Where(r =>
                    r.Name.Contains(searchQuery) ||
                    r.Description.Contains(searchQuery) ||
                    r.Category.Contains(searchQuery) ||
                    r.Address.City.Contains(searchQuery));
            }
            return await collection.ToListAsync();

        }
        public async Task<Restaurant> GetAsync(Guid id)
        {
            return await _context.Restaurants.Include(r => r.Address).FirstOrDefaultAsync(r => r.Id == id);
        }

    }
}