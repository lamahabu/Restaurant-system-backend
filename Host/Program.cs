using EF.Data;

namespace AutoMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new AppDbContext();
            //foreach (var food in context.Food)
            //{
            //   Console.WriteLine(food.name);
            // }
            Console.ReadKey();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}