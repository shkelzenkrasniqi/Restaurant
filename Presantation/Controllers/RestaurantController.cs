using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Service.Abstractions;
    using Shared.DTOs;

    namespace YourNamespace.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class RestaurantController : ControllerBase
        {
            private readonly IRestaurantService _restaurantService;

            public RestaurantController(IRestaurantService restaurantService)
            {
                _restaurantService = restaurantService;
            }

            [HttpPost]
            public async Task<ActionResult<RestaurantDTO>> AddAsync(RestaurantDTO restaurantDTO)
            {
                await _restaurantService.AddAsync(restaurantDTO);
                return Ok(restaurantDTO);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<RestaurantDTO>> GetAsync(Guid id)
            {
                var restaurantDTO = await _restaurantService.GetAsync(id);
                if (restaurantDTO == null)
                {
                    return NotFound();
                }
                return Ok(restaurantDTO);
            }

            [HttpGet]
            public async Task<ActionResult<List<RestaurantDTO>>> GetAllAsync([FromQuery] RestaurantParametersDTO restaurantParametersDTO)
            {
                var restaurantDTOs = await _restaurantService.GetAllAsync(restaurantParametersDTO);
                return Ok(restaurantDTOs);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAsync(Guid id, RestaurantDTO restaurantDTO)
            {
                if (id != restaurantDTO.Id)
                {
                    return BadRequest();
                }

                await _restaurantService.UpdateAsync(restaurantDTO);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(Guid id)
            {
                await _restaurantService.DeleteAsync(id);
                return NoContent();
            }
        }
    }

}
