using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Persistance.Repositories
{
    internal sealed class AddressRepository(ApplicationDbContext _context) : IAddressRepository
    {
        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            var address = await _context.Addresses.FindAsync(id);
            return address ?? throw new InvalidOperationException($"Address with id {id} not found.");
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await Task.FromResult(_context.Addresses.ToList());
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
