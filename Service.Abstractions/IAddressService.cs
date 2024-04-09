using Shared.DTOs;

namespace Service.Abstractions
{
    public interface IAddressService
    {
        Task AddAddressAsync(AddressDTO addressDTO);
        Task<AddressDTO> GetAddressByIdAsync(Guid id);
        Task<IEnumerable<AddressDTO>> GetAllAddressesAsync();
        Task UpdateAddressAsync(AddressDTO addressDTO);
        Task DeleteAddressAsync(Guid id);
    }
}
