using AutoMapper;
using Contract;
using Domain;
using static Domain.Shared.Layer.ErrorsConstant;

namespace Application
{
    public class FoodServices : IFood
    {
        private readonly IMapper _mapper;
        private List<Food> _foodList = new List<Food>();

        public FoodServices(IMapper mapper)
        {
            _mapper = mapper;
            _foodList = new List<Food>();
        }

        public FoodDto Create(CreateFoodDto dto)
        {
            var food = _mapper.Map<CreateFoodDto, Food>(dto);

            _foodList.Add(food);

            var mapping = _mapper.Map<Food, FoodDto>(food);

            return mapping;
        }

        public void Delete(int id)
        {
            var food = _foodList.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);

            if (food == null)
            {
                throw new Exception(NotFound);
            }

            food.IsDeleted = true;
        }

        public FoodDto Update(int id, UpdateFoodDto dto)
        {
            var food = _mapper.Map<UpdateFoodDto, Food>(dto);
            var foundFood = _foodList.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);

            if (foundFood is null)
            {
                throw new Exception(NotFound);
            }

            foundFood.Name = food.Name;
            foundFood.Price = food.Price;

            var mapping = _mapper.Map<Food, FoodDto>(foundFood);

            return mapping;
        }

    }
}
