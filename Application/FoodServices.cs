using AutoMapper;
using Contract;
using Domain;
using EFramework.Data;
using static Domain.Shared.Layer.ErrorsConstant;

namespace Application
{
    public class FoodServices : IFood
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FoodServices(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;

        }
        public FoodDto Create(CreateFoodDto dto)
        {
            var Food = _mapper.Map<CreateFoodDto, Food>(dto);

            _context.Food.Add(Food);
            _context.SaveChanges();

            var mapping = _mapper.Map<Food, FoodDto>(Food);

            return mapping;
        }

        public void Delete(int id)
        {
            var Food = _context.Food.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);
            if (Food == null)
            {
                throw new Exception(NotFound);
            }

            Food.IsDeleted = true;

            _context.SaveChanges();
        }

        public FoodDto Update(int id, UpdateFoodDto dto)
        {
            var Food = _mapper.Map<UpdateFoodDto, Food>(dto);

            var FoundFood = _context.Food.FirstOrDefault(d => d.Id == id && d.IsDeleted != true);

            if (FoundFood == null)
            {
                throw new Exception(NotFound);
            }

            FoundFood.Name = dto.Name;
            FoundFood.Price = dto.Price;

            var mapping = _mapper.Map<Food, FoodDto>(FoundFood);

            _context.SaveChanges();

            return mapping;
        }
    }
}