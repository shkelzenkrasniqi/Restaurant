using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Persistance.Repositories
{
    internal sealed class FoodItemRepository(ApplicationDbContext _context) : IFoodItemRepository
    {

        public async Task AddAsync(FoodItem foodItem)
        {
            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task<FoodItem> GetByIdAsync(Guid id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            return foodItem ?? throw new InvalidOperationException($"Food item with id {id} not found.");
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync()
        {
            return await Task.FromResult(_context.FoodItems.ToList());
        }

        public async Task UpdateAsync(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
