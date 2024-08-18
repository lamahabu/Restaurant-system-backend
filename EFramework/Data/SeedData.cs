using Domain;
namespace EFramework.Data
{
    public static class SeedData
    {
        public static List<Food> LoadFood() => new()
        {
            new Food("Burger", 10) { Id = 1 },
            new Food("Pizza", 20) { Id = 2 },
            new Food("Fries", 30) { Id = 3 },
            new Food("Sandwich", 40) { Id = 4 },
            new Food("Pasta", 50) { Id = 5 }
        };
        public static List<Drink> LoadDrinks()
        {
            List<Drink> drinks = new()
            {
                new Drink("Coca-Cola", 5) { Id = 1 },
                new Drink("Pepsi", 4.5) { Id = 2 },
                new Drink("Sprite", 4) { Id = 3}
            };

            return drinks;
        }
    }
}
