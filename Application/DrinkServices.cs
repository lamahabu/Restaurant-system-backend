using AutoMapper;
using Contract;
using Domain;
using static Domain.Shared.Layer.ErrorsConstant;

namespace Application
{
    public class DrinkServices : IDrink
    {
        private readonly IMapper _mapper;
        private readonly List<Drink> _drinksList;

        public DrinkServices(IMapper mapper)
        {
            _mapper = mapper;
            _drinksList = new List<Drink>();
        }

        public DrinkDto Create(CreateDrinkDto dto)
        {
            var drink = _mapper.Map<CreateDrinkDto, Drink>(dto);

            _drinksList.Add(drink);

            var mapping = _mapper.Map<Drink, DrinkDto>(drink);

            return mapping;
        }

        public void Delete(int id)
        {
            var drink = _drinksList.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);
            if (drink == null)
            {
                throw new Exception(NotFound);
            }
            drink.IsDeleted = true;

        }

        public DrinkDto Update(int id, UpdateDrinkDto dto)
        {
            var drink = _mapper.Map<UpdateDrinkDto, Drink>(dto);
            var foundDrink = _drinksList.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);

            if (foundDrink is null)
            {
                throw new Exception(NotFound);
            }

            foundDrink.Name = drink.Name;
            foundDrink.Price = drink.Price;

            var mapping = _mapper.Map<Drink, DrinkDto>(foundDrink);

            return mapping;
        }


    }
}
