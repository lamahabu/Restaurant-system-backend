using Domain;
using AutoMapper;
using EFramework.Data;
using Domain.Shared.Layer;
using Microsoft.EntityFrameworkCore;
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
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<FoodDto> Create(CreateFoodDto dto)
        {
            var food = _mapper.Map<CreateFoodDto, Food>(dto);
            _logger.LogInformation("ADDING food: {FoodName} with price {FoodPrice}", dto.Name, dto.Price);

            try
            {
                await _context.Food.AddAsync(food);
                await _context.SaveChangesAsync();

                var mapping = _mapper.Map<Food, FoodDto>(food);
                _logger.LogInformation("{message} FoodID: {foodId}", ResponseMessages.AddedItem, mapping.Id);

                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}: {FoodName}, {FoodPrice}", ErrorsConstant.AddingProblem, dto.Name, dto.Price);
                throw new ApplicationException(ErrorsConstant.AddingProblem, ex);
            }
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation("Attempting to delete food with ID: {foodId}", id);

            try
            {
                var food = await _context.Food.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
                if (food == null)
                {
                    _logger.LogWarning("{message} FoodID: {foodId}", id, ErrorsConstant.NotFoundItem);
                    throw new Exception(ErrorsConstant.NotFoundItem);
                }

                food.IsDeleted = true;

                await _context.SaveChangesAsync();
                _logger.LogInformation("{message} FoodID: {foodId}", ResponseMessages.DeletedItem, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message} FoodID: {foodId}", id, ErrorsConstant.DeletingProblem);
                throw new InvalidOperationException(ErrorsConstant.DeletingProblem, ex);
            }
        }

        public async Task<FoodDto> Update(int id, UpdateFoodDto dto)
        {
            _logger.LogInformation("Attempting to update food with ID: {foodId}", id);

            try
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }

                var foundFood = await _context.Food.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
                if (foundFood == null)
                {
                    _logger.LogWarning("{message} FoodID: {foodId}", id, ErrorsConstant.NotFoundItem);
                    throw new KeyNotFoundException(ErrorsConstant.NotFoundItem);
                }

                foundFood.Name = dto.Name;
                foundFood.Price = dto.Price;

                await _context.SaveChangesAsync();

                var mapping = _mapper.Map<Food, FoodDto>(foundFood);
                _logger.LogInformation("{message} FoodID: {foodId}, FoodName: {FoodName}, FoodPrice: {FoodPrice}", ResponseMessages.UpdatedItem, id, dto.Name, dto.Price);

                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message} FoodID: {foodId}", ErrorsConstant.UpdatingProblem, id);
                throw new InvalidOperationException(ErrorsConstant.UpdatingProblem, ex);
            }
        }

        public async Task<IEnumerable<FoodDto>> GetAllFood()
        {
            var foodsDtos = new List<FoodDto>();
            var retrievedFoods = await _context.Food.ToListAsync();

            foreach (var food in retrievedFoods)
            {
                if (food.IsDeleted != true)
                {
                    var foodDto = new FoodDto
                    {
                        Id = food.Id,
                        Name = food.Name,
                        Price = food.Price,
                    };
                    foodsDtos.Add(foodDto);
                }
            }
            return foodsDtos;
        }
    }

}
