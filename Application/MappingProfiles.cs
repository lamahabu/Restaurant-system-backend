using AutoMapper;
using Domain;

namespace Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Food, FoodDto>().ReverseMap();

            CreateMap<Drink, DrinkDto>().ReverseMap();

            CreateMap<Food, UpdateFoodDto>().ReverseMap();

            CreateMap<Food, CreateFoodDto>().ReverseMap();

            CreateMap<Drink, CreateDrinkDto>().ReverseMap();

            CreateMap<Drink, UpdateDrinkDto>().ReverseMap();

        }
    }
}
