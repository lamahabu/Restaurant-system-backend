using Microsoft.AspNetCore.Mvc;

public interface IDrink
{
    Task<DrinkDto> Create(CreateDrinkDto input);
    Task Delete(int id);
    Task<DrinkDto> Update(int id, UpdateDrinkDto input);
    Task<IEnumerable<DrinkDto>> GetAllDrinks();
}
