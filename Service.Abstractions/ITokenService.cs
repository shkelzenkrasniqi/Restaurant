using Domain.Entities;

namespace Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
