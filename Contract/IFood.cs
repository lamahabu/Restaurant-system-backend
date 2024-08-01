namespace Contract
{
    public interface IFood
    {
        FoodDto Create(CreateFoodDto dto);

        void Delete(int Id);

        FoodDto Update(int Id, UpdateFoodDto drink);
    }
}
