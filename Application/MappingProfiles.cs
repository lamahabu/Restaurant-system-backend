using AutoMapper;
using Domain;

namespace Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Drink, DrinkDto>().ReverseMap();

            CreateMap<Drink, CreateDrinkDto>().ReverseMap();

            CreateMap<Drink, UpdateDrinkDto>().ReverseMap();

            CreateMap<Food, FoodDto>().ReverseMap();

            CreateMap<Food, CreateFoodDto>().ReverseMap();

            CreateMap<Food, UpdateFoodDto>().ReverseMap();

        }
    }
}
