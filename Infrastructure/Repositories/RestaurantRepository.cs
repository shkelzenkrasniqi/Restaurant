using Domain.Entities;
using Domain.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal sealed class RestaurantRepository(ApplicationDbContext _context) : IRestaurantRepository
    {
        public async Task AddAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> GetByIdAsync(Guid id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            return restaurant ?? throw new InvalidOperationException($"Restaurant with id {id} not found.");
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants
                                    .Include(r => r.FoodItems)
                                    .Include(r => r.Address)
                                    .ToListAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }
}