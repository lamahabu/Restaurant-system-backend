using Application;
using Contract;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FoodController : ControllerBase
    {
        private readonly IFood _foodServices;
        private readonly ILogger<FoodController> _logger;

        public FoodController(IFood foodServices, ILogger<FoodController> logger)
        {
            _foodServices = foodServices;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateFoodDto input)
        {
            try
            {
                _logger.LogInformation("Received request to add food {FoodName} with price {FoodPrice}", input.Name, input.Price);
                var food = _foodServices.Create(input);
                return Ok(food);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding food with name {FoodName} and price {FoodPrice}", input.Name, input.Price);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("Received request to delete food with ID: {FoodId}", id);
                _foodServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting food with ID: {FoodId}", id);
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateFoodDto input)
        {
            try
            {
                _logger.LogInformation("Received request to update food with ID: {FoodId}, Name: {FoodName}, Price: {FoodPrice}", id, input.Name, input.Price);
                var food = _foodServices.Update(id, input);
                if (food == null)
                {
                    return NotFound();
                }
                return Ok(food);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating food with ID: {FoodId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
