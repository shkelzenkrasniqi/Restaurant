using Domain.Entities;
using Domain.Parameters;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    internal sealed class FoodItemRepository(ApplicationDbContext _context) : GenericRepository<FoodItem>(_context), IFoodItemRepository
    {
        public async Task<List<FoodItem>> GetAllAsync(Guid restaurantId,
            FoodItemParameters foodItemParameters)
        {
            if (foodItemParameters == null) throw new ArgumentNullException(nameof(foodItemParameters));

            var collection = _context.FoodItems.Where(d => d.RestaurantId == restaurantId);

            if (!string.IsNullOrWhiteSpace(foodItemParameters.Name))
                collection = collection.Where(d => d.Name == foodItemParameters.Name);

            if (foodItemParameters.MaximumPrice != null)
                collection = collection.Where(d => d.Price <= foodItemParameters.MaximumPrice);

            if (!string.IsNullOrWhiteSpace(foodItemParameters.SearchQuery))
            {
                var searchQuery = foodItemParameters.SearchQuery.Trim();

                collection = collection.Where(d =>
                    d.Name.Contains(searchQuery) ||
                    d.Description.Contains(searchQuery));
            }
            return await collection.ToListAsync();
        }

        public async Task<FoodItem> GetAsync(Guid restaurantId, Guid id)
        {
            return await _context.FoodItems.FirstOrDefaultAsync(d => d.RestaurantId == restaurantId && d.Id == id);
        }

        public async Task<bool> RestaurantExists(Guid restaurantId)
        {
            return await _context.Restaurants.AnyAsync(r => r.Id == restaurantId);
        }

    }
}

