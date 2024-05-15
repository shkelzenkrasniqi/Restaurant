using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared.DTOs;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController(IFoodItemService _foodItemService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<FoodItemDTO>> AddAsync(FoodItemDTO foodItemDTO)
        {
            await _foodItemService.AddAsync(foodItemDTO);
            return Ok(foodItemDTO);
        }

        [HttpDelete("{restaurantId}/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid restaurantId, Guid id)
        {
            await _foodItemService.DeleteAsync(restaurantId, id);
            return NoContent();
        }

        [HttpGet("{restaurantId}/{id}")]
        public async Task<ActionResult<FoodItemDTO>> GetAsync(Guid restaurantId, Guid id)
        {
            var foodItemDTO = await _foodItemService.GetAsync(restaurantId, id);
            if (foodItemDTO == null)
            {
                return NotFound();
            }
            return Ok(foodItemDTO);
        }

        [HttpGet("{restaurantId}")]
        public async Task<ActionResult<List<FoodItemDTO>>> GetAllAsync(Guid restaurantId, [FromQuery] FoodItemParametersDTO foodItemParametersDTO)
        {
            var foodItemDTOs = await _foodItemService.GetAllAsync(restaurantId, foodItemParametersDTO);
            return Ok(foodItemDTOs);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FoodItemDTO foodItemDTO)
        {
            await _foodItemService.UpdateAsync(foodItemDTO);
            return NoContent();
        }
    }
}
