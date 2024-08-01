namespace Contract
{
    public interface IDrink
    {
        DrinkDto Create(CreateDrinkDto dto);

        void Delete(int Id);

        DrinkDto Update(int Id, UpdateDrinkDto drink);
    }
}
