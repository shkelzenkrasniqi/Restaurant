using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared.DTOs;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController(IAccountService _accountService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var user = await _accountService.Login(loginDto);
            if (user != null)
                return Ok(user);

            return BadRequest("Invalid email or password");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            try
            {
                var user = await _accountService.Register(registerDto);
                return CreatedAtAction(nameof(Login), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
