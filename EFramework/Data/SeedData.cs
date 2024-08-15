using Domain;
namespace EFramework.Data
{
    public static class SeedData
    {
        public static List<Food> LoadFood() => new()
        {
            new Food("Burger", 10),
            new Food("Pizza", 20),
            new Food("Fries", 30),
            new Food("Sandwich", 40),
            new Food("Pasta", 50)
        };
        public static List<Drink> LoadDrinks()
        {
            List<Drink> drinks = new()
            {
              new Drink("Coke", 2),
              new Drink("Pepsi", 2),
              new Drink("Lemonade", 3),
              new Drink("Water", 1),
              new Drink("Coffee", 4)
            };
           
            return drinks;
        }
    }
}
