using System;
namespace Test
{
        public static void Main()
        {
            using (var context = new 
            {
                Console.WriteLine("-------- Food -----------");
                Console.WriteLine();
                foreach (var food in context.Food)
                {
                    Console.WriteLine(food.name);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Drinks -----------");
                Console.WriteLine();
                foreach (var drink in context.Drinks)
                {
                    Console.WriteLine(drink.name);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}