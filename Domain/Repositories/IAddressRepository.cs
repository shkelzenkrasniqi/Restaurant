using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAddressRepository
    {
        Task AddAsync(Address address);
        Task<Address> GetByIdAsync(Guid id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task UpdateAsync(Address address);
        Task DeleteAsync(Guid id);
    }
}
