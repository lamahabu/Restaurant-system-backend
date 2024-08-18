using AutoMapper;
using Contract;
using Domain;
using EFramework.Data;
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
            _mapper = mapper;
            _context = context;
            _logger = logger;

        }

        public DrinkDto Create(CreateDrinkDto dto)
        {
            var drink = _mapper.Map<CreateDrinkDto, Drink>(dto);
            _logger.LogInformation("ADDING drink: {DrinkName} with price {DrinkPrice}", dto.Name, dto.Price);
            try
            {
                _context.Drinks.Add(drink);
                _context.SaveChanges();

                var mapping = _mapper.Map<Drink, DrinkDto>(drink);
                _logger.LogInformation("Successfully add drink with ID: {drinkId}", mapping.Id);
                return mapping;
            }
            catch (Exception ex)
            {
                _logger.LogError("Problem in Adding new food {x},{y}", dto.Name, dto.Price);
                throw new ApplicationException("There was a problem adding the new drink", ex);
            }
        }

        public void Delete(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
            _logger.LogInformation("Attempting to delete drink with ID: {drinkId}", id);

            try
            {
                if (drink == null)
                {
                    _logger.LogWarning("Drink with ID: {drinkId} not found or already deleted.", id);
                    throw new Exception("Drink not found.");
                }

                drink.IsDeleted = true;
                _context.SaveChanges();
                _logger.LogInformation("Successfully deleted drink with ID: {drinkId}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Problem deleting drink with ID: {drinkId}", id);
            }
        }
        public DrinkDto Update(int id, UpdateDrinkDto dto)
        {
            try
            {
                if (dto == null)
                {
                    throw new ArgumentNullException(nameof(dto));
                }
                var foundDrink = _context.Drinks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

                if (foundDrink == null)
                {
                    throw new KeyNotFoundException($"Drink with ID {id} not found.");
                }

                foundDrink.Name = dto.Name;
                foundDrink.Price = dto.Price;

                _context.SaveChanges();

                var mapping = _mapper.Map<Drink, DrinkDto>(foundDrink);

                _logger.LogInformation("Updated drink with ID: {drinkId}. New Name: {name}, New Price: {price}", id, dto.Name, dto.Price);

                return mapping;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Problem Updating drink with ID: {drinkId}", id);
                return null;
            }
        }
    }
}
