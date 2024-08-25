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
        public async Task<IActionResult> Create(CreateFoodDto input)
        {
            try
            {
                _logger.LogInformation("Received request to add food {FoodName} with price {FoodPrice}", input.Name, input.Price);

                var food = await _foodServices.Create(input);

                return Ok(food);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Adding Food with ID: {FoodId}", input.Name);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Received request to Delete {FoodId}", id);

                await _foodServices.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting Food with ID: {FoodId}", id);
                return NoContent(); // 404 Not Found
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFoodDto input)
        {
            try
            {
                _logger.LogInformation("Received request to Update {FoodId} with {FoodName} and {FoodPrice}", id, input.Name, input.Price);

                var food = await _foodServices.Update(id, input);

                return Ok(food);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Food with ID: {FoodId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var foods = await _foodServices.GetAllFood();
                return Ok(foods);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving Foods");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
