public interface IFood
{
    Task<FoodDto> Create(CreateFoodDto input);
    Task Delete(int id);
    Task<FoodDto> Update(int id, UpdateFoodDto input);
    Task<IEnumerable<FoodDto>> GetAllFood();

}
