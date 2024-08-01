using Contract;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrink _drinkServices;

        public DrinkController(IDrink drinkServices)
        {
            _drinkServices = drinkServices;
        }

        [HttpPost]
        public IActionResult Create(CreateDrinkDto input)
        {
            try
            {
                var drink = _drinkServices.Create(input);
                return Ok(drink);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _drinkServices.Delete(id);
                return Ok(); // 204 No Content
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
                var drink = _drinkServices.Update(id, input);
                return Ok(drink);
            }
            catch (Exception)
            {
                return NoContent();
            }

        }
    }
}
