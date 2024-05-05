using Domain.Repositories;
using Infrastructure;

namespace Persistance.Repositories
{
    public abstract class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
