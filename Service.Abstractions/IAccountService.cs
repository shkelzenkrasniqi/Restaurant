using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IAccountService
    {
        Task<UserDTO> Login(LoginDTO loginDTO);
        Task<UserDTO> Register(RegisterDTO registerDTO);
    }
}
