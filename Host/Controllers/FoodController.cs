using Application;
using Contract;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace AutoMapper.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FoodController : ControllerBase
    {
        private readonly IFood _foodServices;

        public FoodController(IFood foodServices)
        {
            _foodServices = foodServices;
        }

       [HttpPost]
        public IActionResult Create(CreateFoodDto input)
        {
            try
            {
                var Food = _foodServices.Create(input);
                return Ok(Food);
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
                _foodServices.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NoContent();
            }
 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateFoodDto input)
        {
            try
            {
                var food = _foodServices.Update(id, input);
                return Ok(food);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }


    }
}

