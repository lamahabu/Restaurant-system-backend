using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrink _drinkServices;
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(IDrink drinkServices, ILogger<DrinkController> logger)
        {
            _drinkServices = drinkServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDrinkDto input)
        {
            try
            {
                _logger.LogInformation("Received request to add drink {DrinkName} with price {DrinkPrice}", input.Name, input.Price);

                var drink = await _drinkServices.Create(input);

                return Ok(drink);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Adding Drink with ID: {DrinkId}", input.Name);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Received request to Delete {DrinkId}", id);

                await _drinkServices.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting Drink with ID: {DrinkId}", id);
                return NoContent(); // 404 Not Found
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDrinkDto input)
        {
            try
            {
                _logger.LogInformation("Received request to Update {DrinkId} with {DrinkName} and {DrinkPrice}", id, input.Name, input.Price);

                var drink = await _drinkServices.Update(id, input);

                return Ok(drink);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Drink with ID: {DrinkId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var drinks = await _drinkServices.GetAllDrinks();
                return Ok(drinks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retriving Drinks");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
