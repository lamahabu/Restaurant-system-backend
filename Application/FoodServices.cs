using AutoMapper;
using Contract;
using Domain;
using EFramework.Data;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class FoodServices : IFood
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ILogger<FoodServices> _logger;

        public FoodServices(IMapper mapper, AppDbContext context, ILogger<FoodServices> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public FoodDto Create(CreateFoodDto dto)
        {
            var food = _mapper.Map<CreateFoodDto, Food>(dto);
            _logger.LogInformation("ADDING food: {FoodName} with price {FoodPrice}", dto.Name, dto.Price);
            try
            {
                _context.Food.Add(food);
                _context.SaveChanges();

                var mapping = _mapper.Map<Food, FoodDto>(food);
                _logger.LogInformation("Successfully added food with ID: {foodId}", mapping.Id);
                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Problem adding new food {x}, {y}", dto.Name, dto.Price);
                throw new ApplicationException("There was a problem adding the new food", ex);
            }
        }

        public void Delete(int id)
        {
            var food = _context.Food.FirstOrDefault(f => f.Id == id && !f.IsDeleted);
            _logger.LogInformation("Attempting to delete food with ID: {foodId}", id);

            try
            {
                if (food == null)
                {
                    _logger.LogWarning("Food with ID: {foodId} not found or already deleted.", id);
                    throw new KeyNotFoundException("Food not found.");
                }

                food.IsDeleted = true;
                _context.SaveChanges();
                _logger.LogInformation("Successfully deleted food with ID: {foodId}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Problem deleting food with ID: {foodId}", id);
            }
        }

        public FoodDto Update(int id, UpdateFoodDto dto)
        {
            try
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }
                var foundFood = _context.Food.FirstOrDefault(f => f.Id == id && !f.IsDeleted);

                if (foundFood == null)
                {
                    throw new KeyNotFoundException($"Food with ID {id} not found.");
                }

                foundFood.Name = dto.Name;
                foundFood.Price = dto.Price;

                _context.SaveChanges();

                var mapping = _mapper.Map<Food, FoodDto>(foundFood);

                _logger.LogInformation("Updated food with ID: {foodId}. New Name: {name}, New Price: {price}", id, dto.Name, dto.Price);

                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Problem updating food with ID: {foodId}", id);
                return null;
            }
        }
    }
}
