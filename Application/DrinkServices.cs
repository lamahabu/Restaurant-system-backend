using Domain;
using AutoMapper;
using EFramework.Data;
using Domain.Shared.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class DrinkServices : IDrink
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ILogger<DrinkServices> _logger;

        public DrinkServices(IMapper mapper, AppDbContext context, ILogger<DrinkServices> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<DrinkDto> Create(CreateDrinkDto dto)
        {
            var drink = _mapper.Map<CreateDrinkDto, Drink>(dto);
            _logger.LogInformation("ADDING drink: {DrinkName} with price {DrinkPrice}", dto.Name, dto.Price);

            try
            {
                await _context.Drinks.AddAsync(drink);
                await _context.SaveChangesAsync();

                var mapping = _mapper.Map<Drink, DrinkDto>(drink);
                _logger.LogInformation("{message} DrinkID: {drinkId}", ResponseMessages.AddedItem, mapping.Id);

                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}: {DrinkName}, {DrinkPrice}", ErrorsConstant.AddingProblem, dto.Name, dto.Price);
                throw new ApplicationException(ErrorsConstant.AddingProblem, ex);
            }
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation("Attempting to delete drink with ID: {drinkId}", id);

            try
            {
                var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
                if (drink == null)
                {
                    _logger.LogWarning("{message} DrinkID: {drinkId}", id, ErrorsConstant.NotFoundItem);
                    throw new Exception(ErrorsConstant.NotFoundItem);
                }

                drink.IsDeleted = true;

                await _context.SaveChangesAsync();
                _logger.LogInformation("{message} DrinkID: {drinkId}", ResponseMessages.DeletedItem, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message} DrinkID: {drinkId}", id, ErrorsConstant.DeletingProblem);
                throw new InvalidOperationException(ErrorsConstant.DeletingProblem, ex);
            }
        }

        public async Task<DrinkDto> Update(int id, UpdateDrinkDto dto)
        {
            _logger.LogInformation("Attempting to update drink with ID: {drinkId}", id);

            try
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }

                var foundDrink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
                if (foundDrink == null)
                {
                    _logger.LogWarning("{message} DrinkID: {drinkId}", id, ErrorsConstant.NotFoundItem);
                    throw new KeyNotFoundException(ErrorsConstant.NotFoundItem);
                }

                foundDrink.Name = dto.Name;
                foundDrink.Price = dto.Price;

                await _context.SaveChangesAsync();

                var mapping = _mapper.Map<Drink, DrinkDto>(foundDrink);
                _logger.LogInformation("{message} DrinkID: {drinkId}, DrinkName: {DrinkName}, DrinkPrice: {DrinkPrice}", ResponseMessages.UpdatedItem, id, dto.Name, dto.Price);

                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message} DrinkID: {drinkId}", ErrorsConstant.UpdatingProblem, id);
                throw new InvalidOperationException(ErrorsConstant.UpdatingProblem, ex);
            }
        }
        public async Task<IEnumerable<DrinkDto>> GetAllDrinks()
        {
            var drinksDtos = new List<DrinkDto>();
            var retrivedDrinks = await _context.Drinks.ToListAsync();

            foreach (var drink in retrivedDrinks)
            {
                if (drink.IsDeleted != true)
                {
                    var drinkDto = new DrinkDto
                    {
                        Id = drink.Id,
                        Name = drink.Name,
                        Price = drink.Price,
                    };
                    drinksDtos.Add(drinkDto);

                }
            }
            return drinksDtos;
        }
    }
}
