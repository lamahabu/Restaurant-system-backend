using Application;
using Contract;
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
        public IActionResult Create(CreateDrinkDto input)
        {
            try
            {
                _logger.LogInformation("Received request to add drink {DrinkName} with price {DrinkPrice}", input.Name, input.Price);
                var drink = _drinkServices.Create(input);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while Adding Drink with ID: {DrinkId}", input.Name);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("Received request to Delete {DrinkId}",id);
                _drinkServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NoContent(); // 404 Not Found
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateDrinkDto input)
        {
            try
            {
                _logger.LogInformation("Received request to Update {DrinkId} with {DrinkName} and {DrinkPrice}", id, input.Name,input.Price);
                var drink = _drinkServices.Update(id, input);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Drink with ID: {DrinkId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
