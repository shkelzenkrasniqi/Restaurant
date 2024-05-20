using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using Shared.DTOs;

namespace Services
{
    internal sealed class AccountService(UserManager<AppUser> _userManager, IMapper _mapper, ITokenService _tokenService) : IAccountService
    {
        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user is null) return null;

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if (passwordValid)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                return userDto;
            }
            else
            {
                // Password does not match, return a UserDto with null token
                var userDto = _mapper.Map<UserDTO>(user);
                userDto.Token = null;
                return userDto;
            }
        }
        public async Task<UserDTO> Register(RegisterDTO registerDTO)
        {

            var user = new AppUser
            {
                UserName = registerDTO.UserName,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                var userDto = _mapper.Map<UserDTO>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                return userDto;
            }

            throw new Exception("Failed to register the user");
        }

    }
}
